<%@ Page Title="" Language="C#" MasterPageFile="~/Main_MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>
<%@ Register Assembly="JQControls" Namespace="JQControls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript">
        $(function () {
            $("#searchpage").addClass("MainTopSelectMenu");
        });

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plContentMP" Runat="Server">
    <cc1:JQLoader ID="JQLoader1" runat="server" />

                <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSearchProduct">  
<div class="ProuductAbout" style="text-align:right;">
            <div id="searchCM" class="BoxDivShadow">
                 <div class="clear"></div>
                 <div class="divsatrS">
                        <div class="lblS">نام :</div>
                        <div class="valueS"><asp:TextBox ID="txtName" CssClass="txtbox" runat="server"></asp:TextBox></div>
                  </div>
                  <div class="divsatrS">  
                        <div class="lblS">نوع محصول :</div>
                        <div class="valueS"><asp:DropDownList ID="DropDownTypeProduct" CssClass="ddlS" runat="server" AppendDataBoundItems="true" ></asp:DropDownList></div>
                  </div>
                  <div class="divsatrS">
                        <div class="lblS">توضیح کوتاه :</div>
                        <div class="valueS"><asp:TextBox ID="txtDesp" CssClass="TextAreaS" TextMode="MultiLine" runat="server"></asp:TextBox></div>
                  </div>   
                  <div class="divsatrS">
                        <div class="lblS">توضیحات کامل :</div>
                        <div class="valueS"><asp:TextBox ID="txtAboutProduct" CssClass="TextAreaS" TextMode="MultiLine" runat="server" placeholder="درباره محصول توضیح دهید(فوایدو...) :"></asp:TextBox></div>
                  </div>
                  <div class="divsatrS">
                        <div class="lblS">تاریخ درج بین :</div>
                        <div class="valueS">
                            <div style="float:right"><cc1:JQDatePicker ID="txtFrom" CssClass="txtbox" ChangeMonth="true" ChangeYear="true" Culture="fa-IR" runat="server"></cc1:JQDatePicker></div>
                            <div style="width:15px; float:right; text-align:center; height:25px; line-height:25px">و</div>
                            <div style="float:right"><cc1:JQDatePicker ID="txtTo" CssClass="txtbox"  ChangeMonth="true" ChangeYear="true" Culture="fa-IR" runat="server"></cc1:JQDatePicker></div>
                        </div>
                   </div>

                  <div class="divsatrS">
                        <div class="lblS">لوکس :</div>
                        <div class="valueS">
                            <asp:DropDownList CssClass="ddlS" ID="DropDownLuxe" runat="server">
                                <asp:ListItem Value="-1" >فرقی نمی کند</asp:ListItem>
                                <asp:ListItem Value="1">لوکس</asp:ListItem>
                                <asp:ListItem Value="0">غیر لوکس</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                   </div>

                  <div class="divsatrS">
                        <div class="lblS">سایز :</div>
                        <div class="valueS">
                            <asp:DropDownList CssClass="ddlS" ID="DropDownSize" runat="server">
                                <asp:ListItem Value="-1">فرقی نمی کند</asp:ListItem>
                                <asp:ListItem Value="1">دارد</asp:ListItem>
                                <asp:ListItem Value="0">ندارد</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                   </div>

                  <div class="divsatrS">
                        <div class="lblS">قیمت :</div>
                        <div class="valueS">
                            <div style="float:right; width:195px"><asp:DropDownList CssClass="ddlS" ID="DropDownPrice" runat="server">
                                <asp:ListItem Value="none">فرقی نمی کند</asp:ListItem>
                                <asp:ListItem Value="both">بین</asp:ListItem>
                                <asp:ListItem Value="less">کمتر از</asp:ListItem>
                                <asp:ListItem Value="more">بیش تر از</asp:ListItem>
                            </asp:DropDownList>
                            </div>
                            <div style="float:right; width:160px"><asp:TextBox ID="txtMin" CssClass="txtbox" Width="150px" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox></div>
                            <div style="float:right; width:160px"><asp:TextBox ID="txtMax" CssClass="txtbox" Width="150px" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox></div>
                        </div>
                   </div>

                  <div class="divsatrS">
                        <div class="lblS">امتیاز :</div>
                        <div class="valueS">
                            <div style="float:right; width:195px"><asp:DropDownList CssClass="ddlS" ID="DropDownPoint" runat="server">
                                <asp:ListItem Value="none">فرقی نمی کند</asp:ListItem>
                                <asp:ListItem Value="both">بین</asp:ListItem>
                                <asp:ListItem Value="less">کمتر از</asp:ListItem>
                                <asp:ListItem Value="more">بیش تر از</asp:ListItem>
                            </asp:DropDownList>
                            </div>
                            <div style="float:right; width:80px"><asp:TextBox CssClass="txtbox" Width="70px" ID="txtminPoint" runat="server"></asp:TextBox></div>
                            <div style="float:right; width:80px"><asp:TextBox CssClass="txtbox" Width="70px" ID="txtmaxPoint" runat="server"></asp:TextBox></div>
                            <div style="float:right; width:195px"><asp:DropDownList CssClass="ddlS" Width="157px" ID="DropDownPoints" runat="server">
                                <asp:ListItem Value="0">یا برابر</asp:ListItem>
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>
                                <asp:ListItem Value="3">3</asp:ListItem>
                                <asp:ListItem Value="4">4</asp:ListItem>
                                <asp:ListItem Value="5">5</asp:ListItem>
                            </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                  <div class="divsatrS">
                        <div class="lblS">مرتب بر اساس :</div>
                        <div class="valueS">
                            <asp:RadioButton GroupName="r" ID="rdbCode" runat="server" Text="کد جواهر" Checked="true"/>
                            <asp:RadioButton GroupName="r" ID="rdbDate" runat="server" Text="تاریخ"/>
                            <asp:RadioButton GroupName="r" ID="rdbPoint" runat="server" Text="امتیاز"/>
                            <asp:RadioButton GroupName="r" ID="rdbPrice" runat="server" Text="قیمت"/>
                        </div>
                   </div>

                  <div class="divsatrS">
                        <div class="lblS">مرتب به صورت :</div>
                        <div class="valueS">
                            <asp:RadioButton ID="rdbdesc" GroupName="t" runat="server" Text="نزولی" Checked="true"/>
                            <asp:RadioButton ID="rdbasc" GroupName="t" runat="server" Text="صعودی"/>
                        </div>
                   </div>

                  <div class="divsatrS">
                        <div class="lblS">اندازه صفحات :</div>
                        <div class="valueS">
                            <asp:TextBox ID="txtPageSize" CssClass="txtbox" runat="server" Width="50" onkeypress="return isNumberKey(event)" MaxLength="2"></asp:TextBox>
                        </div>
                   </div>


                        <div class="clear"></div>
                        <div style="text-align:center; width:100%; float:right">
