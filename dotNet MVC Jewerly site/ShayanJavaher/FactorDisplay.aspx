<%@ Page Title="" Language="C#" MasterPageFile="~/Main_MasterPage.master" AutoEventWireup="true" CodeFile="FactorDisplay.aspx.cs" Inherits="UC_FactorDisplay" %>

<%@ Register src="uc/FactorDisplay.ascx" tagname="FactorDisplay" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plContentMP" Runat="Server">
    
    
    <uc1:FactorDisplay ID="FactorDisplay1" runat="server" />
    
    
</asp:Content>

