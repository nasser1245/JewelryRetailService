using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.Library;
using HProtest_DAL;
using ShayanDB_BLL;
using HProtest_BLL.Helper;

public partial class Library : System.Web.UI.Page
{
    string sortDir = "desc", sortExpression = "tbl_Library.Id";
    int PageSize = 10;
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
        if (!Page.IsPostBack)
        {
            try
            {
                int AllCurrentCount = 0;
                int type = Request.QueryString["type"] == null ? -1 : int.Parse(Request.QueryString["type"]);
                        RepeaterLibraryList.DataSource = LibraryData.GetLibraryList(-1, "", "","", "", "", type,1, 1, "", "", -1, "tbl_Library.Id", "desc", CurrentPageIndex - 1, PageSize, out AllCurrentCount);
                        RepeaterLibraryList.DataBind();
                    
                AllRowCount = AllCurrentCount;

                int LastPageIndex;
                if ((AllRowCount % PageSize) == 0)
                    LastPageIndex = AllRowCount / PageSize;
                else
                    LastPageIndex = AllRowCount / PageSize + 1;
                string typePaging = "";
                if (!String.IsNullOrEmpty(Request["type"])) typePaging = Request["type"].ToString();
                System.Collections.Generic.List<PageItem> PagingArray = HProtest_BLL.Helper.Utility.GetPagingArray(CurrentPageIndex, "Library.aspx?type=" + typePaging, LastPageIndex, 3);

                rptPaging.DataSource = PagingArray;
                rptPaging.DataBind();

            }
            catch { }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindPagingGrid();

    }
    private void BindPagingGrid()
    {
        try
        {
            int AllCurrentCount = 0;
            DateTime From = new DateTime(1985, 1, 1);
            DateTime To = new DateTime(2100, 1, 1);
            int type = Request.QueryString["type"] == null ? -1 : int.Parse(Request.QueryString["type"]);
            using (System.Data.DataTable dtPagedArticles = LibraryData.GetLibraryList(-1, "", Server.HtmlEncode(txtTitle.Text.Trim()), "", "","", type,1, 1, From, To, -1, sortExpression, sortDir, CurrentPageIndex - 1, PageSize, out AllCurrentCount))
            {
                if (dtPagedArticles != null && dtPagedArticles.Rows.Count > 0)
                {
                    RepeaterLibraryList.DataSource = dtPagedArticles;
                }
                RepeaterLibraryList.DataBind();

            }

            AllRowCount = AllCurrentCount;

            int LastPageIndex;
            if ((AllRowCount % PageSize) == 0)
                LastPageIndex = AllRowCount / PageSize;
            else
                LastPageIndex = AllRowCount / PageSize + 1;
            string typePaging = "";
            if (!String.IsNullOrEmpty(Request["type"])) typePaging = Request["type"].ToString();
            System.Collections.Generic.List<PageItem> PagingArray = HProtest_BLL.Helper.Utility.GetPagingArray(CurrentPageIndex, "Library.aspx?type=" + typePaging, LastPageIndex, 3);

            rptPaging.DataSource = PagingArray;
            rptPaging.DataBind();

        }
        catch
        { }
    }
    protected void lbPageing_Click(object sender, EventArgs e)
    {
        //txtPageCount.Text = "1";
        BindPagingGrid();
        //SetPager(PagingType.none);

    }
}