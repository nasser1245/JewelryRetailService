<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master"
    AutoEventWireup="true" CodeFile="ProductType.aspx.cs" Inherits="Manager_Product_ProductType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadsCPH" runat="Server">

<script type="text/javascript">
    function removeArticle(obj, Id) {
        if (confirm('آیا از حذف این عنوان اطمینان دارید؟')) {
            if (obj) {
                $.ajax({
                    type: "POST",
                    url: "ProductType.aspx/DeleteArticle",
                    data: "{'Id':'" + Id + ",'Parent':'"+ Parent+"'}",
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
<asp:Content ID="Content2" ContentPlaceHolderID="BodyCPH" runat="Server">
<asp:HiddenField ID="hfID" runat="server" Value="-1" />
    <div id="alert" class="hide">
        <div class="alert">
            <div class="img" id="imgAlert"></div>
            <div class="text"><span id="lblAlert"></span></div>
            <div class="clear"></div>
        </div>
    </div>
    <div class="AllContent">
     <fieldset class="RightContent" style="min-height:150px;">
           
                <legend>درج سر منو</legend>
                    <div class="LabelP">
                        عنوان</div>
                    <div class="ValueP">
                        <asp:TextBox ID="txtTitleMenu" runat="server"></asp:TextBox></div>
                    <div class="LabelP">
                    </div>
                    <div class="ValueP">
                        <asp:CheckBox ID="chkVisibleMenu" runat="server" Text="قابلیت نمایش" Checked="true"></asp:CheckBox></div>
                    <div class="LabelP">
                    </div>
                    <div class="ValueP">
                        <asp:Button ID="btnAddMenu" runat="server" Text="ثبت" OnClick="btnAddMenu_Click" />
                    </div>
            </fieldset>
     <fieldset class="RightContent" style="min-height:150px;">
                    <legend>درج زیر منو</legend>
                        <div class="LabelP">
                            عنوان</div>
                        <div class="ValueP">
                            <asp:TextBox ID="txtTitleSubMenu" runat="server"></asp:TextBox></div>
                        <div class="LabelP">
                            لیست منوها</div>
                        <div class="ValueP">
                            <asp:DropDownList ID="ddlMenus" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="ValueP">
                            <asp:CheckBox ID="chkVisibleSubMenu" runat="server" Text="قابلیت نمایش" 
                                Checked="true"></asp:CheckBox></div>
                        <div class="LabelP">
                        </div>
                        <div class="LabelP">
                        </div>
                        <div class="ValueP">
                            <asp:Button ID="btnAddSubMenu" runat="server" Text="ثبت" OnClick="btnAddSubMenu_Click" />
                        </div> 
            </fieldset>
  <div class="clear"></div>

        <div style="width:100%;">
                                <%if (hfID.Value != "-1")
                          { %>
                        <asp:Button ID="btnCancel" runat="server" Text="انصراف" 
                            onclick="btnCancel_Click" />
                        <%} %>
        </div>

    <fieldset style="width:96.5%">
        <legend>لیست منوها</legend>
        
        <div class="LabelP">
            جستجو</div>
            
        <div class="ValueP">
        
            <asp:TextBox ID="txtMenuSearch" runat="server"></asp:TextBox>
        
        
           
        </div>
                <div class="LabelP">
            لیست منوها</div>
        <div class="ValueP">
            <asp:DropDownList ID="ddlMenusSearch" runat="server" AppendDataBoundItems="true">
            </asp:DropDownList>

             <asp:Button ID="btnSearch" runat="server" Text="جستجو" 
                onclick="btnSearch_Click" />
            <asp:Button ID="btnDelSearch" runat="server" Text="حذف فیلتر" 
                onclick="btnDelSearch_Click" />
        </div>

    </fieldset>
    
        <div class="clear"></div>
<div style="margin-top:30px"></div>
<asp:Label ID="lblAllCount" runat="server"></asp:Label>
<asp:Label ID="lblMsgResultCount" runat="server"></asp:Label>
<asp:Label ID="lblResultCount" runat="server"></asp:Label>
        <center>
     <div style="width:550px; margin-bottom:20px; margin-top:20px"> 

                 <div class="titrgrid">
                <span style="width:85px; margin-right:10px">شناسه</span>
                <span style="width:100px; margin-right:60px">عنوان</span>
                <span style="width:100px; margin-right:80px">گروه</span>
                <span style="width:100px; margin-right:50px">قابل نمایش</span>
                <span style="width:100px; margin-right:50px">ویرایش و حذف</span>
            </div>

            <div class="grid">
                <asp:Repeater ID="rptProductType" runat="server" >
                    <ItemTemplate>
                         <div class="odd">
                            <span style="width:65px;height:auto;"><%#Eval("ID") %></span>
                            <span style="width:130px;height:auto;"><%#Eval("Name") %></span>
                            <span style="width:100px;height:auto;"><%# Eval("Parent").ToString()=="" ? "سرمنو" : Eval("Parent") %></span>
                            <span style="width:100px;height:auto; padding-right:50px"><asp:CheckBox ID='CheckBox1' Enabled="false" Checked='<%# bool.Parse((bool)Eval("Visible")==true ?"true":"false") %>' runat="server" /> </span>
                                <%if (hfID.Value == "-1")
                                { %>
                                  <span style="width:80px;height:auto;">                              
                                      <asp:LinkButton ID="lbEdit" CommandArgument='<%# Eval("id")+","+Eval("Name")+","+Eval("Parent") +","+ Eval("Visible") %>' runat="server" OnCommand="EditCategory_Command"><img id="imgBtnView" alt="" src= "<%= Page.ResolveClientUrl("~/Resource/PicSite/edit-icon.png") %>" class="mn_l5" width="16" height="16" /></asp:LinkButton>
                                      <asp:LinkButton ID="lbDelete" CommandArgument='<%# Eval("id") + "," + Eval("Parent") %>' runat="server" OnClientClick='return confirm("از حذف این گزینه اطمینان دارید؟")' OnCommand="DeleteMenu_Command"><img id="img2" alt="" src= "<%= Page.ResolveClientUrl("~/Resource/PicSite/delete-icon.png") %>" class="mn_l5" width="16" height="16" /></asp:LinkButton>
                                 </span>  
                                 <%} else { %> 
                                  <span  style="width:80px;height:auto;">                              
                                      <img id="img1" alt="" src="<%= Page.ResolveClientUrl("~/Resource/PicSite/dialog-disable.png") %>" class="mn_l5" width="16" height="16" />
                                      </span>
                                      <%} %>
                                     
                           <div class="clear"></div>
                        </div>

                    </ItemTemplate>
                     <AlternatingItemTemplate>
                         <div class="even">
                            <span style="width:65px;height:auto;"><%#Eval("ID") %></span>
                            <span style="width:130px;height:auto;"><%#Eval("Name") %></span>
                            <span style="width:100px;height:auto;"><%# Eval("Parent").ToString()=="" ? "سرمنو" : Eval("Parent") %></span>
                            <span style="width:100px;height:auto; padding-right:50px"><asp:CheckBox ID='CheckBox1' Enabled="false" Checked='<%# bool.Parse((bool)Eval("Visible")==true ?"true":"false") %>' runat="server" /> </span>
                                <%if (hfID.Value == "-1")
                                { %>
                                  <span style="width:80px;height:auto;">                              
                                      <asp:LinkButton ID="lbEdit" CommandArgument='<%# Eval("id")+","+Eval("Name")+","+Eval("Parent") +","+ Eval("Visible") %>' runat="server" OnCommand="EditCategory_Command"><img id="imgBtnView" alt="" src= "<%= Page.ResolveClientUrl("~/Resource/PicSite/edit-icon.png") %>" class="mn_l5" width="16" height="16" /></asp:LinkButton>
                                      <asp:LinkButton ID="lbDelete" CommandArgument='<%# Eval("id") + "," + Eval("Parent") %>' runat="server" OnClientClick='return confirm("از حذف این گزینه اطمینان دارید؟")' OnCommand="DeleteMenu_Command"><img id="img2" alt="" src= "<%= Page.ResolveClientUrl("~/Resource/PicSite/delete-icon.png") %>" class="mn_l5" width="16" height="16" /></asp:LinkButton>
                                 </span><%}  
                                else { %> 
                                  <span style="width:80px;height:auto;">                              
                                      <img id="img1" alt="" src="<%= Page.ResolveClientUrl("~/Resource/PicSite/dialog-disable.png") %>" class="mn_l5" width="16" height="16" />
                                  </span><%} %>
                                     
                           <div class="clear"></div>
                            
                        </div>

                    </AlternatingItemTemplate>
                </asp:Repeater>
                </div>
        </div>

        <%--<div style="display:none">
        <asp:ImageButton Visible="false" ID="imgbtnNext" CssClass="left mn_l15" ToolTip="صفحه بعد" AlternateText="" Width="35px" Height="35px" ImageUrl="~/Resource/PicSite/go-next-page.png" runat="server" value="" OnClick="imgbtnNext_Click"/>
        <asp:ImageButton Visible="false" ID="imgbtnLast" CssClass="left mn_l15" ToolTip="آخرین صفحه" AlternateText="" Width="35px" Height="35px" ImageUrl="~/Resource/PicSite/go-last-page.png" runat="server" value="" onclick="imgbtnLast_Click"/>
        <asp:Label ID="lblPagNumber" CssClass="left mn_l15" runat="server"></asp:Label>
        <asp:ImageButton ID="imgbtnFirst" CssClass="left" ToolTip="اولین صفحه" AlternateText="" Width="35px" Height="35px" ImageUrl="~/Resource/PicSite/go-first-page.png" runat="server" value="" onclick="imgbtnFirst_Click"/>
        <asp:ImageButton ID="imgbtnPrev" CssClass="left mn_l15" ToolTip="صفحه قبل" AlternateText="" Width="35px" Height="35px" ImageUrl="~/Resource/PicSite/go-previous-page.png" runat="server" value="" onclick="imgbtnPrev_Click"/>

    </div>--%>
        </center>

        </div>

</asp:Content>
