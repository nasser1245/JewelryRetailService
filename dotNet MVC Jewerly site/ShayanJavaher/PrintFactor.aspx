<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintFactor.aspx.cs" Inherits="Manager_Basket_PrintFactor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
    .srchFactor{width:650px; direction:rtl; text-align:center; direction:rtl;border:#666 1px dotted; border-radius:5px; margin:5px; padding:5px}
.srchFactor .divsatr {padding:5px; direction:rtl; width:100%; float:right}
.srchFactor .lbl {width:105px; direction:rtl; text-align:left; float:right; padding:2px}
.srchFactor .value {padding:2px; direction:rtl; text-align:right; float:right; width:525px}
.srchFactor .value2 {padding:0px; direction:rtl; text-align:right; float:right; width:525px; overflow: hidden; min-height: 25px;}
.srchFactor .txtbox {width: 200px; direction:rtl; height: 25px; border: 1px dotted green; color:#336; border-radius: 5px;}
.srchFactor .lblfceditor {text-align:right;width:80px; direction:rtl; padding:5px}
.srchFactor #btn {padding:5px; direction:rtl; margin-top:25px; margin-right:60px; width:80px; float:right;}
.srchFactor .btn {width:60px; direction:rtl; height:30px}

.headerprefactor{height:30px; direction:rtl; line-height:20px; color:#000; font-weight:bold;  background:#C5C5C5; padding-top: 5px; padding-bottom: 5px;width:650px; vertical-align:middle;}
.footerprefactor{height:30px; direction:rtl; line-height:20px; color:#000; font-weight:bold;  background:#C5C5C5; padding-top: 5px; padding-bottom: 5px;width:650px; vertical-align:middle;}
#prefactor {padding:5px; direction:rtl; margin:40px 10px; border-radius: 5px; width:650px; background-color:White; text-align:center; font-Size:12px}
#prefactor #sh_factor {height:30px; direction:rtl; line-height:30px; background-color:#C5C5C5; text-align:center; font-weight:bold; float:right; width:100%}
#prefactor #div_satr{padding: 8px 5px 8px 5px; direction:rtl; float:right; width:100%}
#prefactor #lbl1{float:right; direction:rtl; width:110px;min-width:110px; max-width:110px; text-align:right}
#prefactor #lbl2{float:right; direction:rtl; width:80px; min-width:80px; max-width:80px; margin-right:40px; text-align:right; text-align:right}
#prefactor #val{width:170px; direction:rtl; float:right; min-width:170px; max-width:170px; text-align:right}
#prefactor #lblmail {float:right; direction:rtl; min-width:50px; max-width:50px; width:50px; margin-right:40px; text-align:right}
#prefactor #valmail {width:220px; direction:rtl; min-width:220px; max-width:220px; float:right; text-align:right}
#prefactor #valname{width:200px; direction:rtl; min-width:200px; max-width:200px; float:right; text-align:right}
#prefactor #lbltel {float:right; direction:rtl; width:80px; min-width:80px; max-width:80px; text-align:right}
#prefactor #valtel {width:130px; direction:rtl; min-width:130px; max-width:130px; float:right; text-align:right}
#prefactor #lblhamrah {float:right; direction:rtl; width:50px; min-width:50px; max-width:50px; margin-right:40px; text-align:right}
#prefactor #valhamrah{width:110px;min-width:110px; direction:rtl; max-width:110px; float:right; text-align:right}
#prefactor #lbladrs{float:right; direction:rtl; width:50px; text-align:right}
#prefactor #valadrs{width:550px; direction:rtl; float:right; text-align:justify}
#prefactor #lbl_code_commn {float:right; direction:rtl; width:70px; text-align:right}
#prefactor #valcode {width:100px; direction:rtl; float:right; text-align:justify}
#prefactor #valcommn {width:550px; direction:rtl; float:right; text-align:justify}
#prefactor .baskethead {float:right; direction:rtl; margin-top:30px; text-align:center; width:100%; vertical-align:middle}
#prefactor .titrprefact{padding:5px; direction:rtl; float:right; }
#prefactor .strfacor{padding:5px; direction:rtl; text-align:center; width:100%; height:30px}
#prefactor 
.basketfoot{float:right; direction:rtl; text-align:center; width:100%;}
    </style>
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
    <div class="clear"></div>

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
    <div class="clear"></div>

    </div>
    <div class="clear"></div>

            <%---------------اشانتیون------------%>
    <div style="width:100%; float:right">
            <div style="padding:5px; float:right; width:100%">اشانتیون : </div>
            <div style="padding:5px; float:right; width:100%"><asp:Label ID="lblGiftName" runat="server" Text=""></asp:Label></div>
            <asp:HiddenField ID="hfGiftPicture" runat="server" Value="" />
            <div style="float:right; width:100%"><img alt="" title="" width="40px" height="40px" src='<%= hfGiftPicture.Value %>' /></div>
    <div class="clear"></div>

    </div>
    <div class="clear"></div>
</div>
    </form>
    </center>
</body>
</html>
