<%@ Page Title="" Language="C#" MasterPageFile="~/Main_MasterPage.master" AutoEventWireup="true"
    CodeFile="BuyList.aspx.cs" Inherits="BuyList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="CSS/main.css" rel="stylesheet" type="text/css" />
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <link href="CSS/basket.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plContentMP" runat="Server">
    <center>
        <div style="padding: 5px; width: 660px; height: auto; text-align: center; direction: rtl;">
            <ul class="ca-menu">
                <li><a href='<%= Page.ResolveClientUrl("~/BuyBasket.aspx")%>'><span
                    class="ca-icon">
                    <img width="40px" height="40px" src="Resource/PicSite/basket.png" /></span>
                    <div class="ca-content">
                        <h2 class="ca-main">
                            سبد&nbspخرید</h2>
                        <h3 class="ca-sub">
                            مشاهده&nbspسبد&nbspخرید</h3>
                    </div>
                </a></li>
                <li style="background-color:#34b54e;"><a href='<%= Page.ResolveClientUrl("~/BuyList.aspx")%>'><span
                    class="ca-icon">
                    <img width="40px" height="40px" src="Resource/PicSite/list.png" /></span>
                    <div class="ca-content">
                        <h2 class="ca-main">
                            لیست&nbspخرید&nbspها</h2>
                        <h3 class="ca-sub">
                            مشاهده&nbspخرید&nbspهای&nbspپیشین</h3>
                    </div>
                </a></li>
                <li><a href='<%= Page.ResolveClientUrl("~/UserProfileEdit.aspx") %>'>
                    <span class="ca-icon" id="heart">
                        <img width="40px" height="40px" src="Resource/PicSite/profile.png" /></span>
                    <div class="ca-content">
                        <h2 class="ca-main">
                            پروفایل</h2>
                        <h3 class="ca-sub">
                            تنظیمات&nbspکاربری</h3>
                    </div>
                </a></li>
            </ul>
        </div>
        <!-- content -->
        <div class="clear"></div>
                <% 
                    if (NullList)
                    { %>
           <div>هیچ لیست خریدی وجود ندارد</div>
        <%}
                    else
                    {%>
<div style="padding:5px">

    <div class="header gb">
        <div class="titrshomarefactor">شماره فاکتور</div>
        <div class="titrtarikhpardakht">تاریخ پرداخت</div>
        <div class="titrgift">اشانتیون</div>
        <div class="titrmablaghpardakhti">قیمت کل</div>
        <div class="titrvazeiat">وضعیت</div>
        <div class="titrtarikhersal">تاریخ ارسال</div>
        <div class="clear"></div>
        
    </div>

<div class="satr">
        <asp:Repeater ID="RepeaterBuyList" runat="server">
            <ItemTemplate>
            <div style="width:650px;margin-top:2px; margin-bottom:2px;" class="satrContent">
                <span class="titrshomarefactor"><a href='<%= Page.ResolveClientUrl("~/FactorDisplay.aspx?BasketID=") %><%# Eval("BasketID") %>' title=""> <%# Eval("FactorNumber") %></a></span>
                <span class="titrtarikhpardakht"><%# string.IsNullOrEmpty(Eval("PayDate").ToString()) ? " --- " :  Eval("PayDate")%></span>
                <span class="titrgift"><%# string.IsNullOrEmpty(Eval("GiftName").ToString()) ? " --- " : Eval("GiftName")%></span>
                <span class="titrmablaghpardakhti"><%# string.IsNullOrEmpty(Eval("Sum").ToString()) ? " --- " : Eval("Sum")%></span>
                <span class="titrvazeiat"><%# Eval("BasketStatus")%></span>
                <span class="titrtarikhersal"><%# string.IsNullOrEmpty(Eval("PostDate").ToString()) ? " --- " : Eval("PostDate")%></span>
                <div class="clear"></div>
            </div>
            </ItemTemplate>
            
        </asp:Repeater>
</div>

    <div class="footer gp">
        <div style="padding:5px; float:right">تعداد خرید : <asp:Label ID="lblGetCountTotal" runat="server" Text="Label"></asp:Label></div>
        <div style="padding:5px;">پرداختی ها : <asp:Label ID="lblGetPiceTotal" runat="server" Text="Label"></asp:Label></div>
    </div>

</div>  
<%} %>
    </center>
</asp:Content>
