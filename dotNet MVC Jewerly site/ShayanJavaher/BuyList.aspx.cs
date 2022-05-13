using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.Basket;

public partial class BuyList : System.Web.UI.Page
{
    int BasketCount;
    int PayCount;
    public bool NullList;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.User.IsInRole("4"))
        {
            Response.Redirect("~/default.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                string UserName = Page.User.Identity.Name;
                RepeaterBuyList.DataSource = BasketData.GetBasketList(UserName, out BasketCount, out PayCount);
                RepeaterBuyList.DataBind();
                lblGetCountTotal.Text = BasketCount.ToString();
                lblGetPiceTotal.Text = PayCount.ToString();

                if (RepeaterBuyList.Items.Count < 1)
                    NullList = true;
                else
                    NullList = false;
            }
            else
            {
            }
        }
    }
}