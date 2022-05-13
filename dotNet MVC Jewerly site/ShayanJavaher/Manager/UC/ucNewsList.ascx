<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucNewsList.ascx.cs" Inherits="Manager_UC_ucNewsList" %>
  <asp:HiddenField ID="hfNewsCat" runat="server" Value="-1" />
<script type="text/javascript">
    function removeArticle(obj, Id) {
        if (confirm('آیا از حذف این خبر اطمینان دارید؟')) {
            if (obj) {
                $.ajax({
                    type: "POST",
                    url: "NewsList.aspx/DeleteArticle",
                    data: "{'Id':'" + Id + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        if (msg.d == "1") {
                            var val = $('#<%=lblResultCount.ClientID %>').html();

                            val = val - 1;
                            $('#<%=lblResultCount.ClientID %>').html(val);
                            showMsg('warning', 'عملیات با موفقیت انجام شد.');
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
<div style="padding:5px; margin:5px;">
    <div style="margin:5px;">
        <div style="width:80px; float:right">عنوان :</div>
        <div><asp:TextBox ID="txtTitle" runat="server"></asp:TextBox></div>
    </div>
    <div style="margin:5px;">
        <div style="width:80px; float:right">خلاصه خبر :</div>
        <div><asp:TextBox ID="txtSummary" runat="server"></asp:TextBox></div>
    </div>
    <div style="margin:5px;">
        <div style="width:80px; float:right">گروه:</div>
        <asp:DropDownList DataTextField="Title" DataValueField="CatID" ID="ddlNewsCategory" runat="server" AppendDataBoundItems="true" Width="130px"></asp:DropDownList>
    </div>
    <div style="margin:5px;">
        <div style="width:80px; float:right"> وضعیت:</div>
        <asp:DropDownList DataTextField="Title" DataValueField="Id" ID="ddlVisible" runat="server" AppendDataBoundItems="true" Width="130px"><asp:ListItem Text="انتخاب کنید" Value="-1"></asp:ListItem><asp:ListItem Text="فعال" Value="1"></asp:ListItem><asp:ListItem Text="غیر فعال" Value="0"></asp:ListItem></asp:DropDownList>
    </div>
    <div style="margin:5px;display:none;">
        <div style="width:80px; float:right">نوع خبر:</div>
        <asp:DropDownList ID="ddlNewsType" runat="server" AppendDataBoundItems="true" Width="130px">
            <asp:ListItem Text="همه موارد" Value="-1"></asp:ListItem>
            <asp:ListItem Text="عادی" Value="1"></asp:ListItem>
            <asp:ListItem Text="ویژه" Value="2"></asp:ListItem>
        </asp:DropDownList>
    </div>

    <div  style="margin:20px"> 
        <asp:Button CssClass="btn1" ID="btnAdd" runat="server" Text="افزودن خبر" onclick="btnAdd_Click"  />
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
                    <span style="width:150px"><%# Eval("Title").ToString().Length > 20 ? Eval("Title").ToString().Substring(0, 20) + ".." : Eval("Title").ToString()%></span>
                    <span style="width:75px"><%# HProtest_BLL.Helper.Utility.GetPersianDate(Eval("DateIn"))%></span>
                    <span style="width:90px"><%# Eval("Visible").ToString() == "1" ? "فعال" : "غیر فعال" %></span>
                    <span style="width:80px"><%# Eval("VisitCount") %></span>
                    <span style="width:105px"><%# Eval("Creator").ToString().Length > 25 ? Eval("Creator").ToString().Substring(0, 25) + ".." : Eval("Creator").ToString()%></span>
                    <span style="width:75px">
                        <a href="NewsContent.aspx?Id=<%# Eval("id") %>" title="ویرایش" >
                            <img id="img1" alt="" src='<%#Page.ResolveClientUrl("~/Resource/PicSite/edit-icon.png")%>' class="mn_l5" width="16" height="16" /></a>
                        <a  title="حذف" href="#" onclick='return removeArticle(this,"<%# Eval("id") %>")'>
                            <img id="imgBtnDelete" alt="" src='<%#Page.ResolveClientUrl("~/Resource/PicSite/delete-icon.png")%>' class="mn_l5" width="16" height="16" /></a>
                    </span>
                </div>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <div class="even">
                    <span style="width:150px"><%# Eval("Title").ToString().Length > 20 ? Eval("Title").ToString().Substring(0, 20) + ".." : Eval("Title").ToString()%></span>
                    <span style="width:75px"><%# HProtest_BLL.Helper.Utility.GetPersianDate(Eval("DateIn"))%></span>
                    <span style="width:90px"><%# Eval("Visible").ToString() == "1" ? "فعال" : "غیر فعال" %></span>
                    <span style="width:80px"><%# Eval("VisitCount") %></span>
                    <span style="width:105px"><%# Eval("Creator").ToString().Length > 25 ? Eval("Creator").ToString().Substring(0, 25) + ".." : Eval("Creator").ToString()%></span>
                    <span style="width:75px">
                        <a href="NewsContent.aspx?Id=<%# Eval("id") %>" title="ویرایش" >
                            <img id="imgBtnView" alt="" src='<%#Page.ResolveClientUrl("~/Resource/PicSite/edit-icon.png")%>' class="mn_l5" width="16" height="16" /></a>
                        <a title="حذف" href="#" onclick='return removeArticle(this,"<%# Eval("id") %>")'>
                            <img id="imgBtnDelete" alt="" src='<%#Page.ResolveClientUrl("~/Resource/PicSite/delete-icon.png")%>' class="mn_l5" width="16" height="16" /></a>
                    </span>
                </div>
                </AlternatingItemTemplate>
        </asp:Repeater>
    </div>

</div>
    <div style="margin-top:30px">
        <asp:ImageButton Visible="false" ID="imgbtnNext" CssClass="left mn_l15" ToolTip="صفحه بعد" AlternateText="" Width="35px" Height="35px" ImageUrl="~/Resource/PicSite/go-next-page.png" runat="server" value="" OnClick="imgbtnNext_Click"/>
        <asp:ImageButton Visible="false" ID="imgbtnLast" CssClass="left mn_l15" ToolTip="آخرین صفحه" AlternateText="" Width="35px" Height="35px" ImageUrl="~/Resource/PicSite/go-last-page.png" runat="server" value="" onclick="imgbtnLast_Click"/>
        <asp:Label ID="lblPagNumber" CssClass="left mn_l15" runat="server"></asp:Label>
        <asp:ImageButton ID="imgbtnFirst" CssClass="left" ToolTip="اولین صفحه" AlternateText="" Width="35px" Height="35px" ImageUrl="~/Resource/PicSite/go-first-page.png" runat="server" value="" onclick="imgbtnFirst_Click"/>
        <asp:ImageButton ID="imgbtnPrev" CssClass="left mn_l15" ToolTip="صفحه قبل" AlternateText="" Width="35px" Height="35px" ImageUrl="~/Resource/PicSite/go-previous-page.png" runat="server" value="" onclick="imgbtnPrev_Click"/>

    </div>

</center>
    

  
    
    
    

