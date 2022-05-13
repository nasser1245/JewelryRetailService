<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucMemberContent.ascx.cs" Inherits="Manager_UC_ucMemberContent" %>
<asp:HiddenField ID="hfMemberId" runat="server" Value="1" />
<asp:HiddenField ID="hfEditType" runat="server" Value="1" />
<asp:HiddenField ID="hfShowoptionlistaddress" runat="server" />
<asp:HiddenField ID="hfShowMsg" runat="server" />


<script type="text/javascript">
    $(function () {

        $("#btnResetPass").click(function () {
            $("#divResetPass").slideToggle();
        });

        if ($('#<%=hfEditType.ClientID %>').val() == "2") {
            $("#divResetPass").hide();
        }

        

//        HighLightRequired();

        var config = {
            skin: 'kama',
            toolbar:
		[
			['Bold', 'Italic', '-', 'NumberedList', 'BulletedList', '-', 'Link', 'Unlink', 'TextColor', 'BGColor', 'Source'],
			['UIColor'],
            ['-', 'NewPage', 'DocProps', 'Preview', 'Print', '-', 'Templates'],
            ['Find', 'Replace', '-', 'SelectAll', '-', 'SpellChecker', 'Scayt'],
            ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript', '-', 'RemoveFormat'],
            ['Form', 'Checkbox', 'Radio', 'TextField', 'Textarea', 'Select', 'Button', 'ImageButton', 'HiddenField'],
            ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote', 'CreateDiv', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'BidiLtr', 'BidiRtl'],
            ['Link', 'Unlink', 'Anchor', 'Maximize'],
            ['Styles', 'Format', 'Font', 'FontSize'],
            ['Image', 'Flash', 'Table', 'HorizontalRule', 'Smiley', 'SpecialChar', 'PageBreak', 'Iframe', 'ShowBlocks']
		],
            removePlugins: 'resize',
            height: '190px',
            //width: '680px',
            language: 'fa',
            uiColor: '#CCDBFF'
        };
    });
    if ($('#<%=hfShowMsg.ClientID %>').val() != "") {
        showMsg('warning', $('#<%=hfShowMsg.ClientID %>').val());
    }
    
</script>

<%--   <div id="alert" class="hide">
        <div class="alert">
            <div class="img" id="imgAlert"></div>
            <div class="text"><span id="lblAlert"></span></div>
    <div class="clear"></div>

        </div>
    <div class="clear"></div>

    </div>--%>
<asp:Label ID="lblMessage" style="height:50px;clear:both;display:block;background:#cee7ed;line-height:50px" CssClass="round" runat="server"></asp:Label>
<h5>بخش ثبت نام</h5>
<div class="desc">
    <h5>راهنمای درج</h5>
    <div class="clear"></div>
    <span>
        
        *موارد دارای ستاره،الزامی است
        <br />
        </span>
    <div class="clear"></div>
</div>


            <div class="LabelP">
                نام:
            </div>
            <div class="ValueP">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </div>

            <div class="LabelP">
                نام خانوادگی:
            </div>
            <div class="ValueP">
                <asp:TextBox ID="txtFamily" runat="server"></asp:TextBox>
                </div>

            <div class="LabelP">
                ایمیل:
            </div>
            <div class="ValueP">
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </div>

            <div class="LabelP">
                نام کاربری:*
            </div>
            <div class="ValueP">
                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                </div>
<% if(hfEditType.Value=="2"){ %>
                            <div class="LabelP">
                
            </div>
            
            <div class="ValueP">
            <input type="button" id="btnResetPass" value= "پاک کردن رمز"/>
            <span>برای ثبت پسورد جدید حتما مقدار آن را وارد کنید</span>
                </div>
                <%} %>
                  <div id="divResetPass" style="float:right;width:100%">
                              <div class="LabelP">
                <asp:Label ID="lblPassword" runat="server" Text="رمز عبور:*"></asp:Label>
            </div>

            <div class="ValueP">
                <asp:TextBox ID="txtPassword" runat="server" TextMode ="Password"></asp:TextBox>
                </div>
            <div class="LabelP">
                <asp:Label ID="lblPasswordRepeat"  runat="server" Text="تکرار رمز:*"></asp:Label>
            </div>
            <div class="ValueP">
                <asp:TextBox ID="txtPasswordRepeat" runat="server" TextMode ="Password"></asp:TextBox>
                </div>
                <div class="clear"></div>
                </div>  

                
            <div class="LabelP" >
                تلفن ثابت:
            </div>
            <div class="ValueP">
                <asp:TextBox ID="txtTel" runat="server"></asp:TextBox>
                </div>

            <div class="LabelP" >
                تلفن همراه:
            </div>
            <div class="ValueP">
                <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                </div>

            <div class="LabelP" >
                کدپستی:
            </div>
            <div class="ValueP">
                <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
                </div>

            <div class="LabelP" >
                آدرس:
            </div>
            <div class="ValueP">
                <asp:TextBox ID="txtAddress" runat="server" Width="450px"></asp:TextBox>
                </div>

<div>
<div class="clear"></div>

            <div class="LabelP" >
            </div>
            <div class="ValueP">
    <asp:Button ID="btnSave" runat="server" Text="ثبت اطلاعات" ValidationGroup="reg" onclick="btnSave_Click" />
                </div>

<%--<div class="button left" style="width:100px;margin-left:20px">
    <asp:Button CssClass="btn" ID="btnSave" runat="server" Text="ثبت اطلاعات" ValidationGroup="reg" onclick="btnSave_Click" />
    <span class="icon" style="background-image:url(images/btnadd.png)"></span>--%>