using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.Helper;
using HProtest_BLL;
using System.Net.Mail;
using System.Net;

public partial class UC_ChangePassWoed : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["capResult"] == null)
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, "زمان شما برای وارد کردن کد امنیتی به پایان رسیده مجددا تلاش کنید");
            return;
        }
        if ((HProtest_BLL.Helper.Utility.GetMD5HashText(txtCaptcha.Text.Trim().ToLower()) != Request.Cookies["capResult"].Value.ToString()))
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, "متن وارد شده براي عبارت تصويري اشتباه است !");
            return;
        }

        string AlertMessage = "";
        if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            AlertMessage += "فیلد نام کاربری نمی تواند خالی باشد<br>";
        if (txtUsername.Text.Length > 0 && !Utility.IsValidUserName(txtUsername.Text))
            AlertMessage += "نام کاربری صحیح نمی باشد<br>";

        if (string.IsNullOrEmpty(txtMail.Text.Trim()))
            AlertMessage += "ایمیل نمی تواند خالی باشد<br>";
        if (txtMail.Text.Length > 0 && !Utility.IsValidEmail(txtMail.Text))
            AlertMessage += "ایمیل صحیح نمی باشد<br>";

        if (AlertMessage != "")
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, AlertMessage);
            return;
        }
        string ID;
        string valid = MemberChecking.ActivatetionGenerate(txtMail.Text, txtUsername.Text,out ID);
        if (valid.Length < 1)
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, "نام کاربری یا ایمیل اشتباه می باشد");
        }
        else
        {

            
            string From = "nassrezan@live.com";
            string MailPass = "1qazxsw2";
            string To = txtMail.Text;
            string Subject = "بازیابی رمز عبور";
            string Body = "کاربر گرامی " + txtUsername.Text + "\n" + "با سلام و عرض خسته نباشید " + "\n" + "با کلیک بر روی لینک زیر رمز عبور خود را بازیابی کنید " 
                + "\n " +Request.Url.Scheme+"://" +Request.Url.Authority+"/ResetPassword.aspx?uis=" + ID + "&V0aL=" + valid + " \n" + "با تشکر " + "\n"+ " تیم پشتیبانی شایان جواهر " ;


            MailMessage mailObj = new MailMessage( From, To, Subject, Body);
            NetworkCredential objNC = new NetworkCredential(From, MailPass);
            SmtpClient objsmtp = new SmtpClient("smtp.live.com", 587); // for hotmail
            objsmtp.EnableSsl = true;
            objsmtp.Credentials = objNC;
            try
            {
                objsmtp.Send(mailObj);
            }
            catch (Exception ex)
            {
            }
            Utility.ShowMsg(Page, PropertyData.MsgType.accept, "کد فعال سازی به ایمیل شما ارسال شد");
            Response.Redirect("~/Default.aspx");
        }
    }
}