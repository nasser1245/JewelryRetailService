using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AboutUs : System.Web.UI.Page
{
    public string Text;
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Data.DataRow dt = HProtest_BLL.InfoSite.InfoSiteData.GetInfoSite(1);
        if (dt != null)
            Text = dt["Text"].ToString();
        else
            Response.Redirect("Default.aspx");
    }
}