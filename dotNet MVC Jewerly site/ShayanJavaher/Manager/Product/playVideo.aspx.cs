using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Manager_Product_playVideo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["AccessLevel"] == null)
            Response.Redirect("~/manager/login.aspx");

        if (Page.User.IsInRole("1") || ((HProtest_BLL.AccessLevel.AccessLevel)HttpContext.Current.Session["AccessLevel"]).ProductAgent == true)
        {
            if (Request["videoaddr"] != null)
            {
                string path = "~\\Resource\\ProductVideo\\";
                VideoPlayer.VideoURL = path + Request["videoaddr"].ToString();
            }
        }
        else
            Response.Redirect("~/manager/login.aspx");
        //Label1.Text = VideoPlayer.VideoURL;

    }
}