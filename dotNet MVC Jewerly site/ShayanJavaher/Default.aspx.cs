using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using HProtest_BLL.Basket;
using HProtest_BLL.Manager;
using HProtest_DAL;
using ShayanDB_BLL;
using HProtest_BLL.ClassView;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    public Products Product = new Products();
    int PageSize = 18;
    private int CurrentPageIndex
    {
        get
        {
            if (Request["page"] == null)
                return 1;
            if (string.IsNullOrEmpty(Request["page"]))

                return 1;
            else
                return int.Parse(Request["page"]);
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int AllCurrentCount = 0;
            rptAdsBottomCenter.DataSource = HProtest_BLL.Advertise.AdvertiseData.GetAdvertiseList("", "", DateTime.Now.AddYears(-20), DateTime.Now.AddYears(20), 1, -1, 2, "tbAdvertise.Id", "desc", 0, 20, out AllCurrentCount);
            rptAdsBottomCenter.DataBind();
            try
            {
                rptPaging.Visible = false;
                if (Request.QueryString["type"] == null)
                {
                    Response.Redirect("~/default.aspx?type=all");
                }
                else
                {
                    string type = Request.QueryString["type"].ToString();
                    switch (type)
                    {
                        case "all":
                            lblDisplayTitle.Text = "تمام جواهرات";
                            DataListGetType.DataSource = ManagerData.GetProductInfo(0, "", "", 0, "", "", "none", null, null, -1, -1, "none", 0, 0, "none", 0, 5, 0, "desc", "tbl_product.insertdate", CurrentPageIndex - 1, PageSize, 1);
                            DataListGetType.DataBind();
                            rptPaging.Visible = true;
                            break;
                        case "newest":
                            lblDisplayTitle.Text = "جدیدترین جواهرات";
                            DataListGetType.DataSource = ManagerData.GetProductInfo(0, "", "", 0, "", "", "none", null, null, -1, -1, "none", 0, 0, "none", 0, 5, 0, "desc", "tbl_product.insertdate", CurrentPageIndex - 1, PageSize, 1);
                            DataListGetType.DataBind();
                            break;
                        case "visit":
                            lblDisplayTitle.Text = "پر بازدیدترین جواهرات";
                            DataListGetType.DataSource = ManagerData.GetProductInfo(0, "", "", 0, "", "", "none", null, null, -1, -1, "none", 0, 0, "none", 0, 5, 0, "desc", "tbl_product.visited", CurrentPageIndex - 1, PageSize, 1);
                            DataListGetType.DataBind();
                            break;
                        case "price":
                            lblDisplayTitle.Text = "گران قیمت ترین جواهرات";
                            DataListGetType.DataSource = ManagerData.GetProductInfo(0, "", "", 0, "", "", "none", null, null, -1, -1, "none", 0, 0, "none", 0, 5, 0, "desc", "tbl_product.price", CurrentPageIndex - 1, PageSize, 1);
                            DataListGetType.DataBind();
                            break;
                        case "point":
                            lblDisplayTitle.Text = " پر امتیازترین جواهرات";
                            DataListGetType.DataSource = ManagerData.GetProductInfo(0, "", "", 0, "", "", "none", null, null, -1, -1, "none", 0, 0, "none", 0, 5, 0, "desc", "tbl_product.point", CurrentPageIndex - 1, PageSize, 1);
                            DataListGetType.DataBind();
                            break;
                    }
                    if (HProtest_BLL.Helper.Utility.IsNumeric(type))
                    {
                        lblDisplayTitle.Text = " انواع ";
                        lblDisplayTitle.Text += Request["title"].ToString();
                        DataListGetType.DataSource = ManagerData.GetProductInfo(int.Parse(Request.QueryString["type"].ToString()), "desc", "tbl_product.id", CurrentPageIndex - 1, PageSize, 1);
                        DataListGetType.DataBind();
                        rptPaging.Visible = true;
                    }
                }
                int AllRowCount = 0;
                AllRowCount = int.Parse(Property.myCmd.Parameters["@AllCurrentCount"].Value.ToString());

                int LastPageIndex;
                if ((AllRowCount % PageSize) == 0)
                    LastPageIndex = AllRowCount / PageSize;
                else
                    LastPageIndex = AllRowCount / PageSize + 1;
                string title = "", typePaging = "";
                if (!String.IsNullOrEmpty(Request["type"])) typePaging = Request["type"].ToString();
                if (!String.IsNullOrEmpty(Request["title"])) title = Request["title"].ToString();
                System.Collections.Generic.List<PageItem> PagingArray = HProtest_BLL.Helper.Utility.GetPagingArray(CurrentPageIndex, "default.aspx?type=" + typePaging + "&title=" + title, LastPageIndex, 3);

                rptPaging.DataSource = PagingArray;
                rptPaging.DataBind();

            }
            catch { }
        }

    }
    protected void BuyProduct(object sender, CommandEventArgs e)
    {
        Page page = this.Page;
        if (Page.User.IsInRole("4"))
        {
            string Count=BasketTransfer.InsertBasketProduct(Page.User.Identity.Name, int.Parse(e.CommandArgument.ToString()));
            if (int.Parse(Count) >= 0)
                ((Main_MasterPage)this.Page.Master).setBasketCount(Count);
        }
        else
        {
            Response.Redirect("~/LoginOrRegister.aspx");
        }
    }
}