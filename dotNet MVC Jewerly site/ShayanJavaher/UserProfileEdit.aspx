<%@ Page Title="" Language="C#" MasterPageFile="~/Main_MasterPage.master" AutoEventWireup="true"
    CodeFile="UserProfileEdit.aspx.cs" Inherits="UserProfileEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</script>
    <link href="CSS/main.css" rel="stylesheet" type="text/css" />
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="Creative CSS3 Animation Menus" />
    <meta name="keywords" content="menu, navigation, animation, transition, transform, rotate, css3, web design, component, icon, slide" />
    <meta name="author" content="Codrops" />
    <link href="CSS/basket.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plContentMP" runat="Server">
                <asp:Panel ID="Panel1" runat="server" DefaultButton="btnEdit">  
    <center>
        <div style="padding: 5px; width: 660px; height: auto; text-align: center; direction: rtl;">
            <ul class="ca-menu">
                <li><a href='<%= Page.ResolveClientUrl("~/BuyBasket.aspx")%>'><span
                    class="ca-icon">
                    <img width="40px" height="40px" src="Resource/PicSite/basket.png" /></span>
                    <div class="ca-content">
                        <h2 class="ca-main">
                            سبد&nbspخرید</h2>
                        <h3 class="ca-sub">
                            مشاهده&nbspسبد&nbspخرید</h3>
                    </div>
                </a></li>
                <li><a href='<%= Page.ResolveClientUrl("~/BuyList.aspx")%>'><span
                    class="ca-icon">
                    <img width="40px" height="40px" src="Resource/PicSite/list.png" /></span>
                    <div class="ca-content">
                        <h2 class="ca-main">
                            لیست&nbspخرید&nbspها</h2>
                        <h3 class="ca-sub">
                            مشاهده&nbspخرید&nbspهای&nbspپیشین</h3>
                    </div>
                </a></li>
                <li style="background-color:#34b54e;"><a href='<%= Page.ResolveClientUrl("~/UserProfileEdit.aspx") %>'>
                    <span class="ca-icon" id="heart">
                        <img width="40px" height="40px" src="Resource/PicSite/profile.png" /></span>
                    <div class="ca-content">
                        <h2 class="ca-main">
                            پروفایل</h2>
                        <h3 class="ca-sub">
                            تنظیمات&nbspکاربری</h3>
                    </div>
                </a></li>
            </ul>
        </div>
        <!-- content -->
        <div class="clear"></div>
        <div id="alert" class="hide">
        <div style="padding:5px; width:650px; border-radius:5px; border:1px dotted #666; text-align:right;">
            <div class="img" id="imgAlert"></div>
            <div class="text"><span id="lblAlert"></span></div>
        </div>
    </div>
        <asp:HiddenField ID="hfShowMsg" runat="server" Value="1" />
        <div class="clear"></div>
