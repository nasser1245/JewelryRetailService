<%@ Page Title="" Language="C#" MasterPageFile="~/Main_MasterPage.master" AutoEventWireup="true" CodeFile="RegFiche.aspx.cs" Inherits="RegFiche" %>
<%@ Register Assembly="JQControls" Namespace="JQControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plContentMP" Runat="Server">
<cc1:JQLoader ID="JQLoader1" runat="server" />
    <div id="alert" class="hide">
        <div style="padding: 5px; width: 650px; border-radius: 5px; border: 1px dotted #666;
            text-align: right;">
            <div class="img" id="imgAlert">
            </div>
            <div class="text">
                <span id="lblAlert"></span>
            </div>
        </div>
    </div>
        <div class="clear">
    </div>
                <asp:Panel ID="Panel1" runat="server" DefaultButton="btnRegister">  
    <div style="padding: 5px; width: 650px; border-radius: 5px; border: 1px dotted #666;
        text-align: right;">
        <div style="padding: 5px;">
            ثبت فیش 
            عابربانکی یا شعبه :
            <%# Eval("UserName") %></div>
        <div style="padding: 5px;">
            <div style="padding: 5px;" class="labelE">
                مبلغ :
            </div>
            <div style="padding: 5px;">
                <span style="color: Maroon">*&nbsp</span><asp:TextBox CssClass="valueE"
                    ID="txtSumma" runat="server"></asp:TextBox></div>
        </div>
        <div style="padding: 5px;">
            <div style="padding: 5px;" class="labelE">
                به شماره حساب :
            </div>
            <div style="padding: 5px;">
                <span style="color: Maroon">*&nbsp</span><asp:TextBox CssClass="valueE"
                    ID="txtAccountNo" runat="server"></asp:TextBox></div>
        </div>
        <div style="padding: 5px;">
            <div style="padding: 5px;" class="labelE">
                به شماره فیش :
            </div>
            <div style="padding: 5px;">
                <span style="color: Maroon">*&nbsp</span><asp:TextBox CssClass="valueE" ID="txtFicheNo"
                    runat="server"></asp:TextBox></div>
        </div>
        <div style="padding: 5px;">
            <div style="padding: 5px;" class="labelE">
                نوع فیش :
            </div>
            <div style="padding: 5px;">
                <span style="color: Maroon">*&nbsp</span><asp:DropDownList CssClass="valueEddl" ID="ddlFicheType" runat="server">
                    <asp:ListItem Value="0">بانکی</asp:ListItem>
                    <asp:ListItem Value="1">خودپرداز</asp:ListItem>
                    <asp:ListItem Value="2">سایر</asp:ListItem>
                </asp:DropDownList></div>
        </div>
        <div style="padding: 5px;">
            <div style="padding: 5px;" class="labelE">
                توسط( نام و نام خانوادگی) :</div>
            <div style="padding: 5px;">
                <span style="color: Maroon">*&nbsp</span><asp:TextBox CssClass="valueE" ID="txtFullName"
                    runat="server"></asp:TextBox></div>
        </div>
        <div style="padding: 5px;">
            <div style="padding: 5px;" class="labelE">
                در تاریخ :
            </div>
            <div style="padding: 5px;"><span style="color: Maroon">*&nbsp</span>
                <cc1:JQDatePicker ID="txtPayDate" CssClass="txtbox" ChangeMonth="true" ChangeYear="true" Culture="fa-IR" runat="server"></cc1:JQDatePicker>
                </div>
        </div>
        <div style="padding: 5px;">
            <div style="padding: 5px;" class="labelE">
                توضیحات :</div>
            <div style="padding: 5px;">
                <asp:TextBox CssClass="valueE" ID="txtDescription"
                    TextMode="MultiLine"  Height="80px" runat="server"></asp:TextBox></div>
        </div>
        <div style="padding: 5px;">
            <div style="padding: 5px;" class="labelE">
                واریز شد.
            </div>
  
        </div>
        <div class="clear">
        </div>
        <div style="padding: 5px; text-align: center">
            <asp:Button ID="btnRegister" runat="server" Text="ثبت " OnClick="btnRegister_Click" />
            <asp:Button
                ID="btnCancel" runat="server" Text="انصراف" onclick="btnCancel_Click" /></div>
    </div>
    </asp:Panel>
</asp:Content>

