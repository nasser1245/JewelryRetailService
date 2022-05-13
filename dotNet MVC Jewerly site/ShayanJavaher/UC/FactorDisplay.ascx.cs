using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.Basket;
using HProtest_BLL.Helper;

public partial class UC_FactorDisplay : System.Web.UI.UserControl
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        string UserName = Page.User.Identity.Name;
        System.Data.DataSet ds;
        if (Request.QueryString["BasketID"] != null)
            ds = BasketData.ProcessFactor(2, UserName, int.Parse(Request.QueryString["BasketID"].ToString()));
        else
            ds = BasketData.ProcessFactor(0, UserName);
        if ( ds!= null)
        {
            System.Data.DataTable dtInfo = ds.Tables[1];
            string s = dtInfo.Rows[0]["Sex"].ToString();
            if (dtInfo.Rows[0]["Sex"].ToString() != "")
                lblFullName.Text = dtInfo.Rows[0]["Sex"].ToString().ToLower() != "false" ? "سرکار خانم " : "جناب آقای ";
            lblFullName.Text += dtInfo.Rows[0]["FirstName"].ToString() + " " + dtInfo.Rows[0]["LastName"].ToString();
            lblBasketStatus.Text = dtInfo.Rows[0]["BasketStatus"].ToString();
            lblInsertDate.Text = Utility.GetPersianDate((DateTime)dtInfo.Rows[0]["InsertDate"]);
            lblTel.Text = dtInfo.Rows[0]["Tel"].ToString();
            lblMobile.Text = dtInfo.Rows[0]["Mobile"].ToString();
            lblEmail.Text = dtInfo.Rows[0]["Email"].ToString();
            lblZipCode.Text = dtInfo.Rows[0]["ZipCode"].ToString();
            lblAddress.Text = dtInfo.Rows[0]["Province"].ToString() + " - " + dtInfo.Rows[0]["City"].ToString() + " - "
                + dtInfo.Rows[0]["Address"].ToString();
            lblDescription.Text =dtInfo.Rows[0]["Description"].ToString();
            lblGiftName.Text = dtInfo.Rows[0]["GiftName"].ToString();
            hfGiftPicture.Value = Page.ResolveUrl("~/Resource/ProductPic/") + dtInfo.Rows[0]["GiftPicture"].ToString();
            lblFactorID.Text = dtInfo.Rows[0]["FactorID"].ToString();
            lblSum.Text =HProtest_BLL.Common.DigitCommo(dtInfo.Rows[0]["Sum"].ToString());
            lblNumRow.Text = dtInfo.Rows[0]["NumRow"].ToString();
            RepeaterBuyBasket.DataSource = ds.Tables[0];
            RepeaterBuyBasket.DataBind();
        }
        else
            Response.Redirect("~/BuyBasket.aspx");
    }
    protected void btnPrintFactor_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["BasketID"] != null)
            Response.Redirect("~/PrintFactor.aspx?BasketID=" + Request.QueryString["BasketID"].ToString());
        else
            Response.Redirect("~/PrintFactor.aspx"); 
    }

}