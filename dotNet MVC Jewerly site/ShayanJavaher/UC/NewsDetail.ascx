<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsDetail.ascx.cs" Inherits="HomePage_UC_NewsDetail" %>




<div class="newsDetails">
    <div class="headernews">
        <div class="titlenews"><%=news.Title %></div>
        <div class="datenews"><%=news.DateInput.Insert(4,"/").Insert(7,"/") %></div>
        <div class="idnews">شناسه خبر : <%= HProtest_BLL.Helper.Utility.GetPersianString(news.ID.ToString())%></div>
        <div class="idnews">نعداد بازدید : <%= HProtest_BLL.Helper.Utility.GetPersianString(news.VisitCount.ToString())%></div>
    </div>

    <div class="contentTopnews">
        <div class="summarynews">
            <div class="titrnews">شایان جواهر:</div>
            <div class="textnews"><%=HProtest_BLL.Helper.Utility.GetPersianString(news.Summary)%></div>
        </div>
        <div class="picnews">
                <% if (news.Picture != null)
                    { %><img alt='<%=news.Title%>' style="height:180px; width:250px" title='<%=news.Title %>' src='<%= Page.ResolveUrl("Resource/News/")+news.Picture.ToString()%>'/> <% }%>
                <%else 
                    {%><img alt='<%=news.Title%>' src=""/> <% }%>
        </div>
    </div>

    <div class="contentDownnews">
        <div class="texttnews"><%=Server.HtmlDecode(news.Detail)%></div>
        <div class="endnews">پایان خبر</div>
        <div class="writernews">نویسنده : <%=news.FirstName %>&nbsp<%=news.LastName %></div>
    </div>
</div>
