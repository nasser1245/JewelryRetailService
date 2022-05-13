<%@ Page Title="" Language="C#" MasterPageFile="~/Main_MasterPage.master" AutoEventWireup="true" CodeFile="ViewSelectedPoduct.aspx.cs" Inherits="ViewSelectedPoduct" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>
    <%= Product.Name.ToString()%></title>
    <link href="CSS/Slider.css" rel="stylesheet" type="text/css" />
    <link href="CSS/Rating.css" rel="stylesheet" type="text/css" />

    <script src="JS/script.js" type="text/javascript"></script>

            <script type="text/javascript">
                $(document).ready(function () {
                    $("#defaultpage").addClass("MainTopSelectMenu");

                    var buttons = { previous: $('#lofslidecontent45 .lof-previous'),
                        next: $('#lofslidecontent45 .lof-next')
                    };

                    $obj = $('#lofslidecontent45').lofJSidernews({ interval: 4000,
                        direction: 'opacitys',
                        easing: 'easeInOutExpo',
                        duration: 1200,
                        auto: true,
                        maxItemDisplay: 4,
                        navPosition: 'horizontal', // horizontal
                        navigatorHeight: 32,
                        navigatorWidth: 80,
                        mainWidth: 385,
                        buttons: buttons
                    });
                });
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plContentMP" Runat="Server">

