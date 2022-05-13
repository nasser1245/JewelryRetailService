using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.Helper;
using HProtest_BLL;
using ShayanDB_BLL;
using HProtest_BLL.Library;


public partial class Manager_Library_LibraryContent : System.Web.UI.Page
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
                ddlLibraryCategory.DataSource = GetData.GetTable("tbl_LibraryCategory");
                ddlLibraryCategory.DataValueField = "Id";
                ddlLibraryCategory.DataTextField = "Title";
                ddlLibraryCategory.DataBind();
                if (!string.IsNullOrEmpty(Request.QueryString["Id"]) && Utility.IsNumeric(Request.QueryString["Id"]))
                {
                    #region fill contain
                    System.Data.DataRow drLibrary = null;
                    drLibrary = LibraryData.GetLibrary(int.Parse(Request.QueryString["Id"]));
                    if (drLibrary != null)
                    {
                        hfEditType.Value = "2";
                        txtTitle.Text = drLibrary["Title"].ToString();
                        txtSummary.Text = drLibrary["Summary"].ToString();

                        if (System.IO.File.Exists(Server.MapPath("~/Resource/LibraryFiles/" + Request.QueryString["Id"]  + drLibrary["Link"].ToString())))
                        {
                            txtLink.Text = "~/Resource/LibraryFiles/" + Request.QueryString["Id"] + drLibrary["Link"].ToString();
                        }
                        else
                            txtLink.Visible = false;

                        txtDetail.Text = Server.HtmlDecode(drLibrary["Detail"].ToString());
                        ddlLibraryCategory.SelectedValue = drLibrary["LibraryCategory"].ToString();
                        cbVisible.Checked = drLibrary["Visible"].ToString().Trim() == "1" ? true : false;

                        if (System.IO.File.Exists(Server.MapPath("~/Resource/Library/" + Request.QueryString["Id"] +  drLibrary["Picture"].ToString())))
                        {
                            imgLibrary.ImageUrl = "~/Resource/Library/" + Request.QueryString["Id"] + drLibrary["Picture"].ToString();
                        }
                        else
                            imgLibrary.Visible = false;

                        if (drLibrary["DateInput"].ToString().Trim().Length == 8)
                        {
                            string DateInput = drLibrary["DateInput"].ToString().Trim();
                            try
                            {
                                txtLibraryYear.Text = DateInput.Substring(0, 4);
                                ddlLibraryDay.Items.FindByText(DateInput.Substring(6, 2)).Selected = true;

                                if (ddlLibraryMounth.Items.FindByValue(DateInput.Substring(4, 2)) != null)
                                    ddlLibraryMounth.Items.FindByValue(DateInput.Substring(4, 2)).Selected = true;
                            }
                            catch
                            { txtLibraryYear.Text = ""; ddlLibraryDay.SelectedIndex = ddlLibraryMounth.SelectedIndex = 0; }
                        }

                        lblDateIn.Text = "تاریخ درج:" + Utility.GetPersianDate(drLibrary["DateIn"]);

                        hfLibraryId.Value = Server.HtmlEncode(Request.QueryString["Id"]);
                        lblMessage.Text = "وضعیت جاری:در حال ویرایش  : " + drLibrary["Title"].ToString();

                    }
                    else
                    {
                        lblMessage.Text = "وضعیت جاری:در حال درج";
                        SetCurrentDateTime();
                        imgLibrary.Visible = false;
                        txtLink.Visible = false;
                    }
                    #endregion
                }
                else
                {
                    lblMessage.Text = "وضعیت جاری:در حال درج";
                    SetCurrentDateTime();
                    imgLibrary.Visible = false;
                    txtLink.Visible = false;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        if (fuPic.PostedFile != null && fuPic.PostedFile.ContentLength > 0) 
            PostedFile = fuPic.PostedFile;

        if (fuLink.PostedFile != null && fuLink.PostedFile.ContentLength > 0)
            PostedFile = fuLink.PostedFile;
        }
        else
            Response.Redirect("~/manager/login.aspx");

   
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string UserName = Page.User.Identity.Name;

        if (txtTitle.Text.Length < 1 || txtDetail.Text.Length < 1 || txtSummary.Text.Length < 1 || (!string.IsNullOrEmpty(txtLibraryYear.Text) && txtLibraryYear.Text.Length < 4))
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, "لطفا اطلاعات را طبق موارد گفته شده تکمیل نمایید");
            return;
        }

        if (fuPic.HasFile && !Utility.IsValidExt(fuPic.FileName))
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, "تنها فایلهای تصویری معمول قابل انتخاب می باشند");
            return;
        }
        else if (fuPic != null && !Utility.IsValidExt(fuPic.FileName))
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, "تنها فایلهای تصویری معمول قابل انتخاب می باشند");
            return;
        }
        if (fuLink.HasFile && !Utility.IsValidDocExt(fuLink.FileName))
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, "تنها می توانید از فرمت های رایج مانند فایل های متنی و فشرده شده استفاده نمایید");
            return;
        }
        else if (PostedFile != null && !Utility.IsValidDocExt(PostedFile.FileName))
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, "تنها می توانید از فرمت های رایج مانند فایل های متنی و فشرده شده استفاده نمایید");
            return;
        }

        if (string.IsNullOrEmpty(txtLibraryYear.Text))
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, "وارد کردن سال الزامی است مانند 1391");
            return;
        }
        #region insert operation

        string DateInput = Server.HtmlEncode(txtLibraryYear.Text.Trim()) + Server.HtmlEncode(ddlLibraryMounth.SelectedValue) + Server.HtmlEncode(ddlLibraryDay.SelectedItem.Text);
        int LibraryId = -1;

        if (hfEditType.Value == "1")
        {
            LibraryId = LibraryTransfer.InsertLibrary(UserName, Server.HtmlEncode(txtTitle.Text.Trim()), Server.HtmlEncode(txtSummary.Text.Trim()), fuLink.FileName, Server.HtmlEncode(txtDetail.Text.Trim()), fuPic.FileName, cbVisible.Checked ? 1 : 0, DateInput, int.Parse(ddlLibraryCategory.SelectedValue));
        }
        else if (hfEditType.Value == "2")
        {
            LibraryId = LibraryTransfer.EditLibrary(int.Parse(hfLibraryId.Value), Server.HtmlEncode(txtTitle.Text.Trim()), Server.HtmlEncode(txtSummary.Text.Trim()), fuLink.FileName, Server.HtmlEncode(txtDetail.Text.Trim()), fuPic.FileName, cbVisible.Checked ? 1 : 0, DateInput, int.Parse(ddlLibraryCategory.SelectedValue));
        }
        #endregion


        if (LibraryId != -1)
        {
            if (hfEditType.Value == "2")
            {
                string imageName = imgLibrary.ImageUrl;
                if (!string.IsNullOrEmpty(imageName))
                {
                    string pic = System.Web.HttpContext.Current.Server.MapPath(imageName.Trim());
                    if (System.IO.File.Exists(pic))
                        System.IO.File.Delete(pic);
                }

                string FileName = txtLink.Text;
                if (!string.IsNullOrEmpty(FileName))
                {
                    string pic = System.Web.HttpContext.Current.Server.MapPath(FileName.Trim());
                    if (System.IO.File.Exists(pic))
                        System.IO.File.Delete(pic);
                }

            }
            if (fuPic.HasFile)
                fuPic.SaveAs(Request.PhysicalApplicationPath + "Resource/Library/" + LibraryId.ToString() + fuPic.FileName);
            else if (PostedFile != null)
            {
                PostedFile.SaveAs(Request.PhysicalApplicationPath + "Resource/Library/" + LibraryId.ToString() + fuPic.FileName);

                //remove PostedFile from session
                Session.Remove("postedFile");
            }
            if (fuLink.HasFile)
                fuLink.SaveAs(Request.PhysicalApplicationPath + "Resource/LibraryFiles/" + LibraryId.ToString() + fuLink.FileName);
            else if (PostedFile != null)
            {
                PostedFile.SaveAs(Request.PhysicalApplicationPath + "Resource/LibraryFiles/" + LibraryId.ToString() + fuLink.FileName);

                //remove PostedFile from session
                Session.Remove("postedFile");
            }

            Utility.ShowMsg(Page, PropertyData.MsgType.accept, "درج اطلاعات با موفقیت انجام گردید");
            Utility.ClearText(pnData);
            if (hfEditType.Value == "2")
                Response.Redirect("~/Manager/Library/LibraryList.aspx?r=ok");

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
        ddlLibraryDay.Items.FindByText(pc.GetDayOfMonth(DateTime.Now).ToString()).Selected = true;
        ddlLibraryMounth.Items.FindByValue(pc.GetMonth(DateTime.Now).ToString()).Selected = true;
        txtLibraryYear.Text = pc.GetYear(DateTime.Now).ToString();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Manager/Library/LibraryList.aspx?r=stop");
    }
    
}