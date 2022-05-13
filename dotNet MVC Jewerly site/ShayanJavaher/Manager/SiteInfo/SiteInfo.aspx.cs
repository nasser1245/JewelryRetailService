using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.Helper;
using HProtest_BLL;
using ShayanDB_BLL;
using HProtest_BLL.InfoSite;
using System.IO;
public partial class Manager_SiteInfo_SiteInfo : System.Web.UI.Page
{
    #region UC Properties

    public System.Web.HttpPostedFile PostedFile
    {
        get
        {
            if (Session["postedFile"] != null)
                return (System.Web.HttpPostedFile)Session["postedFile"];
            else
                return null;
        }
        set { Session["postedFile"] = value; }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (HttpContext.Current.Session["AccessLevel"] == null)
            Response.Redirect("~/manager/login.aspx");

        if (Page.User.IsInRole("1") || ((HProtest_BLL.AccessLevel.AccessLevel)HttpContext.Current.Session["AccessLevel"]).LibraryAgent == true)
        {
            if (!IsPostBack)
            {
                try
                {

                    if (!string.IsNullOrEmpty(Request.QueryString["InfoType"]) && Utility.IsNumeric(Request.QueryString["InfoType"]))
                    {
                        System.Data.DataRow drInfoSite = null;
                        drInfoSite = InfoSiteData.GetInfoSite(int.Parse(Request.QueryString["InfoType"]));
                        if (drInfoSite != null)
                            txtText.Text = Server.HtmlDecode(drInfoSite["Text"].ToString());
                    }else
                        Response.Redirect("~/manager/SiteInfo/SiteInfo.aspx?InfoType=1");
                }
                catch (Exception ex)
                {
                    return;
                }

                DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/Resource/InfoSite/"));
                FileInfo[] filePath;
                switch (int.Parse(Request.QueryString["InfoType"]))
                {
                    case 1:
                        lblHint.Text = "ویرایش بخش درباره ما";
                        filePath = di.GetFiles("a*");
                        rptPic.DataSource = filePath;
                        rptPic.DataBind();
                        break;
                    case 2:
                        lblHint.Text = "ویرایش بخش خرید محصول";
                        filePath = di.GetFiles("b*");
                        rptPic.DataSource = filePath;
                        rptPic.DataBind();
                        break;
                    case 3:
                        lblHint.Text = "ویرایش بخش راهنمای سایزبندی";
                        filePath = di.GetFiles("s*");
                        rptPic.DataSource = filePath;
                        rptPic.DataBind();
                        break;
                    default:
                        lblHint.Text = "ویرایش بخش درباره ما";
                        filePath = di.GetFiles("a*");
                        rptPic.DataSource = filePath;
                        rptPic.DataBind();
                        break;
                }
            }
        }
        else
            Response.Redirect("~/manager/login.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtText.Text.Length < 1 )
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, "لطفا اطلاعات را طبق موارد گفته شده تکمیل نمایید");
            return;
        }
        int Id = -1;
            Id = InfoSiteData.EditInfoSite(int.Parse(Request.QueryString["InfoType"]), Server.HtmlEncode(txtText.Text.Trim()));
        if (Id != -1)
            Utility.ShowMsg(Page, PropertyData.MsgType.accept, "درج اطلاعات با موفقیت انجام گردید");
        else
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, "مشکلی در درج اطلاعات به وجود آمده است");
    }
    protected void btnAddPics_Click(object sender, EventArgs e)
    {
        int pu = PicUpload.PostedFile.ContentLength;
        string extPic = "";
        if (pu > 0)
            extPic = ValidatePics();
        else
        {
            HProtest_BLL.Helper.Utility.ShowMsg(this, PropertyData.MsgType.warning, "لطفا یک عکس انتخاب کنید.");
            return;
        }
        if (extPic == null)
            return;
        if(PicUploads(PicUpload.PostedFile.FileName)){
            Response.Redirect(Request.RawUrl);
        }
    }
    public void lblDeleteProduct_Command(object sender, CommandEventArgs e)
    {
        try
        {
            string path = Server.MapPath("~\\Resource\\InfoSite\\");
            Common.DelFile(path + e.CommandArgument.ToString());
            HProtest_BLL.Helper.Utility.ShowMsg(this, PropertyData.MsgType.accept, "عملیات با موفقیت انجام شد.");
            Response.Redirect(Request.RawUrl);
        }
        catch
        {
            HProtest_BLL.Helper.Utility.ShowMsg(this, PropertyData.MsgType.warning, "بروز خطای نامشخص مجدد تلاش کنید.");
        }
    }
    public bool PicUploads(string filename)
    {
        string path = Server.MapPath("~\\Resource\\InfoSite\\");
        Random rnd = new Random();
        try
        {
            switch (int.Parse(Request.QueryString["InfoType"]))
            {
                case 1:
                    PicUpload.PostedFile.SaveAs(path + "a" + rnd.Next(1000) + filename);
                    break;
                case 2:
                    PicUpload.PostedFile.SaveAs(path + "b" + rnd.Next(1000) + filename);
                    break;
                case 3:
                    PicUpload.PostedFile.SaveAs(path + "s" + rnd.Next(1000) + filename);
                    break;
                default:
                    PicUpload.PostedFile.SaveAs(path + "a" + rnd.Next(1000) + filename);
                    break;
            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    public string ValidatePics()
    {
        String[] Validext = { ".jpg", ".gif", ".png", ".bmp" };
        string ext = System.IO.Path.GetExtension(PicUpload.PostedFile.FileName);
        if (Array.IndexOf(Validext, ext.ToLower()) < 0)
        {
            HProtest_BLL.Helper.Utility.ShowMsg(this, PropertyData.MsgType.warning, "فایل وارد شده معتبر نیست!");
            return null;
        }
        long size = PicUpload.PostedFile.ContentLength;
        size = size / 1024;
        if (size > 2000)
        {
            HProtest_BLL.Helper.Utility.ShowMsg(this, PropertyData.MsgType.warning, "حداکثر حجم فایل 2 مگابایت است!");
            return null;
        }
        return ext;
    }
}