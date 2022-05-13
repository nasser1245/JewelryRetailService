using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.News;
using HProtest_DAL;
using ShayanDB_BLL;
using HProtest_BLL.Helper;

public partial class HomePage_UC_News : System.Web.UI.UserControl
{
    string sortDir = "desc", sortExpression = "tbNews.Id";
    int PageSize = 1;
    private enum PagingType
    {
        First = 0,
        Previuse,
        Next,
        Last,
        none
    }
    private int CurrentPageIndex
    {
        get
        {
            if (string.IsNullOrEmpty(Request["page"]))
                return 1;
            else
                return int.Parse(Request["page"]);
        }
    }
    private int AllRowCount;
    protected void Page_Load(object sender, EventArgs e)
    {
       // BindPagingGrid();
        //SetPager(PagingType.none);
        if (!Page.IsPostBack)
        {
            try
            {
                int AllCurrentCount=0;
                if (Request.QueryString["type"] == null)
                {
                    //newest news (all) with paging
                    RepeaterNewsList.DataSource = NewsData.GetNewsList(-1, "", "", "", "", -1, -1, 1, "", "", -1, "tbNews.Id", "desc", CurrentPageIndex-1, PageSize, out AllCurrentCount);
                    RepeaterNewsList.DataBind();
                }
                else
                {
                    string type = Request.QueryString["type"].ToString();
                    if (type == "all")
                    {
                        //newest news (all) with paging
                        RepeaterNewsList.DataSource = NewsData.GetNewsList(-1, "", "", "", "", -1, -1, 1, "", "", -1, "tbNews.Id", "desc", CurrentPageIndex-1, PageSize, out AllCurrentCount);
                        RepeaterNewsList.DataBind();
                    }
                    else
                    {
                        //news by group with paging
                        RepeaterNewsList.DataSource = NewsData.GetNewsList(-1, "", "", "", "", int.Parse(type), -1, 1, "", "", -1, "tbNews.Id", "desc", CurrentPageIndex-1, PageSize, out AllCurrentCount);
                        RepeaterNewsList.DataBind();
                    }
                }
                AllRowCount = AllCurrentCount;

                int LastPageIndex;
                if ((AllRowCount % PageSize) == 0)
                    LastPageIndex = AllRowCount / PageSize;
                else
                    LastPageIndex = AllRowCount / PageSize + 1;
                string typePaging = "";
                if (!String.IsNullOrEmpty(Request["type"])) typePaging = Request["type"].ToString();
                System.Collections.Generic.List<PageItem> PagingArray = HProtest_BLL.Helper.Utility.GetPagingArray(CurrentPageIndex, "news.aspx?type=" + typePaging, LastPageIndex, 3);

                rptPaging.DataSource = PagingArray;
                rptPaging.DataBind();

            }
            catch { }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //CurrentPageIndex = 0;
        BindPagingGrid();
        //SetPager(PagingType.none);

    }
    private void BindPagingGrid()
    {
        try
        {
            object From = DateTime.Now.AddYears(-30), To = DateTime.Now;
            int AllCurrentCount = 0;



            if (!String.IsNullOrEmpty(txtFrom.Text))
            {
                if (!HProtest_BLL.Helper.Utility.IsDateTime(txtFrom.Date.Value))
                {

                    return;
                }
                From = txtFrom.Date.Value;
            }
            if (!String.IsNullOrEmpty(txtTo.Text))
            {
                if (!HProtest_BLL.Helper.Utility.IsDateTime(txtTo.Date.Value))
                {
                    return;
                }
                To = txtTo.Date.Value;
            }


           
            using (System.Data.DataTable dtPagedArticles = NewsData.GetNewsList(-1, "", Server.HtmlEncode(txtTitle.Text.Trim()), "", "",-1, -1, 1, From, To, -1, sortExpression, sortDir, CurrentPageIndex-1, PageSize, out AllCurrentCount))
            {
                if (dtPagedArticles != null && dtPagedArticles.Rows.Count > 0)
                {
                    RepeaterNewsList.DataSource = dtPagedArticles;
                }
                RepeaterNewsList.DataBind();

            }

            AllRowCount = AllCurrentCount;

            int LastPageIndex;
            if ((AllRowCount % PageSize) == 0)
                LastPageIndex = AllRowCount / PageSize;
            else
                LastPageIndex = AllRowCount / PageSize + 1;
            string typePaging = "";
            if (!String.IsNullOrEmpty(Request["type"])) typePaging = Request["type"].ToString();
            System.Collections.Generic.List<PageItem> PagingArray = HProtest_BLL.Helper.Utility.GetPagingArray(CurrentPageIndex-1, "news.aspx?type=" + typePaging, LastPageIndex, 3);

            rptPaging.DataSource = PagingArray;
            rptPaging.DataBind();

            //lblResultCount.Text = AllRowCount.ToString();
        }
        catch
        { }
    }
}

