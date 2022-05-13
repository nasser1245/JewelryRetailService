<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master"
    AutoEventWireup="true" CodeFile="MemberAccess.aspx.cs" Inherits="Manager_Member_MemberAccess" %>



<asp:Content ID="Content1" ContentPlaceHolderID="HeadsCPH" runat="Server">

<link href='<%= Page.ResolveUrl("~/Manager/Css/css.css")%>' rel="stylesheet" type="text/css" />
<link href="../Css/css.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyCPH" runat="Server">
    <div class="ghaleb">
        <div class="titleLabelGhaleb">
            <div>اختیارات کاربری<span style="color:Red;font-weight:bold; padding-right:10px"><asp:Label ID="lblUserName" runat="server" Text=""></asp:Label></span></div>
        </div>
        <div class="titleLabelGhaleb">
            <div class="titleLabel"><asp:CheckBox ID="chkProductAgent" runat="server" Text="&nbspمسئول محصولات : " /></div>
            <div><asp:Label ID="ProductAgent" runat="server" Text="Label"></asp:Label></div>
        </div>
        <div class="titleLabelGhaleb">
            <div class="titleLabel"><asp:CheckBox ID="chkNewsAgent" runat="server" Text="&nbspمسئول اخبار : " /></div>
            <div><asp:Label ID="NewsAgent" runat="server" Text="Label"></asp:Label></div>
        </div>
        <div class="titleLabelGhaleb">
            <div class="titleLabel"><asp:CheckBox ID="chkSellAgent" runat="server" Text="&nbspمسئول فروش : " /></div>
            <div><asp:Label ID="SellAgent" runat="server" Text="Label"></asp:Label></div>
        </div>
        <div class="titleLabelGhaleb">
            <div class="titleLabel"><asp:CheckBox ID="chkUserAgent" runat="server" Text="&nbspمسئول کاربران و نظرسنجی : " /></div>
            <div><asp:Label ID="UserAgent" runat="server" Text="Label"></asp:Label></div>
        </div>
        <div class="titleLabelGhaleb">
            <div class="titleLabel"><asp:CheckBox ID="chkAdvertiseAgent" runat="server" Text="&nbspمسئول تبلیغات : " /></div>
            <div><asp:Label ID="AdvertiseAgent" runat="server" Text="Label"></asp:Label></div>
        </div>
        <div class="titleLabelGhaleb">
            <div class="titleLabel"><asp:CheckBox ID="chkLibraryAgent" runat="server" Text="&nbspمسئول کتابخانه جامع : " /></div>
            <div><asp:Label ID="LibraryAgent" runat="server" Text="Label"></asp:Label></div>
        </div>
        <div class="titleLabelGhaleb">
            <div class="titleLabel"><asp:CheckBox ID="chkSupportAgent" runat="server" Text="&nbspمسئول پشتیبانی : " /></div>
            <div><asp:Label ID="SupportAgent" runat="server" Text="Label"></asp:Label></div>
        </div>
        <div class="titleLabelGhaleb">
            <div class="titleLabel"><asp:CheckBox ID="chkManagerAgent" runat="server" Text="&nbspمسئول مدیران : " /></div>
            <div><asp:Label ID="ManagerAgent" runat="server" Text="Label"></asp:Label></div>
        </div>
        
        <div class="titleLabelGhaleb">
            <asp:Button CssClass="btn1" ID="btnEditAccess" runat="server" Text="ثبت" OnClick="btnEditAccess_Click" />
        </div>
</div>
</asp:Content>
