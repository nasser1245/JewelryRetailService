<%@ Page Title="" Language="C#" MasterPageFile="~/Main_MasterPage.master" AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plContentMP" runat="Server">
                    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnRegister">  
<div id="RegisterCo" class="BoxDivShadow">
    <div id="alert" class="hide">
            <div class="alert">
                <div class="img" id="imgAlert"></div>
                <div class="text"><span id="lblAlert"></span></div>
            </div>
        </div>
        <div class="clear"></div>
        <div style="padding: 5px;">ثبت نام کاربر :<%# Eval("UserName") %></div>
        <div style="padding: 5px; direction: rtl; text-align: justify; color: Maroon; font-size: 8pt; width: 500px; margin-right: 10px;">
            <div style="padding: 5px;">تذکر :</div>
            <div style="padding: 5px;">1- لطفاً اطلاعات خود را به زبان فارسی وارد نمایید.</div>
        </div>
        <div style="padding: 5px;">
            <div style="padding: 5px;" class="labelE">نام :</div>
            <div style="padding: 5px;"><span style="color: Maroon">&nbsp&nbsp&nbsp</span><asp:TextBox CssClass="valueE txtboxsearchnews" ID="txtName" runat="server"></asp:TextBox></div>
        </div>
        <div style="padding: 5px;">
            <div style="padding: 5px;" class="labelE">نام خانوادگی :</div>
            <div style="padding: 5px;"><span style="color: Maroon">&nbsp&nbsp&nbsp</span><asp:TextBox CssClass="valueE txtboxsearchnews" ID="txtFamily" runat="server"></asp:TextBox></div>
        </div>
        <div style="padding: 5px;">
            <div style="padding: 5px;" class="labelE">نام کاربری :</div>
            <div style="padding: 5px;"><span style="color: Maroon">*&nbsp</span><asp:TextBox CssClass="valueE txtboxsearchnews" ID="txtUserName" runat="server"></asp:TextBox></div>
        </div>
        <div style="padding: 5px;">
            <div style="padding: 5px;" class="labelE">رمز عبور :</div>
            <div style="padding: 5px;"><span style="color: Maroon">*&nbsp</span><asp:TextBox CssClass="valueE txtboxsearchnews" ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox></div>
        </div>
        <div style="padding: 5px;">
            <div style="padding: 5px;" class="labelE">تکرار رمز :</div>
            <div style="padding: 5px;"><span style="color: Maroon">*&nbsp</span><asp:TextBox CssClass="valueE txtboxsearchnews" ID="txtPasswordRepeat" TextMode="Password" runat="server"></asp:TextBox></div>
        </div>
        <div style="padding: 5px;">
            <div style="padding: 5px;" class="labelE">ایمیل :</div>
            <div style="padding: 5px;"><span style="color: Maroon">*&nbsp</span><asp:TextBox CssClass="valueE txtboxsearchnews" ID="txtMail" runat="server"></asp:TextBox></div>
        </div>
        <div style="padding: 5px;">
            <div style="padding: 5px;" class="labelE">جنسیت :</div>
            <div style="padding: 5px;"><span style="margin-right:10px"></span>
                <asp:DropDownList CssClass="valueEddl" ID="ddlSex" runat="server">
                    <asp:ListItem Value="0">آقا</asp:ListItem>
                    <asp:ListItem Value="1">خانم</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div style="padding: 5px;">
            <div style="padding: 5px;" class="labelE">تلفن همراه :</div>
            <div style="padding: 5px;"><span style="margin-right:10px"></span><asp:TextBox CssClass="valueE txtboxsearchnews" ID="txtMobile" runat="server"></asp:TextBox></div>
        </div>
        <div style="padding: 5px;">
            <div style="padding: 5px;" class="labelE">تلفن ثابت + پیش شماره :</div>
            <div style="padding: 5px;"><span style="margin-right:10px"></span><asp:TextBox CssClass="valueE txtboxsearchnews" ID="txtTel" runat="server"></asp:TextBox></div>
        </div>
        <div style="padding: 5px;">
            <div style="padding: 5px;" class="labelE">استان :</div>
            <div style="padding: 5px;">
                <span style="margin-right:10px"></span>
                <asp:DropDownList CssClass="valueEddl" ID="ddlProvince" runat="server">
                    <asp:ListItem Selected="True" Value="">انتخاب کنید ...</asp:ListItem>
                    <asp:ListItem Value="آذربایجان شرقی">آذربایجان شرقی</asp:ListItem>
                    <asp:ListItem Value="آذربایجان غربی">آذربایجان غربی</asp:ListItem>
                    <asp:ListItem Value="اردبیل">اردبیل</asp:ListItem>
                    <asp:ListItem Value="اصفهان">اصفهان</asp:ListItem>
                    <asp:ListItem Value="البرز">البرز</asp:ListItem>
                    <asp:ListItem Value="ایلام">ایلام</asp:ListItem>
                    <asp:ListItem Value="بوشهر">بوشهر</asp:ListItem>
                    <asp:ListItem Value="تهران">تهران</asp:ListItem>
                    <asp:ListItem Value="8">چهارمحال و بختیاری</asp:ListItem>
                    <asp:ListItem Value="9">خراسان جنوبی</asp:ListItem>
                    <asp:ListItem Value="10">خراسان رضوی</asp:ListItem>
                    <asp:ListItem Value="11">خراسان شمالی</asp:ListItem>
                    <asp:ListItem Value="12">خوزستان</asp:ListItem>
                    <asp:ListItem Value="13">زنجان</asp:ListItem>
                    <asp:ListItem Value="14">سمنان</asp:ListItem>
                    <asp:ListItem Value="15">سیستان و بلوچستان</asp:ListItem>
                    <asp:ListItem Value="16">فارس</asp:ListItem>
                    <asp:ListItem Value="17">قزوین</asp:ListItem>
                    <asp:ListItem Value="18">قم</asp:ListItem>
                    <asp:ListItem Value="19">کردستان</asp:ListItem>
                    <asp:ListItem Value="20">کرمان</asp:ListItem>
                    <asp:ListItem Value="21">کرمانشاه</asp:ListItem>
                    <asp:ListItem Value="22">کهگیلویه و بویراحمد</asp:ListItem>
                    <asp:ListItem Value="23">گلستان</asp:ListItem>
                    <asp:ListItem Value="24">گیلان</asp:ListItem>
                    <asp:ListItem Value="25">لرستان</asp:ListItem>
                    <asp:ListItem Value="26">مازندران</asp:ListItem>
                    <asp:ListItem Value="27">مرکزی</asp:ListItem>
                    <asp:ListItem Value="28">هرمزگان</asp:ListItem>
                    <asp:ListItem Value="29">همدان</asp:ListItem>
                    <asp:ListItem Value="30">یزد</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div style="padding: 5px;">
            <div style="padding: 5px;" class="labelE">شهر :</div>
            <div style="padding: 5px;"><span style="margin-right:10px"></span><asp:TextBox CssClass="valueE txtboxsearchnews" ID="txtCity" runat="server"></asp:TextBox></div>
        </div>
        <div style="padding: 5px;">
            <div style="padding: 5px;" class="labelE">آدرس دقیق پستی :</div>
            <div style="padding: 5px;"><span style="margin-right:10px; vertical-align: top;"></span><asp:TextBox CssClass="txtareasearchnews" ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox></div>
        </div>
        <div style="padding: 5px;">
            <div style="padding: 5px;" class="labelE">کدپستی :</div>
            <div style="padding: 5px;"><span style="margin-right:10px"></span><asp:TextBox CssClass="valueE txtboxsearchnews" ID="txtZipCode" runat="server"></asp:TextBox></div>
        </div>
        <div class="clear"></div>
        <div style="text-align:center; width:100%; float:right; margin-right:147px">
            <div id="divcaptcha"><img alt="" class="" id="imgcaptcha" src='<%= Page.ResolveClientUrl("~/CAPTCHA/Captcha.aspx") %>' /></div>
            <div id="jahat">>></div>
            <div id="valuecaptcha"><asp:TextBox ID="txtCaptcha" CssClass="txtboxCaptcha" MaxLength="6" EnableViewState="false" runat="server" AutoCompleteType="None"></asp:TextBox></div>
            <div class="clear"></div>
        </div>
        <div class="clear"></div>
        <div style="padding: 5px; text-align: center">
            <asp:Button ID="btnRegister" runat="server" Text="ثبت نام" OnClick="btnRegister_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="انصراف" onclick="btnCancel_Click" />
        </div>
    </div>
    </asp:Panel>
</asp:Content>
