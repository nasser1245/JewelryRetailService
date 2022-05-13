<%@ Page Title="" Language="C#" MasterPageFile="~/Main_MasterPage.master" AutoEventWireup="true" CodeFile="NewsView.aspx.cs" Inherits="NewsView" %>

<%@ Register src="UC/NewsDetail.ascx" tagname="NewsDetail" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plContentMP" Runat="Server">
    <uc1:NewsDetail ID="NewsDetail1" runat="server" />
</asp:Content>

