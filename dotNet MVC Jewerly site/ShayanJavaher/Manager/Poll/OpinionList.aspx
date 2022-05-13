<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master"
    AutoEventWireup="true" CodeFile="OpinionList.aspx.cs" Inherits="Manager_Poll_OpinionList" %>

<%@ Register Assembly="JQControls" Namespace="JQControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadsCPH" runat="Server">
    <link href="../Css/Poll.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function removeOpinion(obj, Id) {
            if (confirm('آیا از حذف این عنوان اطمینان دارید؟')) {

                if (obj) {
                    $.ajax({
                        type: "POST",
                        url: "OpinionList.aspx/DeleteOpinion",
                        data: "{'Id':'" + Id + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (msg) {

                            if (msg.d == 0) {
                                showMsg('warning', 'شما اجازه ی دسترسی به این عملیات را ندارید');
                            }


                            if (msg.d == 1) {
                                showMsg('accept', 'عملیات با موفقیت انجام شد');
                                $(obj).parent().parent().fadeOut(500);
                            }

                            if (msg.d == -1) {
                                showMsg('warning', 'خطایی  رخ داده است و لطفا لحظاتی بعد مجددا انجام دهید');
                            }
                        },
                        error: function () {
                            showMsg('warning', 'بروز خطای نا مشخص،لطفا لحظاتی بعد مجددا سعی نمایید');
                        }
                    });
                }
                return false;
            }
            else {
                return false;
            }

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyCPH" runat="Server">
<div style="width:681px; margin:10px">
    <cc1:JQLoader ID="JQLoader1" runat="server"></cc1:JQLoader>

    <div class="BoxDivShadow" style="width:100%; margin:23px 10px 10px 10px; background-color:white">
        <div class="BoxDivShadow" style="margin:-19px -11px 5px 5px; position:absolute; border-radius:5px; width:88px; float:right; background-color:Yellow; height:40px; line-height:40px; text-align:center">جستجو</div>
        

    
    <div class="rowpoll" style="padding: 40px 5px 5px 5px">
        <div style="width:50px; text-align:right; float:right; padding:2px; height:25px; line-height:25px" class="required">سوال : </div>
        <div class="valuepoll"><asp:TextBox ID="txtQuestion" CssClass="txtboxdottedgreen" Width="200px" runat="server"></asp:TextBox></div>
    </div>
    <div class="rowpoll">
        <div style="width:50px; text-align:right; float:right; padding:2px; height:25px; line-height:25px" class="required">وضعیت :</div>
        <asp:DropDownList ID="ddltype" CssClass="ddldottedgreen" Width="200px" runat="server">
            <asp:ListItem Value="-1">انتخاب کنید</asp:ListItem>
            <asp:ListItem Value="0">غیر فعال</asp:ListItem>
            <asp:ListItem Value="1">فعال</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div class="rowpoll">
        <div style="width:50px; text-align:right; float:right; padding:2px; height:25px; line-height:25px" >از تاریخ :</div>
        <div style="width:210px; float:right; padding:2px; height:25px; line-height:25px"><cc1:JQDatePicker ID="txtstartdatepicker" runat="server" Width="200px" CssClass="txtboxdottedgreen" ChangeMonth="true" ChangeYear="true" Culture="fa-IR"></cc1:JQDatePicker></div>
        <div style="width:20px; float:right; padding:2px; height:25px; line-height:25px">تا : </div>
        <div style="width:120px; float:right; padding:2px; height:25px; line-height:25px"><cc1:JQDatePicker ID="txtenddatepicker" runat="server" Width="200px" CssClass="txtboxdottedgreen" ChangeMonth="true" ChangeYear="true" Culture="fa-IR"></cc1:JQDatePicker></div>
    </div>
    <div style="width:100%; float:right; text-align:center">
        <div style="text-align:center"><asp:Button CssClass="btn" ID="Button2" runat="server" Text="جستجو" OnClick="btnsearch_Click" /></div>
    </div>
    <hr />
    <div class="clear"></div>
    </div>






    <fieldset style="position: relative;">
        <div class="titrgrid head_title mn_t5">
            <div class="h">
                <div class="r">
                </div>
                <div class="l">
                </div>
                <span style="text-align: center; width: 40px">ردیف</span> <span style="text-align: center;
                    width: 125px">سوال </span><span style="text-align: center; width: 100px">درج کننده</span>
                <span style="text-align: center; width: 100px">وضعیت</span> <span style="text-align: center;
                    width: 100px">نوع نظرسنجی</span> <span style="text-align: center; width: 100px">تاریخ
                        انقضا</span> <span style="text-align: center; width: 100px">عملیات</span>
            </div>
        </div>
        <div class="grid">
            <asp:Repeater ID="rptOpinionList" runat="server">
                <ItemTemplate>
                    <div class="odd hht">
                        <span style="width: 40px">
                            <%# Eval("RowNum")%></span> <span style="width: 125px;" class="hht">
                                <%# string.IsNullOrEmpty(Eval("Question").ToString()) ? " --- " : (Eval("Question").ToString().Length > 17 ? Eval("Question").ToString().Substring(0, 15) + ".." : Eval("Question").ToString())%></span>
                        <span style="width: 100px" class="hht">
                            <%# string.IsNullOrEmpty(Eval("FullName").ToString()) ? " --- " : (Eval("FullName").ToString().Length > 20 ? Eval("FullName").ToString().Substring(0, 17) + ".." : Eval("FullName").ToString())%></span>
                        <span style="width: 100px" class="hht">
                            <%#Eval("HasMultipleAnswer").ToString() == "True" ? "چند انتخابی" : " تک انتخابی"%></span>
                        <span style="width: 100px" class="hht">
                            <%#Eval("IsEnable").ToString() == "True" ? "فعال" : "غیر فعال "%></span> <span style="width: 100px">
                                <%# string.IsNullOrEmpty(HProtest_BLL.Helper.Utility.GetPersianDate(Eval("EndDate"))) ? " --- " : (HProtest_BLL.Helper.Utility.GetPersianDate(Eval("EndDate")).Length > 30 ? HProtest_BLL.Helper.Utility.GetPersianDate(Eval("EndDate")).Substring(0, 25) + ".." : HProtest_BLL.Helper.Utility.GetPersianDate(Eval("EndDate")))%></span>
                        <span style="width: 100px" class="hht"><a id="A1" href='<%# "OpinionContent.aspx?OpinionID="+ Eval("OpinionID").ToString() %>'
                            runat="server">
                            <img src="<%= Page.ResolveClientUrl("~/Resource/PicSite/edit-icon.png") %>" class="mn_l5"
                                width="16" height="16" /></a> <a href="#" onclick='return removeOpinion(this,"<%# Eval("OpinionID") %>")'>
                                    <img src="<%= Page.ResolveClientUrl("~/Resource/PicSite/delete-icon.png") %>" class="mn_l5"
                                        width="16" height="16" /></a> </span>
                        <div class="clear">
                        </div>
                    </div>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <div class="even hht">
                        <span style="width: 40px">
                            <%# Eval("RowNum")%></span> <span style="width: 125px" class="hht">
                                <%# string.IsNullOrEmpty(Eval("Question").ToString()) ? " --- " : (Eval("Question").ToString().Length > 17 ? Eval("Question").ToString().Substring(0, 15) + ".." : Eval("Question").ToString())%></span>
                        <span style="width: 100px" class="hht">
                            <%# string.IsNullOrEmpty(Eval("FullName").ToString()) ? " --- " : (Eval("FullName").ToString().Length > 20 ? Eval("FullName").ToString().Substring(0, 17) + ".." : Eval("FullName").ToString())%></span>
                        <span style="width: 100px" class="hht">
                            <%#Eval("HasMultipleAnswer").ToString() == "True" ? "چند انتخابی" : " تک انتخابی"%></span>
                        <span style="width: 100px" class="hht">
                            <%#Eval("IsEnable").ToString() == "True" ? "فعال" : "غیر فعال "%></span> <span style="width: 100px">
                                <%# string.IsNullOrEmpty(HProtest_BLL.Helper.Utility.GetPersianDate(Eval("EndDate"))) ? " --- " : (HProtest_BLL.Helper.Utility.GetPersianDate(Eval("EndDate")).Length > 30 ? HProtest_BLL.Helper.Utility.GetPersianDate(Eval("EndDate")).Substring(0, 25) + ".." : HProtest_BLL.Helper.Utility.GetPersianDate(Eval("EndDate")))%></span>
                        <span style="width: 100px" class="hht"><a id="A2" href='<%# "OpinionContent.aspx?OpinionID="+ Eval("OpinionID").ToString() %>'
                            runat="server">
                            <img src="<%= Page.ResolveClientUrl("~/Resource/PicSite/edit-icon.png") %>" class="mn_l5"
                                width="16" height="16" /></a> <a href="#" onclick='return  removeOpinion(this,"<%# Eval("OpinionID") %>")'>
                                    <img src="<%= Page.ResolveClientUrl("~/Resource/PicSite/delete-icon.png") %>" class="mn_l5"
                                        width="16" height="16" /></a> </span>
                        <div class="clear">
                        </div>
                    </div>
                </AlternatingItemTemplate>
            </asp:Repeater>
        </div>
        <div class="clear">
        </div>
        <div class="paging">
            <asp:Repeater ID="rptPaging" runat="server">
                <ItemTemplate>
                    <a href='<%# Eval("href") %>' title='صفحه <%# Eval("title") %>'>
                        <%# Eval("title") %></a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </fieldset>
    </div>
</asp:Content>
