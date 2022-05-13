<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master"
    AutoEventWireup="true" CodeFile="OpinionContent.aspx.cs" Inherits="Manager_Poll_OpinionContent" %>

<%@ Register Assembly="JQControls" Namespace="JQControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadsCPH" runat="Server">
    <script type="text/javascript">


        $(function () {
            //           HighLightRequired();

            $('#addOption').click(function () {
                $('#<%= hfActionType.ClientID %>').val('add');

            });


            $('.AddRow').click(function () {

                $(this).parent().parent().find('input[type=text]').val('');
                $(this).parent().parent().find('.OptionOrder').val('');
                $(this).parent().parent().find('.NewRow').fadeIn();
                $(this).parent().find('.btnCancel').fadeIn();
                $(this).parent().parent().find('.list').animate({ scrollTop: '0px' }, 800);
                return false;


            });

            $('.btnCancel').click(function () {
                $(this).fadeOut().parent().parent().find('.NewRow').fadeOut();
                if ($('#<%= hfActionType.ClientID %>').val().toString().indexOf('edit') >= 0) {
                }
                return false;

            });
        });

        function editOpinionOption(object, OptionId, OpinionId, OptionOrder, HitCount) {
            var currentRow = $(object).parent().parent().parent();
            $(object).parent().parent().parent().parent().parent().parent().find('.NewRow').fadeIn();
            $(object).parent().parent().parent().parent().parent().parent().animate({ scrollTop: '0px' }, 800);
            $(object).parent().parent().parent().parent().parent().parent().find('.btnCancel').fadeIn();

            $('#<%= hfEditingOption.ClientID %>').val(OpinionId);

            $('#<%= txtOption.ClientID %>').val($.trim($($(currentRow).children()[1]).html()));
            $('#<%= TxtOptionOrder.ClientID %>').val(OptionOrder);

            $('#<%= hfOptionOrder.ClientID %>').val(OptionOrder);

            $('#<%= hfHitCount.ClientID %>').val(HitCount);

            $('#<%= hfActionType.ClientID %>').val('edit,' + OptionId);

        }
     

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyCPH" runat="Server">
<div style="width:681px; margin:10px">

    <div id="alert" class="hide">
        <div class="alert">
            <div class="img" id="imgAlert"></div>
            <div class="text"><span id="lblAlert"></span></div>
        </div>
    </div>

    <cc1:JQLoader ID="JQLoader1" runat="server"></cc1:JQLoader>
    <div class="clear"></div>

    <div style="width:100%; float:right; margin-bottom: 20px;">
        <div style="font-weight:bold; width:100%; float:right; height:25px; line-height:25px; color:blue">راهنمای درج</div>
        <div style="width:100%; float:right; height:25px; line-height:25px; color:Maroon">* موارد دارای ستاره،الزامی است</div>
        <div style="width:100%; float:right; height:25px; line-height:25px; color:Maroon">* متن سوال نظر سنجی نباید خالی باشد</div>
        <div style="width:100%; float:right; height:25px; line-height:25px; color:Maroon">* در قسمت درج گزینه فیلد ردیف مقدار ورودی حتما از نوع عدد صحیح باشد</div>
        <div style="width:100%; float:right; height:25px; line-height:25px; color:Maroon">* تاریخ شروع و پایان باید به به طور صحیح وارد شود</div>
        <div style="width:100%; float:right; height:25px; line-height:25px; color:Maroon">* جهت درج گزینه های نظر سنجی،،ابتدا میبایست اطلاعات را ذخیره نمایید(ثبت اطلاعات)</div>
    <div class="clear"></div>

    </div>
    <div class="clear"></div>

