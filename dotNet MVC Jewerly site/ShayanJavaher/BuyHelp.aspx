<%@ Page Title="" Language="C#" MasterPageFile="~/Main_MasterPage.master" AutoEventWireup="true" CodeFile="BuyHelp.aspx.cs" Inherits="BuyHelp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
$(function () {
    $("#BuyHelppage").addClass("MainTopSelectMenu");
    });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plContentMP" Runat="Server">
<div class="textInfoSite"><%=Server.HtmlDecode(Text)%></div>
</asp:Content>

