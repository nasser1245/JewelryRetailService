using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.Member;
using System.Data;
using HProtest_BLL;
using HProtest_BLL.AccessLevel;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string role = "";
        if (Request.Cookies["capResult"] == null)
        {
            HProtest_BLL.Helper.Utility.ShowMsg(this, PropertyData.MsgType.warning, "زمان شما برای وارد کردن عبارت امنیتی به پایان رسیده دوباره تلاش کنید");
            return;
        }
        if ((HProtest_BLL.Helper.Utility.GetMD5HashText(txtCaptcha.Text.Trim().ToLower()) != Request.Cookies["capResult"].Value.ToString()))
        {
            HProtest_BLL.Helper.Utility.ShowMsg(this,PropertyData.MsgType.warning, "کد امنیتی با تصویر مطابق نیست");
            return;
        }
        else
        if ((!string.IsNullOrEmpty(txtUserName.Text) &&
            !string.IsNullOrEmpty(txtPassword.Text)))
        {
            if (MemberChecking.CheckUserPass(Server.HtmlEncode(txtUserName.Text.Trim()), Server.HtmlEncode(txtPassword.Text.Trim())))
            {
                if (MemberChecking.GetMemberStatusID(Server.HtmlEncode(txtUserName.Text.Trim()), out role))
                {
                    switch (role)
                    {
                        case "1":
                            Response.Cookies.Add(MemberChecking.GetTicket(Server.HtmlEncode(txtUserName.Text.ToLower().Trim()), role));
                            HttpContext.Current.Session["AccessLevel"] = AccessLevelData.FillMemberAccessLevel(txtUserName.Text.Trim());
                            Response.Redirect("~/Manager/Product/AddProduct.aspx");
                            break;

                        case "3":
                                bool Locked = MemberChecking.IsLocked(txtUserName.Text);
                                if (Locked)
                                {
                                    HProtest_BLL.Helper.Utility.ShowMsg(this, PropertyData.MsgType.warning, "حساب کاربری شما مسدود شده است. جهت رفع مشکل با مدیریت سایت تماس بگیرید");
                                    return;
                                }                   
                            Response.Cookies.Add(MemberChecking.GetTicket(Server.HtmlEncode(txtUserName.Text.ToLower().Trim()), role));
                            HttpContext.Current.Session["AccessLevel"] = AccessLevelData.FillMemberAccessLevel(txtUserName.Text.Trim());
                            if (((HProtest_BLL.AccessLevel.AccessLevel)HttpContext.Current.Session["AccessLevel"]).ProductAgent == true)
                                Response.Redirect("~/Manager/Product/AddProduct.aspx");
                            else if (((HProtest_BLL.AccessLevel.AccessLevel)HttpContext.Current.Session["AccessLevel"]).NewsAgent == true)
                                Response.Redirect("~/Manager/News/NewsContent.aspx");
                            else if (((HProtest_BLL.AccessLevel.AccessLevel)HttpContext.Current.Session["AccessLevel"]).SellAgent == true) 
                                Response.Redirect("~/Manager/Basket/BasketList.aspx");
                            else if (((HProtest_BLL.AccessLevel.AccessLevel)HttpContext.Current.Session["AccessLevel"]).UserAgent == true)
                                Response.Redirect("~/Manager/Member/UserList.aspx");
                            else if (((HProtest_BLL.AccessLevel.AccessLevel)HttpContext.Current.Session["AccessLevel"]).AdvertiseAgent == true) 
                                Response.Redirect("~/Manager/Advertise/Advertise.aspx");
                            else if (((HProtest_BLL.AccessLevel.AccessLevel)HttpContext.Current.Session["AccessLevel"]).LibraryAgent == true)
                                Response.Redirect("~/Manager/Library/LibraryList.aspx");
                            else if (((HProtest_BLL.AccessLevel.AccessLevel)HttpContext.Current.Session["AccessLevel"]).SupportAgent == true)
                                Response.Redirect("~/Manager/Contact/FAQ.aspx");
                            else if (((HProtest_BLL.AccessLevel.AccessLevel)HttpContext.Current.Session["AccessLevel"]).ManagerAgent == true)
                                Response.Redirect("~/Manager/Member/MemberContent.aspx");
                            else
                                HProtest_BLL.Helper.Utility.ShowMsg(this, PropertyData.MsgType.warning, "هیج اختیاراتی برای شما در سیستم ثبت نشده است. لطفا با مدیریت تماس بگیرید");
                            break;
                        default:
                            string myScript = "showMsg('warning','در ارتباط با سرور مشکلی پیش آمده. لطفا با مدیریت سایت،تماس حاصل نمایید');";
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "myKey1", myScript, true);
                            break;
                    }
                }

            }
            else
            {

                string myScript = "showMsg('warning','اطلاعات ورودی اشتباه است.لطفا در ورود اطلاعات دقت نمایید.');";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "myKey1", myScript, true);
            }
            
        }
        else
        {
            string myScript = "showMsg('warning','اطلاعات ورودی اشتباه است.لطفا در ورود اطلاعات دقت نمایید <br />زمان مجاز برای ورود اطلاعات : 3 دقیقه.');";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "myKey1", myScript, true);
        }
    }
}