<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master"
    AutoEventWireup="true" CodeFile="Advertise.aspx.cs" Inherits="Manager_Advertise_Advertise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadsCPH" runat="Server">
    <script type="text/javascript">

        $(function () {
            HighLightRequired();

            $('.BoxToggle').click(function () {
                $(this).next('.Box').slideToggle();
            });
        });

        function removeArticle(obj, Id) {
            if (confirm('آیا از حذف این عنوان اطمینان دارید؟')) {
                if (obj) {
                    $.ajax({
                        type: "POST",
                        url: "Advertise.aspx/DeleteArticle",
                        data: "{'Id':'" + Id + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (msg) {
                            if (msg.d == "1")
                                $(obj).parent().parent().fadeOut(500);
                            else if (msg.d == "-2")
                                showMsg('warning', 'شما اجازه ی دسترسی به این عملیات را ندارید.');
                        },
                        error: function () {
                            showMsg('warning', 'بروز خطای نا مشخص،لطفا لحظاتی بعد مجددا سعی نمایید');
                        }
                    });
                }
                return true;
            } else {
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyCPH" runat="Server">
    <asp:HiddenField ID="hfEditType" runat="server" Value="1" />
    <asp:HiddenField ID="hfAdvertiseId" runat="server" Value="1" />
    <asp:HiddenField ID="hfAdvertiseIdFileType" runat="server" Value="1" />
    <asp:HiddenField ID="hfHight" runat="server" />
    <asp:HiddenField ID="hfAddr" runat="server" />
    <div style="width: 681px; margin: 10px">
        

        <asp:Label ID="lblMessage" CssClass="msg round" runat="server"></asp:Label>
        <div id="alert" class="hide">
            <div class="alert">
                <div class="img" id="imgAlert">
                </div>
                <div class="text">
                    <span id="lblAlert"></span>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <div class="BoxDivShadow boxTitradver" style="margin: 19px -5px 5px 5px">اضافه و ویرایش تبلیغات</div>
        <div class="BoxDivShadow averBox">
            <div style="padding:40px 5px 5px 5px; width:100%; float:right">
                <a class="btn_tiny BoxToggle" style="cursor:pointer">راهنمای درج</a>
                <div class="Box hide">
                    <div class="desc">
                        <div class="clear"></div>
                        <div style="width:100%; float:right; margin-bottom: 20px;">
                            <div class="helpadver">* موارد دارای ستاره،الزامی است</div>
                            <div class="helpadver">* ارتفاع را در صورت نیاز به عدد وارد کنید </div>
                            <div class="helpadver">* ارتفاع تنها برای فایلهای فلش معنادار است</div>
                            <div class="helpadver">* درج شود http://www.google.com لینک تبلیغ باید با الگویی مشابه</div>
                        <div class="clear"></div>
                        </div>
                    </div>
                </div>
            </div>
            
            <div class="rowpoll">
                <div class="lblpoll">عنوان : </div>
                <div class="valuepoll"><asp:TextBox ID="TxtTite" Width="200px" CssClass="txtboxdottedgreen" runat="server"></asp:TextBox></div>
            </div>
            <div class="rowpoll">
                <div class="lblpoll"> لینک به : </div>
                <div class="valuepoll"><asp:TextBox ID="TxtLink" Width="200px" CssClass="txtboxdottedgreen" runat="server"></asp:TextBox></div>
            </div>
            <div class="rowpoll">
                <div class="lblpoll">نوع فایل : </div>
                <div class="valuepoll"><asp:DropDownList Width="200px" CssClass="ddldottedgreen" ID="ddlFileType" runat="server" DataTextField="Title"
                    DataValueField="Id">
                </asp:DropDownList></div>
            </div>
            <div class="rowpoll">
                <div class="lblpoll required">افزودن فایل تبلیغ : </div>
                <div class="valuepoll"><asp:FileUpload ID="fuPic" runat="server" /></div>
            </div>
            <asp:RegularExpressionValidator CssClass="right" ID="revMemberPic" runat="server"
                ControlToValidate="fuPic" ValidationGroup="reg" ErrorMessage="تنها فایلهای تصویری معمول و فایل های فلش(swf) قابل انتخاب می باشد."
                ValidationExpression="^.+(.JPG|.jpg|.gif|.GIF|.PNG|.png|.BMP|.bmp|.swf|.flv)$"
                ForeColor="#430e00">
            </asp:RegularExpressionValidator>
            <div class="rowpoll">
                    <div class="lblpoll"> ارتفاع فلش : </div>
                <div class="valuepoll"><asp:TextBox ID="TxtAdHeight" CssClass="txtboxdottedgreen" runat="server"></asp:TextBox></div>
            </div>
            <div class="clear"></div>
            <div id="pnlFilelink">
                <div id="flashContainerPrw" runat="server">
                    <span class="flashadsLR" id="flcontainer" height='<%= hfHight.Value %>' href='<%= hfAddr.Value %>'>
                    </span>
                </div>
                <div id="picContainerPrw" runat="server">
                    <asp:Image CssClass="" ID="Adimg" runat="server" Width="100px" />
                </div>
            </div>
            <div class="rowpoll">
                <div class="lblpoll">وضعیت نمایش : </div>
                <div class="valuepoll"><asp:DropDownList Width="200px" CssClass="ddldottedgreen" ID="ddlVisible" runat="server">
                    <asp:ListItem Value="1">فعال</asp:ListItem>
                    <asp:ListItem Value="0">غیرفعال</asp:ListItem>
                </asp:DropDownList></div>
            </div>
            <div class="rowpoll">
                <div class="lblpoll">محل قرارگیری تصویر:</div>
                <div class="valuepoll"><asp:DropDownList Width="200px" CssClass="ddldottedgreen" ID="ddlPosition" runat="server" DataTextField="Title"
                    DataValueField="Id">
                </asp:DropDownList></div>
            </div>
            <div class="rowpoll">
                <div style="width:100px; float:right; margin-right:234px"><asp:Button CssClass="btn" ID="btnSave" runat="server" Text="ثبت اطلاعات" ValidationGroup="reg" OnClick="btnSave_Click" Style="height: 26px" /></div>
                <div style="width:100px; float:right"><asp:Button CssClass="button mn_l5 btn left" ID="btnCancel" Height="25px" runat="server" Text="انصراف" OnClick="btnCancel_Click" /></div>
            </div>
            <div class="clear"></div>
        </div>




        <div class="BoxDivShadow averBox">
            <div class="BoxDivShadow boxTitradver" style="margin: -19px -11px 5px 5px;">جستجو</div>
            <div style="padding:40px 5px 5px 5px; width:100%; float:right">
                <div style="width:80px; text-align:right; float:right; padding:2px; height:25px; line-height:25px">عنوان : </div>
                <div style="padding:2px; text-align:right; float:right; width:320px"><asp:TextBox ID="StxtTitle" CssClass="txtboxdottedgreen" Width="300px" runat="server"></asp:TextBox></div>
                <div class="button left mn_l15 mn_t5" style="float:right; width: 95px"><asp:Button CssClass="btn" ID="btnSearch" runat="server" Text="جستجو" OnClick="btnSearch_Click" /></div>
                <div class="button left mn_l15 mn_t5" style="float:right; width: 95px"><asp:Button CssClass="btn" ID="btnClearFilter" runat="server" Text="حذف فیلتر" OnClick="btnClearFilter_Click" /></div>
                <div class="clear"></div>
            </div>
            <div class="clear"></div>

            
            <div class="head_title mn_t5" style="height:30px; line-height:30px; background-color:menu">
                <div class="titleadvert">عنوان</div>
                <div class="disadvert">وضعیت نمایش</div>
                <div class="dateadvert">تاریخ درج</div>
                <div class="writeradvert">درج کننده</div>
                <div class="opearationadvert">عملیات</div>
                <div class="clear"></div>
            </div>
            <div class="clear"></div>

            <div class="grid">
                <asp:Repeater ID="rptAdvertise" runat="server">
                    <ItemTemplate>
                        <div class="odd head_title">
                            <div class="titleadvert"><a href='#' title=""><%# Eval("Title").ToString().Length > 10 ? Eval("Title").ToString().Substring(0, 10) + ".." : Eval("Title").ToString()%></a></div>
                            <div class="disadvert"><a href='#' title=""><%# Eval("Visible").ToString() == "1" ? "فعال" : "غیر فعال"%></a></div>
                            <div class="dateadvert"><a href='#' title=""><%# HProtest_BLL.Helper.Utility.GetPersianDate(Eval("DateIn"))%></a></div>
                            <div class="writeradvert"><a href='#' title=""><%# Eval("Creator").ToString().Length > 25 ? Eval("Creator").ToString().Substring(0, 25) + ".." : Eval("Creator").ToString()%></a></div>
                            <div class="opearationadvert">
                                <a title="ویرایش" href='Advertise.aspx?id=<%# Eval("Id") %>'><img id="imgBtnView" alt="" src="../../Resource/PicSite/edit-icon.png" class="mn_l5" width="16" height="16" /></a>
                                <a href="#" onclick='return removeArticle(this,"<%# Eval("Id") %>")'><img id="imgBtnDelete" alt="" src="../../Resource/PicSite/delete-icon.png" class="mn_l5" width="16" height="16" /></a>
                            </div>
                            <div class="clear"></div>
                        </div>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <div class="even head_title">
                            <div class="titleadvert"><a href='#' title=""><%# Eval("Title").ToString().Length > 10 ? Eval("Title").ToString().Substring(0, 10) + ".." : Eval("Title").ToString()%></a></div>
                            <div class="disadvert"><a href='#' title=""><%# Eval("Visible").ToString() == "1" ? "فعال" : "غیر فعال"%></a></div>
                            <div class="dateadvert"><a href='#' title=""><%# HProtest_BLL.Helper.Utility.GetPersianDate(Eval("DateIn"))%></a></div>
                            <div class="writeradvert"><a href='#' title=""><%# Eval("Creator").ToString().Length > 25 ? Eval("Creator").ToString().Substring(0, 25) + ".." : Eval("Creator").ToString()%></a></div>
                            <div class="opearationadvert">
                                <a title="ویرایش" href='Advertise.aspx?id=<%# Eval("Id") %>'><img id="imgBtnView" alt="" src="../../Resource/PicSite/edit-icon.png" class="mn_l5" width="16" height="16" /></a>
                                <a href="#" onclick='return removeArticle(this,"<%# Eval("Id") %>")'><img id="imgBtnDelete" alt="" src="../../Resource/PicSite/delete-icon.png" class="mn_l5" width="16" height="16" /></a>
                            </div>
                            <div class="clear"></div>
                        </div>
                    </AlternatingItemTemplate>
                </asp:Repeater>
                            <div class="clear"></div>

            </div>
            
            <div class=" clear">
            </div>
            <div class="rowpoll">
                <div style="float:right; width:100px; height:25px; line-height:25px" class="label_big">تعداد مورد جستجو:</div><div style="float:right; width:565px; height:25px; line-height:25px"><asp:Label ID="lblResultCount" runat="server"></asp:Label></div>
            </div>
            <div class="clear"></div>
        </div>
</div>
</asp:Content>
