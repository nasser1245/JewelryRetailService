<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master" AutoEventWireup="true" CodeFile="NewsCategory.aspx.cs" Inherits="Manager_News_NewsGroup" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadsCPH" Runat="Server">

<script type="text/javascript">
    function removeArticle(obj, Id) {
        if (confirm('آیا از حذف این عنوان اطمینان دارید؟')) {
            if (obj) {
                $.ajax({
                    type: "POST",
                    url: "NewsCategory.aspx/DeleteArticle",
                    data: "{'Id':'" + Id + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        if (msg.d == "1") {
                            showMsg('accept', 'عملیات با موفقیت انجام شد.');

                            $(obj).parent().parent().fadeOut(500);
                        }
                        else if (msg.d == "0")
                            showMsg('warning', 'عملیات با خطا مواجه شد.');


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
<asp:Content ID="Content2" ContentPlaceHolderID="BodyCPH" Runat="Server">
  <asp:HiddenField ID="hfID" runat="server" Value="-1" />
  <div id="alert" class="hide">
        <div class="alert">
            <div class="img" id="imgAlert"></div>
            <div class="text"><span id="lblAlert"></span></div>
        </div>
    </div>

    <div class="AllContent">
  
            <fieldset style = "width:98%">
                <legend>درج گروه خبری</legend>
                <div class="FieldsKey">
                    <div class="LabelP">
                        عنوان</div>
                    <div class="ValueP">
                        <asp:TextBox ID="txtTitleNewsCategory" runat="server"></asp:TextBox></div>
                    <div class="LabelP">
                    </div>
                    <div class="ValueP">
                        <asp:CheckBox ID="chkVisible" runat="server" Text="قابلیت نمایش" Checked="true"></asp:CheckBox></div>
                    <div class="LabelP">
                    </div>
                    <div class="ValueP">
                        <asp:Button ID="btnAddNewsCategory" runat="server" Text="ثبت" OnClick="btnAddMenu_Click" />
                    </div>
                </div>
            </fieldset>


  
    <fieldset style= "width:98%">
        <legend>لیست گروه های خبری</legend>
        <div class="FieldsKey">
        <div class="LabelP">
            جستجو</div>
        <div class="ValueP">
        
            <asp:TextBox ID="txtNewsCategorySearch" runat="server"></asp:TextBox>
        
        
            <asp:Button ID="btnSearch" runat="server" Text="جستجو" 
                onclick="btnSearch_Click" />
        </div>
       
        </div>
    </fieldset>

        <center>

     <div style="width:400px; margin-bottom:20px; margin-top:20px">
    <div class="titrgrid">
                <span style="width:150px; margin-right:15px">شناسه</span>
                <span style="width:100px; margin-right:40px">عنوان</span>
                <span style="width:100px; margin-right:40px">قابل نمایش</span>
                <span style="width:100px; margin-right:40px">ویرایش و حذف</span>
            </div>
            <div class="grid">
                <asp:Repeater ID="rptProductType" runat="server">
                    <ItemTemplate>
                        <div class="odd">
                            <span style="width:70px"><%#Eval("ID") %></span>
                            <span style="width:90px"><%#Eval("Title") %></span>
                            <span style="width:90px; padding-right:45px"><asp:CheckBox ID='chkVisibility' Enabled="false" Checked='<%# bool.Parse((bool)Eval("Visible")==true ?"true":"false") %>' runat="server" /> </span>
                              <%if (hfID.Value == "-1"){ %>
                                  <span style="width:80px;height:auto;">
                                        <asp:LinkButton ID="LinkButton1" CommandArgument='<%# Eval("id")+","+Eval("Title")+","+Eval("Visible") %>' runat="server" OnCommand="EditCategory_Command"><img id="img1" alt="" src="<%= Page.ResolveClientUrl("~/Resource/PicSite/edit-icon.png") %>" class="mn_l5" width="16" height="16" /></asp:LinkButton><a href="#" onclick='return removeArticle(this,"<%# Eval("id") %>")'><img id="img3" alt="" src="<%= Page.ResolveClientUrl("~/Resource/PicSite/delete-icon.png") %>" class="mn_l5" width="16" height="16" /></a>
                                 </span> 
                              <%} else { %> 
                                  <span style="width:80px;height:auto;">                              
                                      <asp:LinkButton ID="LinkButton2" runat="server"><img id="img2" alt="" src="<%= Page.ResolveClientUrl("~/Resource/PicSite/dialog-disable.png") %>" class="mn_l5" width="16" height="16" /></asp:LinkButton>
                                  </span>
                               <%} %>   
                               <div class="clear"></div>
                        </div>
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <div class="even">
                            <span style="width:70px"><%#Eval("ID") %></span>
                            <span style="width:90px"><%#Eval("Title") %></span>
                            <span style="width:90px; padding-right:45px"><asp:CheckBox ID='chkVisibility' Enabled="false" Checked='<%# bool.Parse((bool)Eval("Visible")==true ?"true":"false") %>' runat="server" /> </span>
                              <%if (hfID.Value == "-1"){ %>
                                  <span style="width:80px;height:auto;">
                                        <asp:LinkButton ID="LinkButton1" CommandArgument='<%# Eval("id")+","+Eval("Title")+","+Eval("Visible") %>' runat="server" OnCommand="EditCategory_Command"><img id="img1" alt="" src="<%= Page.ResolveClientUrl("~/Resource/PicSite/edit-icon.png") %>" class="mn_l5" width="16" height="16" /></asp:LinkButton><a href="#" onclick='return removeArticle(this,"<%# Eval("id") %>")'><img id="img3" alt="" src="<%= Page.ResolveClientUrl("~/Resource/PicSite/delete-icon.png") %>" class="mn_l5" width="16" height="16" /></a>
                                 </span> 
                              <%} else { %> 
                                  <span style="width:80px;height:auto;">                              
                                      <asp:LinkButton ID="LinkButton2" runat="server"><img id="img2" alt="" src="<%= Page.ResolveClientUrl("~/Resource/PicSite/dialog-disable.png") %>" class="mn_l5" width="16" height="16" /></asp:LinkButton>
                                  </span>
                               <%} %>   
                               <div class="clear"></div>
                        </div>
                    </AlternatingItemTemplate>
                </asp:Repeater>
                </div>
                </div>
            </center>
        
    </div>

</asp:Content>

