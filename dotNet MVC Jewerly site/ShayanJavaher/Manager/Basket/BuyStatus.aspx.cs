using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.Basket;
using System.Data;
using HProtest_BLL.Helper;

public partial class Manager_Basket_BuyStatus : System.Web.UI.Page
{
    public bool InvalidFactorID = true;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["AccessLevel"] == null)
            Response.Redirect("~/manager/login.aspx");

        if (Page.User.IsInRole("1") || ((HProtest_BLL.AccessLevel.AccessLevel)HttpContext.Current.Session["AccessLevel"]).SellAgent == true)
        {
            if (!IsPostBack)
            {
                txtSearch.Text = "";
                if (Request.QueryString["FactorID"] != null)
                {
                    string FactorID = Request.QueryString["FactorID"].ToString();
                    DataSet ds = BasketData.ProcessFactor(3, "", 0, FactorID); ;
                    rptProduct.DataSource = BasketData.ProcessFactor(3, "", 0, FactorID);
                    if (ds != null)
                    {
                        System.Data.DataTable dtInfo = ds.Tables[1];
                        hfBasketID.Value = dtInfo.Rows[0]["BasketID"].ToString();
                        lblUserName.Text = dtInfo.Rows[0]["UserName"].ToString();
                        if (dtInfo.Rows[0]["Sex"].ToString() != "")
                            lblFullName.Text = dtInfo.Rows[0]["Sex"].ToString().ToLower() != "false" ? "سرکار خانم " : "جناب آقای ";
                        lblFullName.Text += dtInfo.Rows[0]["FirstName"].ToString() + " " + dtInfo.Rows[0]["LastName"].ToString();
                        lblBasketStatus1.Text = lblBasketStatus.Text = dtInfo.Rows[0]["BasketStatus"].ToString();
                        lblInsertDate.Text = (string.IsNullOrEmpty(dtInfo.Rows[0]["InsertDate"].ToString())) ? "" :Utility.GetPersianDate((DateTime)dtInfo.Rows[0]["InsertDate"]);
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
                        ddlStatus.DataSource = ShayanDB_BLL.GetData.GetTable("tbl_BasketStatus");
                        ddlStatus.DataTextField = "Type";
                        ddlStatus.DataValueField = "ID";
                        ddlStatus.DataBind();
                        ddlStatus.Items.Insert(0, new ListItem("", ""));
                        InvalidFactorID = false;
                    }
                    else
                        InvalidFactorID = true;

                }


            }
        }
        else
            Response.Redirect("~/manager/login.aspx");
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/manager/Basket/BasketList.aspx");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtSearch.Text))
            Response.Redirect("~/manager/Basket/BuyStatus.aspx?FactorID=" + txtSearch.Text);
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        BasketTransfer.UpdateBasketStatus(int.Parse(hfBasketID.Value.ToString()), int.Parse(ddlStatus.SelectedValue.ToString()));
        Response.Redirect("~/manager/Basket/BuyStatus.aspx?FactorID=" + lblFactorID.Text);

    }
    protected void btnPrintFactor_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/manager/Basket/PrintFactor.aspx?FactorID=" + lblFactorID.Text);
        //btnPrintFactor.Attributes.Add("onclick", "window.open('~/manager/Basket/PrintFactor.aspx')");
    }
}