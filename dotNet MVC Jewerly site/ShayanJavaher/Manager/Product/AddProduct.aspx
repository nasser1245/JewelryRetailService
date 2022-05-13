<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/ManagerMasterPage.master"
    AutoEventWireup="true" CodeFile="AddProduct.aspx.cs" Inherits="Manager_Product_AddProduct"
    ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadsCPH" runat="Server">
    <script type="text/javascript" src='<%= Page.ResolveUrl("~/Manager/Js/fckproduct.js")%>'></script>
    <script type="text/javascript">
        $(document).ready(function () {

            $('#' + '<%=txtAboutProduct.ClientID %>').ckeditor(config);

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyCPH" runat="Server">
    <div id="alert" class="hide">
        <div class="alert">
            <div class="img" id="imgAlert"></div>
            <div class="text"><span id="lblAlert"></span></div>
        </div>
    </div>

    <fieldset>
        <legend>درج محصول</legend>
        <div class="AllContentP">
            <div class="LabelP">
                نام :
            </div>
            <div class="ValueP">
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </div>
            <div class="clear"></div>
            <div style="float:right">
                <div style="float:right; width:210px">
                    <div style="float:right; width:60px">سر منو :</div>
                    <div style="float:right; width:120px"><asp:DropDownList Width="130px" 
                            ID="ddlTypeProductParrent" AutoPostBack="true" runat="server" 
                            onselectedindexchanged="ddlTypeProductParrent_SelectedIndexChanged"></asp:DropDownList></div>
                </div>
                <div style="float:right; width:200px">
                    <div style="float:right; width:70px">نوع محصول :</div>
                    <div style="float:right; width:100px"><asp:DropDownList ID="ddlTypeProduct" runat="server"></asp:DropDownList></div>
                </div>
            </div>
            <div class="clear"></div>
            <div class="LabelP">
                توضیح کوتاه</div>
            <div class="ValueP">
                <asp:TextBox ID="txtDesp" TextMode="MultiLine" runat="server"></asp:TextBox>
                </div>
            <div style="width:100%;float:right;">
                درباره محصول توضیح دهید(فوایدو...)</div>
            <div style="width:100%;float:right;">
                <asp:TextBox ID="txtAboutProduct" TextMode="MultiLine" runat="server"></asp:TextBox>
                </div>
            <div class="LabelP">
                <asp:CheckBox ID="chkLuxe" runat="server" Text=" لوکس" />
                </div>

            <div class="ValueP">
                <asp:CheckBox ID="chkSize" runat="server" Text="سایزبندی دارد" />
                
                </div>

              <div class="LabelP">
                <asp:CheckBox ID="chkVisible" runat="server" Text="وضعیت نمایش" Checked="true"/>
                </div>

            <div class="ValueP">
                </div>

                <div class="clear"></div>
                <div style="width:200px"><asp:CheckBox ID="Chkgift" runat="server" Text="اشانتیون می باشد "/></div>
               
                <div style="width:600px; margin-bottom:5px; margin-bottom:5px">
                    <div style="width:110px; float:right">از محدوده ی قیمت : </div>
                    <div style="width:72px; float:right"><asp:TextBox ID="txtFrom" Width="60px" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox></div>
                    <div style="width:25px; float:right">تا : </div>
                    <div style="width:60px; float:right"><asp:TextBox ID="txtTo" Width="60px" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox></div>
                    <div class="clear"></div>
                </div>
                
                 <div class="clear"></div>
            <div class="LabelP">
            تعداد
                </div>

            <div class="ValueP">
                <asp:TextBox ID="txtProductCount" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                </div>


            <div class="LabelP">
                قیمت</div>
            <div class="ValueP">
                <asp:TextBox ID="txtPrice" runat="server" onkeypress="return isNumberKey(event)"></asp:TextBox>
                </div>
          
                <div class="LabelP">تصویر
                </div>
                <div class="ValueP">
                    <asp:FileUpload ID="PicUpload" runat="server" />
                    </div>
                
               
                <%if (Request["id"] != null)
                  { %>
                <div class="LabelP">
                    <asp:Label ID="Label13" runat="server" Text="Label">عکس : </asp:Label>
                    </div>
                    <div class="ValueP">
                    <asp:Image ID="imgMainPic" runat="server" Height="140px" Width="110px" />
                    <asp:HyperLink ID="hplpics" runat="server">مشاهده سایر عکس ها</asp:HyperLink>
                </div>
                
                <%}
                  %>
                  
                   
     
          
                 <div class="LabelP">ویدئو
                </div>
                <div class="ValueP">
                    <asp:FileUpload ID="VideoUpload" runat="server" />
                    <asp:Label ID="lblHasVideo" runat="server" Text=""></asp:Label>
                    </div>

            <div class="LabelP">
            <%if (Request["id"] != null)
              { %>
            <asp:Button ID="btnCancle" runat="server" Text="انصراف" 
                     Height="21px" onclick="btnCancle_Click" />
                     <%} %>
            </div>
            <div class="ValueP">
                <asp:Button ID="btnAddProduct" runat="server" Text="ثبت" 
                    OnClick="btnAddProduct_Click" Height="21px" />
            </div>
            <asp:HiddenField ID="HidenVisited" runat="server" />
            <asp:HiddenField ID="HidenCount" runat="server" />
            <asp:HiddenField ID="HidenPoint" runat="server" />
            <div class="clear"></div>
        </div>
    </fieldset>
</asp:Content>
