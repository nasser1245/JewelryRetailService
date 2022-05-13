<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="Manager_ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadsCPH" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyCPH" Runat="Server">
    <div id="alert" class="hide">
        <div class="alert">
            <div class="img" id="imgAlert"></div>
            <div class="text">
                <div style="width:100px; float:right">تعداد کل: </div>
                <div style="width:100px; float:right" id="lblAlert"><asp:Label ID="lblAllCount" runat="server" Text="Label"></asp:Label></div>
            </div>
        </div>
    </div>
<div style="width:655px; border:1px dotted #666; text-align:center; margin:10px">
    
            <asp:Repeater ID="rptContactUs" runat="server">
                <ItemTemplate>
                <div style="width:640px; margin:5px; float:right; text-align:right; border-radius:5px; border:1px dotted red; background-color:#F8FFAB; border-radius:5px; padding:5px">
                    <div style="width:100%; float:right">
                        <div style="width:30px; padding:5px; float:right; text-align:right; direction:rtl">نام : </div>
                        <div style="width:188px; padding:5px; float:right; text-align:right; direction:rtl"><%# string.IsNullOrEmpty(Eval("Name").ToString()) ? " --- " : Eval("Name")%></div>
                         
                        <div style="width:80px; padding:5px; float:right; text-align:right; direction:rtl">نام خانوادگی : </div>
                        <div style="width:200px; padding:5px; float:right; text-align:right; direction:rtl"><%# string.IsNullOrEmpty(Eval("Family").ToString()) ? " --- " : Eval("Family")%></div>
                    </div>
                    <div style="width:100%; float:right">
                        <div style="width:45px; padding:5px; float:right; text-align:right; direction:rtl">ایمیل : </div>
                        <div style="width:175px; padding:5px; float:right; text-align:right; direction:rtl"><%# string.IsNullOrEmpty(Eval("Email").ToString()) ? " --- " : Eval("Email")%></div>

                        <div style="width:35px; padding:5px; float:right; text-align:right; direction:rtl">تلفن : </div>
                        <div style="width:165px; padding:5px; float:right; text-align:right; direction:rtl"><%# string.IsNullOrEmpty(Eval("Tel").ToString()) ? " --- " : Eval("Tel")%></div>

                        <div style="width:55px; padding:5px; float:right; text-align:right; direction:rtl">تاریخ درج : </div>
                        <div style="width:100px; padding:5px; float:right; text-align:right; direction:rtl"><%# string.IsNullOrEmpty(Eval("InsertDate").ToString()) ? " --- " : HProtest_BLL.Helper.Utility.GetPersianDate((DateTime)Eval("InsertDate"))%></div>

                    </div>
                        <div style="width:59px; padding:5px; float:right; text-align:right; direction:rtl">نوع ارتباط : </div>
                        <div style="width:540px; padding:5px; float:right; text-align:right; direction:rtl"><%# string.IsNullOrEmpty(Eval("ContactUsType").ToString()) ? " --- " : Eval("ContactUsType")%></div>

                        <div style="width:40px; padding:5px; float:right; text-align:right; direction:rtl">عنوان : </div>
                        <div style="width:540px; padding:5px; float:right; text-align:right; direction:rtl"><%# string.IsNullOrEmpty(Eval("Title").ToString()) ? " --- " : Eval("Title")%></div>

                        <div style="width:35px; padding:5px; float:right; text-align:right; direction:rtl">متن : </div>
                        <div style="width:540px; padding:5px; float:right; text-align:justify; direction:rtl"><%# string.IsNullOrEmpty(Eval("Details").ToString()) ? " --- " : Eval("Details")%></div>

                        
                </div>
                </ItemTemplate>
                <AlternatingItemTemplate>
                <div style="width:640px; margin:5px; float:right; text-align:right; border-radius:5px; border:1px dotted red; background-color:#F8FFAB; border-radius:5px; padding:5px">
                    <div style="width:100%; float:right">
                        <div style="width:30px; padding:5px; float:right; text-align:right; direction:rtl">نام : </div>
                        <div style="width:188px; padding:5px; float:right; text-align:right; direction:rtl"><%# string.IsNullOrEmpty(Eval("Name").ToString()) ? " --- " : Eval("Name")%></div>
                         
                        <div style="width:80px; padding:5px; float:right; text-align:right; direction:rtl">نام خانوادگی : </div>
                        <div style="width:200px; padding:5px; float:right; text-align:right; direction:rtl"><%# string.IsNullOrEmpty(Eval("Family").ToString()) ? " --- " : Eval("Family")%></div>
                    </div>
                    <div style="width:100%; float:right">
                        <div style="width:45px; padding:5px; float:right; text-align:right; direction:rtl">ایمیل : </div>
                        <div style="width:175px; padding:5px; float:right; text-align:right; direction:rtl"><%# string.IsNullOrEmpty(Eval("Email").ToString()) ? " --- " : Eval("Email")%></div>

                        <div style="width:35px; padding:5px; float:right; text-align:right; direction:rtl">تلفن : </div>
                        <div style="width:165px; padding:5px; float:right; text-align:right; direction:rtl"><%# string.IsNullOrEmpty(Eval("Tel").ToString()) ? " --- " : Eval("Tel")%></div>

                        <div style="width:55px; padding:5px; float:right; text-align:right; direction:rtl">تاریخ درج : </div>
                        <div style="width:100px; padding:5px; float:right; text-align:right; direction:rtl"><%# string.IsNullOrEmpty(Eval("InsertDate").ToString()) ? " --- " : HProtest_BLL.Helper.Utility.GetPersianDate((DateTime)Eval("InsertDate"))%></div>

                    </div>
                        <div style="width:59px; padding:5px; float:right; text-align:right; direction:rtl">نوع ارتباط : </div>
                        <div style="width:540px; padding:5px; float:right; text-align:right; direction:rtl"><%# string.IsNullOrEmpty(Eval("ContactUsType").ToString()) ? " --- " : Eval("ContactUsType")%></div>

                        <div style="width:40px; padding:5px; float:right; text-align:right; direction:rtl">عنوان : </div>
                        <div style="width:540px; padding:5px; float:right; text-align:right; direction:rtl"><%# string.IsNullOrEmpty(Eval("Title").ToString()) ? " --- " : Eval("Title")%></div>

                        <div style="width:35px; padding:5px; float:right; text-align:right; direction:rtl">متن : </div>
                        <div style="width:540px; padding:5px; float:right; text-align:justify; direction:rtl"><%# string.IsNullOrEmpty(Eval("Details").ToString()) ? " --- " : Eval("Details")%></div>

                        
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

