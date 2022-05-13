<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucAdvertiseManage.ascx.cs" Inherits="Manager_UC_ucAdvertiseManage" %>
<asp:HiddenField ID="hfEditType" runat="server" Value="1" />
<asp:HiddenField ID="hfAdvertiseId" runat="server" Value="1" />
<asp:HiddenField ID="hfAdvertiseIdFileType" runat="server" Value="1" />
<asp:HiddenField ID="hfHight" runat="server" />
<asp:HiddenField ID="hfAddr" runat="server" />

<script type="text/javascript">

    $(function () {
        HighLightRequired();

        $('.BoxToggle').click(function () {
            $(this).next('.Box').slideToggle();
        });
    });

    function removeArticle(obj, Id) {
        if (confirm('آیا از حذف این عنوان اطمینان دارید؟')) {
            if (obj) {
                $.ajax({
                    type: "POST",
                    url: "Advertise.aspx/DeleteArticle",
                    data: "{'Id':'" + Id + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        if (msg.d == "1")
                            $(obj).parent().parent().fadeOut(500);
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

<asp:Label ID="lblMessage" CssClass="msg round" runat="server"></asp:Label>
<script src="../js/swfobject.js" type="text/javascript"></script>

<h5>بخش بنر</h5>
<a class="btn_tiny BoxToggle">راهنما</a>
<div class="Box hide">
<div class="desc">
    <h5>راهنمای درج</h5>
    <div class="clear">
    </div>
    <span>
        <br />
        *موارد دارای ستاره،الزامی است
        <br />
        *ارتفاع را در صورت نیاز به عدد وارد کنید
        <br />
       * ارتفاع تنها برای فایلهای فلش معنادار است 
       <br />
    درج شود   http://www.google.com  لینک تبلیغ باید با الگویی  مشابه 
    </span>
    
    <div class="clear"></div>
</div>
</div>
<fieldset style="border: solid 1px #000">
    <legend>اضافه و ویرایش</legend>
    <div class="row">
        <span class="label_big required">عنوان :</span>
        <asp:TextBox ID="TxtTite" runat="server"></asp:TextBox>
    </div>
    <div class="row">
        <span class="label_big">لینک : </span>
        <asp:TextBox ID="TxtLink" runat="server"></asp:TextBox>
    </div>
    <div class="row">
        <span class="label_big" style="width: 110px;">نوع فایل:</span>
        <asp:DropDownList Width="125" ID="ddlFileType" runat="server" DataTextField="Title" DataValueField="Id"></asp:DropDownList>
    </div>
    <div class="row">
        <span class="label_big required">افزودن فایل تبلیغ</span>
        <div class="uploadButton right mn_t5 " style="width: 100px;">
            <span class="label">افزودن </span>
            <asp:FileUpload ID="fuPic" runat="server" />
        </div>
    </div>
    <asp:RegularExpressionValidator CssClass="right" ID="revMemberPic" runat="server"
        ControlToValidate="fuPic" ValidationGroup="reg" ErrorMessage="تنها فایلهای تصویری معمول و فایل های فلش(swf) قابل انتخاب می باشد."
        ValidationExpression="^.+(.JPG|.jpg|.gif|.GIF|.PNG|.png|.BMP|.bmp|.swf|.flv)$" ForeColor="#430e00"></asp:RegularExpressionValidator>
    <div class="row">
        <span class="label_big">ارتفاع فلش </span>
        <asp:TextBox ID="TxtAdHeight" runat="server"></asp:TextBox>
    </div>
    <div class="clear">
    </div>
    <div id="pnlFilelink">
        <div id="flashContainerPrw" runat="server">
            <span class="flashadsLR" id="flcontainer" height='<%= hfHight.Value %>' href='<%= hfAddr.Value %>'>
            </span>
        </div>
        <div id="picContainerPrw" runat="server">
            <asp:Image CssClass="" ID="Adimg" runat="server" Width="100px" />
        </div>
    </div>
    <div class="row">
        <span class="label_big">وضعیت نمایش:</span>
        <asp:DropDownList Width="125" ID="ddlVisible" runat="server">
            <asp:ListItem Value="1">فعال</asp:ListItem>
            <asp:ListItem Value="0">غیرفعال</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="row">
        <span class="label_big" style="width: 110px;">محل قرارگیری تصویر:</span>
        <asp:DropDownList Width="125" ID="ddlPosition" runat="server" DataTextField="Title" DataValueField="Id"></asp:DropDownList>
    </div>
    
    <asp:Button CssClass="button mn_l5 btn left" ID="btnCancel" Height="25px" runat="server" Text="انصراف" OnClick="btnCancel_Click" />
    <div class="button left" style="width: 95px; margin-left: 10px;">
        <asp:Button CssClass="btn" ID="btnSave" runat="server" Text="ثبت اطلاعات" ValidationGroup="reg"
            OnClick="btnSave_Click" Style="height: 26px" />
        <span class="icon" style="background-image: url(images/btnadd.png)"></span>
    </div>
</fieldset>
<fieldset style="border: solid 1px #000">
    <legend>جستجو </legend>
    <div class="row">
        <span class="label_big">عنوان </span>
        <asp:TextBox ID="StxtTitle" runat="server"></asp:TextBox>
    </div>
    <div class="clear"></div>
    <div class="button left mn_l15 mn_t5" style="width: 95px">
        <asp:Button CssClass="btn" ID="btnClearFilter" runat="server" Text="حذف فیلتر" OnClick="btnClearFilter_Click" />
        <span class="icon" style="background-image: url(images/btnsearchclear.png)"></span>
    </div>
    <div class="button left mn_l15 mn_t5" style="width: 95px">
        <asp:Button CssClass="btn" ID="btnSearch" runat="server" Text="جستجو" OnClick="btnSearch_Click" />
        <span class="icon" style="background-image: url(images/btnsearch.png)"></span>
    </div>
    <div class="clear">
    </div>
</fieldset>
<div class="head_title mn_t5">
    <div class="h">
        <div class="r">
        </div>
        <div class="l">
        </div>
        <span style="width: 90px">عنوان</span>
        <span style="width: 140px">وضعیت نمایش</span>
        <span style="width: 50px">تاریخ درج</span>
        <span style="width: 90px">درج کننده</span>
        <span class="last" style="width: 80px">عملیات</span>
    </div>
</div>
<div class="grid">
    <asp:Repeater ID="rptAdvertise" runat="server">
        <ItemTemplate>
            <div class="odd">
                <span style="width: 90px"><a href='#' title=""><%# Eval("Title").ToString().Length > 10 ? Eval("Title").ToString().Substring(0, 10) + ".." : Eval("Title").ToString()%></a></span>
                <span style="width:90px"><a href='#' title=""><%# Eval("Visible").ToString() == "1" ? "فعال" : "غیر فعال"%></a></span>
                <span style="width:90px"><a href='#' title=""><%# HProtest_BLL.Helper.Utility.GetPersianDate(Eval("DateIn"))%></a></span>
                <span style="width: 90px"><a href='#' title=""><%# Eval("Creator").ToString().Length > 25 ? Eval("Creator").ToString().Substring(0, 25) + ".." : Eval("Creator").ToString()%></a></span>
                
                <span style="width:100px">
                    <a title="ویرایش" href='Advertise.aspx?id=<%# Eval("Id") %>'><img id="imgBtnView" alt="" src="images/edit.png" class="mn_l5" width="16" height="16" /></a>
                    <a href="#" onclick='return removeArticle(this,"<%# Eval("Id") %>")'><img id="imgBtnDelete" alt="" src="images/delete.png" class="mn_l5" width="16" height="16" /></a>
                </span>
                <div class="clear"></div>
            </div>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <div class="even">
                <span style="width: 90px"><a href='#' title=""><%# Eval("Title").ToString().Length > 10 ? Eval("Title").ToString().Substring(0, 10) + ".." : Eval("Title").ToString()%></a></span>
                <span style="width:90px"><a href='#' title=""><%# Eval("Visible").ToString() == "1" ? "فعال" : "غیر فعال"%></a></span>
                <span style="width:90px"><a href='#' title=""><%# HProtest_BLL.Helper.Utility.GetPersianDate(Eval("DateIn"))%></a></span>
                <span style="width: 90px"><a href='#' title=""><%# Eval("Creator").ToString().Length > 25 ? Eval("Creator").ToString().Substring(0, 25) + ".." : Eval("Creator").ToString()%></a></span>
                
                <span style="width:100px">
                    <a title="ویرایش" href='Advertise.aspx?id=<%# Eval("Id") %>'><img id="imgBtnView" alt="" src="images/edit.png" class="mn_l5" width="16" height="16" /></a>
                    <a href="#" onclick='return removeArticle(this,"<%# Eval("Id") %>")'><img id="imgBtnDelete" alt="" src="images/delete.png" class="mn_l5" width="16" height="16" /></a>
                </span>
                <div class="clear"></div>
            </div>
        </AlternatingItemTemplate>
    </asp:Repeater>
</div>
<div style="height: 15px; margin: 5px 0; padding-left: 310px; position: relative">
    <asp:ImageButton ID="imgbtnFirst" CssClass="left" ToolTip="اولین صفحه" AlternateText=""
        ImageUrl="~/CPanel/images/arrow_first.gif" runat="server" value="" OnClick="imgbtnFirst_Click" />
    <asp:ImageButton ID="imgbtnPrev" CssClass="left mn_l15" ToolTip="صفحه قبل" AlternateText=""
        ImageUrl="~/CPanel/images/arrow_pre.gif" runat="server" value="" OnClick="imgbtnPrev_Click" />
    <asp:Label ID="lblPagNumber" CssClass="left mn_l15" runat="server"></asp:Label>
    <asp:ImageButton Visible="false" ID="imgbtnNext" CssClass="left mn_l15" ToolTip="صفحه بعد"
        AlternateText="" ImageUrl="~/CPanel/images/arrow_next.gif" runat="server" value="" OnClick="imgbtnNext_Click" />
    <asp:ImageButton Visible="false" ID="imgbtnLast" CssClass="left mn_l15" ToolTip="آخرین صفحه"
        AlternateText="" ImageUrl="~/CPanel/images/arrow_last.gif" runat="server" value="" OnClick="imgbtnLast_Click" />
</div>
<div class=" clear">
</div>
<h5>
    آمار بخش:</h5>
<div class="row">
    <span class="label_big">تعداد تبلیغات :</span><asp:Label ID="lblAllCount" runat="server"></asp:Label>
    <span class="label_big">تعداد مورد جستجو:</span><asp:Label ID="lblResultCount" runat="server"></asp:Label>
</div>

 