<div style="padding:5px; width:650px; border-radius:5px; border:1px dotted #666; text-align:right;">
    
    <div style="padding:5px;">پروفایل کاربر : <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>&nbsp|&nbsp<span><a href='<%= Page.ResolveClientUrl("~/ChangePassword.aspx") %>'>تغییر رمز عبور</a></span></div>

    <div style="padding:5px; direction:rtl; text-align:justify; color:Maroon; font-size:8pt; width:500px; margin-right:10px;">
        <div style="padding:5px;">تذکر : </div>
        <div style="padding:5px;">1- برای ارسال سفارش و خرید از شایان جواهر پر کردن اطلاعات ستاره دار الزامی می باشد .</div>
        <div style="padding:5px;">2- لطفاً اطلاعات خود را به زبان فارسی وارد نمایید.</div>
    </div>
    <div style="padding:5px;">
        <div style="padding:5px;" class="labelE">نام : </div>
        <div style="padding:5px;"><span style="color:Maroon">&nbsp;&nbsp;</span><asp:TextBox  CssClass="valueE" ID="txtName" runat="server"></asp:TextBox></div>
    </div>
    <div style="padding:5px;">
        <div style="padding:5px;" class="labelE">نام خانوادگی : </div>
        <div style="padding:5px;"><span style="color:Maroon">*&nbsp</span><asp:TextBox CssClass="valueE" ID="txtFamily" runat="server"></asp:TextBox></div>
    </div>

    <div style="padding:5px;">
        <div style="padding:5px;" class="labelE">جنسیت : </div>
        <div style="padding:5px;"><span style="color:Maroon">&nbsp&nbsp&nbsp</span>
            <asp:DropDownList CssClass="valueEddl" ID="ddlSex" runat="server">
	            <asp:ListItem value="0">آقا</asp:ListItem>
	            <asp:ListItem value="1">خانم</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div style="padding:5px;">
        <div style="padding:5px;" class="labelE">ایمیل : </div>
        <div style="padding:5px;"><span style="color:Maroon">*&nbsp</span><asp:TextBox CssClass="valueE" ID="txtMail" runat="server"></asp:TextBox></div>
    </div>

    <div style="padding:5px;">
        <div style="padding:5px;" class="labelE">تلفن همراه : </div>
        <div style="padding:5px;"><span style="color:Maroon">&nbsp&nbsp&nbsp</span><asp:TextBox CssClass="valueE" ID="txtMobile" runat="server"></asp:TextBox></div>
    </div>
    <div style="padding:5px;">
        <div style="padding:5px;" class="labelE">تلفن ثابت + پیش شماره : </div>
        <div style="padding:5px;"><span style="color:Maroon">*&nbsp</span><asp:TextBox CssClass="valueE" ID="txtTel" runat="server"></asp:TextBox></div>
    </div>
    <div style="padding:5px;">
        <div style="padding:5px;" class="labelE">استان : </div>
        <div style="padding:5px;"><span style="color:Maroon">*&nbsp</span>
                <asp:DropDownList CssClass="valueEddl" ID="ddlProvince" runat="server">
	                <asp:ListItem Selected="True" value="">انتخاب کنید ...</asp:ListItem>
	                <asp:ListItem value="آذربایجان شرقی">آذربایجان شرقی</asp:ListItem>
	                <asp:ListItem value="آذربایجان غربی">آذربایجان غربی</asp:ListItem>
	                <asp:ListItem value="اردبیل">اردبیل</asp:ListItem>
	                <asp:ListItem value="اصفهان">اصفهان</asp:ListItem>
	                <asp:ListItem value="البرز">البرز</asp:ListItem>
	                <asp:ListItem value="ایلام">ایلام</asp:ListItem>
	                <asp:ListItem value="بوشهر">بوشهر</asp:ListItem>
	                <asp:ListItem value="تهران">تهران</asp:ListItem>
	                <asp:ListItem value="8">چهارمحال و بختیاری</asp:ListItem>
	                <asp:ListItem value="9">خراسان جنوبی</asp:ListItem>
	                <asp:ListItem value="10">خراسان رضوی</asp:ListItem>
	                <asp:ListItem value="11">خراسان شمالی</asp:ListItem>
	                <asp:ListItem value="12">خوزستان</asp:ListItem>
	                <asp:ListItem value="13">زنجان</asp:ListItem>
	                <asp:ListItem value="14">سمنان</asp:ListItem>
	                <asp:ListItem value="15">سیستان و بلوچستان</asp:ListItem>
	                <asp:ListItem value="16">فارس</asp:ListItem>
	                <asp:ListItem value="17">قزوین</asp:ListItem>
	                <asp:ListItem value="18">قم</asp:ListItem>
	                <asp:ListItem value="19">کردستان</asp:ListItem>
	                <asp:ListItem value="20">کرمان</asp:ListItem>
	                <asp:ListItem value="21">کرمانشاه</asp:ListItem>
	                <asp:ListItem value="22">کهگیلویه و بویراحمد</asp:ListItem>
	                <asp:ListItem value="23">گلستان</asp:ListItem>
	                <asp:ListItem value="24">گیلان</asp:ListItem>
	                <asp:ListItem value="25">لرستان</asp:ListItem>
	                <asp:ListItem value="26">مازندران</asp:ListItem>
	                <asp:ListItem value="27">مرکزی</asp:ListItem>
	                <asp:ListItem value="28">هرمزگان</asp:ListItem>
	                <asp:ListItem value="29">همدان</asp:ListItem>
	                <asp:ListItem value="30">یزد</asp:ListItem>
                </asp:DropDownList>
        </div>
    </div>
    <div style="padding:5px;">
        <div style="padding:5px;" class="labelE">شهر : </div>
        <div style="padding:5px;"><span style="color:Maroon">*&nbsp</span><asp:TextBox CssClass="valueE" ID="txtCity" runat="server"></asp:TextBox></div>
    </div>
    <div style="padding:5px;">
        <div style="padding:5px;" class="labelE">آدرس دقیق پستی : </div>
        <div style="padding:5px;"><span style="color:Maroon; vertical-align: top;">*&nbsp</span><asp:TextBox CssClass="" ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox></div>
    </div>
    <div style="padding:5px;">
        <div style="padding:5px;" class="labelE">کدپستی : </div>
        <div style="padding:5px;"><span style="color:Maroon">*&nbsp</span><asp:TextBox CssClass="valueE" ID="txtZipCode" runat="server"></asp:TextBox></div>
    </div>
    <div style="padding:5px; text-align:center"><asp:Button ID="btnEdit" runat="server" 
            Text="ویرایش" onclick="btnEdit_Click" /><asp:Button ID="btnCancel" runat="server" Text="انصراف" /></div>
</div>  
    </center>
    </asp:Panel>
</asp:Content>
