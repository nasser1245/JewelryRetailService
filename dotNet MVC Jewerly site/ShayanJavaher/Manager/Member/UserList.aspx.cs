using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.Member;
using System.Web.Services;

public partial class Manager_Member_UserList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["AccessLevel"] == null)
            Response.Redirect("~/manager/login.aspx");

        if (Page.User.IsInRole("1") || ((HProtest_BLL.AccessLevel.AccessLevel)HttpContext.Current.Session["AccessLevel"]).UserAgent == true)
        { }
        else
            Response.Redirect("~/manager/login.aspx");
    }

    [WebMethod]
    public static int LockMember(string UserName)
    {
        try
        {

            if (UserName != null && UserName != "" && UserName != "undefined")
            {
                bool Successed;
                Successed=MemberTransfer.ToggleMember(UserName);
                if (Successed)
                    return 1;
                else 
                    return 0;
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

    }
   
}