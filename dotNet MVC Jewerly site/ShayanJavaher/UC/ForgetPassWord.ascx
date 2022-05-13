<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ForgetPassWord.ascx.cs" Inherits="UC_ChangePassWoed" %>
<script type="text/javascript">

</script>
<center>
            <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSend">    

<div id="forgetPass">
    <div id="title">برای به دست آوردن رمز عبور خود اطلاعات زیر را وارد نمایید</div>
    <div id="rowstxt" style="margin-top: 20px;">
        <div id="Lable">نام کاربری : </div>
        <div id="txtuserpass"><asp:TextBox ID="txtUsername" Width="220px" Height="25px" runat="server"></asp:TextBox></div>
    </div>
    <div id="rowstxt" >
        <div id="Lable">ایمیل : </div>
        <div id="txtuserpass"><asp:TextBox ID="txtMail" Width="220px" Height="25px" runat="server"></asp:TextBox></div>
    </div>
    <div class="clear"></div>

    <div>
        <div id="divcaptcha"><img  alt="" class="" id="imgcaptcha" src='<%= Page.ResolveClientUrl("~/CAPTCHA/Captcha.aspx") %>'   /></div>
        <div id="jahat">>></div>
        <div id="valuecaptcha"><asp:TextBox ID="txtCaptcha" CssClass="txtboxCaptcha" MaxLength="6" EnableViewState="false" runat="server"></asp:TextBox></div>
    </div>

    <div class="clear"></div>
    <div><asp:Button ID="btnSend" runat="server" Text="ارسال" onclick="btnSend_Click" /></div>
</div>
</asp:Panel>
</center>
