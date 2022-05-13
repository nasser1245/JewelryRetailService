<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master" AutoEventWireup="true" CodeFile="BuyStatus.aspx.cs" Inherits="Manager_Basket_BuyStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadsCPH" Runat="Server">
    <link href="../Css/css.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyCPH" Runat="Server">

    <asp:HiddenField ID="hfBasketID" runat="server" />
<%---------------------------------------------------box 1 -----------------------------------------------%>


<div style="width:650px; border:1px dotted green; background-color:#D4FF77; padding:40px 5px 5px 5px; margin:34px 15px 10px 10px; border-radius: 5px;">
    <div style="width:650px; float:right; padding:5px;">
    <div style="width:130px; margin:-66px -19px 5px 5px; font-size:13px; text-align:center; border:1px solid red; height:40px; line-height:40px; border-radius:5px; background-color:Yellow; position:absolute">جستجوی فاکتور</div>
        <div style="width:300px; height:25px; line-height:25px; float:right">
            <div style="width:150px; height:25px; line-height:25px; float:right">جستجو بر اساس فاکتور : </div>
            <div style="width:150px; float:right"><asp:TextBox ID="txtSearch" Height="25px" runat="server"></asp:TextBox></div>
        </div>
        <div style="width:350px; height:25px; line-height:25px; float:right">
            <div style="width:80px; float:right; margin-right:-30px;">
                <asp:Button style="margin:-7px 20px 5px 5px" ID="btnSearch" runat="server" 
                    Text="جستجو" onclick="btnSearch_Click" /></div>
            <div style="width:150px; margin:-5px 20px 5px 5px;  float:right; margin-right:140px;">
                <asp:Button ID="btnReturn" Width="150px" runat="server" Text="بازگشت به لیست سفارشات" onclick="btnReturn_Click" /></div>
            </div>
        <div class="clear"></div>
    </div>
        <div class="clear"></div>
        <%
            if (InvalidFactorID == false)
           { %>
</div>
<div style="width:650px; border:1px dotted green; background-color:#D4FF77; padding:40px 5px 5px 5px; margin:60px 15px 10px 10px; border-radius: 5px;">
    <div style="width:130px; margin:-61px -14px 5px 5px; font-size:13px; text-align:center; border:1px solid red; height:40px; line-height:40px; border-radius:5px; background-color:Yellow; position:absolute">تعیین وضعیت</div>

    <div style="width:620px; float:right; padding:5px;">
        <div style="width:70px; float:right">نام کاربری : </div>
        <div style="width:200px; float:right"><asp:Label ID="lblUserName" runat="server" Text=""></asp:Label></div>
        <div class="clear"></div>
    </div>
    <div style="width:650px; float:right; padding:5px;">
        <div style="width:82px; float:right; line-height:24px">وضعیت فعلی : </div>
        <div style="width:170px; float:right; line-height:24px"><asp:Label ID="lblBasketStatus1" runat="server" Text=""></asp:Label></div>
        <div style="width:120px; float:right; line-height:24px">تغییر حالت به وضعیت : </div>
        <div style="width:120px; float:right; line-height:24px"><asp:DropDownList ID="ddlStatus" Width="150px" Height="25px" runat="server"></asp:DropDownList></div>
        <div style="text-align: left; margin-left: 5px; margin-top: -8px; margin-bottom: 5px; margin-right: 35px; width: 40px; float: right;">
            <asp:Button ID="btnSubmit" runat="server" Width="30px" Text="ثبت" onclick="btnSubmit_Click" />
        </div>

        <div class="clear"></div>
    </div>
    <div class="clear"></div>
</div>
<div style="width:650px; border:1px dotted green; background-color:#D4FF77; padding:40px 5px 5px 5px; margin:60px 15px 10px 10px; border-radius: 5px;">
    <div style="width:130px; margin:-61px -14px 5px 5px; font-size:13px; text-align:center; border:1px solid red; height:40px; line-height:40px; border-radius:5px; background-color:Yellow; position:absolute">اطلاعات پرداخت</div>

        <div style="width:100%; float:right; height:30px; line-height:30px">درگاه : </div>
        <div style="width:100%; float:right; height:30px; line-height:30px">تاریخ پرداخت : </div>
        <div style="width:100%; float:right; height:30px; line-height:30px">شماره فیش : </div>
        <div class="clear"></div>
</div>
<div class="clear"></div>

<%---------------------------------------------------box 3 -----------------------------------------------%>
 
<div id="prefactor" style="border: 1px dotted #666;">
<div style="text-align: center; width: 80px; margin: -23px -10px 4px 5px; position: absolute;">
    <asp:Button ID="btnPrintFactor" runat="server" Text="چاپ فاکتور" onclick="btnPrintFactor_Click" /></div>
    <%--------------------------مشخصات---------------------%>
    <div style="width:100%; float:right">
            <div id="sh_factor">شماره فاکتور : <asp:Label ID="lblFactorID" runat="server" Text=""></asp:Label></div>

            <div id="div_satr">
                <div style="width:320px; float:right">
                    <div id="lbl1">وضعیت سفارش : </div>
                    <div id="val"><asp:Label ID="lblBasketStatus" runat="server" Text=""></asp:Label></div>
                </div>
                <div style="width:320px; float:right">
                    <div id="lbl2">تاریخ ثبت : </div>
                    <div id="val"><asp:Label ID="lblInsertDate" runat="server" Text=""></asp:Label></div>
                </div>
            </div>

            <hr />
            <div class="clear"></div>
            <div id="div_satr">
                <div style="width:320px; float:right">
                    <div id="lbl1">نام و نام خانوادگی : </div>
                    <div id="valname"><asp:Label ID="lblFullName" runat="server" Text=""></asp:Label></div>
                </div>
                <div style="width:320px; float:right">
                    <div id="lblmail">ایمیل : </div>
                    <div id="valmail"><asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></div>
                </div>
            </div>
            <div class="clear"></div>
            <div id="div_satr">
                <div style="width:320px; float:right">
                    <div id="lbltel">شماره تلفن : </div>
                    <div id="valtel"><asp:Label ID="lblTel" runat="server" Text=""></asp:Label></div>
                </div>
                <div style="width:320px; float:right">
                    <div id="lblhamrah">همراه : </div>
                    <div id="valhamrah"><asp:Label ID="lblMobile" runat="server" Text=""></asp:Label></div>
                </div>
            </div>
            <div class="clear"></div>
            <div id="div_satr" style="float:right">
                <div id="lbladrs">آدرس : </div>
                <div id="valadrs"><asp:Label ID="lblAddress" runat="server" Text=""></asp:Label></div>
            </div>

            <div id="div_satr">
                <div id="lbl_code_commn">کد پستی : </div>
                <div id="valcode"><asp:Label ID="lblZipCode" runat="server" Text=""></asp:Label></div>
            </div>

            <div id="div_satr" style="float:right">
                <div id="lbl_code_commn">توضیحات : </div>
                <div id="valcommn"><asp:Label ID="lblDescription" runat="server" Text=""></asp:Label></div>
            </div>
    </div>
    <div class="clear"></div>

            <%--------------محصولات----------%>
    <div style="width:100%; float:right;">
            <div class="headerprefactor gb baskethead">
                    <div class="titrprefact" style="width:40px">ردیف</div>
                    <div class="titrprefact" style="width:180px">نام</div>
                    <div class="titrprefact" style="width:80px">کد</div>
                    <div class="titrprefact" style="width:40px">تعداد</div>
                    <div class="titrprefact" style="width:80px">قیمت واحد</div>
                    <div class="titrprefact" style="width:100px">قیمت کل</div>
                    <div class="titrprefact" style="width:40px">تصویر</div>
            </div>
            <div class="clear"></div>
                    <div style="width:640px;margin-top:0px; margin-bottom:0px;" class="">
                        <asp:Repeater ID="rptProduct" runat="server">
                                <ItemTemplate>
                                    <div class="" style="width:100%;float:right;">
                                        <div class="titrprefact"  style="width:40px;"><%# Eval("Rank")%></div>
                                        <div class="titrprefact" style="width:180px"><%# Eval("Name") %></div>
                                        <asp:HiddenField ID="hfProductID" runat="server" Value='<%# Eval("ProductID") %>' />
                                        <div class="titrprefact" style="width:80px;"><%# Eval("ProductID") %></div>
                                        <div class="titrprefact" style="width:40px;"><%# Eval("Count") %> </div>
                                        <div class="titrprefact" style="width:80px;"><%# Eval("UnitPrice") %></div>
                                        <div class="titrprefact" style="width:100px;"><%# int.Parse(Eval("Count").ToString()) * int.Parse(Eval("UnitPrice").ToString()) %></div>
                                        <div class="titrprefact" style="width:40px;"><img alt="" title="" width="40px" height="40px" src='<%= Page.ResolveUrl("~/Resource/ProductPic/")%><%# Eval("MainPic").ToString()%>' /></div>
                                    </div>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <div class="" style="width:100%;float:right;background-color:Menu">
                                        <div class="titrprefact"  style="width:40px;"><%# Eval("Rank")%></div>
                                        <div class="titrprefact" style="width:180px"><%# Eval("Name") %></div>
                                        <asp:HiddenField ID="hfProductID" runat="server" Value='<%# Eval("ProductID") %>' />
                                        <div class="titrprefact" style="width:80px;"><%# Eval("ProductID") %></div>
                                        <div class="titrprefact" style="width:40px;"><%# Eval("Count") %> </div>
                                        <div class="titrprefact" style="width:80px;"><%# Eval("UnitPrice") %></div>
                                        <div class="titrprefact" style="width:100px;"><%# int.Parse(Eval("Count").ToString()) * int.Parse(Eval("UnitPrice").ToString()) %></div>
                                        <div class="titrprefact" style="width:40px;"><img alt="" title="" width="40px" height="40px" src='<%= Page.ResolveUrl("~/Resource/ProductPic/")%><%# Eval("MainPic").ToString()%>' /></div>
                                    </div>
                                </AlternatingItemTemplate>
                        </asp:Repeater>
                    </div>
            <div class="clear"></div>
            <div class="footerprefactor gp basketfoot">
                    <div class="titrname" style="padding:5px; float:right">جمع کل : </div>
                    <div class="titrprefact" style="width:20px; float:right; margin-right:146px"><asp:Label ID="lblNumRow" runat="server" Text=""></asp:Label></div>
                    <div class="titrprefact" style="width:100px; float:right"><asp:Label ID="lblSum" runat="server" Text=""></asp:Label></div>
                    <div class="titrprefact" style="width:30px; float:right; margin-right:2px">تومان</div>
            </div>
    </div>
    <div class="clear"></div>

            <%---------------اشانتیون------------%>
    <div style="width:100%; float:right">
            <div style="padding:5px; float:right; width:100%">اشانتیون : </div>
            <div style="padding:5px; float:right; width:100%"><asp:Label ID="lblGiftName" runat="server" Text=""></asp:Label></div>
            <asp:HiddenField ID="hfGiftPicture" runat="server" Value="" />
            <div style="float:right; width:100%"><img alt="" title="" width="40px" height="40px" src='<%= hfGiftPicture.Value %>' /></div>
    </div>
    <div class="clear"></div>
</div> 
 <%}
           else if(InvalidFactorID == true && Request.QueryString["FactorID"]!= null)
           { %>
 <div> سفارشی با شماره فاکتور مذکور پیدا نشد</div>
 <%} %>
<%---------------------------------------------------box 4 -----------------------------------------------%>  
   
</asp:Content>

