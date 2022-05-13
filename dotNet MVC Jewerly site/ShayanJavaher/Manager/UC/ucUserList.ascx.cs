using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.Member;
using HProtest_BLL;
using HProtest_BLL.Helper;

public partial class Manager_UC_ucUserList : System.Web.UI.UserControl
{
    string sortDir = "desc", sortExpression = "tbMember.Id";
    int PageSize = 10;

    private enum PagingType
    {
        First = 0,
        Previuse,
        Next,
        Last,
        none
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["GoBackTo"] = Request.UrlReferrer;
            BindPagingGrid();
            SetPager(PagingType.none);
        }
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

    private void BindPagingGrid()
    {
        try
        {
            int AllCurrentCount = 0;
            // اگر مدیر اصلی بود یا اگر مدیر میانی بود باید دسترسی مسئول کاربران را داشته باشد
            if (Page.User.IsInRole("1") || ((HProtest_BLL.AccessLevel.AccessLevel)HttpContext.Current.Session["AccessLevel"]).UserAgent == true)
            {
                using (System.Data.DataTable dtPagedArticles = MemberData.GetMemberList(txtUserName.Text, txtName.Text, txtFamily.Text, txtEmail.Text, "4",
                    sortExpression, sortDir, CurrentPageIndex, PageSize, ref AllCurrentCount))
                {

                    if (dtPagedArticles != null && dtPagedArticles.Rows.Count > 0)
                    {
                        rptArticle.DataSource = dtPagedArticles;
                    }
                    rptArticle.DataBind();

                    AllRowCount = AllCurrentCount;
                }
                lblMsgResultCount.Text = "تعداد ردیف مورد جستجو: ";
                lblResultCount.Text = AllRowCount.ToString();
            }
            else
            {
                Utility.ShowMsg(Page, PropertyData.MsgType.warning, "شما اجازه ی دسترسی به این عملیات را ندارید");
                Response.Redirect(ViewState["GoBackTo"].ToString());

            }
        }
        catch (Exception ex)
        { }
    }

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

    protected void btnClearFilter_Click(object sender, EventArgs e)
    {
        txtFamily.Text = "";
        txtName.Text = "";
        txtUserName.Text = "";
        txtEmail.Text = "";

        BindPagingGrid();
        SetPager(PagingType.none);
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        CurrentPageIndex = 0;
        BindPagingGrid();
        SetPager(PagingType.none);
    }

}