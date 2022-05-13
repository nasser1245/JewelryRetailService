using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL;
using HProtest_BLL.Member;

public partial class Manager_Member_MemberAccess : System.Web.UI.Page
{
    public void setCheckBox()
    {
        if (Request.QueryString["UserName"] != null)
        {
            bool isIt = false;
            using (System.Data.DataTable DTAccess = HProtest_BLL.Member.MemberData.GetMemberAccessLevelList(Request.QueryString["UserName"].ToString(), ref isIt))
            {
                if (isIt != false)
                {
                    lblUserName.Text = Request.QueryString["UserName"].ToString();
                    if (DTAccess != null)
                    {
                        ProductAgent.Text = DTAccess.Rows[0][2].ToString();
                        NewsAgent.Text = DTAccess.Rows[1][2].ToString();
                        SellAgent.Text = DTAccess.Rows[2][2].ToString();
                        UserAgent.Text = DTAccess.Rows[3][2].ToString();
                        AdvertiseAgent.Text = DTAccess.Rows[4][2].ToString();
                        LibraryAgent.Text = DTAccess.Rows[5][2].ToString();
                        SupportAgent.Text = DTAccess.Rows[6][2].ToString();
                        ManagerAgent.Text = DTAccess.Rows[7][2].ToString();

                        chkProductAgent.Checked = DTAccess.Rows[0][3].ToString() == "" ? false : true;
                        chkNewsAgent.Checked = DTAccess.Rows[1][3].ToString() == "" ? false : true;
                        chkSellAgent.Checked = DTAccess.Rows[2][3].ToString() == "" ? false : true;
                        chkUserAgent.Checked = DTAccess.Rows[3][3].ToString() == "" ? false : true;
                        chkAdvertiseAgent.Checked = DTAccess.Rows[4][3].ToString() == "" ? false : true;
                        chkLibraryAgent.Checked = DTAccess.Rows[5][3].ToString() == "" ? false : true;
                        chkSupportAgent.Checked = DTAccess.Rows[6][3].ToString() == "" ? false : true;
                        chkManagerAgent.Checked = DTAccess.Rows[7][3].ToString() == "" ? false : true;
                    }
                    
                }
                else { }
            }
        }
    }
                        

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["AccessLevel"] == null)
            Response.Redirect("~/manager/login.aspx");

        if (Page.User.IsInRole("1") || ((HProtest_BLL.AccessLevel.AccessLevel)HttpContext.Current.Session["AccessLevel"]).ManagerAgent == true)
        {

            if (Request.QueryString["UserName"] != null)
            {
                if (!Page.IsPostBack)
                    setCheckBox();
            }
        }
        else
            Response.Redirect("~/manager/login.aspx");

    }

    protected void btnEditAccess_Click(object sender, EventArgs e)
    {
        string Access="";
        Access +=  (chkProductAgent.Checked == true) ? "1,":"";
        Access += (chkNewsAgent.Checked == true) ? "2," : "";
        Access += (chkSellAgent.Checked == true) ? "3," : "";
        Access += (chkUserAgent.Checked == true) ? "4," : "";
        Access += (chkAdvertiseAgent.Checked == true) ? "5," : "";
        Access += (chkLibraryAgent.Checked == true) ? "6," : "";
        Access += (chkSupportAgent.Checked == true) ? "7," : "";
        Access += (chkManagerAgent.Checked == true) ? "10," : "";
        if (Request.QueryString["UserName"] != null)
        {
            MemberTransfer.EditMemberAccessLevel(Request.QueryString["UserName"].ToString(), Access);
        }
        Response.Redirect("~/Manager/Member/MemberList.aspx");
        setCheckBox();
    }
}