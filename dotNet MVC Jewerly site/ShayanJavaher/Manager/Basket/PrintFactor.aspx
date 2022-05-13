<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintFactor.aspx.cs" Inherits="Manager_Basket_PrintFactor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/css.css" rel="stylesheet" type="text/css" />

</head>
<body onload="window.print()">
<center>
    <form id="form1" runat="server">
   <div id="prefactor" style="border: 1px dotted #666;">
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
    </form>
    </center>
</body>
</html>
