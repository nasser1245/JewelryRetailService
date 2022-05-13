using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.Manager;
using HProtest_BLL.Member;
using JQControls;
using HProtest_DAL;
using HProtest_BLL;
using ShayanDB_BLL;

public partial class Manager_Product_ProductList : System.Web.UI.Page
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

    public void BindPagingGrid(int ISSearchClick=0)
    {
        int minPrice = 0, maxPrice = 0, minPoint = 0, maxPoint = 0, minLimit = 0, maxLimit = 0, equlPoint = 0; object From = DateTime.Now.AddYears(-30), To = DateTime.Now;
        string ProductType = "0";

        if (!HProtest_BLL.Helper.Utility.IsNumeric(ddlTypeProduct.SelectedValue))
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

        if (!String.IsNullOrEmpty(txtFromPrice.Text))
        {
            if (!HProtest_BLL.Helper.Utility.IsNumeric(txtFromPrice.Text))
            {
                HProtest_BLL.Helper.Utility.ShowMsg(this, HProtest_BLL.PropertyData.MsgType.warning, "قیمت ها را بصورت عدد وارد کنید.");

                return;
            }
            minLimit = int.Parse(txtFromPrice.Text);
        }

        if (!String.IsNullOrEmpty(TextToPrice.Text))
        {
            if (!HProtest_BLL.Helper.Utility.IsNumeric(TextToPrice.Text))
            {
                HProtest_BLL.Helper.Utility.ShowMsg(this, HProtest_BLL.PropertyData.MsgType.warning, "قیمت ها را بصورت عدد وارد کنید.");
                return;
            }
            maxLimit = int.Parse(TextToPrice.Text);
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


        ProductType = ddlTypeProduct.SelectedValue;

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

        string UserName = "";
        if (!Page.User.IsInRole("1"))
            UserName = Page.User.Identity.Name;
        Repeater1.DataSource = ManagerData.GetProductInfo(0, UserName, txtName.Text, int.Parse(ProductType), txtAboutProduct.Text, txtDesp.Text, IsSearchDate, From, To,
            int.Parse(DropDownLuxe.SelectedValue), int.Parse(DropDownSize.SelectedValue), DropDownPrice.SelectedValue, minPrice, maxPrice,equlPoint==0? DropDownPoint.SelectedValue:"equl", minPoint, maxPoint, equlPoint
            , "desc", "tbl_product.id",tmpCurrentPageIndex!=0?tmpCurrentPageIndex-1: CurrentPageIndex-1, PageSize,-1,ddlgift.SelectedValue,minLimit,maxLimit);
        Repeater1.DataBind();
        int AllRowCount = 0;
        AllRowCount = int.Parse(Property.myCmd.Parameters["@AllCurrentCount"].Value.ToString());

        int LastPageIndex;
        if ((AllRowCount % PageSize) == 0)
            LastPageIndex = AllRowCount / PageSize;
        else
            LastPageIndex = AllRowCount / PageSize + 1;

        System.Collections.Generic.List<PageItem> PagingArray = HProtest_BLL.Helper.Utility.GetPagingArray(tmpCurrentPageIndex != 0 ? tmpCurrentPageIndex : CurrentPageIndex, "prOdUCtLiST.aSPX?key=ora", LastPageIndex, 3);

        rptPaging.DataSource = PagingArray;
        rptPaging.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["AccessLevel"] == null)
            Response.Redirect("~/manager/login.aspx");

        if (Page.User.IsInRole("1") || ((HProtest_BLL.AccessLevel.AccessLevel)HttpContext.Current.Session["AccessLevel"]).ProductAgent == true)
        {


            if (!Page.IsPostBack)
            {
                ddlTypeProductParrent.Items.Add(new System.Web.UI.WebControls.ListItem("انتخاب کنید", "-1"));
                ddlTypeProductParrent.DataSource = ManagerData.GetMenu(0);
                ddlTypeProductParrent.DataTextField = "type";
                ddlTypeProductParrent.DataValueField = "id";
                ddlTypeProductParrent.DataBind();

                try
                {
                    ddlTypeProduct.Items.Add(new System.Web.UI.WebControls.ListItem("انتخاب کنید", "0"));
                    ddlTypeProduct.DataSource = ManagerData.GetMenuByParent(int.Parse(ddlTypeProductParrent.SelectedValue));
                    ddlTypeProduct.DataTextField = "type";
                    ddlTypeProduct.DataValueField = "id";
                   
                    ddlTypeProduct.DataBind();
                }
                catch { }
                BindPagingGrid();
                //SetPager(PagingType.none);

                if (Request["r"] != null)
                {
                    if (Request["r"].ToString() == "ok")
                        HProtest_BLL.Helper.Utility.ShowMsg(this, HProtest_BLL.PropertyData.MsgType.accept, "عملیات با موفقیت انجام شد.");
                    if (Request["r"].ToString() == "stop")
                        HProtest_BLL.Helper.Utility.ShowMsg(this, HProtest_BLL.PropertyData.MsgType.accept, "عملیات متوقف شد.");
                }

            }

        }
        else
            Response.Redirect("~/manager/login.aspx");
    }

    public void lbEditProduct_Command(object sender, CommandEventArgs e)
    {
        string[] fields = e.CommandArgument.ToString().Split(',');
        Response.Redirect("AddProduct.aspx?id=" + fields[0] + "&extPic=" + fields[1] + "&extVid=" + fields[2]);
    }
    public void lblDeleteProduct_Command(object sender, CommandEventArgs e)
    {
        string[] fields = e.CommandArgument.ToString().Split(',');
        string path = Server.MapPath("~\\Resource\\ProductPic\\");

        Common.DelFile(path + fields[1]);
        path = Server.MapPath("~\\Resource\\ProductVideo\\");
        Common.DelFile(path + fields[2]);

        ManagerData.DeleteProduct(int.Parse(fields[0]));
        Repeater1.DataSource = ManagerData.GetProductInfo();
        Repeater1.DataBind();
    }
  
    protected void lbPageing_Click(object sender, EventArgs e)
    {
        //txtPageCount.Text = "1";
        BindPagingGrid();
        //SetPager(PagingType.none);

    }
    
   

    protected void btnTempforPageCount_Click(object sender, EventArgs e)
    {
       
    }

    protected void imgbtnRemoveFilters_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("pRoDUcTlIsT.AsPX");
    }
    protected void btnSearchProduct_Click(object sender, ImageClickEventArgs e)
    {
        BindPagingGrid(1);
    }
    protected void ddlTypeProductParrent_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlTypeProduct.Items.Clear();
        ddlTypeProduct.Items.Add(new System.Web.UI.WebControls.ListItem("انتخاب کنید", "0"));
        ddlTypeProduct.DataSource = ManagerData.GetMenuByParent(int.Parse(ddlTypeProductParrent.SelectedValue));
        ddlTypeProduct.DataTextField = "type";
        ddlTypeProduct.DataValueField = "id";
        //ddlTypeProduct.Items.Insert(0, new ListItem("انتخاب کنید...", "-1"));
        ddlTypeProduct.DataBind();
    }

}