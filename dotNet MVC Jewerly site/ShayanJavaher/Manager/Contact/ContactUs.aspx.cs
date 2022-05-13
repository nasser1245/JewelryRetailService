using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShayanDB_BLL;
using HProtest_BLL.ContactFAQ;

public partial class Manager_ContactUs : System.Web.UI.Page

{

    int PageSize = 10;

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


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (HttpContext.Current.Session["AccessLevel"] == null)
                Response.Redirect("~/manager/login.aspx");

            if (Page.User.IsInRole("1") || ((HProtest_BLL.AccessLevel.AccessLevel)HttpContext.Current.Session["AccessLevel"]).SupportAgent == true)
            {
                BindGrid();
            }
            else
                Response.Redirect("~/manager/login.aspx");
        }
    }

    public void BindGrid()
    {
        int AllCurrentCount = 0;
        rptContactUs.DataSource = ContactData.GetContactList(out AllCurrentCount,-1,"desc",CurrentPageIndex-1,PageSize);
        rptContactUs.DataBind();
        lblAllCount.Text = AllCurrentCount.ToString();
        int LastPageIndex;
        if ((AllCurrentCount % PageSize) == 0)
            LastPageIndex = AllCurrentCount / PageSize;
        else
            LastPageIndex = AllCurrentCount / PageSize + 1;

      

        System.Collections.Generic.List<PageItem> PagingArray = HProtest_BLL.Helper.Utility.GetPagingArray( CurrentPageIndex, "ContactUs.aSPX?key=ora", LastPageIndex, 3);

        rptPaging.DataSource = PagingArray;
        rptPaging.DataBind();
    }

}
