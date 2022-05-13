<%@ Control Language="C#" AutoEventWireup="true" CodeFile="News.ascx.cs" Inherits="HomePage_UC_News" %>
<%@ Register Assembly="JQControls" Namespace="JQControls" TagPrefix="cc1" %>

<cc1:JQLoader ID="JQLoader1" runat="server" />

<div style="width:635px">
        <div id="search" class="BoxDivShadow">
<asp:Panel ID="Panel1" DefaultButton="btnSearch" runat="server">

            <div style="width:100%; float:right; padding:5px">
                <div class="title">عنوان مطلب : </div>
                <div class="txtboxdiv"><asp:TextBox ID="txtTitle" CssClass="txtboxsearchnews" Width="233px" runat="server"></asp:TextBox></div>
                <div class="from">از تاریخ : </div>
                <div class="txtdivfrom"><cc1:JQDatePicker ID="txtFrom" CssClass="txtboxsearchnews" ChangeMonth="true" Width="70px" ChangeYear="true" Culture="fa-IR" runat="server"></cc1:JQDatePicker></div>
                <div class="to">تا : </div>
                <div class="txtdivTo"><cc1:JQDatePicker ID="txtTo" CssClass="txtboxsearchnews" ChangeMonth="true" Width="70px" ChangeYear="true" Culture="fa-IR" runat="server"></cc1:JQDatePicker></div>
                <div class="divbtn"><asp:Button ID="btnSearch" CssClass="btnsearchnews"  runat="server" Text="جستجو" onclick="btnSearch_Click" /></div>
            </div>
            <div  class="clear"></div>
            </asp:Panel>
        </div>

        <asp:Repeater ID="RepeaterNewsList" runat="server">
        <ItemTemplate>
            <div id="news">
                <div style="width:100%; float:right; margin:0px 5px 8px 0px">
                    <div class="title"><a target="_blank" href='NewsView.aspx?pid=<%# Eval("Id") %>' title='<%# Eval("Title") %>'><spam><%# Eval("Title") %></spam></a></div>
                    <div class="VisitCount">نعداد بازدید : <%# Eval("VisitCount")%></div>
                </div>
                <div class="divimg">
                    <a target="_blank" href='NewsView.aspx?pid=<%# Eval("Id") %>' title="<%# Eval("Title") %>">
                        <img alt='<%# Eval("Title") %>' style="height: 80px; width: 100px" title='<%# Eval("Title") %>'
                            src='<%#Page.ResolveClientUrl("~/Resource/News/"+Eval("Picture").ToString())%>' /></a>
                </div>
                <div class="summary">
                    <div class="title">شایان جواهر:
                    </div>
                    <div class="text">
                        <%# Eval("Summary").ToString().Length>240 ? Eval("Summary").ToString().Substring(0,240)+"..." : Eval("Summary") %></div>
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
                <div class="Pagingg"><a class="hplinkPaging" href='<%# Eval("href") %>' title='صفحه <%# Eval("title") %>'><%# Eval("title") %></a></div>
                <%--<asp:LinkButton ID="lbPageing" style="width:10px;" PostBackUrl='<%# Eval("href") %>' runat="server" Text='<%# Eval("title") %>' OnClick="lbPageing_Click"></asp:LinkButton>--%>
            </ItemTemplate>
        </asp:Repeater>
        </div>
    </div>
 <%--   <div style="margin-top:30px">
        <asp:ImageButton Visible="false" ID="imgbtnNext" CssClass="left mn_l15" ToolTip="صفحه بعد" AlternateText="" Width="35px" Height="35px" ImageUrl="~/Resource/PicSite/go-next-page.png" runat="server" value="" OnClick="imgbtnNext_Click"/>
        <asp:ImageButton Visible="false" ID="imgbtnLast" CssClass="left mn_l15" ToolTip="آخرین صفحه" AlternateText="" Width="35px" Height="35px" ImageUrl="~/Resource/PicSite/go-last-page.png" runat="server" value="" onclick="imgbtnLast_Click"/>
        <asp:Label ID="lblPagNumber" CssClass="left mn_l15" runat="server"></asp:Label>
        <asp:ImageButton ID="imgbtnFirst" CssClass="left" ToolTip="اولین صفحه" AlternateText="" Width="35px" Height="35px" ImageUrl="~/Resource/PicSite/go-first-page.png" runat="server" value="" onclick="imgbtnFirst_Click"/>
        <asp:ImageButton ID="imgbtnPrev" CssClass="left mn_l15" ToolTip="صفحه قبل" AlternateText="" Width="35px" Height="35px" ImageUrl="~/Resource/PicSite/go-previous-page.png" runat="server" value="" onclick="imgbtnPrev_Click"/>

    </div>--%>
</div>