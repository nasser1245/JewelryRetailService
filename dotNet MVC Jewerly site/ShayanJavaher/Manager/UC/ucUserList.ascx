<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucUserList.ascx.cs" Inherits="Manager_UC_ucUserList" %>
<script type="text/javascript">
    function LockMember(obj, UserName) {
        if (obj) {
            $.ajax({
                type: "POST",
                url: "UserList.aspx/LockMember",
                data: "{'UserName':'" + UserName + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    if (msg.d == "1") {
                        showMsg('warning', 'عملیات با موفقیت انجام شد.');
                        var typepath = $(obj).parent().parent().find("img").attr("typepath");
                        if (typepath == "true.jpg")
                            typepath = "false.jpg";
                            else
                                typepath = "true.jpg";
                            $(obj).parent().parent().find("img").attr("src", "../../Resource/PicSite/active" + typepath);
                            $(obj).parent().parent().find("img").attr("typepath", typepath);

                        //       $(obj).parent().parent().fadeOut(500);
                    }
                    else if (msg.d == "-2")
                        showMsg('warning', 'شما اجازه ی دسترسی به این عملیات را ندارید.');
                },
                error: function () {
                    showMsg('warning', 'بروز خطای نا مشخص،لطفا لحظاتی بعد مجددا سعی نمایید');
                }
            });
            }
            return true;
    }
    </script>
    
<div style="padding:5px; margin:5px;">
    <div style="margin:5px;">
        <div style="width:80px; float:right;">نام : </div>
        <div><asp:TextBox ID="txtName" runat="server"></asp:TextBox></div>
    </div>
    <div style="margin:5px;">
        <div style="width:80px; float:right;">نام خانوادگی : </div>
        <div><asp:TextBox ID="txtFamily" runat="server"></asp:TextBox></div>
    </div>
    <div style="margin:5px;">
        <div style="width:80px; float:right">نام کاربری:</div><div>
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></div>
    </div>
    <div style="margin:5px;">
        <div style="width:80px; float:right">ایمیل:</div>
        <div><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></div>
    </div>

    <div style="margin:20px">
        <asp:Button CssClass="btn1" ID="btnClearFilter" runat="server" Text="حذف فیلتر"  onclick="btnClearFilter_Click" />
        <asp:Button CssClass="btn1" ID="btnSearch" runat="server" Text="جستجو"  onclick="btnSearch_Click"/>
    </div>
</div>



<div class="clear"></div>
<div style="margin-top:30px"><h5>آمار بخش:</h5></div>
<asp:Label ID="lblAllCount" runat="server"></asp:Label>
<asp:Label ID="lblMsgResultCount" runat="server"></asp:Label>
<asp:Label ID="lblResultCount" runat="server"></asp:Label>




