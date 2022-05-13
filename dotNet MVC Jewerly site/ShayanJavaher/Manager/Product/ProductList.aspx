<%@ Page Title="لیست محصولات" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master"
    AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="Manager_Product_ProductList" %>

<%@ Register Assembly="JQControls" Namespace="JQControls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadsCPH" runat="Server">

   <%-- <link href="../Css/CssSubAdmin.css" rel="stylesheet" type="text/css" />--%>


    <script type="text/javascript">
        $(function () {

        });


    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyCPH" runat="Server">
    <cc1:JQLoader ID="JQLoader1" runat="server" />
       <div id="alert" class="hide">
        <div class="alert">
            <div class="img" id="imgAlert"></div>
            <div class="text"><span id="lblAlert"></span></div>
            <div class="clear"></div>
        </div>
    </div>

    <div class="AllContent">
        <div class="ProuductAbout">
            <fieldset>
                <legend>&nbsp;&nbsp;جستجو&nbsp;&nbsp;</legend>
                 <div class="clear">
                   
                    </div>
                        <div class="LabelP">نام :</div>
                        <div class="ValueP"><asp:TextBox ID="txtName" runat="server"></asp:TextBox></div>
                    
               <div style="float:right">
                <div style="float:right; width:210px">
                    <div style="float:right; width:60px">سر منو :</div>
                    <div style="float:right; width:120px"><asp:DropDownList Width="130px" 
                            ID="ddlTypeProductParrent" AutoPostBack="true" runat="server" 
                            onselectedindexchanged="ddlTypeProductParrent_SelectedIndexChanged" AppendDataBoundItems="true"></asp:DropDownList></div>
                </div>
                <div style="float:right; width:200px">
                    <div style="float:right; width:70px">نوع محصول :</div>
                    <div style="float:right; width:100px"><asp:DropDownList ID="ddlTypeProduct" runat="server" AppendDataBoundItems="true"></asp:DropDownList></div>
                </div>
            </div>
            <div class="clear"></div>
                        
                        <div class="LabelP">توضیح کوتاه :</div>
                        <div class="ValueP TextArea"><asp:TextBox ID="txtDesp" TextMode="MultiLine" runat="server"></asp:TextBox></div>
                        
                        <div class="LabelP">توضیحات کامل :</div>
                        <div class="ValueP TextArea"><asp:TextBox ID="txtAboutProduct" TextMode="MultiLine" runat="server" placeholder="درباره محصول توضیح دهید(فوایدو...) :"></asp:TextBox></div>


                        <div class="LabelP">تاریخ درج بین :
                    </div>
                        <div class="ValueP">
                        <cc1:JQDatePicker ID="txtFrom" ChangeMonth="true" ChangeYear="true" Culture="fa-IR"
                                runat="server"></cc1:JQDatePicker>
                        و
                          <cc1:JQDatePicker ID="txtTo"  ChangeMonth="true" ChangeYear="true" Culture="fa-IR"
                                runat="server"></cc1:JQDatePicker>                          
                        </div>


                        <div class="LabelP">لوکس :</div>
                        <div class="ValueP">
                            <asp:DropDownList ID="DropDownLuxe" runat="server">
                                <asp:ListItem Value="-1" >فرقی نمی کند</asp:ListItem>
                                <asp:ListItem Value="1">لوکس</asp:ListItem>
                                <asp:ListItem Value="0">غیر لوکس</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="LabelP">سایز :</div>
                        <div class="ValueP">
                            <asp:DropDownList ID="DropDownSize" runat="server">
                                <asp:ListItem Value="-1">فرقی نمی کند</asp:ListItem>
                                <asp:ListItem Value="1">دارد</asp:ListItem>
                                <asp:ListItem Value="0">ندارد</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="LabelP">قیمت :</div>
                        <div class="ValueP">
                            <asp:DropDownList ID="DropDownPrice" runat="server">
                             <asp:ListItem Value="none">فرقی نمی کند</asp:ListItem>
                                <asp:ListItem Value="both">بین</asp:ListItem>
                                <asp:ListItem Value="less">کمتر از</asp:ListItem>
                                <asp:ListItem Value="more">بیش تر از</asp:ListItem>
                            </asp:DropDownList>
                            <span><asp:TextBox ID="txtMin" runat="server"></asp:TextBox></span>
                            <span><asp:TextBox ID="txtMax" runat="server"></asp:TextBox></span>
                        </div>
                        <div class="LabelP">اشانتیون :</div>
                        <div class="ValueP">
                            <asp:DropDownList ID="ddlgift" runat="server">
                             <asp:ListItem Value="none">فرقی نمی کند</asp:ListItem>
                                <asp:ListItem Value="both">بین</asp:ListItem>
                                <asp:ListItem Value="less">کمتر از</asp:ListItem>
                                <asp:ListItem Value="more">بیش تر از</asp:ListItem>
                            </asp:DropDownList>
                            <span><asp:TextBox ID="txtFromPrice" runat="server"></asp:TextBox></span>
                            <span><asp:TextBox ID="TextToPrice" runat="server"></asp:TextBox></span>
                        </div>


                        <div class="LabelP">امتیاز :</div>
                        <div class="ValueP">
                            <asp:DropDownList ID="DropDownPoint" runat="server">
                                <asp:ListItem Value="none">فرقی نمی کند</asp:ListItem>
                                <asp:ListItem Value="both">بین</asp:ListItem>
                                <asp:ListItem Value="less">کمتر از</asp:ListItem>
                                <asp:ListItem Value="more">بیش تر از</asp:ListItem>
                            </asp:DropDownList>

                            <span><asp:TextBox ID="txtminPoint" runat="server"></asp:TextBox></span>
                            <span><asp:TextBox ID="txtmaxPoint" runat="server"></asp:TextBox></span>
                            <asp:Label ID="lblEqul" runat="server" Text="برابر"></asp:Label>
                            <asp:DropDownList ID="DropDownPoints" runat="server">
                                <asp:ListItem Value="0">انتخاب کنید</asp:ListItem>
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>
                                <asp:ListItem Value="3">3</asp:ListItem>
                                <asp:ListItem Value="4">4</asp:ListItem>
                                <asp:ListItem Value="5">5</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="LabelP"> 
                            <asp:ImageButton ImageUrl="~/Resource/PicSite/Search.png" Width="32" Height="32" ID="btnSearchProduct" runat="server" Text="جستجو" OnClick="btnSearchProduct_Click" />
                            
