<%@ Page Title="" Language="C#" MasterPageFile="~/Main_MasterPage.master" AutoEventWireup="true" CodeFile="LibraryView.aspx.cs" Inherits="LibraryView" %>

<%@ Register src="UC/LibraryDetail.ascx" tagname="LibraryDetail" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="CSS/dl.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $("#libpage").addClass("MainTopSelectMenu");
        });

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plContentMP" Runat="Server">
    <uc1:LibraryDetail ID="LibraryDetail1" runat="server" />
</asp:Content>

