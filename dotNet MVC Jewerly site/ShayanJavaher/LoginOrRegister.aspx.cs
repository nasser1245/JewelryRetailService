using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.Helper;
using HProtest_BLL.Member;
using HProtest_BLL;

public partial class LoginOrRegister : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.UrlReferrer == null)
                Response.Redirect("~/Default.aspx");
            HttpCookie RedirectBack = new HttpCookie("RedirectBack", Request.UrlReferrer.AbsoluteUri);

            RedirectBack.Expires = DateTime.Now.AddMinutes(20);
            Response.Cookies.Add(RedirectBack);
            hfShowMsg.Value = "برای خرید از سایت باید عضو سایت باشید";
        }

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {

        if (Request.Cookies["capResult"] == null)
        {
            hfShowMsg.Value = "زمان شما برای وارد کردن کد امنیتی به پایان رسیده مجددا تلاش کنید";
            return;
        }
        if ((HProtest_BLL.Helper.Utility.GetMD5HashText(txtCaptcha.Text.Trim().ToLower()) != Request.Cookies["capResult"].Value.ToString()))
        {
            hfShowMsg.Value = "متن وارد شده براي عبارت تصويري اشتباه است !";
            return;
        }

        string AlertMessage = "";
        if (string.IsNullOrEmpty(txtRegisterUsername.Text.Trim()))
            AlertMessage += "فیلد نام کاربری نمی تواند خالی باشد<br>";
        if (txtRegisterUsername.Text.Length > 0 && !Utility.IsValidUserName(txtRegisterUsername.Text))
            AlertMessage += "نام کاربری صحیح نمی باشد<br>";

        if (string.IsNullOrEmpty(txtRegisterEmail.Text.Trim()))
            AlertMessage += "ایمیل نمی تواند خالی باشد<br>";
        if (txtRegisterEmail.Text.Length > 0 && !Utility.IsValidEmail(txtRegisterEmail.Text))
            AlertMessage += "ایمیل صحیح نمی باشد<br>";

        if (txtRegisterPassword.Text.Length < 1)
            AlertMessage += "فیلد رمز عبور نمی تواند خالی باشد<br>";
        if ((txtRegisterPassword.Text.Length > 0) && (txtRegisterPassword.Text != txtRegisterConfirmPassword.Text))
            AlertMessage += "رمز عبور و تکرار رمز عبور باهم برابر نیستند<br>";
        if ((txtRegisterPassword.Text.Length > 0) && (!Utility.IsValidPassword(txtRegisterPassword.Text)))
            AlertMessage += "رمز عبور معتبر نمی باشد<br>";

        if (AlertMessage != "")
        {
            AlertMessage = "لطفا خطاهای زیر را تصحیح کنید<br>" + AlertMessage.Substring(0, AlertMessage.Length - 4);
            hfShowMsg.Value = AlertMessage;
            return;
        }
        string MemberUserID = "";
        string hashed = "";
        string RandomStr = Utility.GetRandomString();
        using (System.Security.Cryptography.MD5 md5Hash = System.Security.Cryptography.MD5.Create())
        {
            hashed = HProtest_BLL.Helper.Utility.GetMD5Hash(md5Hash, txtRegisterPassword.Text + RandomStr.Trim());
        }

        string role = "";

        MemberUserID = MemberTransfer.InsertMember(txtRegisterUsername.Text, txtRegisterEmail.Text, "", "", 4,
            hashed, RandomStr, "", "", "", "");
        if (!string.IsNullOrEmpty(MemberUserID))
        {
            if (MemberUserID == "0")
                hfShowMsg.Value = "این نام کاربری قبلا ثبت شده است";
            else
            {
                if (MemberChecking.GetMemberStatusID(Server.HtmlEncode(txtRegisterUsername.Text.Trim()), out role))
                {
                    Response.Cookies.Add(MemberChecking.GetTicket(Server.HtmlEncode(txtRegisterUsername.Text.ToLower().Trim()), role));
                    if (Request.Cookies["RedirectBack"] != null)
                        Response.Redirect(Request.Cookies["RedirectBack"].Value.ToString());

                }
            }
        }
        else
            hfShowMsg.Value = "خطایی در درج اطلاعات به وجود آمده است";
    }

    protected void btnlogin_Click(object sender, EventArgs e)
    {
        string role = "";
        if ((!string.IsNullOrEmpty(txtUserName.Text) &&
            !string.IsNullOrEmpty(txtPassword.Text)))
        {
            if (MemberChecking.CheckUserPass(Server.HtmlEncode(txtUserName.Text.Trim()), Server.HtmlEncode(txtPassword.Text.Trim())))
            {
                if (MemberChecking.GetMemberStatusID(Server.HtmlEncode(txtUserName.Text.Trim()), out role))
                {
                    if (role == "4")
                    {
                        Response.Cookies.Add(MemberChecking.GetTicket(Server.HtmlEncode(txtUserName.Text.ToLower().Trim()), role));
                        if (Request.Cookies["RedirectBack"] != null)
                            Response.Redirect(Request.Cookies["RedirectBack"].Value.ToString());

                    }
                }
                else
                {
                    hfShowMsg.Value = "نام کاربری یا رمز عبور اشتباه می باشد";
                }
            }
            else
            {
                hfShowMsg.Value = "نام کاربری یا رمز عبور اشتباه می باشد";
            }
        }
        else
        {
            hfShowMsg.Value = "پر کردن فیلد های نام کاربری و رمز عبور الزامی است";
        }
    }
}