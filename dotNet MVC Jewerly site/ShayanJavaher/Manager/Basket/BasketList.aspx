<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master" AutoEventWireup="true" CodeFile="BasketList.aspx.cs" Inherits="Manager_BuyBasket_BasketList" %>
<%@ Register Assembly="JQControls" Namespace="JQControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadsCPH" Runat="Server">
    <link href="../Css/css.css" rel="stylesheet" type="text/css" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="BodyCPH" Runat="Server">
    <cc1:JQLoader ID="JQLoader1" runat="server" />

<%----------------------------search-----------------------%>
<div style="padding:5px">
<div class="srchFactor">
    <div class="divsatr">
        <div class="lbl">وضعیت : </div>
        <div class="value">
            <asp:DropDownList Width="208px" Height="25px" ID="ddlStatus" runat="server">

            </asp:DropDownList>
        </div>
    </div>
    <div class="divsatr">
        <div class="lbl">نام کاربری : </div>
        <div class="value"><asp:TextBox ID="txtUserName" CssClass="txtbox" runat="server"></asp:TextBox></div>
    </div>
    <div class="divsatr">
        <div class="lbl">شماره فاکتور : </div>
        <div class="value"><asp:TextBox CssClass="txtbox" ID="txtFactorID" runat="server"></asp:TextBox></div>
    </div>
    <div class="divsatr">
        <div class="lbl">تاریخ پرداخت : </div>
        <div class="value"><cc1:JQDatePicker ID="txtBeginPayDate" CssClass="txtbox" ChangeMonth="true" ChangeYear="true" Culture="fa-IR" runat="server"></cc1:JQDatePicker> و <cc1:JQDatePicker ID="txtEndPayDate" CssClass="txtbox" ChangeMonth="true" ChangeYear="true" Culture="fa-IR" runat="server"></cc1:JQDatePicker></div>
    </div>
    <div class="divsatr">
        <div class="lbl">تاریخ ارسال : </div>
        <div class="value"><cc1:JQDatePicker ID="txtBeginPostDate" CssClass="txtbox" ChangeMonth="true" ChangeYear="true" Culture="fa-IR" runat="server"></cc1:JQDatePicker> و <cc1:JQDatePicker ID="txtEndPostDate" CssClass="txtbox" ChangeMonth="true" ChangeYear="true" Culture="fa-IR" runat="server"></cc1:JQDatePicker></div>
    </div>
    <div class="divsatr">
        <div class="lbl">اشانتیون : </div>
        <div class="value"><asp:TextBox CssClass="txtbox" ID="txtGift" runat="server"></asp:TextBox></div>
    </div>
    <div class="divsatr">
        <div class="lbl">قیمت :</div>
        <div class="value2">
            <span><asp:TextBox ID="txtMinPrice" runat="server" CssClass="txtbox" Width="150px"  onkeypress="return isNumberKey(event)"></asp:TextBox></span>
            <span><asp:TextBox ID="txtMaxPrice" runat="server" CssClass="txtbox" Width="150px" onkeypress="return isNumberKey(event)"></asp:TextBox></span>
        </div>
    </div>
    
    <div class="clear"></div>
    <div class="divsatr"><asp:Button ID="btnSearch" runat="server" Text="جستجو" 
            onclick="btnSearch_Click" /></div>
    <div class="clear"></div>

</div>
</div>

<div class="clear"></div>
        <% 
            if (NullBasket)
            { %>
           <div>هیج موردی وجود ندارد</div>
        <%}
            else
            {%>
<%----------------------------basket list-----------------------%>
<div style="padding:5px">
    <div class="headerfactor gb">
        <div class="username">نام کاربری</div>
        <div class="titrshomarefactor">شماره فاکتور</div>
        <div class="titrvazeiat">وضعیت</div>
        <div class="titrTotalPrice">قیمت کل</div>
        <div class="titrPayDate">تاریخ پرداخت</div>
        <div class="titrSendDate">تاریخ ارسال</div>
        <div class="titrgift">اشانتیون</div>
        <div class="clear"></div>
    </div>

        <asp:Repeater ID="RepeaterBuyList" runat="server">
            <ItemTemplate>
            <div style="width:750px;margin-top:2px; margin-bottom:2px;" class="satrContent">
                <span class="username"></span>
                <span class="titrvazeiat"><%# Eval("UserName")%></span>
                <span class="titrshomarefactor"><a href='<%= Page.ResolveClientUrl("~/Manager/Basket/BuyStatus.aspx?FactorID=") %><%# Eval("FactorID") %>' title=""> <%# Eval("FactorID") %></a></span>
                <span class="titrvazeiat"><%# Eval("BasketStatus")%></span>
                <span class="titrTotalPrice"><%# string.IsNullOrEmpty(Eval("Sum").ToString()) ? " --- " : Eval("Sum")%></span>
                <span class="titrPayDate"><%# string.IsNullOrEmpty(Eval("PayDate").ToString()) ? " --- " : HProtest_BLL.Helper.Utility.GetPersianDate((DateTime)Eval("PayDate"))%></span>
                <span class="titrSendDate"><%# string.IsNullOrEmpty(Eval("PostDate").ToString()) ? " --- " : HProtest_BLL.Helper.Utility.GetPersianDate((DateTime)Eval("PostDate"))%></span>
                <span class="titrgift"><%# string.IsNullOrEmpty(Eval("GiftName").ToString()) ? " --- " : Eval("GiftName")%></span>
                <div class="clear"></div>
            </div>
            </ItemTemplate>
            
        </asp:Repeater>
                    <div class="paging">
                    <asp:Repeater ID="rptPaging" runat="server">
                        <ItemTemplate>
                         <%--   <a href='<%# Eval("href") %>' title='صفحه <%# Eval("title") %>'><%# Eval("title") %></a>
--%>                       
                            <asp:LinkButton ID="lbPageing" style="width:10px;" PostBackUrl='<%# Eval("href") %>' runat="server" Text='<%# Eval("title") %>' OnClick="lbPageing_Click"></asp:LinkButton>
                         </ItemTemplate>
                    </asp:Repeater>
                </div>

    <div class="footerfactor gp">
        <div style="padding:5px; float:right">تعداد کل: <asp:Label ID="lblGetCountTotal" runat="server" Text="Label"></asp:Label></div>
    </div>
</div>  
<%} %>
</asp:Content>

