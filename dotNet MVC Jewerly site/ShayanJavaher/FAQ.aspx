<%@ Page Title="" Language="C#" MasterPageFile="~/Main_MasterPage.master" AutoEventWireup="true" CodeFile="FAQ.aspx.cs" Inherits="UC_FAQ01" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="CSS/FAQ.css" rel="stylesheet" type="text/css" />
    <script src="JS/show_user_question.js" type="text/javascript"></script>
    <script src="JS/city.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#FAQPage").addClass("MainTopSelectMenu");
        });

</script>
<title>شایان جواهر | پرسش و پاسخ</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plContentMP" Runat="Server">
    <div id="alert" class="hide">
        <div class="alert">
            <div class="img" id="imgAlert"></div>
            <div class="text"><span id="lblAlert"></span></div>
    <div class="clear"></div>

        </div>
    <div class="clear"></div>

    </div>


    <asp:HiddenField ID="hfShowMsg" runat="server" Value="1" />

<center>
    <div class="QandP">
            <div class="QP">
                
                <asp:Repeater ID="rptFAQ" runat="server">
                    <ItemTemplate>
                        
                        <div class="contentFAQ BoxDivShadow">
                            <div class="contentTop BoxDivShadow">
                                <div class="contentTopRight">
                                    <asp:HiddenField ID="hfID" runat="server" Value='<%# Eval("ID") %>' />
                                    <div class="NameFAQ"><%# string.IsNullOrEmpty(Eval("Name").ToString()) ? " --- " : Eval("Name")%></div>
                                    <div class="FromFAQ">از</div>
                                    <div class="ProFAQ"><%# string.IsNullOrEmpty(Eval("Province").ToString()) ? " --- " : Eval("Province")%></div>
                                    <div class="slashFAQ">/</div>
                                    <div class="cityFAQ"><%# string.IsNullOrEmpty(Eval("City").ToString()) ? " --- " : Eval("City")%></div>
                                </div>
                                <div class="contentTopLeft">
                                   <div class="dateFAQ"><%# HProtest_BLL.Helper.Utility.GetPersianDate((DateTime) Eval("InsertDate")) %></div>
                                </div>
                            </div>
                            <div class="askFAQ"><%#Eval("Comment") %></div>
                            <div class="ansFAQ BoxDivShadowIn"><span style="font-style:italic; color:red"> پاسخ : </span><%# string.IsNullOrEmpty(Eval("Answer").ToString()) ? " --- " : Eval("Answer")%></div>
                        </div>

                        <div class="clear"></div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
          
          <div class="clear"></div>
        <div class="paging">
        <div style="width:100%; text-align:center; margin-right:20px">
        <asp:Repeater ID="rptPaging" runat="server">
            <ItemTemplate>
                <div class="Pagingg"><a class="hplinkPaging" href='<%# Eval("href") %>'><%# Eval("title") %></a></div>
            </ItemTemplate>
        </asp:Repeater>
        </div>
        </div>
          <div class="clear"></div>
        
            <hr noshade="noshade" />

            <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSubmit">
            <div id="new_comment" class="BoxDivShadow">
                <div class="HeaderSite gradient" style="height: 30px; line-height: 30px; font-size: 13px;">سؤالات خود را با ما در میان بگذارید:</div>
                <div id="satr">
                    <div id="lblname">نام :</div>
                    <div id="val"><asp:TextBox ID="txtName" Width="175px" runat="server"></asp:TextBox></div>
                    <div id="lblmail">ایمیل :</div>
                    <div id="val"><asp:TextBox ID="txtMail" Width="175px" runat="server"></asp:TextBox></div></div>
                <div id="satr">
                    <div id="lblostan">استان :</div>
                    <div id="val" style="text-align: right;">
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
                    <div style="float: right; width: 40px; margin-right: 10px; text-align: right">شهر :</div>
                    <div style="width: 200px; float: right; text-align: right"><asp:TextBox ID="txtCity" Width="175px" runat="server"></asp:TextBox></div>
                </div>
                <div style="text-align: right; margin-top: 20px; margin-right: 50px;">
                    <asp:TextBox ID="txtQuestion" TextMode="MultiLine" runat="server"></asp:TextBox>
                </div>
                <div class="clear"></div>
                <div>
                    <div id="divcaptcha"><img alt="" class="" id="imgcaptcha" src='<%= Page.ResolveClientUrl("~/CAPTCHA/Captcha.aspx") %>' /></div>
                    <div id="jahat">>></div>
                    <div id="valuecaptcha"><asp:TextBox ID="txtCaptcha" CssClass="txtboxCaptcha" MaxLength="6" EnableViewState="false" runat="server"></asp:TextBox></div>
                    <div id="btn"><asp:Button ID="btnSubmit" CssClass="btn" runat="server" Text="ثبت" OnClick="btnSubmit_Click" /></div>
                </div>
                <div class="clear">
                </div>
            </div>
            </asp:Panel>
    </div>
</center>


</asp:Content>

