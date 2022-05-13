using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.News;
using System.Web.Services;

public partial class Manager_News_NewsList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["AccessLevel"] == null)
            Response.Redirect("~/manager/login.aspx");
        if (Page.User.IsInRole("1") || ((HProtest_BLL.AccessLevel.AccessLevel)HttpContext.Current.Session["AccessLevel"]).NewsAgent == true)
        { }
        else
            Response.Redirect("~/manager/login.aspx");

        if (!Page.IsPostBack)
        {
            if (Request["r"] != null)
            {
                if (Request["r"].ToString() == "ok")
                    HProtest_BLL.Helper.Utility.ShowMsg(this, HProtest_BLL.PropertyData.MsgType.accept, "عملیات با موفقیت انجام شد.");
                if (Request["r"].ToString() == "stop")
                    HProtest_BLL.Helper.Utility.ShowMsg(this, HProtest_BLL.PropertyData.MsgType.accept, "عملیات متوقف شد.");
            }
        }
    }
    [WebMethod]
    public static int DeleteArticle(string Id)
    {
        try
        {
            //if (HttpContext.Current.Session["AccessLevel"] != null && ((Bime1ir_BLL.AccessLevel.AccessLevel)HttpContext.Current.Session["AccessLevel"]).NewsCreateDelete != true)
            //{
            //    return -2;
            //}

            if (Id != null && Id != "" && Id != "undefined")
            {
                using (System.Data.DataTable dtResult = NewsTransfer.DeleteNews(int.Parse(Id)))
                {
                    if (dtResult != null && dtResult.Rows.Count > 0)
                    {
                        string imageName = dtResult.Rows[0]["imageName"].ToString();
                        if (!string.IsNullOrEmpty(imageName))
                        {
                            string pic = System.Web.HttpContext.Current.Server.MapPath("~/Resource/News/" + imageName.Trim());
                            if (System.IO.File.Exists(pic))
                                System.IO.File.Delete(pic);
                        }
                    }
                }
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

        return 1;
    }
}