<center>
<div style="width:500px; margin-bottom:20px; margin-top:20px">
    <div class="titrgrid">
        <span style="width:150px; margin-right:50px">نام کاربری</span>
        <span style="width:150px; margin-right:60px">نام و نام خانوادگی</span>
        <span style="width:100px; margin-right:60px">ایمیل</span>
        <span style="width:100px; margin-right:60px">عملیات</span>

    </div>

    <div class="grid">
        <asp:Repeater ID="rptArticle" runat="server" >
            
            <ItemTemplate>
                <div class="odd">
                    <span style="width:150px"><%# Eval("UserName").ToString().Length > 20 ? Eval("UserName").ToString().Substring(0, 20) + ".." : Eval("UserName").ToString()%></span>
                    <span style="width:150px"><%# (Eval("FirstName").ToString() + Eval("LastName").ToString()).ToString().Length > 20 ? (Eval("FirstName").ToString() + " " + Eval("LastName").ToString()).ToString().Substring(0, 20) + ".." : ((Eval("FirstName").ToString() + " " + Eval("LastName").ToString()).ToString()) == " " ? " --- " : ((Eval("FirstName").ToString() + " " + Eval("LastName").ToString()).ToString())%></span>
                    <span style="width:100px"><%# Eval("Email") %></span>                 
                    <%if (Page.User.IsInRole("1") || ((HProtest_BLL.AccessLevel.AccessLevel)HttpContext.Current.Session["AccessLevel"]).UserAgent == true)
                      { %>
                        <span style="width:100px"><a title='<%# Eval("Locked").ToString().ToLower() == "false" ? "غیرفعال کردن" :  "فعال کردن" %>' href="#" onclick='return LockMember(this,"<%# Eval("UserName") %>")'><img typepath='<%# Eval("Locked").ToString().ToLower() +  ".jpg" %>'  src = '<%= Page.ResolveClientUrl("~/Resource/PicSite/active")%><%# Eval("Locked").ToString().ToLower() +  ".jpg" %>' alt="غیرفعال" class="mn_l5" width="16" height="16" /></a></span>
                 <%} %>
                 <div class="clear"></div>
                </div>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <div class="even">
                    <span style="width:150px"><%# Eval("UserName").ToString().Length > 20 ? Eval("UserName").ToString().Substring(0, 20) + ".." : Eval("UserName").ToString()%></span>
                    <span style="width:150px"><%# (Eval("FirstName").ToString() + Eval("LastName").ToString()).ToString().Length > 20 ? (Eval("FirstName").ToString() + " " + Eval("LastName").ToString()).ToString().Substring(0, 20) + ".." : ((Eval("FirstName").ToString() + " " + Eval("LastName").ToString()).ToString()) == " " ? " --- " : ((Eval("FirstName").ToString() + " " + Eval("LastName").ToString()).ToString())%></span>
                    <span style="width:100px"><%# Eval("Email") %></span>  
                    <%if (Page.User.IsInRole("1") || ((HProtest_BLL.AccessLevel.AccessLevel)HttpContext.Current.Session["AccessLevel"]).UserAgent == true)
                      { %>     
                        <span style="width:100px"><a title='<%# Eval("Locked").ToString().ToLower() == "false" ? "غیرفعال کردن" :  "فعال کردن" %>' href="#" onclick='return LockMember(this,"<%# Eval("UserName") %>")'><img typepath='<%# Eval("Locked").ToString().ToLower() +  ".jpg" %>' src = '<%= Page.ResolveClientUrl("~/Resource/PicSite/active")%><%# Eval("Locked").ToString().ToLower() +  ".jpg" %>' alt="غیرفعال" class="mn_l5" width="16" height="16" /></a></span>
                                     <%} %>
                 <div class="clear"></div>
                </div>
                </AlternatingItemTemplate>
        </asp:Repeater>
    </div>
</div>    

    <div style="margin-top:30px">
        <asp:ImageButton Visible="false" ID="imgbtnNext" CssClass="left mn_l15" ToolTip="صفحه بعد" AlternateText="" Width="35px" Height="35px" ImageUrl="~/Resource/PicSite/go-next-page.png" runat="server" value="" OnClick="imgbtnNext_Click"/>
        <asp:ImageButton Visible="false" ID="imgbtnLast" CssClass="left mn_l15" ToolTip="آخرین صفحه" AlternateText="" Width="35px" Height="35px" ImageUrl="~/Resource/PicSite/go-last-page.png" runat="server" value="" onclick="imgbtnLast_Click"/>
        <asp:Label ID="lblPagNumber" CssClass="left mn_l15" runat="server"></asp:Label>
        <asp:ImageButton ID="imgbtnFirst" CssClass="left" ToolTip="اولین صفحه" AlternateText="" Width="35px" Height="35px" ImageUrl="~/Resource/PicSite/go-first-page.png" runat="server" value="" onclick="imgbtnFirst_Click"/>
        <asp:ImageButton ID="imgbtnPrev" CssClass="left mn_l15" ToolTip="صفحه قبل" AlternateText="" Width="35px" Height="35px" ImageUrl="~/Resource/PicSite/go-previous-page.png" runat="server" value="" onclick="imgbtnPrev_Click"/>

    </div>
    </center>
    