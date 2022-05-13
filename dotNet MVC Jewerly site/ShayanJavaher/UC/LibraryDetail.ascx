<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LibraryDetail.ascx.cs" Inherits="UC_LibraryDetail" %>
<link href="../CSS/dl.css" rel="stylesheet" type="text/css" />
<div class="LibraryView BoxDivShadow">
    <div class="headerLibrary">
        <div class="titleLibrary"><%=lib.Title%>
         <div style="text-align:left;font-size:11px">تعداد بازدید :<%=lib.VisitCount %></div>
        </div>
     </div>
     <div class="brdTop BoxDivShadow">
        <div class="idLibrary">شناسه مطلب : <%= HProtest_BLL.Helper.Utility.GetPersianString(lib.ID.ToString())%></div>
        <div class="typeLibrary">نوع مطلب : <%=lib.LibraryCategory%></div>
        <div class="dateLibrary"><%=lib.DateInput.Insert(4,"/").Insert(7,"/")%></div>
    </div>
    <div class="contentTopLibrary"> 
        <div class="summaryLibrary BoxDivShadow">
            <div class="titrLibrary">درباره <%=lib.LibraryCategory%>:</div>
            <div class="textLibrary"><%=HProtest_BLL.Helper.Utility.GetPersianString(lib.Summary)%></div>
        </div>
    </div>
    <div class="picLibrary">
                <% if (lib.Picture != null)
                    { %><img alt='<%=lib.Title%>' style="height:320px; width:280px" title='<%=lib.Title %>' src='<%= Page.ResolveUrl("Resource/Library/")+lib.ID.ToString()+lib.Picture.ToString()%>'/> <% }%>
                <%else 
                    {%><img alt='<%=lib.Title%>' src=""/> <% }%>
        </div>
        <div class="clear"></div>
    <div class="clear"></div>
    <div class="contentDownLibrary">
        <div class="texttLibrary"><%=Server.HtmlDecode(lib.Detail)%></div>

        <div style="width:100%; float:right; text-align:center">
            <div id="wrap">
                <%--<asp:LinkButton ID="btn-wrap" CommandArgument = '<%= lib.ID.ToString()%>' runat="server" OnCommand="btnMethodTwo_Click" >
<%--                <asp:Button ID="btnMethodTwo" runat="server" Text="Download" OnClick="btnMethodTwo_Click" CommandArgument = '<%Server.MapPath("~/Resource/LibraryFiles/" + lib.ID.ToString() + lib.Link.ToString()) %>' />--%>
		        <a href='<%= Page.ResolveClientUrl("~/Resource/LibraryFiles/")+lib.ID.ToString()+lib.Link.ToString()%>'  title="Download Me!" id="btn-wrap">
			        <span class="title">دریافت</span>
			        <div id="info">
				        
					        <div style="margin-right: 28px; margin-top: 5px; text-align: right; width: 100%; float: right;">
                                    <%=lib.LibraryCategory%> دانلود </div>
					        <%
                                try
                                {
                                    System.IO.FileInfo f = new System.IO.FileInfo(Server.MapPath("~/Resource/LibraryFiles/" + lib.ID.ToString() + lib.Link.ToString()));
                                    Double Size = 0;
                                    string Unit = "";
                                    if (f.Length > (1024 * 1024))
                                    {
                                        Size = Math.Round((Double)((float)f.Length / (1024 * 1024)), 1);
                                        Unit = "مگابایت";
                                    }
                                    else if (f.Length > 1024)
                                    {
                                        Size = Math.Round((Double)((float)f.Length / 1024), 1);
                                        Unit = "کیلو بایت";
                                    }
                                    else
                                    {
                                        Size = f.Length;
                                        Unit = "بایت";
                                    }
                               
                                                      %>
                            <div style="width:100%; float:right; margin-right:28px; direction:rtl; text-align:right"> <%= " " + Size.ToString() + " " +Unit%></div>
                            <%
                                }
                                catch { } %>
				        
			        </div>
                    </a>
		        <%--</asp:LinkButton>--%>
            </div>
        </div>
        <%--<div style="width:100%; float:right"><a href='<%= Page.ResolveUrl("Resource/LibraryFiles/")+lib.ID.ToString()+lib.Link.ToString()%>'/>دریافت</a></div>--%>
        <div class="writerLibrary">نویسنده : <%=lib.FirstName%>&nbsp<%=lib.LastName%></div>
    </div>
    <div class="clear"></div>
</div>
