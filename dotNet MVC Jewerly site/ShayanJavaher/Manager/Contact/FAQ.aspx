<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master" AutoEventWireup="true" CodeFile="FAQ.aspx.cs" Inherits="Manager_FAQ"%>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadsCPH" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyCPH" Runat="Server">
    <div id="alert" class="hide">
        <div class="alert">
            <div class="img" id="imgAlert"></div>
            <div class="text"><span id="lblAlert"></span></div>
        </div>
    </div>
    <div style="width:650px; text-align:center; margin:10px">
    
            <asp:Repeater ID="rptFAQ" runat="server" onitemcommand="rptFAQ_ItemCommand">
                <ItemTemplate>
                <div style="width:100%; margin:5px; float:right; text-align:right; border-radius:5px; border:1px dotted red; background-color:#DFFFAE">
                    <div style="width:60px;  float:right; height:30px; line-height:30px; text-align: center;">سوال : </div>
                    <div style="width:560px; float:right; text-align:justify; min-height:30px; padding:7px"><%#Eval("Comment") %></div>
                     <div style="width:60px; float:right; height:30px; line-height:30px; text-align: center;">پاسخ : </div>
                    <div style="width:574px; float:right; text-align:justify;"><asp:TextBox TextMode="MultiLine" ID="txtAnswer" Text='<%# Eval("Answer") %>' runat="server"></asp:TextBox></div>
                    <div style="width:560px; float:right; height:30px; padding-right:5px; line-height:30px; text-align: right;"><asp:CheckBox ID="chkVisible" Text=" به کاربران نمایش داده شود" runat="server" Checked='<%# Eval("Visible") %>' /></div>
                    <div class="clear"></div>
                    <div style="width:100%; float:right">
                        <div style="width:180px; float:right; height:30px; padding-right:5px; line-height:30px; text-align: right;">تاریخ درج: <%# HProtest_BLL.Helper.Utility.GetPersianDate((DateTime) Eval("InsertDate")) %></div>
                        <div style="width:180px; float:right; height:30px; padding-right:5px; line-height:30px; text-align: right;">نام: <%# Eval("Name") %></div><asp:HiddenField ID="hfID" runat="server" Value='<%# Eval("ID") %>' />
                        <div style="width:180px; float:right; height:30px; padding-right:5px; line-height:30px; text-align: right;">ایمیل: <%# Eval("Email") %></div>
                        <div class="clear"></div>
                    </div>
                    <div style="width:100%; float:right">
                        <div style="width:180px; float:right; height:30px; padding-right:5px; line-height:30px; text-align: right;">استان: <%# Eval("Province") %></div>
                        <div style="width:180px; float:right; height:30px; padding-right:5px; line-height:30px; text-align: right;">شهر: <%# Eval("City") %></div>
                        <div style="width:180px; float:right; height:40px; padding-right:5px; line-height:40px; text-align:center; margin: -223px 512px 5px 5px; position: absolute;"><asp:Button id="btnSubmit" runat="server" Text="ثبت"   /></div>
                        <div class="clear"></div>
                    </div>
                    <div class="clear"></div>
                </div>
                </ItemTemplate>
                <AlternatingItemTemplate>
                <div style="width:100%; margin:5px; float:right; text-align:right; border-radius:5px; border:1px dotted red; background-color:#F8FFAB">
                    <div style="width:60px;  float:right; height:30px; line-height:30px; text-align: center;">سوال : </div>
                    <div style="width:560px; float:right; text-align:justify; min-height:30px; padding:7px"><%#Eval("Comment") %></div>
                     <div style="width:60px; float:right; height:30px; line-height:30px; text-align: center;">پاسخ : </div>
                    <div style="width:574px; float:right; text-align:justify;"><asp:TextBox TextMode="MultiLine" ID="txtAnswer" Text='<%# Eval("Answer") %>' runat="server"></asp:TextBox></div>
                    <div style="width:560px; float:right; height:30px; padding-right:5px; line-height:30px; text-align: right;"><asp:CheckBox ID="chkVisible" Text=" به کاربران نمایش داده شود" runat="server" Checked='<%# Eval("Visible") %>' /></div>
                    <div class="clear"></div>
                    <div style="width:100%; float:right">
                        <div style="width:180px; float:right; height:30px; padding-right:5px; line-height:30px; text-align: right;">تاریخ درج: <%# HProtest_BLL.Helper.Utility.GetPersianDate((DateTime) Eval("InsertDate")) %></div>
                        <div style="width:180px; float:right; height:30px; padding-right:5px; line-height:30px; text-align: right;">نام: <%# Eval("Name") %></div><asp:HiddenField ID="hfID" runat="server" Value='<%# Eval("ID") %>' />
                        <div style="width:180px; float:right; height:30px; padding-right:5px; line-height:30px; text-align: right;">ایمیل: <%# Eval("Email") %></div>
                        <div class="clear"></div>
                    </div>
                    <div style="width:100%; float:right">
                        <div style="width:180px; float:right; height:30px; padding-right:5px; line-height:30px; text-align: right;">استان: <%# Eval("Province") %></div>
                        <div style="width:180px; float:right; height:30px; padding-right:5px; line-height:30px; text-align: right;">شهر: <%# Eval("City") %></div>
                        <div style="width:180px; float:right; height:40px; padding-right:5px; line-height:40px; text-align:center; margin: -223px 512px 5px 5px; position: absolute;"><asp:Button id="btnSubmit" runat="server" Text="ثبت"   /></div>
                        <div class="clear"></div>
                    </div>
                    <div class="clear"></div>
                </div>
                </AlternatingItemTemplate>
            </asp:Repeater>

    <div class="clear"></div>
        <div class="paging" style=" float:right; text-align:center; width:100%">
        <asp:Repeater ID="rptPaging" runat="server">
            <ItemTemplate>
                <a href='<%# Eval("href") %>' title='صفحه <%# Eval("title") %>'>
                    <%# Eval("title") %></a>
                <%--<asp:LinkButton ID="lbPageing" style="width:10px;" PostBackUrl='<%# Eval("href") %>' runat="server" Text='<%# Eval("title") %>' OnClick="lbPageing_Click"></asp:LinkButton>--%>
            </ItemTemplate>
        </asp:Repeater>
        </div>
</div>
    
</asp:Content>

