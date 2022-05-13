<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master" AutoEventWireup="true" CodeFile="NewsList.aspx.cs" Inherits="Manager_News_NewsList" %>

<%@ Register src="../UC/ucNewsList.ascx" tagname="ucNewsList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadsCPH" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyCPH" Runat="Server">
     <div id="alert" class="hide">
        <div class="alert">
            <div class="img" id="imgAlert"></div>
            <div class="text"><span id="lblAlert"></span></div>
    <div class="clear"></div>
        </div>
    <div class="clear"></div>
    </div>
    <uc1:ucNewsList ID="ucNewsList1" runat="server" />
</asp:Content>