<div class="BoxDivShadow" style="width:100%; margin:10px; background-color:white">
    <div class="BoxDivShadow" style="margin:-19px -11px 5px 5px; position:absolute; border-radius:5px; width:150px; float:right; background-color:Yellow; height:40px; line-height:40px; text-align:center">مشخصات نظر سنجی جدید</div>
    <div style="padding-top:30px" class="rowpoll">
        <div style="float:right; width:40px; height:25px; line-height:25px">سوال : </div>
        <div class="valuepoll"><asp:TextBox ID="txtBody" runat="server" CssClass="txtboxdottedgreen" TextMode="MultiLine" Height="184px" Width="580px"></asp:TextBox></div>
    </div>
    <div class="rowpoll">
        <div style="float:right; width:172px; height:25px; line-height:25px"><asp:CheckBox ID="cbIsUnlimited" Checked="false" runat="server" Text=" بدون محدودیت زمانبندی " /></div>
        <div style="float:right; width:105px; height:25px; line-height:25px">تاریخ شروع نمایش : </div>
        <div style="float:right; width:137px; height:25px; line-height:25px"><cc1:JQDatePicker ID="txtstartdatepicker" runat="server" CssClass="txtboxdottedgreen" ChangeMonth="true" ChangeYear="true" Culture="fa-IR"></cc1:JQDatePicker></div>
        <div style="float:right; width:65px; height:25px; line-height:25px">تاریخ انقضا : </div>
        <div style="float:right; width:100px; height:25px; line-height:25px"><cc1:JQDatePicker ID="txtenddatepicker" runat="server" CssClass="txtboxdottedgreen" ChangeMonth="true" ChangeYear="true" Culture="fa-IR"></cc1:JQDatePicker></div>
    </div>
    <div class="clear"></div>
    <div class="rowpoll">
        <div style="float:right; width:110px; height:25px; line-height:25px"> چند انتخابی باشد ؟</div>
        <div style="float:right; width:172px; height:25px; line-height:25px">
            <asp:RadioButtonList ID="Rdcanmultichoice" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Text="بله  " Value="1"></asp:ListItem>
                <asp:ListItem Text="خیر  " Value="0" Selected="True"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </div>
    <div class="rowpoll">
        <div style="float:right; width:90px; height:25px; line-height:25px">وضعیت نمایش : </div>
        <div style="float:right; width:172px; height:25px; line-height:25px">
            <asp:DropDownList ID="dlIsEnable" CssClass="ddldottedgreen" runat="server">
                <asp:ListItem Text="فعال" Value="1" Selected="True"></asp:ListItem>
                <asp:ListItem Text="غیر فعال" Value="0"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="rowpoll">
        <div style="width: 650px; margin-left: 10px; text-align:center"><asp:Button CssClass="btn" ID="btnSave" runat="server" Text="ثبت اطلاعات" ValidationGroup="reg" OnClick="btnSave_Click" /></div>
    </div>
    <div class="clear"></div>
    
</div>



<div class="BoxDivShadow" style="width:100%; margin:10px; background-color:white; margin-top:50px">
    <div class="BoxDivShadow" style="margin:-19px -11px 5px 5px; position:absolute; border-radius:5px; width:171px; float:right; background-color:Yellow; height:40px; line-height:40px; text-align:center">مشخصات گزینه های نظرسنجی</div>

    <div style="width:100%; float:right; color:Maroon; padding:40px 5px 20px 0px">نکته : جهت درج گزینه های نظر سنجی،ابتدا میبایست اطلاعات را ذخیره نمایید(ثبت اطلاعات)</div>

    <div class="rowpoll">
        <div style="width:70px; float:right; text-align:center">اولویت</div>
        <div style="width:320px; float:right; text-align:center">گزینه نظر سنجی</div>
        <div style="width:156px; float:right; text-align:center">عملیات</div>
    </div>
    <div class="rowpoll">
        <div style="width:70px; float:right; text-align:center"><asp:TextBox ID="TxtOptionOrder"  CssClass="txtboxdottedgreen" runat="server" Width="30px"></asp:TextBox></div>
        <div style="width:320px; float:right; text-align:center"><asp:TextBox ID="txtOption" Width="300px" CssClass="txtboxdottedgreen" runat="server"></asp:TextBox></div>
        <div style="width:100px; float:right; text-align:center; height:25px; line-height:25px"><a href="#" id="addOption">افزودن</a></div>
        <div style="width:100px; float:right; text-align:center; position:absolute; margin:-8px 459px 5px 5px"><asp:Button ID="btnSaveOption" runat="server" Text="ثبت" OnClick="btnSaveOption_Click" /></div>
    </div>
    <div class="clear"></div>
                <div style="width:100%; text-align:center; float:right; margin-top:20px; margin-bottom:10px">
                <asp:Repeater ID="rptOpinionOption" runat="server">
                    <ItemTemplate>
                        <div class="rowpoll">
                            <div style="width: 70px; margin-top: 0px; float:right;"><%# Eval("OptionOrder").ToString()%></div>
                            <div style="width: 320px; float:right;"><%# Eval("Text").ToString()%></div>
                            <div style="width: 100px; cursor: hand; float:right;">
                                    <asp:ImageButton Width="16" Height="16" ID="ImgbtnDelete" runat="server" OnClientClick='return confirm("آیا از حذف این عنوان اطمینان دارید؟")' CommandArgument='<%# Eval("OptionID") %>' runat="server" OnCommand="btnDelete_Ckick" ImageUrl="~/Resource/PicSite/delete-icon.png" />
                                    <%--<img width="16" height="16" onclick='editOpinionOption(this,"<%# Eval("OptionID").ToString() %>","<%# Eval("OpinionID").ToString() %>","<%# Eval("OptionOrder").ToString() %>","<%# Eval("HitCount").ToString()%>")' class="cursor" title="ویرایش" alt="ویرایش" src="<%= Page.ResolveClientUrl("~/Resource/PicSite/edit-icon.png") %>" />--%>
                            </div>
                            <div style="width: 100px; float:right;">تعداد ارا=<%# Eval("HitCount").ToString()%></div>

                            <div class="clear"></div>
                            
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="clear"></div>

                </div>

    
    
    <div class="clear"></div>

</div>
</div>
    <asp:HiddenField ID="hfActionType" runat="server" />
    <asp:HiddenField ID="hfEditingOption" runat="server" />
    <asp:HiddenField ID="hfOptionOrder" runat="server" />
    <asp:HiddenField ID="hfHitCount" runat="server" />
</asp:Content>
