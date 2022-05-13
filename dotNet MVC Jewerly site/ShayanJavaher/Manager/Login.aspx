<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>صفحه ورود مدیریت شایان جواهر</title>
    <style type="text/css">
body{background:#a6b6a3 url('../Resource/PicSite/Bg-Master.jpg') repeat-x;}
        
        .clear{clear:both;}
.Border{border:2px solid #c5cdb6;-webkit-border-radius: 10px;-moz-border-radius: 10px;border-radius: 10px;}
        #Header{width:100%;height:155px;background:url('../Resource/PicSite/Header.jpg') no-repeat;float:left;}
    #Login{width:350px;height:250px;background:url('../Resource/PicSite/Bg-Login.jpg') repeat-x;}
#HeaderLogin{width:100%;height:35px;background:url('../Resource/PicSite/HeaderLogin.png') no-repeat;font:600 11px/30px Tahoma;direction:rtl;}
#ContentLogin{width:97%;height:208px;border:2px solid #c5cdb6;-webkit-border-radius: 0 0 10px 10px ;-moz-border-radius: 0 0 10px 10px;border-radius: 0 0 10px 10px;}
.LoginLabel{width:20%;font:9pt/30px Tahoma;float:right;text-align:right;direction:rtl;margin-right:5px;}
.LoginValue{width:75%;height:30px;float:right;text-align:right;}
.LoginButton{width:100%;height:30px;text-align:center;line-height:30px;
             
             }
             
   .alert{width:90%;min-height:30px;line-height:30px;margin:10px auto;height:auto;clear:both;border:solid 1px #99CCFF;background-color:#dbf1ff;position:relative;-moz-border-radius: 5px;-webkit-border-radius: 5px;border-radius: 5px;}
.alert .img{width:50px;height:30px;float:right}
.alert .img.warning{background:url(../Resource/PicSite/alert_error.png) no-repeat center center}
.alert .img.accept{background:url(../Resource/PicSite/alert_accept.png) no-repeat center center}
.alert .text{color:#7891a3;float:right;font:8pt tahoma;font-weight:700}
.alert .text span{line-height:30px;width:90%;margin:0 10px}
.alert img{width:16px;margin:12px 0 0 0}
.hide{display:none;}          
             
</style>
    <%--<link href="Styles/Site.css" rel="stylesheet" type="text/css" />--%>
<%--    <asp:PlaceHolder runat="server">
    <script src='<%= Page.ResolveUrl("~/Js/jquery-1.7.2.min.js")%>' type="text/javascript"></script>
    <script src='<%= Page.ResolveUrl("~/JS/Util.js")%>' type="text/javascript"></script>
    </asp:PlaceHolder>
--%>
<script src="../JS/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function showMsg(imgClass, text) {

            var isOk = (imgClass != 'warning');
            var color = isOk ? 'green' : 'red';
            if (text == "err") { text = "بروز خطای نا مشخص.لطفا لحظاتی بعد مجددا سعی نمایید!"; }
            $("#imgAlert").addClass(imgClass);
            $(".text span").css('color', color);
            $(".text span").html(text);
            $('html, body').animate({ scrollTop: '100px' }, 500);
            $("#alert").fadeIn(800);
        }
    </script>
</head>
<body>
<div id="alert" class="hide">
        <div class="alert">
            <div class="img" id="imgAlert">
            </div>
            <div class="text">
                <span id="lblAlert"></span>
            </div>
            <div class="clearDiv">
            </div>
        </div>
    </div>
    <form id="form1" runat="server">
    <center style="margin-top:200px;">
   <div id="Login" class="Border">
					<div id="HeaderLogin"><span style="margin-right:25px;">ورود</span></div>
					<div id="ContentLogin">
						<br/>
						<div class="LoginLabel">نام کاربري</div>
						<div class="LoginValue"><asp:TextBox ID="txtUserName" runat="server" Text="" EnableViewState="false" style="width:150px"></asp:TextBox></div>
						<div class="LoginLabel">رمز ورود</div>
						<div class="LoginValue"> <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" Text="" style="width:150px"></asp:TextBox></div>
                        <div class="LoginLabel" style="min-height:60px">کد امنیتی</div>
                        <div class="LoginValue" style="min-height:60px">
<div style="width: 150px;float: right;overflow: hidden;border-color:maroon;border-width: 3px;border-style: solid;">
                        <div id="divcaptcha"><img alt="" class="" id="imgcaptcha" src='<%= Page.ResolveClientUrl("~/CAPTCHA/Captcha.aspx") %>' /></div>
</div>                        
</div>
                        <div class="LoginLabel" style="visibility:hidden">saeed oraji</div>
                        <div class="LoginValue">
						<asp:TextBox ID="txtCaptcha" runat="server"
                        EnableViewState="false" style="width:150px"></asp:TextBox></div>

						<div class="LoginLabel" style="visibility:hidden">saeed oraji</div>
                        <div class="LoginValue">
                        <asp:Button CssClass="btnlogin" ID="btnLogin" runat="server" Text="ورود" OnClick="btnLogin_Click" /></div>
					</div>
                    
				</div>
                </center>
    </form>
</body>
</html>
