<%@ Page Title="" Language="C#" MasterPageFile="~/Main_MasterPage.master" AutoEventWireup="true"
    CodeFile="BuyBasket.aspx.cs" Inherits="BuyBasket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
    <link href="CSS/main.css" rel="stylesheet" type="text/css" />
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta name="description" content="Creative CSS3 Animation Menus" />
    <meta name="keywords" content="menu, navigation, animation, transition, transform, rotate, css3, web design, component, icon, slide" />
    <meta name="author" content="Codrops" />
    <link href="CSS/basket.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plContentMP" runat="Server">

<asp:Panel ID="Panel1" runat="server" DefaultButton="btnPishFactor">    

    <center>
    <%--------------------------------menu ------------------------------%>

        <div style="padding: 5px; width: 660px; height: auto; text-align: center; direction: rtl;">
            <ul class="ca-menu">
                <li style="background-color:#34b54e;"><a href='<%= Page.ResolveClientUrl("~/BuyBasket.aspx")%>'>
                    <span class="ca-icon">
                    <img width="40px" height="40px" src="Resource/PicSite/basket.png" /></span>
                    <div class="ca-content">
                        <h2 class="ca-main">سبد&nbspخرید</h2>
                        <h3 class="ca-sub">مشاهده&nbspسبد&nbspخرید</h3>
                    </div>
                </a></li>
                <li><a href='<%= Page.ResolveClientUrl("~/BuyList.aspx")%>'>
                    <span class="ca-icon"><img width="40px" height="40px" src="Resource/PicSite/list.png" /></span>
                    <div class="ca-content">
                        <h2 class="ca-main">لیست&nbspخرید&nbspها</h2>
                        <h3 class="ca-sub">مشاهده&nbspخرید&nbspهای&nbspپیشین</h3>
                    </div>
                </a></li>
                <li><a href='<%= Page.ResolveClientUrl("~/UserProfileEdit.aspx") %>'>
                    <span class="ca-icon" id="heart"><img width="40px" height="40px" src="Resource/PicSite/profile.png" /></span>
                    <div class="ca-content">
                        <h2 class="ca-main">پروفایل</h2>
                        <h3 class="ca-sub">تنظیمات&nbspکاربری</h3>
                        </div>
                </a></li>
            </ul>
        </div>

        <!-------------------------- message ---------------->
        <div class="clear"></div>
        <% 
            if (NullBasket)
           { %>
           <div>سبد شما خالی است</div>
        <%}else {%>

    <%--------------------------------hedaer ------------------------------%>
            <div class="header gb">
                <div class="titrname">نام</div>
                <div class="titrcount">تعداد</div>
                <div class="titroneprice">قیمت واحد</div>
                <div class="titrtotalprice">قیمت کل</div>
                <div class="titrpic">تصویر</div>
                <div class="titrdel">حذف</div>
                <div class="clear"></div>
            </div>

     <%--------------------------------products list ------------------------------%>
        <asp:HiddenField ID="hfBasketID" runat="server" />
    <div class="satr">
            <asp:Repeater ID="RepeaterBuyBasket" runat="server" 
                onitemdatabound="RepeaterBuyBasket_ItemDataBound">
                <ItemTemplate>
                <div style="width:650px;margin-top:2px; margin-bottom:2px;" class="satrContent">
                    <span style="margin-top:10px" class="titrname"><%# Eval("Name") %></span>
                    <asp:HiddenField ID="hfID" runat="server" Value='<%# Eval("ID") %>' />
                    <asp:HiddenField ID="hfProductID" runat="server" Value='<%# Eval("ProductID") %>' />
                    <span style="margin-top:10px" class="titrcount">
                    <asp:HiddenField ID="hfRemain" runat="server" Value='<%# Eval("Remain")%>' />
                    <asp:HiddenField ID="hfCount" runat="server" Value='<%# Eval("Count")%>' />
                    <asp:DropDownList runat="server" Width="45px" ID="dd">
                    
                         </asp:DropDownList>
                    </span>
                    <span style="margin-top:10px" class="titroneprice"><%# Eval("UnitPrice") %></span>
                    <span style="margin-top:10px" class="titrtotalprice"><%# Eval("Sum") %></span>
                    <span class="titrpic"><img alt="" title="" width="48" height="48" src='<%# Page.ResolveClientUrl("~/Resource/ProductPic/")+Eval("MainPic").ToString()%>' /></span>
                    <span style="margin-top:15px" class="titrdel">
                        <asp:LinkButton ID="lnkDelete" CommandArgument='<%# Eval("ID") %>' runat="server" OnCommand="DeleteProductFromList_Command"><img id="imgBtnDelete" alt="" src='<%=Page.ResolveClientUrl("~/Resource/PicSite/delete-icon.png")%>' class="mn_l5" width="16" height="16" /></asp:LinkButton></span>
                    <div class="clear"></div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
    </div>

     <%--------------------------------footer ------------------------------%>
    <div class="footer gp">
            <div class="titrname">جمع کل : </div>
            <div class="titrcount"><asp:Label ID="lblGetCountTotal" runat="server" Text="Label"></asp:Label></div>
            <div class="getpriceall"><asp:Label ID="lblGetPiceTotal" runat="server" Text="Label"></asp:Label></div>
            <div style="float:right; width:140px; margin-right:35px"><asp:Button ID="btnUpdate" Width="140px" runat="server" Text="بروز رسانی لیست" onclick="btnUpdate_Click" /></div>
            <div class="clear"></div>
    </div>
    <div class="clear"></div>

     <%--------------------------------display gift ------------------------------%>

     <% if (NullGift == false)
        { %>

     <div style="margin-top:30px" class="header gb">یک محصول را به عنوان اشانتیون انتخاب نمایید</div>
     <div style="width:640px;height:200px;overflow-y:scroll;" class="">
        <asp:DataList ID="RepeaterDisplayGift" runat="server" RepeatDirection="Horizontal" RepeatColumns="11">
                <ItemTemplate>
                <div style="margin:1px 1px 1px 0px;">
                        <asp:HiddenField ID="hfProductID" runat="server" Value='<%# Eval("ID") %>' />
                        <div style="width:50px; height:50px; padding:1px 0px 0px 1px"><asp:LinkButton ID="lnkSelectGift" CommandArgument='<%# Eval("ID") + "," + Eval("Name") %>' runat="server" OnCommand="SelectGift_Command"><img class="imggift" alt='<%# Eval("Name")%>' title='<%# Eval("Name") %>' src='<%# Page.ResolveClientUrl("~/Resource/ProductPic/")+Eval("MainPic").ToString()%>' /></asp:LinkButton></div>
                        <div class="clear"></div>
                </div>
                </ItemTemplate>
            </asp:DataList>
     </div>
     <div class="footer gp">
         
     </div>
     <div class="clear"></div>
     
     <%
            if (!string.IsNullOrEmpty(lblGiftName.Text))
        { %>
     <div style="border:1px dotted #666; padding:10px; font-size:12px; margin:10px; width:400px; background:#C2FF00">
        <asp:Label ID="lblGiftName" runat="server" Text=""></asp:Label>
     </div>
     <%} %>
     <div class="clear"></div>
      <%} %>
      <div style="width:650px; float:right; color:red">اگر توضیحی برای محصول دارید در این قسمت اضافه نمایید : </div>
      <div style="width:650px; float:right"><asp:TextBox ID="txtDescription" width="300px" TextMode="MultiLine" runat="server"></asp:TextBox></div>

     <%--------------------------------buttons ------------------------------%>

    <div style="" class="divbtnbuybasket">
        <div style="width:650px; color:red; font-weight:bolder; float:right">تذکر : برای اتمام خرید باید مشخصات کاربری خود را تکمیل نمایید</div>
        <div style="width:650px; float:right; text-align:center; margin-top:20px">
            <span style="width:95px"><asp:Button ID="btnMoreBuy" Width="90px" runat="server" Text="خرید بیشتر" onclick="btnMoreBuy_Click" /></span>   
            <span style="width:235px"><asp:Button ID="btnPishFactor" Width="125px" runat="server" Text="نمایش پیش فاکتور" onclick="btnPishFactor_Click" /></span>  
            <span style="width:235px"><asp:Button ID="btnPayOnline" Width="150px" runat="server" Text="پرداخت اینترنتی" /></span>  
            <span style="width:235px"><asp:Button ID="btnPayOffline" Width="150px" 
                runat="server" Text="ثبت فیش" onclick="btnPayOffline_Click" /></span>  
        </div>
    </div>
    <%} %>
    </center>
    </asp:Panel>
</asp:Content>
