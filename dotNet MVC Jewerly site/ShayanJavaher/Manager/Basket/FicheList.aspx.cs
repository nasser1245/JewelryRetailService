using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.Basket;
using ShayanDB_BLL;

public partial class Manager_BuyBasket_FicheList : System.Web.UI.Page
{
    public bool NullBasket;
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
        if (HttpContext.Current.Session["AccessLevel"] == null)
            Response.Redirect("~/manager/login.aspx");
        
        if (Page.User.IsInRole("1") || ((HProtest_BLL.AccessLevel.AccessLevel)HttpContext.Current.Session["AccessLevel"]).SellAgent == true)
        {
            if (!IsPostBack)
            {
                ddlFicheType.Items.Insert(0, new ListItem("", ""));
                ddlFicheType.Items.Insert(1, new ListItem("بانکی", "بانکی"));
                ddlFicheType.Items.Insert(2, new ListItem("خودپرداز", "خودپرداز"));
                ddlFicheType.Items.Insert(3, new ListItem("سایر", "سایر"));
                BindGrid();
             
            }
        }
        else
            Response.Redirect("~/manager/login.aspx");
    }

    public void BindGrid(int ISSearchClick = 0)
    {
     int AllRow=0;
     int tmpCurrentPageIndex = 0;
     if (ISSearchClick == 1)
     {
         tmpCurrentPageIndex = 1;
     }
     RepeaterFicheList.DataSource = BasketData.GetAllFiche(out AllRow, ddlFicheType.SelectedItem.ToString(), txtFactorID.Text, txtSerial.Text, string.IsNullOrEmpty(txtBeginPayDate.Text) ? "" : txtBeginPayDate.Date.Value.ToString(),
         string.IsNullOrEmpty(txtEndPayDate.Text) ? "" : txtEndPayDate.Date.Value.ToString(), txtMinPrice.Text, txtMaxPrice.Text, "", txtFullName.Text, (tmpCurrentPageIndex != 0 ? tmpCurrentPageIndex : CurrentPageIndex).ToString(), PageSize.ToString());
     RepeaterFicheList.DataBind();
        //RepeaterBuyList.DataSource = BasketData.GetAllBasket(out AllRow, txtFactorID.Text, string.IsNullOrEmpty(txtBeginPostDate.Text) ? "" : txtBeginPostDate.Date.Value.ToString(),
        //    string.IsNullOrEmpty(txtEndPostDate.Text) ? "" : txtEndPostDate.Date.Value.ToString(), string.IsNullOrEmpty(txtBeginPayDate.Text) ? "" : txtBeginPayDate.Date.Value.ToString(),
        //    string.IsNullOrEmpty(txtEndPayDate.Text) ? "" : txtEndPayDate.Date.Value.ToString(), ddlStatus.SelectedValue, txtUserName.Text, txtGift.Text, txtMinPrice.Text, txtMaxPrice.Text, (tmpCurrentPageIndex != 0 ? tmpCurrentPageIndex : CurrentPageIndex).ToString(), PageSize.ToString());
        //RepeaterBuyList.DataBind();
     if (RepeaterFicheList.Items.Count < 1)
            NullBasket = true;
        lblGetCountTotal.Text = AllRow.ToString();

       

        int LastPageIndex;
        if ((AllRow % PageSize) == 0)
            LastPageIndex = AllRow / PageSize;
        else
            LastPageIndex = AllRow / PageSize + 1;

        System.Collections.Generic.List<PageItem> PagingArray = HProtest_BLL.Helper.Utility.GetPagingArray(tmpCurrentPageIndex != 0 ? tmpCurrentPageIndex : CurrentPageIndex, "BasketList.aSPX?key=ora", LastPageIndex, 3);

        rptPaging.DataSource = PagingArray;
        rptPaging.DataBind();

    
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindGrid(1);
    }

    protected void lbPageing_Click(object sender, EventArgs e)
    {
        BindGrid();
    }

}