<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master" AutoEventWireup="true" CodeFile="FicheList.aspx.cs" Inherits="Manager_BuyBasket_FicheList" %>
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
        <div class="lbl">نوع فیش : </div>
        <div class="value">
            <asp:DropDownList Width="208px" Height="25px" ID="ddlFicheType" runat="server">

            </asp:DropDownList>
        </div>
    </div>
    <div class="divsatr">
        <div class="lbl">شماره فیش : </div>
        <div class="value"><asp:TextBox ID="txtSerial" CssClass="txtbox" runat="server"></asp:TextBox></div>
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
        <div class="lbl">نام پرداخت کننده : </div>
        <div class="value"><asp:TextBox CssClass="txtbox" ID="txtFullName" runat="server"></asp:TextBox></div>
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
        <div class="username">شماره فیش</div>
        <div class="titrshomarefactor">شماره فاکتور</div>
        <div class="titrvazeiat">نام پرداخت کننده</div>
        <div class="titrTotalPrice">به حساب</div>
        <div class="titrPayDate">نوع فیش</div>
        <div class="titrSendDate">تاریخ پرداخت</div>
        <div class="titrgift">توضیحات</div>
        <div class="clear"></div>
    </div>

        <asp:Repeater ID="RepeaterFicheList" runat="server">
            <ItemTemplate>
            <div style="width:750px;margin-top:2px; margin-bottom:2px;" class="satrContent">
                <span class="username"></span>
                <span class="titrvazeiat"><%# Eval("Serial")%></span>
                <span class="titrshomarefactor"><a href='<%= Page.ResolveClientUrl("~/Manager/Basket/BuyStatus.aspx?FactorID=") %><%# Eval("FactorID") %>' title=""> <%# Eval("FactorID") %></a></span>
                <span class="titrTotalPrice"><%# string.IsNullOrEmpty(Eval("FullName").ToString()) ? " --- " : Eval("FullName")%></span>
                <span class="titrvazeiat"><%# string.IsNullOrEmpty(Eval("AccountNo").ToString()) ? " --- " : Eval("AccountNo")%></span>
                <span class="titrPayDate"><%# string.IsNullOrEmpty(Eval("FicheType").ToString()) ? " --- " : Eval("FicheType")%></span>
                <span class="titrSendDate"><%# string.IsNullOrEmpty(Eval("PayDate").ToString()) ? " --- " : HProtest_BLL.Helper.Utility.GetPersianDate((DateTime)Eval("PayDate"))%></span>
                <span class="titrgift"><%# string.IsNullOrEmpty(Eval("Description").ToString()) ? " --- " : Eval("Description")%></span>
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

