<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master" AutoEventWireup="true" CodeFile="UserList.aspx.cs" Inherits="Manager_Member_UserList" %>

<%@ Register src="../UC/ucUserList.ascx" tagname="ucUserList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadsCPH" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyCPH" Runat="Server">
    <uc1:ucUserList ID="ucUserList1" runat="server" />
</asp:Content>

