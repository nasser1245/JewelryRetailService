using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.Manager;
using ShayanDB_BLL;
using HProtest_DAL;
using HProtest_BLL.Basket;

public partial class Search : System.Web.UI.Page
{
    int PageSize = 10;

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

    public void BindPagingGrid(int ISSearchClick = 0)
    {
        int minPrice = 0, maxPrice = 0, minPoint = 0, maxPoint = 0, equlPoint = 0; object From = DateTime.Now.AddYears(-30), To = DateTime.Now;
        string ProductType = "0";

        if (!HProtest_BLL.Helper.Utility.IsNumeric(DropDownTypeProduct.SelectedValue))
        {
            HProtest_BLL.Helper.Utility.ShowMsg(this, HProtest_BLL.PropertyData.MsgType.warning, "مقدار نوع دستکاری شده!.");

            return;


        }

        if (!String.IsNullOrEmpty(txtMin.Text))
        {
            if (!HProtest_BLL.Helper.Utility.IsNumeric(txtMin.Text))
            {
                HProtest_BLL.Helper.Utility.ShowMsg(this, HProtest_BLL.PropertyData.MsgType.warning, "قیمت ها را بصورت عدد وارد کنید.");

                return;
            }
            minPrice = int.Parse(txtMin.Text);
        }

        if (!String.IsNullOrEmpty(txtMax.Text))
        {
            if (!HProtest_BLL.Helper.Utility.IsNumeric(txtMax.Text))
            {
                HProtest_BLL.Helper.Utility.ShowMsg(this, HProtest_BLL.PropertyData.MsgType.warning, "قیمت ها را بصورت عدد وارد کنید.");
                return;
            }
            maxPrice = int.Parse(txtMax.Text);
        }


        if (!String.IsNullOrEmpty(txtminPoint.Text))
        {
            if (!HProtest_BLL.Helper.Utility.IsNumeric(txtminPoint.Text))
            {
                HProtest_BLL.Helper.Utility.ShowMsg(this, HProtest_BLL.PropertyData.MsgType.warning, "قیمت ها را بصورت عدد وارد کنید.");

                return;
            }
            minPoint = int.Parse(txtminPoint.Text);
        }

        if (!String.IsNullOrEmpty(txtmaxPoint.Text))
        {
            if (!HProtest_BLL.Helper.Utility.IsNumeric(txtmaxPoint.Text))
            {
                HProtest_BLL.Helper.Utility.ShowMsg(this, HProtest_BLL.PropertyData.MsgType.warning, "قیمت ها را بصورت عدد وارد کنید.");
                return;
            }
            maxPoint = int.Parse(txtmaxPoint.Text);
        }



        if (!String.IsNullOrEmpty(txtFrom.Text))
        {
            if (!HProtest_BLL.Helper.Utility.IsDateTime(txtFrom.Date.Value))
            {
                HProtest_BLL.Helper.Utility.ShowMsg(this, HProtest_BLL.PropertyData.MsgType.warning, "تاریخ را درست وارد کنید.");

                return;
            }
            From = txtFrom.Date.Value;
        }
        if (!String.IsNullOrEmpty(txtTo.Text))
        {
            if (!HProtest_BLL.Helper.Utility.IsDateTime(txtTo.Date.Value))
            {
                HProtest_BLL.Helper.Utility.ShowMsg(this, HProtest_BLL.PropertyData.MsgType.warning, "تاریخ را درست وارد کنید.");
                return;
            }
            To = txtTo.Date.Value;
        }


        ProductType = DropDownTypeProduct.SelectedValue;

        if (DropDownPrice.SelectedIndex == 0)
        {
            minPrice = 0;
            maxPrice = 0;
        }

        if (DropDownPoint.SelectedIndex == 0)
        {
            minPoint = 0;
            maxPoint = 0;
        }

        if (DropDownPoints.SelectedValue != "0")
        {
            equlPoint = int.Parse(DropDownPoints.SelectedValue);
        }

        //تعیین این که بر چه اساسی بر اساس تاریخ جستجو کند
        string IsSearchDate = "none";
        if (string.IsNullOrEmpty(txtFrom.Text) && string.IsNullOrEmpty(txtTo.Text)) IsSearchDate = "none";
        else if (!string.IsNullOrEmpty(txtFrom.Text) && string.IsNullOrEmpty(txtTo.Text)) IsSearchDate = "more";
        else if (string.IsNullOrEmpty(txtFrom.Text) && !string.IsNullOrEmpty(txtTo.Text)) IsSearchDate = "less";
        else if (!string.IsNullOrEmpty(txtFrom.Text) && !string.IsNullOrEmpty(txtTo.Text)) IsSearchDate = "both";

        int tmpCurrentPageIndex = 0;
        if (ISSearchClick == 1)
        {
            tmpCurrentPageIndex = 1;
        }

        string SortDirections = "desc";
        string SortExpression = "tbl_product.id";
        if (rdbCode.Checked)
            SortExpression = "tbl_product.id";
        else if (rdbDate.Checked)
            SortExpression = "tbl_product.insertdate";
        else if (rdbPoint.Checked)
            SortExpression = "tbl_product.point";
        else if (rdbPrice.Checked)
            SortExpression = "tbl_product.price";

        if (rdbdesc.Checked)
            SortDirections = "desc";
        else if (rdbasc.Checked)
            SortDirections = "asc";

        if (String.IsNullOrEmpty(txtPageSize.Text))
            PageSize = 10;
        else
            if (HProtest_BLL.Helper.Utility.IsNumeric(txtPageSize.Text))
                PageSize = int.Parse(txtPageSize.Text);
            else
                PageSize = 10;
        try
        {
            string title = "";
            if (!string.IsNullOrEmpty(Request["SqFt"]))
                title = Request["SqFt"].ToString();
            else
                title = txtName.Text;

            DataListGetType.DataSource = ManagerData.GetProductInfo(0, "", title, int.Parse(ProductType), txtAboutProduct.Text, txtDesp.Text, IsSearchDate, From, To,
                int.Parse(DropDownLuxe.SelectedValue), int.Parse(DropDownSize.SelectedValue), DropDownPrice.SelectedValue, minPrice, maxPrice, equlPoint == 0 ? DropDownPoint.SelectedValue : "equl", minPoint, maxPoint, equlPoint
                , SortDirections, SortExpression, tmpCurrentPageIndex != 0 ? tmpCurrentPageIndex - 1 : CurrentPageIndex - 1, PageSize, 1);
            DataListGetType.DataBind();
            int AllRowCount = 0;
            AllRowCount = int.Parse(Property.myCmd.Parameters["@AllCurrentCount"].Value.ToString());

            int LastPageIndex;
            if ((AllRowCount % PageSize) == 0)
                LastPageIndex = AllRowCount / PageSize;
            else
                LastPageIndex = AllRowCount / PageSize + 1;

            System.Collections.Generic.List<PageItem> PagingArray = HProtest_BLL.Helper.Utility.GetPagingArray(tmpCurrentPageIndex != 0 ? tmpCurrentPageIndex : CurrentPageIndex, "sEArcH.AsPX?key=ora", LastPageIndex, 3);

            lblDisplayTitle.Text = "تعداد مورد جستجو " + AllRowCount.ToString();
            rptPaging.DataSource = PagingArray;
            rptPaging.DataBind();
        }
        catch { }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DropDownTypeProduct.Items.Add(new System.Web.UI.WebControls.ListItem("انتخاب کنید", "0"));
            DropDownTypeProduct.DataSource = ManagerData.GetMenuList("-1", "0");
            DropDownTypeProduct.DataTextField = "type";
            DropDownTypeProduct.DataValueField = "id";
            DropDownTypeProduct.DataBind();

            BindPagingGrid();
        }
    }
    //protected void btnSearchProduct_Click(object sender, ImageClickEventArgs e)
    //{
    //    BindPagingGrid(1);

    //}
    protected void btnRemoveFilters_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/SeArCH.AsPX");

    }

    protected void lbPageing_Click(object sender, EventArgs e)
    {
        //txtPageCount.Text = "1";
        BindPagingGrid();
        //SetPager(PagingType.none);

    }
    protected void BuyProduct(object sender, CommandEventArgs e)
    {
        if (Page.User.IsInRole("4"))
        {
            string Count = BasketTransfer.InsertBasketProduct(Page.User.Identity.Name, int.Parse(e.CommandArgument.ToString()));
            if (int.Parse(Count) >= 0)
                ((Main_MasterPage)this.Page.Master).setBasketCount(Count);
        }
        else
        {
            Response.Redirect("~/LoginOrRegister.aspx");
        }
    }


    protected void btnSearchProduct_Click(object sender, EventArgs e)
    {
        BindPagingGrid(1);
    }
    
}