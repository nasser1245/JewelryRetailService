<%@ Page Title="" Language="C#" MasterPageFile="~/Main_MasterPage.master" AutoEventWireup="true" CodeFile="ForgetPassWord.aspx.cs" ValidateRequest="false" Inherits="UC_ChangePassWord" %>

<%@ Register src="UC/ForgetPassWord.ascx" tagname="ForgetPassWord" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plContentMP" Runat="Server">
<div id="alert" class="hide">
        <div class="alert">
            <div class="img" id="imgAlert"></div>
            <div class="text"><span id="lblAlert"></span></div>
    <div class="clear"></div>

        </div>
    <div class="clear"></div>

    </div>
    <uc1:ForgetPassWord ID="ForgetPassWord1" runat="server" />

</asp:Content>

