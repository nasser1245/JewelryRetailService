<%@ Page Title="" Language="C#" MasterPageFile="~/Main_MasterPage.master" AutoEventWireup="true" CodeFile="Library.aspx.cs" Inherits="Library" %>
<%@ Register Assembly="JQControls" Namespace="JQControls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script type="text/javascript">
    $(function () {
        $("#libpage").addClass("MainTopSelectMenu");
    });

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plContentMP" Runat="Server">
<cc1:JQLoader ID="JQLoader1" runat="server" />
<div id="Library1">
<asp:Panel ID="Panel1" DefaultButton="btnSearch" runat="server">
        <div class="search BoxDivShadow">
            <div id="content">
                <div class="lbl">عنوان مطلب : </div>
                <div class="val"><asp:TextBox ID="txtTitle" CssClass="txtboxsearchnews" Width="200px" runat="server"></asp:TextBox></div>
                <div class="divbtn"><asp:Button ID="btnSearch" Width="65px" runat="server" Text="جستجو" onclick="btnSearch_Click" /></div>
            </div>
            <div  class="clear"></div>
        </div>
</asp:Panel>
        <asp:Repeater ID="RepeaterLibraryList" runat="server">
        <ItemTemplate>
            <div id="contentt">
                <div class="title">
                    <a target="_blank" href='LibraryView.aspx?pid=<%# Eval("Id") %>' title='<%# Eval("Title") %>'>
                        <spam><%# Eval("Title") %></spam>
                    </a>
                    <div style="text-align:left;font-size:11px">تعداد بازدید :<%#Eval("VisitCount") %></div>
                </div>
                <div class="divimg">
                    <a target="_blank" href='LibraryView.aspx?pid=<%# Eval("Id") %>' title="<%# Eval("Title") %>">
                        <img alt='<%# Eval("Title") %>' style="height: 190px; width: 160px" title='<%# Eval("Title") %>'
                            src='<%#Page.ResolveClientUrl("~/Resource/Library/"+Eval("Id")+Eval("Picture").ToString())%>' /></a>
                </div>
                <div class="summary">
                        <%# Eval("Summary").ToString().Length>240 ? Eval("Summary").ToString().Substring(0,240)+"..." : Eval("Summary") %>
                </div>
                <div class="link">
                        <a href='LibraryView.aspx?pid=<%# Eval("Id") %>'>ادامه مطلب + دانلود</a>
                </div>
                <div class="clear">
                </div>
            </div>
     
        </ItemTemplate>
        </asp:Repeater>
        <div class="clear"></div>
   
    <div class="paging">
    <div style="width:100%; text-align:center; margin-right:16px">
    
        <asp:Repeater ID="rptPaging" runat="server">
            <ItemTemplate>
                <div class="Pagingg"><asp:LinkButton ID="lbPageing" CssClass="hplinkPaging" PostBackUrl='<%# Eval("href") %>' runat="server" Text='<%# Eval("title") %>' OnClick="lbPageing_Click"></asp:LinkButton></div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="clear"></div>
        
    </div>
        <div class="clear"></div>
    </div>

</div>
</asp:Content>

