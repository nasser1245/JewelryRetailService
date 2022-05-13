<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucNewsContent.ascx.cs" Inherits="Manager_UC_ucNewsContent" %>
<asp:HiddenField ID="hfnewsId" runat="server" Value="1" />
<asp:HiddenField ID="hfEditType" runat="server" Value="1" />
<asp:HiddenField ID="hfShowoptionlistaddress" runat="server" />

<script src='<%= Page.ResolveUrl("~/js/ckeditor_3.6.2/ckeditor.js") %>' type="text/javascript"></script>
<script src='<%= Page.ResolveUrl("~/js/ckeditor_3.6.2/adapters/jquery.js") %>' type="text/javascript"></script>

<script type="text/javascript">
    $(function () {
        HighLightRequired();

        var config = {
            skin: 'kama',
            toolbar:
		[
			['Link', 'Unlink', 'TextColor', 'BGColor'],
			['UIColor'],
            ['-', 'NewPage', 'DocProps', 'Preview', 'Print', '-', 'Templates'],
            ['Find', 'Replace', '-', 'SelectAll', '-'],
            ['Bold', 'Italic', 'Underline', 'Strike', '-', 'RemoveFormat'],
            ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', '-', 'Blockquote', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', '-', 'BidiLtr', 'BidiRtl'],
            ['Styles', 'Format', 'Font', 'FontSize'],
            [ 'Table', 'HorizontalRule', 'Smiley', 'PageBreak',  'ShowBlocks']
		],
            removePlugins: 'resize',
            height: '190px',
            //width: '680px',
            language: 'fa',
            uiColor: '#CCDBFF'
        };
        $('#<%= txtDetail.ClientID %>').ckeditor(config);
    });
</script>

<asp:Label ID="lblMessage" style="height:50px;clear:both;display:block;background:#cee7ed;line-height:50px" CssClass="round" runat="server"></asp:Label>
<h5>بخش اخبار</h5>
<div class="desc">
    <h5>راهنمای درج</h5>
    <div class="clear"></div>
    <span>
        <br />
        *موارد دارای ستاره،الزامی است
        <br />
        * عنوان،شرح خبر و خلاصه خبر میبایست بیش از 1 حرف باشد
        <br />
        *فیلد سال را برای تاریخ خبر به صورت 4 رقمی وارد نمایید
    </span>
    <div class="clear"></div>
</div>
<div class="row">
    <span class="label_big required">عنوان خبر:</span><asp:TextBox ID="txtTitle" runat="server" Width="580px"></asp:TextBox>
</div>
<div class="row">
    <span class="label_big required" style="vertical-align:top">خلاصه خبر:</span>
    <asp:TextBox ID="txtSummary" TextMode="MultiLine" runat="server" Height="62px" Width="580px"></asp:TextBox>
</div>
<div class="row">
    <span class="label" style="width:auto">گروه خبر:</span>
    <asp:DropDownList DataTextField="Title" DataValueField="Id" ID="ddlNewsCategory" runat="server" AppendDataBoundItems="true" Width="120px"></asp:DropDownList>
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Manager/News/NewsCategory.aspx">درج گروه خبری</asp:HyperLink>
</div>
<div class="row" style="display:none;">
    <span class="label" style="width:auto">نوع خبر:</span>
    <asp:DropDownList ID="ddlNewsType" runat="server" AppendDataBoundItems="true" Width="120px">
        <asp:ListItem Text="عادی" Value="1"></asp:ListItem>
        <asp:ListItem Text="ویژه" Value="2"></asp:ListItem>
    </asp:DropDownList>
</div>

<div class="row"><span class="label_big required">شرح خبر:</span></div>

