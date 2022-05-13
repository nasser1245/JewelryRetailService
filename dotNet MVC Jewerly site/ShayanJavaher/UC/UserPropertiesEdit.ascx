<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserPropertiesEdit.ascx.cs" Inherits="HomePage_UC_UserPropertiesEdit" %>
<asp:HiddenField ID="hfShowMsg" runat="server" Value="1" />

<link href="../CSS/main.css" rel="stylesheet" type="text/css" />
<center>
            <asp:Panel ID="Panel1" runat="server" DefaultButton="btnEdit">    
<div style="padding:5px; width:650px; border-radius:5px; border:1px dotted #666; text-align:right;">
    
    <div style="padding:5px;">پروفایل کاربر : <%# Eval("UserName") %>&nbsp|&nbsp<span><a href="#">تغییر رمز عبور</a></span></div>

    <div style="padding:5px; direction:rtl; text-align:justify; color:Maroon; font-size:8pt; width:500px; margin-right:10px;">
        <div style="padding:5px;">تذکر : </div>
        <div style="padding:5px;">1- برای ارسال سفارش و خرید از شایان جواهر پر کردن اطلاعات ستاره دار الزامی می باشد .</div>
        <div style="padding:5px;">2- لطفاً اطلاعات خود را به زبان فارسی وارد نمایید.</div>
    </div>
    <div style="padding:5px;">
        <div style="padding:5px;" class="labelE">نام : </div>
        <div style="padding:5px;"><span style="color:Maroon">*&nbsp</span><asp:TextBox  CssClass="valueE" ID="txtName" runat="server"></asp:TextBox></div>
    </div>
    <div style="padding:5px;">
        <div style="padding:5px;" class="labelE">نام خانوادگی : </div>
        <div style="padding:5px;"><span style="color:Maroon">*&nbsp</span><asp:TextBox CssClass="valueE" ID="txtFamily" runat="server"></asp:TextBox></div>
    </div>

    <div style="padding:5px;">
        <div style="padding:5px;" class="labelE">جنسیت : </div>
        <div style="padding:5px;"><span style="color:Maroon">*&nbsp</span>
            <asp:DropDownList CssClass="valueEddl" ID="ddlSex" runat="server">
                <asp:ListItem Selected="True" value="-1">انتخاب کنید ...</asp:ListItem>
	            <asp:ListItem value="0">آقا</asp:ListItem>
	            <asp:ListItem value="1">خانم</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div style="padding:5px;">
        <div style="padding:5px;" class="labelE">ایمیل : </div>
        <div style="padding:5px;"><span style="color:Maroon">&nbsp&nbsp&nbsp</span><asp:TextBox CssClass="valueE" ID="txtMail" runat="server"></asp:TextBox></div>
    </div>

    <div style="padding:5px;">
        <div style="padding:5px;" class="labelE">تلفن همراه : </div>
        <div style="padding:5px;"><span style="color:Maroon">*&nbsp</span><asp:TextBox CssClass="valueE" ID="txtMobile" runat="server"></asp:TextBox></div>
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
</asp:Panel>
</center>