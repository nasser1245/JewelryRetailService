<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master"
    AutoEventWireup="true" CodeFile="AddPics.aspx.cs" Inherits="Manager_Product_PicsDisplay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadsCPH" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyCPH" runat="Server">
       <div id="alert" class="hide">
        <div class="alert">
            <div class="img" id="imgAlert"></div>
            <div class="text"><span id="lblAlert"></span></div>
            <div class="clear"></div>
        </div>
    </div>
    <fieldset class="PdProduct">
        <legend>ارسال عکس</legend>
        <div class="FileUploadValue">
            <asp:FileUpload ID="PicUpload" runat="server" /></div>
        <div class="UploadPic">
            <div>
                <asp:Button ID="btnAddPics" runat="server" Text="درج" OnClick="btnAddPic_Click" />
                <asp:Button ID="btnReturn" runat="server" Text="بازگشت" 
                    onclick="btnReturn_Click" />
                <%if (Request["id"] != null)
                  { %>
                <div>
                    
                    <asp:Image ID="imgUploadedPic" runat="server" Height="140px" Width="110px" />
                    
                </div>
                <%} %>
            </div>
        </div>
    </fieldset>
    <fieldset class="PdProduct">
        <legend>نمایش و ویرایش عکس ها</legend>
        <asp:Datalist ID="DatalistDisplayPics" runat="server" GridLines="Horizontal" RepeatColumns="5" >
            <ItemTemplate>
                <div id="trt" class="DivParentRepeater">
                    <div>
                        <div>
                            
                            <asp:Image ID="Image1" runat="server" Height="180px" ImageUrl='<%# Page.ResolveClientUrl("~/Resource/ProductOtherPic/")+Eval("Pic") %>'
                                Width="150px" />
                            
                        </div>
                        <div>
                        </div>
                        <div>
                            
                            <asp:LinkButton ID="btnDelete" runat="server" CommandName="delete" CommandArgument='<%# Eval("Pic")%>'
                                OnClientClick='return confirm("از حذف این گزینه اطمینان دارید؟")'
                                OnCommand="lblDeleteProduct_Command">حذف</asp:LinkButton>
                        </div>
                    </div>
                    <hr />
                </div>
            </ItemTemplate>
        </asp:Datalist>
    </fieldset>
</asp:Content>
