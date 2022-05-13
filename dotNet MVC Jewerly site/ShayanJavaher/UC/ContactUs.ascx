<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContactUs.ascx.cs" Inherits="HomePage_UC_ContactUs" %>

<script src='<%= Page.ResolveUrl("~/Js/jquery-1.7.2.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/Manager/Js/ckeditor/ckeditor.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/Manager/Js/ckeditor/adapters/jquery.js")%>' type="text/javascript"></script>
<script type="text/javascript">
    var config = {
        skin: 'kama',
        toolbar:
		[
			['TextColor', 'BGColor',  'UIColor', 'Bold', 'Italic', 'Underline', 'Strike', 'RemoveFormat', 'Styles', 'Font', 'FontSize'],

            
		],
        removePlugins: 'resize',
        height: '190px',
        //width: '680px',
        language: 'fa',
        uiColor: '#CCDBFF'
    };
    $(function () {

        
        $('#<%= txtDetailsContactUs.ClientID %>').ckeditor(config);
    });
</script>
<script type="text/javascript">
    if ($('#<%=hfShowMsg.ClientID %>').val() != "") {
        showMsg('warning', $('#<%=hfShowMsg.ClientID %>').val());
    }
</script>
<asp:HiddenField ID="hfShowMsg" runat="server" Value="1" />
<center>
            <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSubmit">    

<div id="contactus" class="BoxDivShadow">
<div id="alert" class="hide">
        <div class="alert">
            <div class="img" id="imgAlert"></div>
            <div class="text"><span id="lblAlert"></span></div>
    <div class="clear"></div>

        </div>
    <div class="clear"></div>

    </div>
    <div id="divsatr">
        <div id="lbl">نام : </div>
        <div id="value" class="Space"><asp:TextBox ID="txtName" CssClass="txtbox" runat="server"></asp:TextBox></div>
    </div>
    <div id="divsatr">
        <div id="lbl">نام خانوادگی : </div>
        <div id="value" class="Space"><asp:TextBox CssClass="txtbox" ID="txtFamily" runat="server"></asp:TextBox></div>
    </div>
    <div id="divsatr">
        <div id="lbl">ایمیل : </div>
        <div id="value" class="Space"><asp:TextBox CssClass="txtbox" ID="txtEmail" runat="server"></asp:TextBox></div>
    </div>
    <div id="divsatr">
        <div id="lbl">تلفن : </div>
        <div id="value"><span style="color: Maroon">*&nbsp</span><asp:TextBox CssClass="txtbox" ID="txtTel" runat="server"></asp:TextBox></div>
    </div>
    <div id="divsatr">
        <div id="lbl">نوع نظر : </div>
        <div id="value" class="Space">
            <asp:DropDownList CssClass="ddlCU" ID="ddlTypeContactUs" runat="server">
                <asp:ListItem Value="1">نظرات و پیشنهاد</asp:ListItem>
                <asp:ListItem Value="2">سفارش کالا</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div id="divsatr">
        <div id="lbl">عنوان : </div>
        <div id="value" class="Space"><asp:TextBox CssClass="txtbox" ID="txtTitle" runat="server"></asp:TextBox></div>
    </div>
    <div id="divsatr">
        <div id="value"><asp:TextBox ID="txtDetailsContactUs" TextMode="MultiLine" runat="server"></asp:TextBox></div>
    </div>

    <div class="clear"></div>

    <div>
        <div id="divcaptcha"><img  alt="" class="" id="imgcaptcha" src='<%= Page.ResolveClientUrl("~/CAPTCHA/Captcha.aspx")%>'/></div>
        <div id="jahat">>></div>
        <div id="valuecaptcha"><asp:TextBox ID="txtCaptcha" CssClass="txtboxCaptcha" MaxLength="6" EnableViewState="false" runat="server"></asp:TextBox></div>
        <div id="btn"><asp:Button ID="btnSubmit" CssClass="btn" runat="server" Text="ثبت" 
                onclick="btnSubmit_Click" /></div>
    </div>

    <div class="clear"></div>

</div>
</asp:Panel>
</center>