<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.ascx.cs" Inherits="UC_ChangePassword"  %>
<script type="text/javascript">
    if ($('#<%=hfShowMsg.ClientID %>').val() != "") {
        showMsg('warning', $('#<%=hfShowMsg.ClientID %>').val());
    }
</script>
<center>
<asp:HiddenField ID="hfShowMsg" runat="server" Value="1" />
<div class="clear"></div>
<div id="changePass">
    <div id="title">برای تغییر رمز عبور خود اطلاعات زیر را وارد نمایید</div>
    
    <div id="rowstxt" style="margin-top: 20px;">
        <div id="Lable">رمز عبور قدیمی : </div>
        <div id="val"><asp:TextBox ID="txtOldPassword" TextMode="Password" CssClass="txt" runat="server"></asp:TextBox></div>
    </div>
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
</center>