<div class="clear"></div>
<asp:TextBox ID="txtDetail" runat="server" TextMode="MultiLine" Height="184px" Width="580px"></asp:TextBox>
<div class="clear"></div>
<div class="row">
    قابلیت نمایش<span class="label">:</span><asp:CheckBox ID="cbVisible" Checked="true" runat="server" Width="100px" />
    <span class="label">تاریخ خبر:</span>
    <asp:DropDownList ID="ddlNewsDay" Width="40px" runat="server">
                                                    <asp:ListItem>01</asp:ListItem>
                                                    <asp:ListItem>02</asp:ListItem>
                                                    <asp:ListItem>03</asp:ListItem>
                                                    <asp:ListItem>04</asp:ListItem>
                                                    <asp:ListItem>05</asp:ListItem>
                                                    <asp:ListItem>06</asp:ListItem>
                                                    <asp:ListItem>07</asp:ListItem>
                                                    <asp:ListItem>08</asp:ListItem>
                                                    <asp:ListItem>09</asp:ListItem>
                                                    <asp:ListItem>10</asp:ListItem>
                                                    <asp:ListItem>11</asp:ListItem>
                                                    <asp:ListItem>12</asp:ListItem>
                                                    <asp:ListItem>13</asp:ListItem>
                                                    <asp:ListItem>14</asp:ListItem>
                                                    <asp:ListItem>15</asp:ListItem>
                                                    <asp:ListItem>16</asp:ListItem>
                                                    <asp:ListItem>17</asp:ListItem>
                                                    <asp:ListItem>18</asp:ListItem>
                                                    <asp:ListItem>19</asp:ListItem>
                                                    <asp:ListItem>20</asp:ListItem>
                                                    <asp:ListItem>21</asp:ListItem>
                                                    <asp:ListItem>22</asp:ListItem>
                                                    <asp:ListItem>23</asp:ListItem>
                                                    <asp:ListItem>24</asp:ListItem>
                                                    <asp:ListItem>25</asp:ListItem>
                                                    <asp:ListItem>26</asp:ListItem>
                                                    <asp:ListItem>27</asp:ListItem>
                                                    <asp:ListItem>28</asp:ListItem>
                                                    <asp:ListItem>29</asp:ListItem>
                                                    <asp:ListItem>30</asp:ListItem>
                                                    <asp:ListItem>31</asp:ListItem>
                                                </asp:DropDownList>
    <asp:DropDownList ID="ddlNewsMounth" Width="80px" runat="server">
                                                    <asp:ListItem Value="01">فروردین</asp:ListItem>
                                                    <asp:ListItem Value="02">اردیبهشت</asp:ListItem>
                                                    <asp:ListItem Value="03">خرداد</asp:ListItem>
                                                    <asp:ListItem Value="04">تیر</asp:ListItem>
                                                    <asp:ListItem Value="05">مرداد</asp:ListItem>
                                                    <asp:ListItem Value="06">شهریور</asp:ListItem>
                                                    <asp:ListItem Value="07">مهر</asp:ListItem>
                                                    <asp:ListItem Value="08">آبان</asp:ListItem>
                                                    <asp:ListItem Value="09">آذر</asp:ListItem>
                                                    <asp:ListItem Value="10">دی</asp:ListItem>
                                                    <asp:ListItem Value="11">بهمن</asp:ListItem>
                                                    <asp:ListItem Value="12">اسفند</asp:ListItem>
                                                </asp:DropDownList>
    <asp:TextBox ID="txtNewsYear" runat="server" Width="70px" MaxLength="4"></asp:TextBox>
</div>
<div class="row"><asp:Label ID="lblDateIn" runat="server"></asp:Label></div>
<div class="row"><span class="label">تصویر خبر:</span>
<div class="uploadButton right mn_t5">
    <span>افزودن</span>
    <asp:FileUpload ID="fuPic" runat="server" />
</div>

<asp:RegularExpressionValidator CssClass="right" ID="revMemberPic" runat="server" 
        ControlToValidate="fuPic" ValidationGroup="reg" 
        ErrorMessage="تنها فایلهای تصویری معمول قابل انتخاب می باشد." 
        ValidationExpression="^.+(.JPG|.jpg|.gif|.GIF|.PNG|.png|.BMP|.bmp|)$" 
        ForeColor="#430e00"></asp:RegularExpressionValidator>
</div>
<div class="clear"></div>
<%if(hfEditType.Value=="2") {%>
<asp:Image CssClass="right" ID="imgNews" runat="server" Width="80px" />
<%} %>
<div class="clear"></div>
<div class="button left" style="width:100px;margin-left:20px">
    <asp:Button CssClass="btn" ID="btnSave" runat="server" Text="ثبت اطلاعات" ValidationGroup="reg" onclick="btnSave_Click" />
    <span class="icon" style="background-image:url(images/btnadd.png)"></span>

    <%if (hfEditType.Value == "2")
      { %>
        <asp:Button CssClass="btn" ID="BtnCancel" runat="server" Text="انصراف" 
        onclick="btnCancel_Click"/>
        <%} %>
    
</div>