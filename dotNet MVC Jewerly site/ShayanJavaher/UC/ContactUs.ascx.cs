using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL;
using HProtest_BLL.Helper;
using HProtest_BLL.ContactFAQ;
public partial class HomePage_UC_ContactUs : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
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

        if (string.IsNullOrEmpty(txtTel.Text.Trim()))
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, "لطفا شماره تلفن خود را وارد کنید !");   

        int ContactID = ContactTransfer.InsertContactUs(txtEmail.Text, txtName.Text, txtFamily.Text, txtTel.Text
            , ddlTypeContactUs.SelectedItem.ToString(), txtTitle.Text, txtDetailsContactUs.Text);
        if (ContactID > 0)
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.accept, "پیغام شما با موفقیت ثبت شد !");   
        }
        else
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, "مشکلی در سیستم به وجود آمده است. بعد از چند لحظه دوباره پیغام خود را ارسال کنید !");   
    }

}