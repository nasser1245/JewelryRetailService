<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master" AutoEventWireup="true" CodeFile="MemberContent.aspx.cs" Inherits="Manager_Member_MemberContent" ValidateRequest="false" %>

<%@ Register src="../UC/ucMemberContent.ascx" tagname="ucMemberContent" tagprefix="uc1" %>

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
    <uc1:ucMemberContent ID="ucMemberContent" runat="server" />
</asp:Content>

