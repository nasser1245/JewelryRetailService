using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using ShayanDB_BLL;
using HProtest_BLL.Helper;
using HProtest_BLL.News;


public partial class Manager_ManagerMasterPage : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        bool role = Page.User.IsInRole("1");
        if ((Page.User.IsInRole("1") || Page.User.IsInRole("3")) && HttpContext.Current.Session["AccessLevel"] != null)
        {
            lblUserName.Text = Page.User.Identity.Name;
        }
        else
            Response.Redirect("~/manager/login.aspx");
    }
  
    protected void lbManagePagesP_Click(object sender, EventArgs e)
    {
           Response.Redirect("~/Manager/Product/"+(((LinkButton)sender).ID)+".aspx");
    }

    protected void lbManagePagesN_Click(object sender, EventArgs e)
    {
        Response.Redirect( "~/Manager/News/" + (((LinkButton)sender).ID) + ".aspx");
    }
    protected void lbManagePagesL_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Manager/Library/" + (((LinkButton)sender).ID) + ".aspx");
    }

    protected void lbManagePagesU_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Manager/Member/" + (((LinkButton)sender).ID) + ".aspx");
    }

    protected void lbManagePagesPoll_Click(object sender, EventArgs e)
    {
        Response.Redirect( "~/Manager/Poll/" + (((LinkButton)sender).ID) + ".aspx");
    }

    protected void lbManagePagesContact_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Manager/Contact/" + (((LinkButton)sender).ID) + ".aspx");
    }

    protected void lbManagePagesBasket_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Manager/Basket/" + (((LinkButton)sender).ID) + ".aspx");
    }

    protected void lbChangePassword_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Manager/ChangePassword.aspx");
    }

    protected void lbExit_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Session.Abandon();

        HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
        cookie1.Expires = DateTime.Now.AddYears(-1);
        Response.Cookies.Add(cookie1);

        HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
        cookie2.Expires = DateTime.Now.AddYears(-1);
        Response.Cookies.Add(cookie2);

        FormsAuthentication.RedirectToLoginPage();
    }
    protected void lbManagePagesAdvertise_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Manager/Advertise/" + (((LinkButton)sender).ID) + ".aspx");

    }
    protected void lbManagePagesMoreInfo_Click(object sender, EventArgs e)
    {
        if(((LinkButton)sender).ID == "AboutUs")
            Response.Redirect("~/Manager/SiteInfo/SiteInfo.aspx?InfoType=1");
        else if(((LinkButton)sender).ID == "BuyInfo")
            Response.Redirect("~/Manager/SiteInfo/SiteInfo.aspx?InfoType=2");
        else if(((LinkButton)sender).ID == "Size")
            Response.Redirect("~/Manager/SiteInfo/SiteInfo.aspx?InfoType=3");

    }
}
