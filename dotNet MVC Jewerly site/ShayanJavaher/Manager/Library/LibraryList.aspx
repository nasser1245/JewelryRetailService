<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master" AutoEventWireup="true" CodeFile="LibraryList.aspx.cs" Inherits="Manager_Library_LibraryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadsCPH" Runat="Server">
<script type="text/javascript">
    function removeArticle(obj, Id) {
        if (confirm('آیا از حذف این کتاب اطمینان دارید؟')) {
            if (obj) {
                $.ajax({
                    type: "POST",
                    url: "LibraryList.aspx/DeleteArticle",
                    data: "{'Id':'" + Id + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        if (msg.d == "1") {
                            var val = $('#<%=lblResultCount.ClientID %>').html();

                            val = val - 1;
                            $('#<%=lblResultCount.ClientID %>').html(val);
                            showMsg('accept', 'عملیات با موفقیت انجام شد.');
                            $(obj).parent().parent().fadeOut(500);
                        }
                        else if (msg.d == "-2")
                            showMsg('warning', 'شما اجازه ی دسترسی به این عملیات را ندارید.');
                    },
                    error: function () {
                        showMsg('warning', 'بروز خطای نا مشخص،لطفا لحظاتی بعد مجددا سعی نمایید');
                    }
                });
            }
            return true;
        } else {
            return false;
        }
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyCPH" Runat="Server">
<asp:HiddenField ID="hfLibraryCat" runat="server" Value="-1" />
<div id="alert" class="hide">
        <div class="alert">
            <div class="img" id="imgAlert"></div>
            <div class="text"><span id="lblAlert"></span></div>
    <div class="clear"></div>
        </div>
    <div class="clear"></div>
    </div>
    <div style="padding:5px; margin:5px;">
    <div style="margin:5px;">
        <div style="width:80px; float:right">عنوان :</div>
        <div><asp:TextBox ID="txtTitle" runat="server"></asp:TextBox></div>
    </div>
    <div style="margin:5px;">
        <div style="width:80px; float:right">خلاصه کتاب :</div>
        <div><asp:TextBox ID="txtSummary" runat="server"></asp:TextBox></div>
    </div>
    <div style="margin:5px;">
        <div style="width:80px; float:right">لینک منبع :</div>
        <div><asp:TextBox ID="txtLink" runat="server"></asp:TextBox></div>
    </div>
    <div style="margin:5px;">
        <div style="width:80px; float:right">گروه:</div>
        <asp:DropDownList DataTextField="Title" DataValueField="CatID" ID="ddlLibraryCategory" runat="server" AppendDataBoundItems="true" Width="130px"></asp:DropDownList>
    </div>
    <div style="margin:5px;">
        <div style="width:80px; float:right"> وضعیت:</div>
        <asp:DropDownList DataTextField="Title" DataValueField="Id" ID="ddlVisible" runat="server" AppendDataBoundItems="true" Width="130px"><asp:ListItem Text="انتخاب کنید" Value="-1"></asp:ListItem><asp:ListItem Text="فعال" Value="1"></asp:ListItem><asp:ListItem Text="غیر فعال" Value="0"></asp:ListItem></asp:DropDownList>
    </div>
    <div style="margin:5px;display:none;">
        <div style="width:80px; float:right">نوع کتاب:</div>
        <asp:DropDownList ID="ddlLibraryType" runat="server" AppendDataBoundItems="true" Width="130px">
            <asp:ListItem Text="همه موارد" Value="-1"></asp:ListItem>
            <asp:ListItem Text="کتاب" Value="1"></asp:ListItem>
            <asp:ListItem Text="مقاله" Value="2"></asp:ListItem>
        </asp:DropDownList>
    </div>

    <div  style="margin:20px"> 
        <asp:Button CssClass="btn1" ID="btnAdd" runat="server" Text="افزودن کتاب" onclick="btnAdd_Click"  />
        <asp:Button CssClass="" ID="btnClearFilter" runat="server" Text="حذف فیلتر" onclick="btnClearFilter_Click" />
        <asp:Button CssClass="" ID="btnSearch" runat="server" Text="جستجو" onclick="btnSearch_Click"/>
    </div>
    
</div>




<div class=" clear"></div>
<div style="margin-top:30px">
    <span style="float:right"><h5>آمار بخش:</h5></span>
    <span style="float:right; margin-right:5px"><asp:Label ID="lblAllCount" runat="server"></asp:Label></span>
    <span style="float:right; margin-right:5px"><asp:Label ID="lblMsgResultCount" runat="server"></asp:Label></span>
    <span style="float:right; margin-right:5px"><asp:Label ID="lblResultCount" runat="server"></asp:Label></span>
