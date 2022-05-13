using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using HProtest_BLL.Library;
using ShayanDB_BLL;
using HProtest_BLL.Helper;


public partial class Manager_Library_LibraryList : System.Web.UI.Page
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
            if (ViewState["pageindex"] == null)
                ViewState["pageindex"] = 0;
            return Convert.ToInt32(ViewState["pageindex"]);
        }
        set { ViewState["pageindex"] = value; }
    }

    private int AllRowCount
    {
        get
        {
            if (ViewState["rowcount"] == null)
                ViewState["rowcount"] = 0;
            return Convert.ToInt32(ViewState["rowcount"]);
        }
        set { ViewState["rowcount"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["AccessLevel"] == null)
            Response.Redirect("~/manager/login.aspx");
        if (Page.User.IsInRole("1") || ((HProtest_BLL.AccessLevel.AccessLevel)HttpContext.Current.Session["AccessLevel"]).LibraryAgent == true)
        {
        if (!IsPostBack)
        {
            ddlLibraryCategory.Items.Add(new System.Web.UI.WebControls.ListItem("انتخاب کنید", "-1"));
            ddlLibraryCategory.DataSource = GetData.GetTable("tbl_LibraryCategory");
            ddlLibraryCategory.DataValueField = "Id";
            ddlLibraryCategory.DataTextField = "Title";
            ddlLibraryCategory.DataBind();

            BindPagingGrid();
            SetPager(PagingType.none);
        }
        else
        {

        }
            }
        else
            Response.Redirect("~/manager/login.aspx");

        if (!Page.IsPostBack)
        {
            if (Request["r"] != null)
            {
                if (Request["r"].ToString() == "ok")
                    HProtest_BLL.Helper.Utility.ShowMsg(this, HProtest_BLL.PropertyData.MsgType.accept, "عملیات با موفقیت انجام شد.");
                if (Request["r"].ToString() == "stop")
                    HProtest_BLL.Helper.Utility.ShowMsg(this, HProtest_BLL.PropertyData.MsgType.warning, "عملیات متوقف شد.");
            }
        }
    }
    [WebMethod]
    public static int DeleteArticle(string Id)
    {
        try
        {
            if (Id != null && Id != "" && Id != "undefined")
            {
                using (System.Data.DataTable dtResult = LibraryTransfer.DeleteLibrary(int.Parse(Id)))
                {
                    if (dtResult != null && dtResult.Rows.Count > 0)
                    {
                        string imageName = dtResult.Rows[0]["imageName"].ToString();
                        if (!string.IsNullOrEmpty(imageName))
                        {
                            string pic = System.Web.HttpContext.Current.Server.MapPath("~/Resource/Library/" + Id +imageName.Trim());
                            if (System.IO.File.Exists(pic))
                                System.IO.File.Delete(pic);
                        }

                        string FileName = dtResult.Rows[0]["fileName"].ToString();
                        if (!string.IsNullOrEmpty(FileName))
                        {
                            string pic = System.Web.HttpContext.Current.Server.MapPath("~/Resource/LibraryFiles/" + Id + FileName.Trim());
                            if (System.IO.File.Exists(pic))
                                System.IO.File.Delete(pic);
                        }
                    }
                }
            }
            else
            {
                throw new ApplicationException("Error");
            }
        }
        catch
        {
            throw new ApplicationException("Error");
        }

        return 1;
    }
    

    private void BindPagingGrid()
    {
        try
        {
            string UserName = "";
            int AllCurrentCount = 0;
            DateTime DateFrom = new DateTime(1753, 1, 1);
            DateTime DateTo = new DateTime(9999, 1, 1);

            if (!Page.User.IsInRole("1"))
                UserName = Page.User.Identity.Name;
            using (System.Data.DataTable dtPagedArticles =
                        LibraryData.GetLibraryList(-1, UserName, Server.HtmlEncode(txtTitle.Text.Trim()), "", Server.HtmlEncode(txtSummary.Text.Trim()), Server.HtmlEncode(txtLink.Text.Trim()), int.Parse(ddlLibraryCategory.SelectedValue),
                -1,int.Parse(ddlVisible.SelectedValue), DateFrom, DateTo, -1, sortExpression, sortDir, CurrentPageIndex, PageSize, out AllCurrentCount))
            {
                if (dtPagedArticles != null && dtPagedArticles.Rows.Count > 0)
                {
                    rptArticle.DataSource = dtPagedArticles;
                }
                rptArticle.DataBind();

            }

            AllRowCount = AllCurrentCount;
            lblResultCount.Text = AllRowCount.ToString();
        }
        catch
        { }
    }

    #region pager methodes
    private void SetPager(PagingType Type)
    {
        try
        {
            int LastPageIndex = 0;

            if ((AllRowCount % PageSize) == 0)
                LastPageIndex = AllRowCount / PageSize;
            else
                LastPageIndex = AllRowCount / PageSize + 1;

            switch (Type)
            {
                case PagingType.First:
                    CurrentPageIndex = 0;
                    BindPagingGrid();
                    break;
                case PagingType.Previuse:
                    if (CurrentPageIndex >= 0)
                        CurrentPageIndex = CurrentPageIndex - 1;
                    BindPagingGrid();
                    break;
                case PagingType.Next:
                    if (CurrentPageIndex + 1 != LastPageIndex)
                        CurrentPageIndex = CurrentPageIndex + 1;
                    BindPagingGrid();
                    break;
                case PagingType.Last:
                    CurrentPageIndex = LastPageIndex - 1;
                    BindPagingGrid();
                    break;
                default:
                    break;
            }

            if (CurrentPageIndex == 0)
                imgbtnFirst.Visible = imgbtnPrev.Visible = false;
            else
                imgbtnFirst.Visible = imgbtnPrev.Visible = true;

            if (CurrentPageIndex + 1 == LastPageIndex)
                imgbtnLast.Visible = imgbtnNext.Visible = false;
            if (CurrentPageIndex + 1 < LastPageIndex)
                imgbtnLast.Visible = imgbtnNext.Visible = true;

            lblPagNumber.Text = "صفحه " + (CurrentPageIndex + 1).ToString() + " از " + LastPageIndex.ToString();
        }
        catch
        { }
    }

    protected void imgbtnNext_Click(object sender, ImageClickEventArgs e)
    {
        SetPager(PagingType.Next);
    }

    protected void imgbtnLast_Click(object sender, ImageClickEventArgs e)
    {
        SetPager(PagingType.Last);
    }

    protected void imgbtnPrev_Click(object sender, ImageClickEventArgs e)
    {
        SetPager(PagingType.Previuse);
    }

    protected void imgbtnFirst_Click(object sender, ImageClickEventArgs e)
    {
        SetPager(PagingType.First);
    }
    #endregion

    [WebMethod]
    public static System.Collections.ArrayList GetSubs(int IdGroup, int gType)
    {
        if (IdGroup != -1)//validate group id
        {

            using (System.Data.DataTable dtResult = GetData.GetTable("tbl_LibraryCategory"))
            {
                System.Collections.ArrayList subsResult = new System.Collections.ArrayList();
                if (dtResult.Rows.Count > 0)
                {
                    foreach (System.Data.DataRow item in dtResult.Rows)
                    {
                        subsResult.Add(new { Value = item["id"], Display = item["title"] });
                    }
                    return subsResult;
                }
                else
                {
                    subsResult.Add(new { Value = -1, Display = "ـــــــــ" });
                    return subsResult;
                }
            }
        }
        else
        {
            throw new ApplicationException("Invalid Groub ID");
        }
    }

    private static System.Data.DataTable GetSubsDt(int IdGroup, int gType)
    {
        switch (gType)
        {
            case 0:
                return null;
            case 1:
                return null;
            default:
                return null;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        CurrentPageIndex = 0;
        BindPagingGrid();
        SetPager(PagingType.none);
    }

    protected void btnClearFilter_Click(object sender, EventArgs e)
    {
        ddlLibraryCategory.SelectedIndex = 0;
        ddlVisible.SelectedIndex = 0;
        txtSummary.Text = "";
        txtTitle.Text = "";

        BindPagingGrid();
        SetPager(PagingType.none);
    }



    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Manager/Library/LibraryContent.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}