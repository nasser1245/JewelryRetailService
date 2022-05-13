using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.Helper;
using System.Data;
using HProtest_BLL;
using HProtest_BLL.Manager;
using ShayanDB_BLL;

public partial class Manager_UC_ucAdvertiseManage : System.Web.UI.UserControl
{
    public System.Web.HttpPostedFile PostedFile
    {
        set { Session["PostedFile"] = value; }
        get
        {
            if (Session["PostedFile"] != null)
                return (System.Web.HttpPostedFile)(Session["PostedFile"]);
            else return null;
        }
    }

    string sortDir = "desc", sortExpression = "tbAdvertise.Id";
    int PageSize = 10;
    private enum PagingType
    {
        First = 0,
        Previuse,
        Next,
        Last,
        none
    }
    private int CurrentPageIndex
    {
        get
        {
            if (ViewState["pageindex"] == null)
                ViewState["pageindex"] = 0;
            return Convert.ToInt32(ViewState["pageindex"]);
        }
        set { ViewState["pageindex"] = value; }
    }

    private int AllRowCount
    {
        get
        {
            if (ViewState["rowcount"] == null)
                ViewState["rowcount"] = 0;
            return Convert.ToInt32(ViewState["rowcount"]);
        }
        set { ViewState["rowcount"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                
                ddlFileType.DataSource = GetData.GetTable("tbFileType");
                ddlFileType.DataBind();

                ddlPosition.DataSource = GetData.GetTable("tbAdvertisePosition");
                ddlPosition.DataBind();

                picContainerPrw.Visible = false;
                flashContainerPrw.Visible = false;
                if (!string.IsNullOrEmpty(Request["id"]) && Utility.IsNumeric(Request["id"]))
                {

                    DataRow dr = HProtest_BLL.Advertise.AdvertiseData.GetAdvertiseById(int.Parse(Request["id"]));
                    if (dr != null)
                    {
                        #region fill contain

                        TxtTite.Text = dr["Title"].ToString();
                        TxtLink.Text = dr["Link"].ToString();
                        ddlFileType.SelectedValue = dr["IdFileType"].ToString();
                        TxtAdHeight.Text = dr["AdsHeight"].ToString();
                        ddlVisible.SelectedValue = dr["Visible"].ToString();
                        ddlPosition.SelectedValue = dr["IdAdvertisePosition"].ToString();
                        hfEditType.Value = "2";
                        lblMessage.Text = "وضعیت جاری:در حال ویرایش بنر : " + dr["Title"].ToString();

                        switch ((PropertyData.FileType)(int.Parse(dr["IdFileType"].ToString())))
                        {
                            case PropertyData.FileType.Picture:
                                {
                                    picContainerPrw.Visible = true;
                                    flashContainerPrw.Visible = false;

                                    if (System.IO.File.Exists(Server.MapPath("~/Resource/AdvertisePic/" + dr["FileAddress"].ToString())))
                                        Adimg.ImageUrl = Page.ResolveUrl("~/Resource/AdvertisePic/" + dr["FileAddress"].ToString());
                                    else
                                        Utility.ShowMsg(Page, PropertyData.MsgType.warning, "فایل مورد نظر موجود نمی باشد");
                                }
                                break;
                            case PropertyData.FileType.Flash:
                                {
                                    picContainerPrw.Visible = false;
                                    flashContainerPrw.Visible = true;
                                    if (System.IO.File.Exists(Server.MapPath("~/Resource/AdvertisePic/" + dr["FileAddress"].ToString())))
                                    {
                                        flashContainerPrw.Attributes.Add("href", Page.ResolveUrl("~/Resource/AdvertisePic/" + dr["FileAddress"].ToString()));
                                        flashContainerPrw.Attributes.Add("height", dr["AdsHeight"].ToString());
                                    }
                                    else
                                    {
                                        Utility.ShowMsg(Page, PropertyData.MsgType.warning, "فایل مورد نظر از سرور پاک شده");
                                    }
                                }
                                break;
                            default:
                                break;

                        }
                        #endregion

                    }

                }
                else
                {
                    lblMessage.Text = "وضعیت جاری:در حال درج";
                }
            }
            catch { }

            BindPagingGrid(true);
            SetPager(PagingType.none);
        }


        if (fuPic.PostedFile != null && fuPic.PostedFile.ContentLength > 0)
            PostedFile = fuPic.PostedFile;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string Username = Page.User.Identity.Name;

        if (TxtTite.Text.Length < 1 || (!string.IsNullOrEmpty(TxtAdHeight.Text) && !Utility.IsNumeric(TxtAdHeight.Text)))
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, "لطفا اطلاعات را طبق موارد گفته شده تکمیل نمایید");
            return;
        }

        if (!string.IsNullOrEmpty(TxtLink.Text) && !Utility.IsValidLink(TxtLink.Text))
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, "لینک با فرمت مناسبی نوشته نشده است،لطفا از الگوی راهنما استفاده نمایید");
            return;
        }

        if (PostedFile == null && fuPic.PostedFile == null && string.IsNullOrEmpty(Adimg.ImageUrl))
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, "فایلی برای بنر انتخاب نشده است");
            return;
        }

        if (!string.IsNullOrEmpty(fuPic.FileName) && !Utility.IsValidPicOrSwfExt(fuPic.FileName))
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, "تنها فایلهای تصویری و فلش معمول قابل انتخاب می باشند");
            return;
        }
        else if (PostedFile != null && !Utility.IsValidPicOrSwfExt(PostedFile.FileName))
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, "تنها فایلهای تصویری و فلش معمول قابل انتخاب می باشند");
            return;
        }
        ///check file size
        if ((PostedFile != null && PostedFile.ContentLength > 1024000) || (fuPic.PostedFile != null && fuPic.PostedFile.ContentLength > 1024000))
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, "حجم فایل نباید بیشتر از 1 مگابایت باشد");
            return;

        }

        string AdExtention = "";


        int AdvertiseId = 0;
        if (hfEditType.Value == "1")
        {
            //if (Session["AccessLevel"] != null && ((Bime1ir_BLL.AccessLevel.AccessLevel)Session["AccessLevel"]).AdvertiseCreateDelete != true)
            //{
            //    Utility.ShowMsg(Page, PropertyData.MsgType.warning, "شما اجازه ی دسترسی به این عملیات را ندارید");
            //    return;
            //}

            AdExtention = fuPic.HasFile ? System.IO.Path.GetExtension(fuPic.FileName) : (PostedFile != null ? System.IO.Path.GetExtension(PostedFile.FileName) : "-1");

            AdvertiseId = HProtest_BLL.Advertise.AdvertiseTransfer.AdvertiseInsert(Username, Server.HtmlEncode(TxtTite.Text), Server.HtmlEncode(TxtLink.Text),
                            int.Parse(ddlVisible.SelectedValue), Convert.ToInt32(ddlFileType.SelectedValue), int.Parse(ddlPosition.SelectedValue),
                            Utility.IsNumeric(TxtAdHeight.Text) ? int.Parse(TxtAdHeight.Text) : -1, AdExtention);
        }
        else if (hfEditType.Value == "2")//edit mode
        {
            //if (Session["AccessLevel"] != null && ((Bime1ir_BLL.AccessLevel.AccessLevel)Session["AccessLevel"]).AdvertiseEdit != true)
            //{
            //    Utility.ShowMsg(Page, PropertyData.MsgType.warning, "شما اجازه ی دسترسی به این عملیات را ندارید");
            //    return;
            //}

            //++++//باید خلاصه بشه با بالاییdd
            if (!string.IsNullOrEmpty(fuPic.PostedFile.FileName))
            {
                AdExtention = System.IO.Path.GetExtension(fuPic.FileName);

            }
            else
            {
                AdExtention = picContainerPrw.Visible ? Adimg.ImageUrl.Substring(Adimg.ImageUrl.LastIndexOf(".")) :
                    flashContainerPrw.Attributes["href"].ToString().Substring(flashContainerPrw.Attributes["href"].ToString().LastIndexOf("."));
            }

            AdExtention = fuPic.HasFile ? System.IO.Path.GetExtension(fuPic.FileName) : (!string.IsNullOrEmpty(Adimg.ImageUrl) ? System.IO.Path.GetExtension(Adimg.ImageUrl) : "-1");

            AdvertiseId = HProtest_BLL.Advertise.AdvertiseTransfer.EditAdvertise(int.Parse(Request["id"]), Server.HtmlEncode(TxtTite.Text), Server.HtmlEncode(TxtLink.Text),
              Convert.ToInt32(ddlVisible.SelectedValue), int.Parse(ddlFileType.SelectedValue), int.Parse(ddlPosition.SelectedValue),
              Utility.IsNumeric(TxtAdHeight.Text) ? int.Parse(TxtAdHeight.Text) : -1, AdExtention);
        }

        if (AdvertiseId != -1)
        {
            if (!string.IsNullOrEmpty(fuPic.PostedFile.FileName))
                fuPic.SaveAs(Request.PhysicalApplicationPath + "Resource/AdvertisePic/" + AdvertiseId + AdExtention);
            else
                if (PostedFile != null)
                {
                    PostedFile.SaveAs(Request.PhysicalApplicationPath + "Resource/AdvertisePic/" + AdvertiseId + AdExtention);
                    Session.Remove("PostedFile");
                }

            Response.Redirect("Advertise.aspx");
        }
    }

    protected void btnClearFilter_Click(object sender, EventArgs e)
    {
        StxtTitle.Text = "";

        CurrentPageIndex = 0;
        BindPagingGrid();
        SetPager(PagingType.none);
    }

    #region pager method
    private void SetPager(PagingType Type)
    {
        try
        {
            int LastPageIndex = 0;

            if ((AllRowCount % PageSize) == 0)
                LastPageIndex = AllRowCount / PageSize;
            else
                LastPageIndex = AllRowCount / PageSize + 1;

            switch (Type)
            {
                case PagingType.First:
                    CurrentPageIndex = 0;
                    BindPagingGrid();
                    break;
                case PagingType.Previuse:
                    if (CurrentPageIndex >= 0)
                        CurrentPageIndex = CurrentPageIndex - 1;
                    BindPagingGrid();
                    break;
                case PagingType.Next:
                    if (CurrentPageIndex + 1 != LastPageIndex)
                        CurrentPageIndex = CurrentPageIndex + 1;
                    BindPagingGrid();
                    break;
                case PagingType.Last:
                    CurrentPageIndex = LastPageIndex - 1;
                    BindPagingGrid();
                    break;
                default:
                    break;
            }

            if (CurrentPageIndex == 0)
                imgbtnFirst.Visible = imgbtnPrev.Visible = false;
            else
                imgbtnFirst.Visible = imgbtnPrev.Visible = true;

            if (CurrentPageIndex + 1 == LastPageIndex)
                imgbtnLast.Visible = imgbtnNext.Visible = false;
            if (CurrentPageIndex + 1 < LastPageIndex)
                imgbtnLast.Visible = imgbtnNext.Visible = true;

            lblPagNumber.Text = "صفحه " + (CurrentPageIndex + 1).ToString() + " از " + LastPageIndex.ToString();
        }
        catch
        { }
    }

    protected void imgbtnNext_Click(object sender, ImageClickEventArgs e)
    {
        SetPager(PagingType.Next);
    }

    protected void imgbtnLast_Click(object sender, ImageClickEventArgs e)
    {
        SetPager(PagingType.Last);
    }

    protected void imgbtnPrev_Click(object sender, ImageClickEventArgs e)
    {
        SetPager(PagingType.Previuse);
    }

    protected void imgbtnFirst_Click(object sender, ImageClickEventArgs e)
    {
        SetPager(PagingType.First);
    }
    #endregion

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        CurrentPageIndex = 0;
        BindPagingGrid();
        SetPager(PagingType.none);
    }

    private void BindPagingGrid(bool CallPageLoad=false)
    {
        try
        {
            ///use for any datetime filter 
            DateTime DateFrom = new DateTime(1753, 1, 1);
            DateTime DateTo = new DateTime(9999, 1, 1);

            int AllCurrentCount = 0;
            if (!CallPageLoad)
            {
                using (System.Data.DataTable dtAdvertise = HProtest_BLL.Advertise.AdvertiseData.GetAdvertiseList("", Server.HtmlDecode(StxtTitle.Text), DateFrom, DateTo, -1, Convert.ToInt32(ddlFileType.SelectedValue), Convert.ToInt32(ddlPosition.SelectedValue),
                    sortExpression, sortDir, CurrentPageIndex, PageSize, out AllCurrentCount))
                {
                    if (dtAdvertise != null && dtAdvertise.Rows.Count > 0)
                    {
                        rptAdvertise.DataSource = dtAdvertise;
                    }
                    rptAdvertise.DataBind();
                }
            }
            else
            {
                using (System.Data.DataTable dtAdvertise = HProtest_BLL.Advertise.AdvertiseData.GetAdvertiseList("", "", DateFrom, DateTo, -1, -1, -1,
        sortExpression, sortDir, CurrentPageIndex, PageSize, out AllCurrentCount))
                {
                    if (dtAdvertise != null && dtAdvertise.Rows.Count > 0)
                    {
                        rptAdvertise.DataSource = dtAdvertise;
                    }
                    rptAdvertise.DataBind();
                }
            }
            AllRowCount = AllCurrentCount;
            lblResultCount.Text = AllRowCount.ToString();
        }
        catch { }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.AbsolutePath.ToString());
    }
}