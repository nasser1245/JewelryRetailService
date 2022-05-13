using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.Helper;
using HProtest_BLL;
using ShayanDB_BLL;
using HProtest_BLL.News;

public partial class Manager_UC_ucNewsContent : System.Web.UI.UserControl
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
        if (!IsPostBack)
        {
            try
            {
                ddlNewsCategory.DataSource = GetData.GetTable("tbNewsCategory");
                ddlNewsCategory.DataValueField = "Id";
                ddlNewsCategory.DataTextField = "Title";
                ddlNewsCategory.DataBind();
                if (!string.IsNullOrEmpty(Request.QueryString["Id"]) && Utility.IsNumeric(Request.QueryString["Id"]))
                {
                    #region fill contain
                    System.Data.DataRow drNews = null;
                    drNews = NewsData.GetNews(int.Parse(Request.QueryString["Id"]));
                    if (drNews != null)
                    {

                        txtTitle.Text = drNews["Title"].ToString();
                        txtSummary.Text = drNews["Summary"].ToString();
                        txtDetail.Text = Server.HtmlDecode(drNews["Detail"].ToString());
                        ddlNewsCategory.SelectedValue = drNews["IdNewsCategory"].ToString();
                        ddlNewsType.SelectedValue = drNews["IdNewsType"].ToString();
                        cbVisible.Checked = drNews["Visible"].ToString().Trim() == "1" ? true : false;

                        if (System.IO.File.Exists(Server.MapPath("~/Resource/news/" + drNews["Picture"].ToString())))
                        {
                            imgNews.ImageUrl = "~/Resource/news/" + drNews["Picture"].ToString();
                        }
                        else
                            imgNews.Visible = false;

                        if (drNews["DateInput"].ToString().Trim().Length == 8)
                        {
                            string DateInput = drNews["DateInput"].ToString().Trim();
                            try
                            {
                                txtNewsYear.Text = DateInput.Substring(0, 4);
                                ddlNewsDay.Items.FindByText(DateInput.Substring(6, 2)).Selected = true;

                                if (ddlNewsMounth.Items.FindByValue(DateInput.Substring(4, 2)) != null)
                                    ddlNewsMounth.Items.FindByValue(DateInput.Substring(4, 2)).Selected = true;
                            }
                            catch
                            { txtNewsYear.Text = ""; ddlNewsDay.SelectedIndex = ddlNewsMounth.SelectedIndex = 0; }
                        }

                        lblDateIn.Text = "تاریخ درج:" + Utility.GetPersianDate(drNews["DateIn"]);

                        hfEditType.Value = "2";
                        hfnewsId.Value = Server.HtmlEncode(Request.QueryString["Id"]);
                        lblMessage.Text = "وضعیت جاری:در حال ویرایش  : " + drNews["Title"].ToString();
                       
                    }
                   else
                    {
                        lblMessage.Text = "وضعیت جاری:در حال درج";
                        SetCurrentDateTime();
                        imgNews.Visible = false;
                    }

                    #endregion
                }
                else
                {
                    lblMessage.Text = "وضعیت جاری:در حال درج";
                    SetCurrentDateTime();
                    imgNews.Visible = false;
                }
            }
            catch(Exception ex)
            {
                return;
            }
        }

        if (fuPic.PostedFile != null && fuPic.PostedFile.ContentLength > 0)
            PostedFile = fuPic.PostedFile;


    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string UserName = Page.User.Identity.Name;

        if (txtTitle.Text.Length < 1 || txtDetail.Text.Length < 1 || txtSummary.Text.Length < 1 || (!string.IsNullOrEmpty(txtNewsYear.Text) && txtNewsYear.Text.Length < 4))
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, "لطفا اطلاعات را طبق موارد گفته شده تکمیل نمایید");
            return;
        }

        if (fuPic.HasFile && !Utility.IsValidExt(fuPic.FileName))
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, "تنها فایلهای تصویری معمول قابل انتخاب می باشند");
            return;
        }
        else if (PostedFile != null && !Utility.IsValidExt(PostedFile.FileName))
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, "تنها فایلهای تصویری معمول قابل انتخاب می باشند");
            return;
        }

        #region insert operation

        string ImgExtention = "";

        string DateInput = Server.HtmlEncode(txtNewsYear.Text.Trim()) + Server.HtmlEncode(ddlNewsMounth.SelectedValue) + Server.HtmlEncode(ddlNewsDay.SelectedItem.Text);


        int NewsId = -1;

        if (hfEditType.Value == "1")
        {


            ImgExtention = fuPic.HasFile ? System.IO.Path.GetExtension(fuPic.FileName) : (PostedFile != null ? System.IO.Path.GetExtension(PostedFile.FileName) : "-1");

            NewsId = NewsTransfer.InsertNews(UserName, Server.HtmlEncode(txtTitle.Text.Trim()), Server.HtmlEncode(txtSummary.Text.Trim()), Server.HtmlEncode(txtDetail.Text.Trim()), ImgExtention, cbVisible.Checked ? 1 : 0, DateInput, int.Parse(ddlNewsCategory.SelectedValue), 0);

        }
        else if (hfEditType.Value == "2")
        {


            ImgExtention = fuPic.HasFile ? System.IO.Path.GetExtension(fuPic.FileName) : (!string.IsNullOrEmpty(imgNews.ImageUrl) ? System.IO.Path.GetExtension(imgNews.ImageUrl) : "-1");

            NewsId = NewsTransfer.EditNews(int.Parse(hfnewsId.Value), Server.HtmlEncode(txtTitle.Text.Trim()), Server.HtmlEncode(txtSummary.Text.Trim()), Server.HtmlEncode(txtDetail.Text.Trim()), ImgExtention, cbVisible.Checked ? 1 : 0, DateInput, int.Parse(ddlNewsCategory.SelectedValue), 0);
        }
        #endregion


        if (NewsId != -1)
        {
            if (fuPic.HasFile)
                fuPic.SaveAs(Request.PhysicalApplicationPath + "Resource/news/" + NewsId + ImgExtention);
            else if (PostedFile != null)
            {
                PostedFile.SaveAs(Request.PhysicalApplicationPath + "Resource/news/" + NewsId + ImgExtention);

                //remove PostedFile from session
                Session.Remove("postedFile");
            }

            Utility.ShowMsg(Page, PropertyData.MsgType.accept, "درج اطلاعات با موفقیت انجام گردید");
            if (hfEditType.Value == "2")
                Response.Redirect("NewsList.aspx?r=ok");
           
        }
        else
        {
            //Utility.ShowMsg(Page, PropertyData.MsgType.warning, "");
            return;
        }
    }

    private void SetCurrentDateTime()
    {
        System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
        ddlNewsDay.Items.FindByText(pc.GetDayOfMonth(DateTime.Now).ToString()).Selected = true;
        ddlNewsMounth.Items.FindByValue(pc.GetMonth(DateTime.Now).ToString()).Selected = true;
        txtNewsYear.Text = pc.GetYear(DateTime.Now).ToString();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("NewsList.aspx?r=stop");
    }
}