<%--                        <span style=" width:100px" class=""><asp:ImageButton ImageUrl="~/Resource/PicSite/Search.png" Width="32" Height="32" ID="btnSearchProduct" runat="server" Text="جستجو" OnClick="btnSearchProduct_Click"  /></span>
                            <span style="width:100px" class=""><asp:ImageButton ImageUrl="~/Resource/PicSite/cancel_filters.jpg" Width="32"  Height="32" ID="imgbtnRemoveFilters" runat="server" Text="حذف فیلتر" onclick="imgbtnRemoveFilters_Click" /></span>
--%>                        <span style=" width:100px" class=""><asp:Button ID="btnSearchProduct" runat="server" Text="جستجو" onclick="btnSearchProduct_Click"/></span>
                            <span style="width:100px" class=""><asp:Button ID="btnRemoveFilters" runat="server" Text="حذف فیلتر" onclick="btnRemoveFilters_Click" /></span>

                        </div>
                        <div class="clear"></div>
                    
                    </div>
                        <div class="clear"></div>

<div style="text-align:center;float:right; margin:5px 15px 5px 5px" id="main_box">
    <div style="font-size:14px;  width:634px; padding:7px; margin:5px 5px 5px 5px;" class="HeaderSite gradient BoxDivShadow"><asp:Label ID="lblDisplayTitle" runat="server" Text=""></asp:Label></div>
    <asp:DataList ID="DataListGetType" runat="server" RepeatDirection="Horizontal" RepeatColumns="3">
        <ItemTemplate>
            <div class="probox">
                <div class='<%# Convert.ToBoolean(Eval("Luxe").ToString())==true?"deluxe": "displaynull" %>' ></div>
                <div class="top">
                    <a href="ViewSelectedPoduct.aspx?pid=<%# Eval("ID") %>"><img class="dimg BorderMP"  src="<%# Page.ResolveClientUrl("~/Resource/ProductPic/")+Eval("MainPic") %>" alt="<%# Eval("Name") %>" /></a>
                </div>
                <div class="down">
                    <div>
                        <a href="ViewSelectedPoduct.aspx?pid=<%# Eval("ID") %>"><div class="name"><%# Eval("Name") %></div></a>
                        <div class="introtext"><%# Server.HtmlDecode(Eval("Desp").ToString()).Length > 90 ? Server.HtmlDecode(Eval("Desp").ToString()).Substring(0, 80)+"..." : Server.HtmlDecode(Eval("Desp").ToString())%></div>
                        <div class="codeprice">کد جواهر : <span><%# Eval("ID") %></span></div>
                        <div class="codeprice"> قیمت : <%# Eval("Price") %> تومان</div>
                        <div>
                            <asp:ImageButton ImageUrl="~/Resource/PicSite/buy.png" runat="server" OnCommand='BuyProduct' CommandArgument='<%# Eval("ID") %>' Height="35" Width="35" title="خرید جواهر " alt="خرید جواهر " border="0" ID="Img2" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="clear"></div>
        </ItemTemplate>
    </asp:DataList>
</div>
            <div class="clear"></div>

            <div class="paging">
            <div style="width:100%; text-align:center; margin-right:16px">

                    <asp:Repeater ID="rptPaging" runat="server">
                        <ItemTemplate>
                            <div class="Pagingg"><asp:LinkButton class="hplinkPaging" ID="lbPageing"  PostBackUrl='<%# Eval("href") %>' runat="server" Text='<%# Eval("title") %>' OnClick="lbPageing_Click"></asp:LinkButton></div>
                         </ItemTemplate>
                    </asp:Repeater>
                </div>
                </div>

                    </div>
</asp:Panel>
</asp:Content>

