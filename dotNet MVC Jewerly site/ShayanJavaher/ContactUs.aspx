<%@ Page Title="" Language="C#" MasterPageFile="~/Main_MasterPage.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="UC_ContactUs" ValidateRequest="false" %>

<%@ Register src="uc/ContactUs.ascx" tagname="ContactUs" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    $(function () {
        $("#ContactUspage").addClass("MainTopSelectMenu");
    });

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plContentMP" Runat="Server">

    <uc1:ContactUs ID="ContactUs1" runat="server" />
</asp:Content>

