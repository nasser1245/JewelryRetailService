using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.Helper;
using HProtest_BLL;
using HProtest_BLL.Member;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {

        if (Request.Cookies["capResult"] == null)
        {
            Utility.ShowMsg(this, PropertyData.MsgType.warning, "زمان شما برای وارد کردن کد امنیتی به پایان رسیده مجددا تلاش کنید");
            return;
        }
        if ((HProtest_BLL.Helper.Utility.GetMD5HashText(txtCaptcha.Text.Trim().ToLower()) != Request.Cookies["capResult"].Value.ToString()))
        {
            Utility.ShowMsg(this, PropertyData.MsgType.warning, "متن وارد شده براي عبارت تصويري اشتباه است !");
            return;
        }

        string AlertMessage = "";
        if (txtUserName.Text.Length < 1)
            AlertMessage += " نام کاربری خود را وارد نمایید<br>";
        if (txtMail.Text.Length < 1)
            AlertMessage += " ایمیل خود را وارد نمایید<br>";
        if (txtMail.Text.Length > 0 && !Utility.IsValidEmail(txtMail.Text))
            AlertMessage += "  ایمیل خود را به طور صحیح وارد نمایید<br>";
        if (txtMobile.Text.Length > 0 && !Utility.IsNumeric(txtMobile.Text))
            AlertMessage += "  شماره تلفن عدد است<br>";
        if (txtPassword.Text.Length < 1)
            AlertMessage += "فیلد رمز عبور نمی تواند خالی باشد<br>";
        if ((txtPassword.Text.Length > 0) && (txtPassword.Text != txtPasswordRepeat.Text))
            AlertMessage += "رمز عبور و تکرار رمز عبور باهم برابر نیستند<br>";
        if ((txtPassword.Text.Length > 0) && (!Utility.IsValidPassword(txtPassword.Text)))
            AlertMessage += "رمز عبور معتبر نمی باشد<br>";
        if (txtTel.Text.Length > 0 && !Utility.IsNumeric(txtTel.Text))
            AlertMessage += "  شماره همراه عدد است<br>";
        if (txtZipCode.Text.Length > 0 && !Utility.IsNumeric(txtZipCode.Text))
            AlertMessage += "کدپستی عدد است<br>";

        if (AlertMessage != "")
        {
            AlertMessage = "لطفا خطاهای زیر را تصحیح کنید:<br>" + AlertMessage.Substring(0, AlertMessage.Length - 4);
            Utility.ShowMsg(this, PropertyData.MsgType.warning, AlertMessage);
            return;
        }

        string User = "";
        string hashed = "";
        string RandomStr = Utility.GetRandomString();
        using (System.Security.Cryptography.MD5 md5Hash = System.Security.Cryptography.MD5.Create())
        {
            hashed = HProtest_BLL.Helper.Utility.GetMD5Hash(md5Hash, txtPassword.Text + RandomStr.Trim());
        }
        
        string Province = string.IsNullOrEmpty(ddlProvince.SelectedValue.ToString()) ? "" : ddlProvince.SelectedItem.ToString();
        User = MemberTransfer.InsertMember(txtUserName.Text, txtMail.Text, txtName.Text, txtFamily.Text, 4,
            hashed, RandomStr, txtTel.Text, txtMobile.Text, txtZipCode.Text, txtAddress.Text, "",
            ddlSex.SelectedValue.ToString(), Province, txtCity.Text);

        if (string.IsNullOrEmpty(User))
        {
            AlertMessage = "خطایی در ثبت نام به وجود آمده است لطفا مجددا سعی کنید";
            Utility.ShowMsg(this, PropertyData.MsgType.warning, AlertMessage);
            return;

        }
        else if (User == "0")
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.accept, " این نام کاربری قبلا ثبت شده است");
        }
        else
        {
            string role = "";
            if (MemberChecking.GetMemberStatusID(Server.HtmlEncode(txtUserName.Text.Trim()), out role))
            {
                Response.Cookies.Add(MemberChecking.GetTicket(Server.HtmlEncode(txtUserName.Text.ToLower().Trim()), role));
                Response.Redirect("~/Default.aspx");
                Utility.ShowMsg(Page, PropertyData.MsgType.accept, " ثبت نام با موفقیت انجام گردید");
                Response.Redirect("~/Default.aspx");
            }
        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }
}