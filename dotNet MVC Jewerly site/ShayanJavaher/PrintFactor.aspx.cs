using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HProtest_BLL.Basket;

public partial class Manager_Basket_PrintFactor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.IsInRole("4"))
        {
            if (!IsPostBack)
            {
                    DataSet ds;
                    if (Request.QueryString["BasketID"] != null)
                        ds = BasketData.ProcessFactor(2, User.Identity.Name, int.Parse(Request.QueryString["BasketID"].ToString()));
                    else
                        ds = BasketData.ProcessFactor(0, User.Identity.Name);
                    if (ds != null)
                    {
                        System.Data.DataTable dtInfo = ds.Tables[1];
                        if (dtInfo.Rows[0]["Sex"].ToString() != "")
                            lblFullName.Text = dtInfo.Rows[0]["Sex"].ToString().ToLower() != "false" ? "سرکار خانم " : "جناب آقای ";
                        lblFullName.Text += dtInfo.Rows[0]["FirstName"].ToString() + " " + dtInfo.Rows[0]["LastName"].ToString();
                        lblInsertDate.Text = (string.IsNullOrEmpty(dtInfo.Rows[0]["InsertDate"].ToString())) ? "" : HProtest_BLL.Helper.Utility.GetPersianDate((DateTime)dtInfo.Rows[0]["InsertDate"]);
                        lblTel.Text = dtInfo.Rows[0]["Tel"].ToString();
                        lblMobile.Text = dtInfo.Rows[0]["Mobile"].ToString();
                        lblEmail.Text = dtInfo.Rows[0]["Email"].ToString();
                        lblZipCode.Text = dtInfo.Rows[0]["ZipCode"].ToString();
                        lblAddress.Text = dtInfo.Rows[0]["Province"].ToString() + " - " + dtInfo.Rows[0]["City"].ToString() + " - "
                            + dtInfo.Rows[0]["Address"].ToString();
                        lblDescription.Text = dtInfo.Rows[0]["Description"].ToString();
                        lblGiftName.Text = dtInfo.Rows[0]["GiftName"].ToString();
                        hfGiftPicture.Value = Page.ResolveUrl("~/Resource/ProductPic/") + dtInfo.Rows[0]["GiftPicture"].ToString();
                        lblFactorID.Text = dtInfo.Rows[0]["FactorID"].ToString();
                        lblSum.Text = HProtest_BLL.Common.DigitCommo(dtInfo.Rows[0]["Sum"].ToString());
                        lblNumRow.Text = dtInfo.Rows[0]["NumRow"].ToString();
                        rptProduct.DataSource = ds.Tables[0];
                        rptProduct.DataBind();
                    }
                    else
                        Response.Redirect("~/buybasket.aspx");
                }
                    }
        else
            Response.Redirect("~/buybasket.aspx");
    }
}