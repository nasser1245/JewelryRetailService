using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using HProtest_BLL.Member;

public partial class Manager_Member_MemberList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["AccessLevel"] == null)
            Response.Redirect("~/manager/login.aspx");

            if (Page.User.IsInRole("1") || ((HProtest_BLL.AccessLevel.AccessLevel)HttpContext.Current.Session["AccessLevel"]).ManagerAgent == true)
            { }
            else
                Response.Redirect("~/manager/login.aspx");
    }
    [WebMethod]
    public static int DeleteMember(string UserName )
    {
        try
        {

            if (UserName != null && UserName != "" && UserName != "undefined")
            {
                using (System.Data.DataTable dtResult = MemberTransfer.DeleteMember(UserName))
                {
                    if (dtResult != null && dtResult.Rows.Count > 0)
                    {
                        string imageName = dtResult.Rows[0]["imageName"].ToString();
                        if (!string.IsNullOrEmpty(imageName))
                        {
                            string pic = System.Web.HttpContext.Current.Server.MapPath("~/Resource/Member/" + imageName.Trim());
                            if (System.IO.File.Exists(pic))
                                System.IO.File.Delete(pic);
                        }
                    }
                }
            }
            else
            {
                throw new ApplicationException("Error");
            }
        }
        catch
        {
            throw new ApplicationException("Error");
        }

        return 1;
    }
}