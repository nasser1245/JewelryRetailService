using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.Member;
using HProtest_BLL.Manager;
using HProtest_BLL;
using HProtest_BLL.Helper;

public partial class Manager_Product_AddProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["AccessLevel"] == null)
            Response.Redirect("~/manager/login.aspx");
        if (Page.User.IsInRole("1") || ((HProtest_BLL.AccessLevel.AccessLevel)HttpContext.Current.Session["AccessLevel"]).ProductAgent == true)
        {
            if (!IsPostBack)
            {
                ddlTypeProductParrent.DataSource = ManagerData.GetMenu(0);
                ddlTypeProductParrent.DataTextField = "type";
                ddlTypeProductParrent.DataValueField = "id";
                ddlTypeProductParrent.DataBind();

                try
                {
                    ddlTypeProduct.DataSource = ManagerData.GetMenuByParent(int.Parse(ddlTypeProductParrent.SelectedValue));
                    ddlTypeProduct.DataTextField = "type";
                    ddlTypeProduct.DataValueField = "id";
                    ddlTypeProduct.DataBind();
                }
                catch { }
                if (Request["id"] != null)
                {
                    string id = Request["id"].ToString();
                    
                    hplpics.NavigateUrl="~/Manager/Product/AddPics.aspx?pid="+ Request["id"].ToString();
                    System.Data.DataTable dtProduct = ManagerData.GetProductInfo(id);

                    if (dtProduct != null)
                    {
                        for (int i = 0; i < dtProduct.Rows.Count; i++)
                        {
                            txtName.Text = dtProduct.Rows[i]["Name"].ToString();
                            txtDesp.Text = dtProduct.Rows[i]["Desp"].ToString();
                            txtAboutProduct.Text = dtProduct.Rows[i]["AboutProduct"].ToString();
                            chkLuxe.Checked = Convert.ToBoolean((dtProduct.Rows[i]["Luxe"].ToString()));
                            chkSize.Checked = Convert.ToBoolean((dtProduct.Rows[i]["Size"].ToString()));
                            txtPrice.Text = dtProduct.Rows[i]["Price"].ToString();
                            lblHasVideo.Text = dtProduct.Rows[i]["Video"].ToString();
                            imgMainPic.ImageUrl = "~/Resource/ProductPic/" + dtProduct.Rows[i]["MainPic"].ToString();
                            HidenCount.Value = dtProduct.Rows[i]["Count"].ToString();
                            HidenPoint.Value = dtProduct.Rows[i]["Point"].ToString();
                            HidenVisited.Value = dtProduct.Rows[i]["Visited"].ToString();
                            txtProductCount.Text = dtProduct.Rows[i]["ProductCount"].ToString();
                            chkVisible.Checked = Convert.ToBoolean((dtProduct.Rows[i]["Visible"].ToString()));
                            ddlTypeProductParrent.SelectedValue = dtProduct.Rows[i]["parentid"].ToString();
                            //ddlTypeProduct.SelectedValue = dtProduct.Rows[i]["ProductTypeID"].ToString();

                            ddlTypeProduct.DataSource = ManagerData.GetMenuByParent(int.Parse(dtProduct.Rows[i]["parentid"].ToString()));
                            ddlTypeProduct.DataTextField = "type";
                            ddlTypeProduct.DataValueField = "id";
                            ddlTypeProduct.DataBind();
                            ddlTypeProduct.SelectedValue = dtProduct.Rows[i]["ProductTypeID"].ToString();
                            if (!String.IsNullOrEmpty(dtProduct.Rows[i]["LimitFrom"].ToString()) || !String.IsNullOrEmpty(dtProduct.Rows[i]["LimitTo"].ToString()))
                                Chkgift.Checked = true;
                            txtFrom.Text = dtProduct.Rows[i]["LimitFrom"].ToString();
                            txtTo.Text = dtProduct.Rows[i]["LimitTo"].ToString();
                        }
                    }
                }
            }
        }
        else
            Response.Redirect("~/manager/login.aspx");
    }

    protected void btnAddProduct_Click(object sender, EventArgs e)
    {

        Server.ScriptTimeout = 999999;
        
        if (txtName.Text.Length < 1)
            Utility.ShowMsg(this, PropertyData.MsgType.warning, "وارد کردن نام کاربر الزامی است");

        if ((!Utility.IsNumeric(txtProductCount.Text) && !string.IsNullOrEmpty(txtProductCount.Text)) || (!Utility.IsNumeric(txtPrice.Text) && !string.IsNullOrEmpty(txtPrice.Text)) 
            || (!Utility.IsNumeric(txtFrom.Text) && Chkgift.Checked == true) ||
            (!Utility.IsNumeric(txtTo.Text) && Chkgift.Checked == true))
        {
            Utility.ShowMsg(this, PropertyData.MsgType.warning, "فیلد های عددی را ،با دقت پر نمایید");
            return;
        }
        if (Chkgift.Checked == true && (int.Parse(txtFrom.Text) > int.Parse(txtTo.Text)))
        {
            Utility.ShowMsg(this, PropertyData.MsgType.warning, "محدوده های اشانتیون را به طور صحیح وارد کنید");
            return;
        }


        if (Request["id"] == null)//for add
        {
            try
            {
                int vu = VideoUpload.PostedFile.ContentLength;
                int pu = PicUpload.PostedFile.ContentLength;
                string extPic = "1", extVideo = "1";
                if (pu > 0)
                    extPic = ValidatePics();
                if (vu > 0)
                    extVideo = ValidateVideos();
                if (extPic == null) { return; }
                if (extVideo == null) { return; }
                string filename = ManagerData.AddProduct(Page.User.Identity.Name, txtName.Text, txtDesp.Text, txtAboutProduct.Text, vu > 0 ? "is upload" : "-1", pu > 0 ? "is upload" : "-1", extPic, extVideo, chkSize.Checked, chkLuxe.Checked, int.Parse(!string.IsNullOrEmpty(txtPrice.Text) ? txtPrice.Text : "0"), ddlTypeProduct.SelectedItem.Value, chkVisible.Checked, int.Parse(!string.IsNullOrEmpty(txtProductCount.Text) ? txtProductCount.Text : "1"), Chkgift.Checked, int.Parse(!string.IsNullOrEmpty(txtFrom.Text) ? txtFrom.Text : "0"), int.Parse(!string.IsNullOrEmpty(txtTo.Text) ? txtTo.Text : "0"));

                if (pu > 0)
                {
                    PicUploads(filename + extPic);
                }
                if (vu > 0)
                {
                    VideoUploads(filename + extVideo);
                }
                ClearSection();

                Utility.ShowMsg(this, PropertyData.MsgType.accept, "عملیات با موفقیت انجام شد.");
            }
            catch
            {
                Utility.ShowMsg(this, PropertyData.MsgType.warning, "عملیات با خطا مواجه شد دوباره سعی کنید.");
                return;
            }
        }
        else // for edit
        {
            //btnAddProduct.Text = "ثبت تغییرات";
            try
            {
                int vu = VideoUpload.PostedFile.ContentLength;
                int pu = PicUpload.PostedFile.ContentLength;
                string extPic = "1", extVideo = "1";
                if (pu > 0)
                    extPic = ValidatePics();
                if (vu > 0)
                    extVideo = ValidateVideos();

                if (extPic == null) { return; }
                if (extVideo == null) { return; }
                ManagerData.UpdateProduct(Request["id"].ToString(), txtName.Text, txtDesp.Text, txtAboutProduct.Text, vu > 0 ? Request["id"].ToString() + extVideo : "-1", pu > 0 ? Request["id"].ToString() + extPic : "-1", extPic, extVideo, chkSize.Checked, chkLuxe.Checked, int.Parse(!string.IsNullOrEmpty(txtPrice.Text) ? txtPrice.Text : "0"), ddlTypeProduct.SelectedValue, HidenVisited.Value, HidenPoint.Value, HidenCount.Value, chkVisible.Checked, int.Parse(!string.IsNullOrEmpty(txtProductCount.Text) ? txtProductCount.Text : "1"), Chkgift.Checked, int.Parse(!string.IsNullOrEmpty(txtFrom.Text) ? txtFrom.Text : "0"), int.Parse(!string.IsNullOrEmpty(txtTo.Text) ? txtTo.Text : "0"));
                string filename = Request["id"].ToString();

                if (pu > 0)
                {
                    string path = Server.MapPath("~\\Resource\\ProductPic\\");
                    imgMainPic.ImageUrl = null;
                    Common.DelFile(path + Request["extPic"].ToString());
                    PicUploads(filename + extPic);
                }
                if (vu > 0)
                {
                    string path = Server.MapPath("~\\Resource\\ProductVideo\\");
                    imgMainPic.ImageUrl = null;
                    Common.DelFile(path + Request["extVid"].ToString());
                    VideoUploads(filename + extVideo);
                }
                Response.Redirect("ProductList.aspx?r=ok");
            }
            catch
            {
                Utility.ShowMsg(this, PropertyData.MsgType.warning, "عملیات با خطا مواجه شد دوباره سعی کنید.");
                return;
            }

        }
    }
     private void  ClearSection()
        {
            //foreach (var obj in Page.Controls.OfType<TextBox>())
            //{
            //    obj.Text = "";
            //}
            txtAboutProduct.Text = txtDesp.Text = txtName.Text = txtPrice.Text = txtTo.Text = txtFrom.Text = txtProductCount.Text = "";
            chkLuxe.Checked = false; chkSize.Checked = false;
        }
    
    public string ValidatePics()
    {
        String[] Validext = { ".jpg", ".gif", ".png", ".bmp" };
        string ext = System.IO.Path.GetExtension(PicUpload.PostedFile.FileName);
        if (Array.IndexOf(Validext, ext.ToLower()) < 0)
        {
           // lblPicNotValidate.Text = "فایل وارد شده معتبر نیست!";
            Utility.ShowMsg(this, PropertyData.MsgType.warning, "فایل عکس وارد شده معتبر نیست.");

            return null;
        }


        //3- get and check file size
        long size = PicUpload.PostedFile.ContentLength;
        size = size / 1024;
        if (size > 2000)
        {
            Utility.ShowMsg(this, PropertyData.MsgType.warning, "حجم فایل عکس باید کمتر از 2 مگابایت باشد.");
            return null;
        }
        return ext;
    }
    public string ValidateVideos()
    {
        String[] Validext = { ".mp4", ".flv", ".3gp" };
        string ext = System.IO.Path.GetExtension(VideoUpload.PostedFile.FileName);
        if (Array.IndexOf(Validext, ext.ToLower()) < 0)
        {
           //lblPicNotValidate.Text = "فایل وارد شده معتبر نیست!";
            Utility.ShowMsg(this, PropertyData.MsgType.warning, "فایل ویدئو وارد شده معتبر نیست.");

            return null;
        }


        //3- get and check file size
        long size = VideoUpload.PostedFile.ContentLength;
        size = size / 1024;
        if (size > 10000)
        {
            Utility.ShowMsg(this, PropertyData.MsgType.warning, "حجم فایل ویدئو باید کمتر از 9 مگابایت باشد.");
            return null;
        }
        return ext;
    }

    public string PicUploads(string filename)
    {
        string path = Server.MapPath("~\\Resource\\ProductPic\\");

        //4- get file name
        //string filename = System.IO.Path.GetFileName(PicUpload.PostedFile.FileName);

        //5- check file exist and if (true) generate new name
        //while (System.IO.File.Exists(path + "\\" + filename))
        //    filename = "1" + filename;

        //6- save file to server
        PicUpload.PostedFile.SaveAs(path + filename);
        return "1";

    }

    public string VideoUploads(string filename)
    {
        string path = Server.MapPath("~\\Resource\\ProductVideo\\");

        //4- get file name
        // string filename = System.IO.Path.GetFileName(VideoUpload.PostedFile.FileName);


        //6- save file to server
        VideoUpload.PostedFile.SaveAs(path + filename);
        return "";
    }

    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProductList.aspx?r=stop");
        
    }
    protected void ddlTypeProductParrent_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlTypeProduct.DataSource = ManagerData.GetMenuByParent(int.Parse(ddlTypeProductParrent.SelectedValue));
        ddlTypeProduct.DataTextField = "type";
        ddlTypeProduct.DataValueField = "id";
        ddlTypeProduct.DataBind();
    }
}



