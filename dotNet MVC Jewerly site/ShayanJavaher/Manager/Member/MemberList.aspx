<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master" AutoEventWireup="true" CodeFile="MemberList.aspx.cs" Inherits="Manager_Member_MemberList" %>

<%@ Register src="../UC/ucMemberList.ascx" tagname="ucMemberList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadsCPH" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyCPH" Runat="Server">
    <uc1:ucMemberList ID="ucMemberList" runat="server" />
</asp:Content>