</div>
<div class="clear"></div>
<center>
<div style="width:600px; margin-bottom:20px; margin-top:20px">
    <div class="titrgrid">
        <span style="margin-right:60px; width:150px">عنوان</span>
        <span style="margin-right:60px; width:90px">تاریخ درج</span>
        <span style="margin-right:35px; width:90px">وضعیت</span>
        <span style="margin-right:10px; width:90px">تعداد مشاهده</span>
        <span style="margin-right:30px; width:90px">درج کننده</span>
        <span style="margin-right:40px;width:90px">عملیات</span>
    </div>

    <div class="grid">
        <asp:Repeater ID="rptArticle" runat="server">
            
            <ItemTemplate>
                <div class="odd">
                    <span style="width:150px"><%# string.IsNullOrEmpty(Eval("Title").ToString()) ? " --- " : (Eval("Title").ToString().Length > 20 ? Eval("Title").ToString().Substring(0, 20) + ".." : Eval("Title").ToString())%></span>
                    <span style="width:75px"><%# HProtest_BLL.Helper.Utility.GetPersianDate(Eval("DateIn"))%></span>
                    <span style="width:90px"><%# Eval("Visible").ToString() == "1" ? "فعال" : "غیر فعال" %></span>
                    <span style="width:80px"><%# Eval("VisitCount") %></span>
                    <span style="width:105px"><%# string.IsNullOrEmpty(Eval("Creator").ToString()) ? " --- " : (Eval("Creator").ToString().Length > 25 ? Eval("Creator").ToString().Substring(0, 25) + ".." : Eval("Creator").ToString())%></span>
                    <span style="width:75px">
                        <a href="LibraryContent.aspx?Id=<%# Eval("id") %>" title="ویرایش" >
                            <img id="img1" alt="" src='<%#Page.ResolveClientUrl("~/Resource/PicSite/edit-icon.png")%>' class="mn_l5" width="16" height="16" /></a>
                        <a  title="حذف" href="#" onclick='return removeArticle(this,"<%# Eval("id") %>")'>
                            <img id="imgBtnDelete" alt="" src='<%#Page.ResolveClientUrl("~/Resource/PicSite/delete-icon.png")%>' class="mn_l5" width="16" height="16" /></a>
                    </span>
                    <div class="clear"></div>
                </div>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <div class="even">
                    <span style="width:150px"><%# string.IsNullOrEmpty(Eval("Title").ToString()) ? " --- " : (Eval("Title").ToString().Length > 20 ? Eval("Title").ToString().Substring(0, 20) + ".." : Eval("Title").ToString())%></span>
                    <span style="width:75px"><%# HProtest_BLL.Helper.Utility.GetPersianDate(Eval("DateIn"))%></span>
                    <span style="width:90px"><%# Eval("Visible").ToString() == "1" ? "فعال" : "غیر فعال" %></span>
                    <span style="width:80px"><%# Eval("VisitCount") %></span>
                    <span style="width:105px"><%# string.IsNullOrEmpty(Eval("Creator").ToString()) ? " --- " : (Eval("Creator").ToString().Length > 25 ? Eval("Creator").ToString().Substring(0, 25) + ".." : Eval("Creator").ToString())%></span>
                    <span style="width:75px">
                        <a href="LibraryContent.aspx?Id=<%# Eval("id") %>" title="ویرایش" >
                            <img id="imgBtnView" alt="" src='<%#Page.ResolveClientUrl("~/Resource/PicSite/edit-icon.png")%>' class="mn_l5" width="16" height="16" /></a>
                        <a title="حذف" href="#" onclick='return removeArticle(this,"<%# Eval("id") %>")'>
                            <img id="imgBtnDelete" alt="" src='<%#Page.ResolveClientUrl("~/Resource/PicSite/delete-icon.png")%>' class="mn_l5" width="16" height="16" /></a>
                    </span>
                    <div class="clear"></div>
                </div>
                </AlternatingItemTemplate>
        </asp:Repeater>
    </div>

</div>
<div class="clear"></div>

    <div style="margin-top:30px">
        <asp:ImageButton Visible="false" ID="imgbtnNext" CssClass="left mn_l15" ToolTip="صفحه بعد" AlternateText="" Width="35px" Height="35px" ImageUrl="~/Resource/PicSite/go-next-page.png" runat="server" value="" OnClick="imgbtnNext_Click"/>
        <asp:ImageButton Visible="false" ID="imgbtnLast" CssClass="left mn_l15" ToolTip="آخرین صفحه" AlternateText="" Width="35px" Height="35px" ImageUrl="~/Resource/PicSite/go-last-page.png" runat="server" value="" onclick="imgbtnLast_Click"/>
        <asp:Label ID="lblPagNumber" CssClass="left mn_l15" runat="server"></asp:Label>
        <asp:ImageButton ID="imgbtnFirst" CssClass="left" ToolTip="اولین صفحه" AlternateText="" Width="35px" Height="35px" ImageUrl="~/Resource/PicSite/go-first-page.png" runat="server" value="" onclick="imgbtnFirst_Click"/>
        <asp:ImageButton ID="imgbtnPrev" CssClass="left mn_l15" ToolTip="صفحه قبل" AlternateText="" Width="35px" Height="35px" ImageUrl="~/Resource/PicSite/go-previous-page.png" runat="server" value="" onclick="imgbtnPrev_Click"/>

    </div>

</center>
</asp:Content>

