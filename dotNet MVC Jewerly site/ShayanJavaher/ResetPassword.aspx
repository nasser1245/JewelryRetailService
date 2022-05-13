<%@ Page Title="" Language="C#" MasterPageFile="~/Main_MasterPage.master" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plContentMP" Runat="Server">
<center>
<div id="alert" class="hide">
        <div class="alert">
            <div class="img" id="imgAlert"></div>
            <div class="text"><span id="lblAlert"></span></div>
    <div class="clear"></div>

        </div>
    <div class="clear"></div>

    </div>
                <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSend">  
<div id="changePass">
    <div id="title">برای تغییر رمز عبور خود اطلاعات زیر را وارد نمایید</div>
    
    <div id="rowstxt">
        <div id="Lable">رمز عبور جدید : </div>
        <div id="val"><asp:TextBox ID="txtPass" TextMode="Password" CssClass="txt" runat="server"></asp:TextBox></div>
    </div>
    <div id="rowstxt">
        <div id="Lable">تکرار رمز عبور جدید : </div>
        <div id="val"><asp:TextBox ID="txtConfirmPass" TextMode="Password" CssClass="txt" runat="server"></asp:TextBox></div>
    </div>

    <div class="clear"></div> 
    <div><asp:Button ID="btnSend" runat="server" Text="ارسال" onclick="btnSend_Click" /></div>
</div>
</asp:Panel>
</center>
</asp:Content>

