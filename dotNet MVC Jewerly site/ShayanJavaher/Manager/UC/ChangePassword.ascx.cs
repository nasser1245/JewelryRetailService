using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.Member;
using HProtest_BLL;
using HProtest_BLL.Helper;

public partial class UC_ChangePassword : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtOldPassword.Text) || string.IsNullOrEmpty(txtPass.Text) || string.IsNullOrEmpty(txtConfirmPass.Text))
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

        if (MemberChecking.CheckUserPass(Server.HtmlEncode(Page.User.Identity.Name.Trim()), Server.HtmlEncode(txtOldPassword.Text.Trim())))
        {
            string hashed = "";
            string RandomStr = Utility.GetRandomString();
            using (System.Security.Cryptography.MD5 md5Hash = System.Security.Cryptography.MD5.Create())
            {
                hashed = HProtest_BLL.Helper.Utility.GetMD5Hash(md5Hash, txtPass.Text + RandomStr.Trim());
            }
            if (MemberTransfer.ChangePassword(Page.User.Identity.Name, hashed, RandomStr) == Page.User.Identity.Name)
            {
                Utility.ShowMsg(Page, PropertyData.MsgType.accept, "رمز عبور شما با موفقیت تغییر پیدا کرد");
            }
            else
            {
                Utility.ShowMsg(Page, PropertyData.MsgType.warning, "مشکلی در عملیات درخواستی به وجود آمده است");
                return;
            }

        }
        else
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, "رمز عبور وارد شده اشتباه می باشد");

    }
}