</div>
                        <div class="ValueP">
                        <asp:ImageButton ImageUrl="~/Resource/PicSite/cancel_filters.jpg" Width="32" 
                                Height="32" ID="imgbtnRemoveFilters" runat="server" Text="جستجو" 
                                onclick="imgbtnRemoveFilters_Click" />
                        </div>
                    
                    </fieldset>
                        <div class="clear"></div>

                    </div>
                    
            
            <br />
            <fieldset style="position: relative;">
                <legend>&nbsp;&nbsp;لیست محصولات&nbsp;&nbsp;</legend>
                        <div class="head_title mn_t5">
            <div class="h"><div class="r"></div><div class="l"></div>

                        <span style="width:80px;">عکس</span>
                        <span style="width:110px;">نام محصول</span>
                        <span style="width:70px;">نوع محصول</span>
                        <span style="width:40px;">لوکس</span>
                        <span style="width:40px;">سایز</span>
                        <span style="width:50px;">ویدئو</span>
                        <span style="width:50px;">قیمت</span>
                        <span style="width:80px;">درج کننده</span>
                        <span style="width:80px;">تاریخ درج</span>
                        <span style="width:100px;">عملیات</span>
                        <span style="width:45px;">نمایش</span>

            </div>
        </div>
        <div class="grid">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div class="clear list odd" style="min-height:115px;">
                                <span style="width:80px;">
                                    <img width="70px" height="80px" src="<%# Page.ResolveClientUrl("~/Resource/ProductPic/")+Eval("MainPic") %>" alt="<%# Eval("Name") %>" style="margin-top:2px;"/>
                                    <a href="AddPics.aspx?pid=<%# Eval("ID") %>" style="font:7pt/20px Tahoma;width:70px;height:20px;">عکس های بیشتر</a>
                                </span>
                                <span style="width:110px;"><%# Eval("Name") %></span>
                                <span style="width:70px;"><%# Eval("Type")%></span>
                                <span style="width:40px; padding-top:5px"><input type="checkbox" <%# (bool)Eval("Luxe")==true ?"checked":"" %>  disabled="disabled"/></span>
                                <span style="width:40px; padding-top:5px"><input type="checkbox" <%# (bool)Eval("Size")==true ?"checked":"" %>  disabled="disabled"/></span>
                                <span style="width:50px;"><asp:HyperLink ID="HyperLink1" Visible='<%#Eval("Video").ToString()==""?false:true %>' NavigateUrl='<%# "playVideo.aspx?videoaddr="+Eval("Video")%>' runat="server">مشاهده</asp:HyperLink></span>
                                <span style="width:50px;"><%# Eval("Price") %></span>
                                <span style="width:80px; height:5px;"><%# Eval("creator")%></span>
                                <span style="width:80px;"><%# HProtest_BLL.Helper.Utility.GetPersianDate(Eval("InsertDate")) %></span>
                                <span style="width:100px;">
                                    <div style="float:right;width:100%;"><asp:LinkButton ID="LinkButton1" runat="server" CommandName="edit" CommandArgument='<%# Eval("ID")+","+Eval("mainpic")+","+Eval("video")%>'
                                        OnCommand="lbEditProduct_Command"><img alt="E" width="16" height="16" src="<%= Page.ResolveClientUrl("~/Resource/PicSite/edit-icon.png") %>"/></asp:LinkButton></div>
                                    <div style="float:right;width:100%;"><asp:LinkButton ID="LinkButton2" runat="server" CommandName="delete" CommandArgument='<%# Eval("ID")+","+Eval("mainpic")+","+Eval("video")%>'
                                        OnClientClick='return confirm("از حذف این گزینه اطمینان دارید؟")'
                                        OnCommand="lblDeleteProduct_Command"><img alt="E" width="16" height="16" src="<%= Page.ResolveClientUrl("~/Resource/PicSite/delete-icon.png") %>"/></asp:LinkButton></div>
                                    <div style="float:right;width:100%;display:none;"><a id="hpDisplayComplete"  href='DisplayComplete.aspx?pid=<%# Eval("ID") %>'>مشاهده کامل اطلاعات</a></div>
                                </span>
                                
                                <span style="width:45px;text-align:center;"><input type="checkbox" <%# (bool)Eval("Visible")==true ?"checked":"" %>  disabled="disabled"/></span>
                                 <div class="clear">
                                </div>
                                </div>

                        </ItemTemplate>
                        <AlternatingItemTemplate>
                        <div class="clear list even" style="min-height:115px;">
                                   <span style="width:80px;">
                                    <img width="70px" height="80px" src="<%# Page.ResolveClientUrl("~/Resource/ProductPic/")+Eval("MainPic") %>" alt="<%# Eval("Name") %>" style="margin-top:2px;"/>
                                    <a href="AddPics.aspx?pid=<%# Eval("ID") %>" style="font:7pt/20px Tahoma;width:70px;height:20px;">عکس های بیشتر</a>
                                </span>
                                <span style="width:110px;"><%# Eval("Name") %></span>
                                <span style="width:70px;"><%# Eval("Type")%></span>
                                <span style="width:40px; padding-top:5px"><input type="checkbox" <%# (bool)Eval("Luxe")==true ?"checked":"" %>  disabled="disabled"/></span>
                                <span style="width:40px; padding-top:5px"><input type="checkbox" <%# (bool)Eval("Size")==true ?"checked":"" %>  disabled="disabled"/></span>
                                <span style="width:50px;">
                                    <asp:HyperLink ID="HyperLink1" Visible='<%#Eval("Video").ToString()==""?false:true %>' NavigateUrl='<%# "playVideo.aspx?videoaddr="+Eval("Video")%>' runat="server">مشاهده</asp:HyperLink>
                                </span>
                                <span style="width:50px;"><%# Eval("Price") %></span>
                                <span style="width:80px;height:5px;"><%# Eval("creator")%></span>

                                <span style="width:80px;"><%# HProtest_BLL.Helper.Utility.GetPersianDate(Eval("InsertDate")) %></span>
                                <span style="width:100px;">
                                    <div style="float:right;width:100%;"><asp:LinkButton ID="LinkButton1" runat="server" CommandName="edit" CommandArgument='<%# Eval("ID")+","+Eval("mainpic")+","+Eval("video")%>'
                                        OnCommand="lbEditProduct_Command"><img alt="E" width="16" height="16" src="<%= Page.ResolveClientUrl("~/Resource/PicSite/edit-icon.png") %>"/></asp:LinkButton></div>
                                    <div style="float:right;width:100%;"><asp:LinkButton ID="LinkButton2" runat="server" CommandName="delete" CommandArgument='<%# Eval("ID")+","+Eval("mainpic")+","+Eval("video")%>'
                                        OnClientClick='return confirm("از حذف این گزینه اطمینان دارید؟")'
                                        OnCommand="lblDeleteProduct_Command"><img alt="E" width="16" height="16" src="<%= Page.ResolveClientUrl("~/Resource/PicSite/delete-icon.png") %>"/></asp:LinkButton></div>
                                    <div style="float:right;width:100%;display:none;"><a id="hpDisplayComplete"  href='DisplayComplete.aspx?pid=<%# Eval("ID") %>'>مشاهده کامل اطلاعات</a></div>
                                </span>
                                
                                <span style="width:45px;text-align:center;"><input type="checkbox" <%# (bool)Eval("Visible")==true ?"checked":"" %>  disabled="disabled"/></span>
                                 <div class="clear">
                                </div>
                          </div>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
               
