<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master"  ValidateRequest="false" AutoEventWireup="true" CodeFile="SiteInfo.aspx.cs" Inherits="Manager_SiteInfo_SiteInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadsCPH" Runat="Server">
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
            ['Table','Image', 'HorizontalRule', 'Smiley', 'PageBreak', 'ShowBlocks'],
		],
            removePlugins: 'resize',
            height: '190px',
            //width: '680px',
            language: 'fa',
            uiColor: '#CCDBFF'
        };
        $('#<%= txtText.ClientID %>').ckeditor(config);
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyCPH" Runat="Server">
    <div id="alert" class="hide">
        <div class="alert">
            <div class="img" id="imgAlert"></div>
            <div class="text"><span id="lblAlert"></span></div>
    <div class="clear"></div>

        </div>
    <div class="clear"></div>

    </div>

<asp:Label ID="lblMessage" style="height:50px;clear:both;display:block;background:#cee7ed;line-height:50px" CssClass="round" runat="server"></asp:Label>

<div class="desc">
    <h5>
        <asp:Label ID="lblHint" runat="server"></asp:Label></h5>
    <div class="clear"></div>
</div>
<div class="clear"></div>
<asp:TextBox ID="txtText" runat="server" TextMode="MultiLine" Height="184px" Width="580px"></asp:TextBox>
<div class="clear"></div>

<div class="button left" style="width:100px;margin-left:20px">
    <asp:Button CssClass="btn" ID="btnSave" runat="server" Text="ثبت اطلاعات" ValidationGroup="reg" onclick="btnSave_Click" />
    <span class="icon" style="background-image:url(images/btnadd.png)"></span>
    <div class="clear"></div>
<div class="clear"></div>
</div>
        <fieldset class="PdProduct">
        <legend>ارسال عکس</legend>
        <div class="FileUploadValue">
            <asp:FileUpload ID="PicUpload" runat="server" /></div>
        <div class="UploadPic">
            <div>
                <asp:Button ID="btnAddPics" runat="server" Text="درج" 
                    onclick="btnAddPics_Click" />
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
        <asp:Repeater ID="rptPic" runat="server">
            <ItemTemplate>
                <div id="trt" class="DivParentRepeater" style="text-align:center;">
                            <asp:Image ID="imgFile" runat="server" Height="180px" ImageUrl='<%# Page.ResolveClientUrl("~/Resource/InfoSite/")+Eval("Name") %>'
                                Width="150px" />
                                <div class="clear"></div>
                                <asp:LinkButton ID="btnDelete" runat="server" CommandName="delete" CommandArgument='<%#Eval("Name")%>'
                                OnClientClick='return confirm("از حذف این گزینه اطمینان دارید؟")'
                                OnCommand="lblDeleteProduct_Command">حذف</asp:LinkButton>
                                <div class="clear"></div>                            
                                <asp:TextBox ID="txtAddr" runat="server" style="text-align:center;" Width="700px" Text='<%# Request.Url.Scheme + "://" + Request.Url.Host + Page.ResolveClientUrl("/Resource/InfoSite/")+Eval("Name") %>'></asp:TextBox>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </fieldset>
</asp:Content>

