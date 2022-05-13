<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master"
    AutoEventWireup="true" CodeFile="Gift.aspx.cs" Inherits="Manager_Product_Gift" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadsCPH" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyCPH" runat="Server">
    <div class="AllContent">
        <div class="TitleOfGift">
            <div class="Label">
                نام اشانتیون
            </div>
            <div class="Value">
                <asp:TextBox ID="txtGiftName" runat="server"></asp:TextBox></div>
        </div>
        <div class="Details">
            <div class="label">
                جزئیات</div>
            <div class="Value">
                <asp:TextBox class="MultiLineText" ID="Details" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
        </div>
        <div class="FieldsKey">
            <div class="PicLabel">
                تصویر</div>
            <div class="FileUploadValue">
                <asp:FileUpload ID="FileUpload1" runat="server" /></div>
            <div class="UploadPic">
                <asp:Button ID="btnUploadPicture" runat="server" Text="ارسال" /></div>
        </div>
        <div>
            <div class="FloatedLabelValue">
                از خرید</div>
            <div class="FloatedLabelValue">
                <asp:TextBox ID="From" runat="server"></asp:TextBox></div>
            <div class="FloatedLabelValue">
                تا خرید</div>
            <div class="FloatedLabelValue">
                <asp:TextBox ID="To" runat="server"></asp:TextBox></div>
            <div class="FloatedLabelValue">
                تومان</div>
        </div>
        <div>
            <asp:CheckBox ID="Visibility" Text="قابلیت نمایش" runat="server" />
        </div>
        <div class="Label">
        </div>
        <div class="Value">
            <asp:Button ID="btnAddGift" runat="server" Text="ثبت" OnClick="btnAddGift_Click" />
        </div>
    </div>
</asp:Content>