</div>

    
            </fieldset>
            </div>

            <div class="paging">
                    <asp:Repeater ID="rptPaging" runat="server">
                        <ItemTemplate>
                         <%--   <a href='<%# Eval("href") %>' title='صفحه <%# Eval("title") %>'><%# Eval("title") %></a>
--%>                       
                            <asp:LinkButton ID="lbPageing" style="width:10px;" PostBackUrl='<%# Eval("href") %>' runat="server" Text='<%# Eval("title") %>' OnClick="lbPageing_Click"></asp:LinkButton>
                         </ItemTemplate>
                    </asp:Repeater>
                </div>

<%--<asp:Panel ID="p1" DefaultButton="btnTempforPageCount">
                <div style="margin-top:30px;direction:rtl;text-align:right;">
        <asp:ImageButton Visible="false" ID="imgbtnNext" CssClass="left mn_l15" ToolTip="صفحه بعد" AlternateText="" Width="35px" Height="35px" ImageUrl="~/Resource/PicSite/go-next-page.png" runat="server" value="" OnClick="imgbtnNext_Click"/>
        <asp:ImageButton Visible="false" ID="imgbtnLast" CssClass="left mn_l15" ToolTip="آخرین صفحه" AlternateText="" Width="35px" Height="35px" ImageUrl="~/Resource/PicSite/go-last-page.png" runat="server" value="" onclick="imgbtnLast_Click"/>
        <asp:Label ID="lblPagNumber" CssClass="left mn_l15" runat="server"></asp:Label>
            <asp:TextBox ID="txtPageCount"  runat="server" Width="25" ></asp:TextBox><asp:Button
                ID="btnTempforPageCount" Visible="true" runat="server" Text="temp" 
            onclick="btnTempforPageCount_Click" />
        <asp:ImageButton ID="imgbtnFirst" CssClass="left" ToolTip="اولین صفحه" AlternateText="" Width="35px" Height="35px" ImageUrl="~/Resource/PicSite/go-first-page.png" runat="server" value="" onclick="imgbtnFirst_Click"/>
        <asp:ImageButton ID="imgbtnPrev" CssClass="left mn_l15" ToolTip="صفحه قبل" AlternateText="" Width="35px" Height="35px" ImageUrl="~/Resource/PicSite/go-previous-page.png" runat="server" value="" onclick="imgbtnPrev_Click"/>

    </div>
    </asp:Panel>--%>
</asp:Content>
