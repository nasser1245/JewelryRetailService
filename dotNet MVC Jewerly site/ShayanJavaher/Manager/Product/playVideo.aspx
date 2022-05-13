<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master" AutoEventWireup="true" CodeFile="playVideo.aspx.cs" Inherits="Manager_Product_playVideo" %>


<%@ Register assembly="ASPNetFlashVideo.NET3" namespace="ASPNetFlashVideo" tagprefix="ASPNetFlashVideo" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadsCPH" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyCPH" Runat="Server">
    <%--<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>
    <center>
    <ASPNetFlashVideo:FlashVideo ID="VideoPlayer" runat="server">
    </ASPNetFlashVideo:FlashVideo>
    </center>
</asp:Content>

