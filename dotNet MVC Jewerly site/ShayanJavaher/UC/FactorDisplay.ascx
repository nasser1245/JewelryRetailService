<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FactorDisplay.ascx.cs" Inherits="UC_FactorDisplay" %>
<link href="../CSS/main.css" rel="stylesheet" type="text/css" />
<center>

<div class="prefactor" style="border: 1px dotted #666;">
    <%--------------------------مشخصات---------------------%>
    <div style="width:100%; float:right">
    <div style="text-align: center; width: 80px; margin: -3px 564px 4px 5px; position: absolute;">
    <asp:Button ID="btnPrintFactor" runat="server" Text="چاپ فاکتور" onclick="btnPrintFactor_Click" /></div>
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

    <%--------------------------محصولات---------------------%>
    <div style="width:100%; float:right;">
            <div class="header gb baskethead">
                    <div class="titrprefact" style="width:40px">ردیف</div>
                    <div class="titrprefact" style="width:180px">نام</div>
                    <div class="titrprefact" style="width:80px">کد</div>
                    <div class="titrprefact" style="width:40px">تعداد</div>
                    <div class="titrprefact" style="width:80px">قیمت واحد</div>
                    <div class="titrprefact" style="width:100px">قیمت کل</div>
                    <div class="titrprefact" style="width:40px">تصویر</div>
            </div>
            <div class="clear"></div>
                    <div style="width:640px;margin-top:2px; margin-bottom:2px;" >
                        <asp:Repeater ID="RepeaterBuyBasket" runat="server">
                                <ItemTemplate>
                                <div class="satrContent" style="width:100%;float:right;">
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
                        </asp:Repeater>
                        <div class="clear"></div>
                    </div>

            <div class="footer gp">
                    <div class="titrname" style="padding:5px; float:right">جمع کل : </div>
                    <div class="titrprefact" style="width:180px; float:right"><asp:Label ID="lblNumRow" runat="server" Text=""></asp:Label></div>
                    <div class="titrprefact" style="padding:5px; width:120px; float:right"><asp:Label ID="lblSum" runat="server" Text=""></asp:Label></div>

            <div class="clear"></div>
           
            </div>
    </div>
    <div class="clear"></div>

    <%--------------------------اشانتیون---------------------%>
    <div style="width:100%; float:right">
            <div style="padding:5px; float:right; width:100%">اشانتیون : </div>
            <div style="padding:5px; float:right; width:100%"><asp:Label ID="lblGiftName" runat="server" Text=""></asp:Label></div>
            <asp:HiddenField ID="hfGiftPicture" runat="server" Value="" />
            <div style="float:right; width:100%"><img alt="" title="" width="40px" height="40px" src='<%= hfGiftPicture.Value %>' /></div>
    </div>
    <div class="clear"></div>
</div>
</center>