<%@ Page Title="" Language="C#" MasterPageFile="~/Main_MasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<%@ Register src="UC/ChangePassword.ascx" tagname="ChangePassword" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plContentMP" Runat="Server">
<div style="float:left; margin-left:15px;"><a href='<%= Page.ResolveClientUrl("~/UserProfileEdit.aspx") %>'>بازگشت</a></div>
<div class="clear"></div>
<div id="alert" class="hide">
        <div class="alert">
            <div class="img" id="imgAlert"></div>
            <div class="text"><span id="lblAlert"></span></div>
    <div class="clear"></div>

        </div>
    <div class="clear"></div>

    </div>
    <uc1:ChangePassword ID="ChangePassword1" runat="server" />
</asp:Content>

