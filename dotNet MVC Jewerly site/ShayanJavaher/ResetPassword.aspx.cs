using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.Helper;
using HProtest_BLL;

public partial class ResetPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["uis"] == null || Request.QueryString["V0aL"] == null)
            Response.Redirect("~/Default.aspx");
        else
        {
            string UserName;
            if (Request.QueryString["uis"].ToString() != null && Request.QueryString["V0aL"] != null)
            {
                UserName = MemberChecking.IsValidActivation(Request.QueryString["uis"].ToString(), Request.QueryString["V0aL"].ToString());
                if(string.IsNullOrEmpty(UserName))
                    Response.Redirect("~/Default.aspx");
            } 
        }

    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        if ( string.IsNullOrEmpty(txtPass.Text) || string.IsNullOrEmpty(txtConfirmPass.Text))
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, "همه فیلد ها باید تکمیل گردند");
            return;
        }

        if (!Utility.IsValidPassword(txtPass.Text))
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, "رمز عبور جدید به اندازه کافی قدرتمند نیست");
            return;
        }

        if (txtPass.Text != txtConfirmPass.Text)
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, "رمز عبور جدید و تکرار آن باید مثل هم باشند");
            return;
        }
        string UserName;
        UserName = MemberChecking.IsValidActivation(Request.QueryString["uis"].ToString(), Request.QueryString["V0aL"].ToString());
        if (string.IsNullOrEmpty(UserName))
            Response.Redirect("~/Default.aspx");
            string hashed = "";
            string RandomStr = Utility.GetRandomString();
            using (System.Security.Cryptography.MD5 md5Hash = System.Security.Cryptography.MD5.Create())
            {
                hashed = HProtest_BLL.Helper.Utility.GetMD5Hash(md5Hash, txtPass.Text + RandomStr.Trim());
            }
            if (HProtest_BLL.Member.MemberTransfer.ChangePassword(UserName, hashed, RandomStr) == UserName)
            {
                string role = "";
                if (MemberChecking.GetMemberStatusID(UserName, out role))
                {
                    if (role == "4")
                    {
                        bool Locked = MemberChecking.IsLocked(UserName);
                        if (Locked)
                        {
                            Utility.ShowMsg(Page, PropertyData.MsgType.warning, "حساب کاربری شما مسدود شده است. جهت رفع مشکل با مدیریت سایت تماس بگیرید");
                            return;
                        }
                        else
                        {
                            Response.Cookies.Add(MemberChecking.GetTicket(Server.HtmlEncode(UserName.ToLower().Trim()), role));
                            Utility.ShowMsg(Page, PropertyData.MsgType.accept, "رمز عبور شما با موفقیت تغییر پیدا کرد");
                            Response.Redirect("~/UserProfileEdit.aspx");
                        }
                    }
                }
            }
            else
            {
                Utility.ShowMsg(Page, PropertyData.MsgType.warning, "مشکلی در عملیات درخواستی به وجود آمده است");
                return;
            }


    }
}