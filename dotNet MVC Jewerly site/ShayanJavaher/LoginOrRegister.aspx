<%@ Page Title="" Language="C#" MasterPageFile="~/Main_MasterPage.master" AutoEventWireup="true"
    CodeFile="LoginOrRegister.aspx.cs" Inherits="LoginOrRegister" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plContentMP" runat="Server">
    <div id="alert" class="hide">
        <div class="alert">
            <div class="img" id="imgAlert">
            </div>
            <div class="text">
                <span id="lblAlert"></span>
                <div class="clear">
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
    </div>
    <center>
<div id="loginOrRegister" class="BoxDivShadow">
    <div><asp:HiddenField ID="hfShowMsg" runat="server" /></div>

<script type="text/javascript">
    if ($('#<%=hfShowMsg.ClientID %>').val() != "") {
        showMsg('warning', $('#<%=hfShowMsg.ClientID %>').val());
    }
</script>
<%-------------- ثبت نام -------------------%>

            <asp:Panel ID="Panel1" runat="server" DefaultButton="btnRegister">  
        <div class="register">
            <div class="gradient BoxDivShadow HeaderSite headerR">ثبت نام سریع در سایت</div>

            <div class="satr">
                <div class="lbl">نام کاربری :</div>
                <div class="val"><asp:TextBox Width="130px" CssClass="txtbox" ID="txtRegisterUsername" runat="server"></asp:TextBox></div>
            </div>

            <div class="satr">
                <div class="lbl">ایمیل :</div>
                <div class="val"><asp:TextBox Width="130px" CssClass="txtbox" ID="txtRegisterEmail" runat="server"></asp:TextBox></div>
            </div>

            <div class="satr">
                <div class="lbl">&nbsp</div>
                <div class="val" style="font-size: 10px; color:red;">* ایمیل خود را دقیق وارد کنید</div>
            </div>

            <div class="satr">
                <div class="lbl">رمز عبور :</div>
                <div class="val"><asp:TextBox CssClass="txtlogin" Width="130px" ID="txtRegisterPassword" runat="server" TextMode="Password"></asp:TextBox></div>
            </div>

            <div class="satr">
                <div class="lbl">تکرار رمز عبور :</div>
                <div class="val"><asp:TextBox CssClass="txtlogin" Width="130px" ID="txtRegisterConfirmPassword" runat="server" TextMode="Password"></asp:TextBox></div>
            </div>

            <div class="clear"></div>
            <div>
                <div id="divcaptcha"><img alt="" class="" id="imgcaptcha" src='<%= Page.ResolveClientUrl("~/CAPTCHA/Captcha.aspx") %>'   /></div>
                <div id="jahat">>></div>
                <div id="valuecaptcha"><asp:TextBox ID="txtCaptcha" CssClass="txtboxCaptcha" MaxLength="6" EnableViewState="false" AutoCompleteType="None" runat="server"></asp:TextBox></div>
            </div>
            <div class="clear"></div> 
            <div style="text-align: center; padding: 5px">
                <asp:Button ID="btnRegister" runat="server" Text="ثبت نام" OnClick="btnRegister_Click" style="height: 26px" />
            </div>

        </div>
        </asp:Panel>
<%--------------خط جدا کننده-------------------%>

        <div class="line"></div>

<%-------------- ورود به سایت -------------------%>
            <asp:Panel ID="Panel2" runat="server" DefaultButton="btnlogin">  
        <div class="login">
            <div class="gradient BoxDivShadow headerL HeaderSite">ورود به سایت</div>
            <div class="satr">
                <div class="lbl">نام کاربری :</div>
                <div class="val"><asp:TextBox Width="130px" CssClass="txtlogin" ID="txtUserName" runat="server"></asp:TextBox></div>
            </div>
            <div class="satr">
                <div class="lbl">رمز عبور :</div>
                <div class="val"><asp:TextBox CssClass="txtlogin" Width="130px" ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></div>
            </div>
            <div style=""><asp:Button Width="50px" Height="25px" ID="btnlogin" runat="server" Text="ورود" onclick="btnlogin_Click" /></div>
        </div>
        </asp:Panel>
</div>
</center>
</asp:Content>
