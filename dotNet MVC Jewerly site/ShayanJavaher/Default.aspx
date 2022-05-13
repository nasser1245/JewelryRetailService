<%@ Page Title="" Language="C#" MasterPageFile="~/Main_MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<script type="text/javascript">
    $(function () {
        $("#defaultpage").addClass("MainTopSelectMenu");
    });

</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plContentMP" Runat="Server">

      <asp:HiddenField ID="hfBasketCount" runat="server" Value="sas"/>


<div style="width:100%; text-align:center">
    <div id="MenuProductType" style="float:right;margin:5px 95px 0px 0px; width:100%; text-align:center">
        <a href="default.aspx?type=newest" class="atagmenutopproduct"><div class="menutopproduct">جدیدترین جواهرات </div></a>
        <span style="float:right">|</span><a href="default.aspx?type=visit" class="atagmenutopproduct"><div class="menutopproduct"> پر بازدیدترین جواهرات </div></a>
        <span style="float:right">|</span><a href="default.aspx?type=price" class="atagmenutopproduct"><div class="menutopproduct"> گران قیمت ترین جواهرات </div></a>
        <span style="float:right">|</span><a href="default.aspx?type=point" class="atagmenutopproduct"><div class="menutopproduct"> پر امتیازترین جواهرات </div></a>
    </div>
    <div class="clear"></div>
<%--------------------------- نمایش محصولات ---------------------%>


<div style="text-align:center;float:right; width:96%" id="">
    
    <h1 class="HeaderSite gradient BoxDivShadow"><asp:Label ID="lblDisplayTitle" runat="server" Text=""></asp:Label></h1>
    <div class="clear"></div>
    <div style="width:100%; float:right; margin-right:13px">
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

                    <div style="">
                        <asp:ImageButton ImageUrl="~/Resource/PicSite/buy.png" runat="server" OnCommand='BuyProduct' CommandArgument='<%# Eval("ID") %>' Height="35" Width="35" title="خرید جواهر " alt="خرید جواهر " border="0" ID="Img2" />
                    </div>
                </div>
            </div>
        </div>
        <div class="clear"></div>
        </div>
    </ItemTemplate>
</asp:DataList>
</div>
</div>
<div class="clear"></div>
<% if(Request["type"]!=null)
       if (Request["type"].ToString() != "newest" && Request["type"].ToString() != "price" && Request["type"].ToString() != "visit" && Request["type"].ToString() != "point")
       {
       %>
            <div class="paging">
            <div style="width:100%; text-align:center; margin-right:16px">
                    <asp:Repeater ID="rptPaging" runat="server">
                        <ItemTemplate>
                            <div class="Pagingg"><a class="hplinkPaging" href='<%# Eval("href") %>'><%# Eval("title") %></a></div>
                       
                            <%--<asp:LinkButton ID="lbPageing" style="width:10px;" PostBackUrl='<%# Eval("href") %>' runat="server" Text='<%# Eval("title") %>' OnClick="lbPageing_Click"></asp:LinkButton>--%>
                         </ItemTemplate>
                    </asp:Repeater>
                    </div>
                </div>
                <%} %>
<%--<br />
<a href="default.aspx?type=newest" title="مشاهده همه جواهرات" class="gttp">برای مشاهده همه جواهرات اینجا کلیک کنید</a>--%>
<div class="clear"></div>

<%---------------------- Advertise down ----------------%>
            
                <div class="OutRightMenuMP " >
                
                    <div class="ContentfooterMenuMP">
                        <asp:Repeater ID="rptAdsBottomCenter" runat="server">
                           <ItemTemplate>
                           <div><%# Eval("Title") %></div>
                           <a href='<%# Eval("Link").ToString()%>' target="_blank">
                                <img id="Img1" runat="server" visible='<%# Eval("IdFileType").ToString()=="1" %>' alt='<%# Eval("Title") %>' width="160" height="150" src='<%# Page.ResolveClientUrl("~/Resource/AdvertisePic/")+Eval("FileAddress") %>' />
                                <embed runat="server" visible='<%# Eval("IdFileType").ToString()=="2" %>' alt='<%# Eval("Title") %>' width="160" height='<%# int.Parse(Eval("AdsHeight").ToString())==-1?200:Eval("AdsHeight") %>' src='<%# Page.ResolveClientUrl("~/Resource/AdvertisePic/")+Eval("FileAddress") %>'></embed>
                           </a>
                           </ItemTemplate>
                        </asp:Repeater>
                    </div>
<div class="clear"></div>

            </div>
<div class="clear"></div>

</div>

      
    
</asp:Content>