<center>

        <div class="main_box">
            <asp:HiddenField ID="hfID" runat="server" />
            <div class="similaryh1 gradient BoxDivShadow"><%=Product.Name.ToString()%></div>

            <!----------------------1-&-2--------------------------->


            <div class="rows1_2">

                <!----------------------(1)--desp code price buy---------------------------->

                <div class="box_desp_CPB">
                
                    <div class="desp"><%=Product.Desp.ToString().Length > 215 ? Server.HtmlDecode(Product.Desp.ToString().Substring(0, 205)) + "..." : Server.HtmlDecode(Product.Desp.ToString())%></div>
                     
                    <div class="code"><span> کد جواهر : </span><%=Product.ID.ToString()%></div>
                    <div class="price">
                        <div class="row">
                            <span> قیمت :</span>
                            <span style="color:Red; font-weight:bold; margin-right:2px"><%=Product.Price.ToString()%></span>
                            <span style="margin-right:2px">تومان</span>
                        </div>
                    </div>
                    <div class="buy">
                        <asp:ImageButton ImageUrl="~/Resource/PicSite/buy.png" runat="server" OnCommand='BuyProduct' CommandArgument='<%# Eval("ID") %>' Height="35" Width="35" title="خرید جواهر " alt="خرید جواهر " border="0" ID="ImageButton1" />
                    </div>
                    <div class="clear"></div>

                    <asp:ScriptManager ID="ScriptManager1" runat="server" />
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" ChildrenAsTriggers="True">
                            <ContentTemplate>
                                <div style="width:180px; height:50px; margin: 32px 32px;">
                                    <cc1:Rating runat="server" ID="Rating"
                                    MaxRating="5"
                                    CssClass="ratingStar"
                                    StarCssClass="ratingItem"
                                    WaitingStarCssClass="Saved"
                                    FilledStarCssClass="Filled"
                                    EmptyStarCssClass="Empty" AutoPostBack="True" OnChanged="Rating_Changed" >
                                    </cc1:Rating>
                                    <div style="width:180px; text-align: center;"><asp:Label ID="lblRateValue" runat="server" Text=""></asp:Label></div>
                                </div>
                                </ContentTemplate>
                        </asp:UpdatePanel>
                    <div class="clear"></div>
                </div>

                <!----------------------(2)--slide---------------------------->

                <div class="slide">
               
                    <div id="lofslidecontent45" class="lof-slidecontent" style="width:385px; height:270px;">
                        <div class="preload">
                            <div>
                            </div>
                        </div>
                         <!-- MAIN CONTENT --> 
                        <div class="lof-main-outer" style="width:385px; height:270px;">
  	                        <ul class="lof-main-wapper">
                                <% System.Data.DataTable dtProductPic = HProtest_BLL.Common.GetPics(pid);
                                string PicUrl;
                                if(dtProductPic!=null)
                                    if (dtProductPic.Rows.Count>0)
                                foreach (System.Data.DataRow drProPic in dtProductPic.Rows)
                                    {
                                        PicUrl=drProPic["pic"].ToString();
                                    %>
                                    <li>
                                        <img alt="" style="width:385px;height:270px" id="Img4" src='<%= Page.ResolveUrl("~/Resource/ProductOtherPic/")+PicUrl %>' />
                                    </li> 
                                    <%}%>
                              </ul>  	
                        </div>
                        <div class="lof-navigator-wapper">
                            <div onclick="return false" class="lof-next"></div>
                            <div class="lof-navigator-outer">
                                <ul class="lof-navigator">
                                    <%if(dtProductPic!=null)
                                          if (dtProductPic.Rows.Count > 0)
                                        foreach (System.Data.DataRow drProPic in dtProductPic.Rows)
                                        {
                                        PicUrl=drProPic["pic"].ToString();
                                    %>
                                    <li>
                                        <img alt="" style="width:70px;height:27px" id="Img5" src='<%= Page.ResolveUrl("~/Resource/ProductOtherPic/")+PicUrl %>' />
                                    </li>
                                    <%}%>
                                </ul>
                              </div>
                                <div onclick="return false" class="lof-previous"></div>
                         </div>
                     </div>
                </div>
            </div>
            <div class="clear"></div>


            <!----------------------sizeable---------------------------->
            <center>
            <div class="sizeable">
                <% if (Product.Size == true)
                   { %>
                   <div class="imgfingersize"></div>
                   <div class="content">
                        <div class="text"> &nbsp;این&nbsp;<%=Product.ProductType.type %> زیبا در سایزهای مختلف موجود میباشد.</div>
                        <div class="help"><a href='<%= Page.ResolveClientUrl("~/Size.aspx") %>' target="_blank" title="برای مشاهده راهنما کلیک کنید">مشاهده راهنما </a></div>
                   </div>
                <% } %>
            </div>
            </center>
            <div class="clear"></div>


            <!----------------------about product---------------------------->

            <div class="aboutproduct">
                <%=Server.HtmlDecode(Product.AboutProduct.ToString())%>
            </div>
            <div class="clear"></div>

            <!----------------------3-&-4-------------------------->
            <div class="rows3_4">

                    <!--------------------(3)--main pic---------------------------->
                    <div class="mainpic">
                        <div class="content">
                            <img src='<%= Page.ResolveClientUrl("~/Resource/ProductPic/")+Product.MainPic.ToString() %>' class="" width="200px" height="240px" title='<%=Product.Name.ToString()%>' alt="<%=Product.Name.ToString()%>" border="0" id="Img3" />
                        </div>
                        <div class="content"><span> کد جواهر : </span><%=Product.ID.ToString()%></div>
                    </div>

                    <!--------------------(4)--video---------------------------->
                    <div class="video">
                        <div class="videoco" style="position: relative; width: 280px; height: 266px;">
                            <video height="270" width="270" src='<%= Page.ResolveClientUrl("~/Resource/ProductVideo/"+Product.Video.ToString()) %>' controls>
                            مرورگر شما تگ ویدئو را پشتیبانی نمی کند.
                            </video>
                        </div>
                        <div class="clear"></div>
                        <div class="dlvideo">
                            <a href='<%= Page.ResolveClientUrl("~/Resource/ProductVideo/"+Product.Video.ToString()) %>'>دانلود</a>
                        </div>
                    </div>

            </div>
            <div class="clear"></div>
            <!--------------------price & buy---------------------------->
            <div class="PricBuy">
                <div class="price">
                    <div class="row">
                            <span> قیمت :</span>
                            <span style="color:Red; font-weight:bold; margin-right:2px"><%=Product.Price.ToString()%></span>
                            <span style="margin-right:2px">تومان</span>
                    </div>
                </div>
                <div class="buy">
                    <asp:ImageButton ImageUrl="~/Resource/PicSite/buy.png" runat="server" OnCommand='BuyProduct' Height="35" Width="35" title="خرید جواهر " alt="خرید جواهر " border="0" ID="ImageButton2" />
                </div>
            </div>
            <div class="clear"></div>

            <!-------------------Similary Product---------------------------->
             
            <div class="similary">
                <div class="similaryh1 gradient BoxDivShadow">چند نمونه از محصولات مشابه:</div>
                <asp:Repeater ID="RepeaterSimilarType" runat="server">
                    <ItemTemplate>
                        <div class="rowssimilary">
                            <a href="ViewSelectedPoduct.aspx?pid=<%# Eval("ID") %>"><div style="float: right; width: 30px;"><img src='<%# Page.ResolveClientUrl("~/Resource/ProductPic/")+Eval("MainPic")%>' width="30px" height="30px" title="<%# Eval("Name")%>" alt="<%# Eval("Name")%>" border="0" id="Img1" /></div></a>
                            <a href="ViewSelectedPoduct.aspx?pid=<%# Eval("ID") %>"><div style="float: right; width: 250px; margin-right:5px; line-height:30px"><%# Eval("Name") %></div></a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="clear"></div>
            </div>
            <div class="clear"></div>

            <!-------------------display all Similary Product---------------------------->
            <div class="displayAll">
                <div class="row BoxDivShadow">
                    <a href='Default.aspx?title=<%=Product.ProductType.type %>&type=<%=Product.ProductType.ID%>' title="برای مشاهده کلیک کنید"> مشاهده همه محصولات از نوع&nbsp;<%=Product.ProductType.type %></a>
                </div>
            </div>
    </div>
</center>

</asp:Content>

