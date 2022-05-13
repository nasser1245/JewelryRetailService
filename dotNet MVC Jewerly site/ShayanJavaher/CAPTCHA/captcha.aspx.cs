using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class captcha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

            string text = ShayanDB_BLL.Captcha.GenerateRandomCode();
            ShayanDB_BLL.CaptchaResult cap = new ShayanDB_BLL.CaptchaResult(text, System.Web.HttpContext.Current);

            System.Web.HttpCookie cook = new System.Web.HttpCookie("capResult", HProtest_BLL.Helper.Utility.GetMD5HashText(text.Trim().ToLower()));
            cook.Expires = DateTime.Now.AddMinutes(5);
            Response.Cookies.Add(cook);
    }
}