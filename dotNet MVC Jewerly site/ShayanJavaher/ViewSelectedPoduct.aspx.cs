using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using HProtest_BLL.Helper;
using HProtest_BLL.Basket;
using System.Web.UI.HtmlControls;
using HProtest_BLL;
using HProtest_BLL.Product;
using System.Data;
using HProtest_BLL.ClassView;
using HProtest_BLL.Manager;

public partial class ViewSelectedPoduct : System.Web.UI.Page
{
    const int RATING_MIN = 1;
    const int RATING_MAX = 5;
    public Products Product = new Products();
    public string pid;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request["pid"] == null)
            {
                //peygham
                Response.Redirect("default.aspx");
            }
            pid = Request["pid"].ToString();
            if (!Utility.IsNumeric(pid))
                Response.Redirect("default.aspx");


            System.Data.DataTable dt = ManagerData.GetProductInfo(pid);
            Common.UpdateVisited(int.Parse(pid));
            if (dt != null)
            {
                Product.ID = int.Parse(pid);
                hfID.Value = dt.Rows[0]["ID"].ToString();
                Rating.CurrentRating = Convert.ToInt32(Math.Round(Convert.ToDouble(dt.Rows[0]["Point"].ToString())));
                Product.Name = dt.Rows[0]["Name"].ToString();
                Product.Video = dt.Rows[0]["Video"].ToString();
                Product.Desp = dt.Rows[0]["Desp"].ToString();
                Product.Visited = int.Parse(dt.Rows[0]["Visited"].ToString());
                Product.InserDate = Convert.ToDateTime(dt.Rows[0]["InsertDate"]);
                Product.Count = dt.Rows[0]["Count"].ToString();
                Product.Point = dt.Rows[0]["Point"].ToString();
                Product.Luxe = Convert.ToBoolean(dt.Rows[0]["Luxe"]);
                Product.AboutProduct = dt.Rows[0]["AboutProduct"].ToString();
                Product.Size = Convert.ToBoolean(dt.Rows[0]["Size"].ToString());
                Product.MainPic = dt.Rows[0]["MainPic"].ToString();
                Product.Price = int.Parse(dt.Rows[0]["Price"].ToString());
                Product.ProductType.ID = int.Parse(dt.Rows[0]["ProductTypeID"].ToString());
                Product.ProductType.type = dt.Rows[0]["Type"].ToString();
                RepeaterSimilarType.DataSource = ManagerData.GetProductInfo(Product.ProductType.ID, "desc", "tbl_product.id", 0, 8, 1);
                Rating.CurrentRating = Convert.ToInt32(Math.Round(HProtest_BLL.Product.ProductTransfer.InsertRate(hfID.Value.ToString(), "-1")));
            }
            else
                Response.Redirect("default.aspx");

            if (dt.Rows.Count <= 0)
            {
                Response.Redirect("default.aspx");
            }

            RepeaterSimilarType.DataBind();
        }
        catch
        {
            Response.Redirect("default.aspx");

        }
    }
    protected void BuyProduct(object sender, CommandEventArgs e)
    {
        if (Page.User.IsInRole("4"))
        {
            string Count = BasketTransfer.InsertBasketProduct(Page.User.Identity.Name, int.Parse(hfID.Value.ToString()));
            if (int.Parse(Count) >= 0)
                ((Main_MasterPage)this.Page.Master).setBasketCount(Count);
        }
        else
        {
            Response.Redirect("~/LoginOrRegister.aspx");
        }
    }
    protected void Rating_Changed(object sender, AjaxControlToolkit.RatingEventArgs e)
    {
        if (Request.Cookies["Rate"] != null)
        {
            if (Request.Cookies["Rate"].Value.ToString().IndexOf("," + hfID.Value.ToString() + ",") >= 0)
            {
                lblRateValue.Text = "شما قبلا به این محصول امتیاز داده اید ";
                return;
            }
        }
        if (Request.Cookies["Rate"] == null)
        {
            HttpCookie r = new HttpCookie("Rate");
            r.Expires=(DateTime.Now.AddMonths(2));
            r.Value = ",";
            Response.Cookies.Add(r);
        }
        double Rate = HProtest_BLL.Product.ProductTransfer.InsertRate(hfID.Value.ToString(), e.Value);
            //Convert.ToInt32(EvaluateRating(int.Parse(e.Value), Rating.MaxRating, RATING_MIN, RATING_MAX)).ToString());
        if (Rate != -1)
        {
            Response.Cookies["Rate"].Value = Request.Cookies["Rate"].Value + hfID.Value.ToString() + ",";
            lblRateValue.Text = "امتیاز شما ثبت شد ";
        }
        Rating.CurrentRating = Convert.ToInt32( Math.Round(Rate));
    }

    public static string EvaluateRating(int value, int maximalValue, int minimumRange, int maximumRange)
    {
        int stepDelta = (minimumRange == 0) ? 1 : 0;
        double delta = (double)(maximumRange - minimumRange) / (maximalValue - 1);
        double result = delta * value - delta * stepDelta;
        return FormatResult(result);
    }

    public static string FormatResult(double value)
    {
        return String.Format("{0:g}", value);
    }


}