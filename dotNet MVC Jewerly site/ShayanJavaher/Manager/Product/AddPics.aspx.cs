using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.Manager;
using HProtest_BLL;

public partial class Manager_Product_PicsDisplay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
          if (HttpContext.Current.Session["AccessLevel"] == null)
            Response.Redirect("~/manager/login.aspx");
          if (Page.User.IsInRole("1") || ((HProtest_BLL.AccessLevel.AccessLevel)HttpContext.Current.Session["AccessLevel"]).ProductAgent == true)
          {
              if (Request["pid"] == null)
              {
                  //peygham
                  Response.Redirect("ProductList.aspx");
              }
              if(!HProtest_BLL.Helper.Utility.IsNumeric(Request["pid"].ToString()))
                  Response.Redirect("ProductList.aspx");
              string Pid = Request["pid"].ToString();
              DatalistDisplayPics.DataSource = Common.GetPics(Pid);
              DatalistDisplayPics.DataBind();
          }
          else
              Response.Redirect("~/manager/login.aspx");

        
    }
    public string PicUploads(string filename)
    {

        string path = Server.MapPath("~\\Resource\\ProductOtherPic\\");
        PicUpload.PostedFile.SaveAs(path + filename);
        //peygham
        return "1";
    }
    public void lbEditProduct_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("AddProduct.aspx?id=" + e.CommandArgument.ToString());
    }
    public void lblDeleteProduct_Command(object sender, CommandEventArgs e)
    {
        try
        {
            string[] fields = e.CommandArgument.ToString().Split(',');
            ManagerData.DeleteProductPic(int.Parse(fields[0]));

            string path = Server.MapPath("~\\Resource\\ProductOtherPic\\");

            Common.DelFile(path + fields[1]);

            if (Request["pid"] == null)
            {
                HProtest_BLL.Helper.Utility.ShowMsg(this, PropertyData.MsgType.warning, "اطلاعات آدرس دستکاری شده به لیست محصولات  رفته و مجدد تلاش کنید.");
                return;
                //Response.Redirect("ProductList.aspx");
            }
            string Pid = Request["pid"].ToString();

            if (!HProtest_BLL.Helper.Utility.IsNumeric(Pid))
            {
                HProtest_BLL.Helper.Utility.ShowMsg(this, PropertyData.MsgType.warning, "اطلاعات آدرس دستکاری شده به لیست محصولات  رفته و مجدد تلاش کنید.");
                return;
            }
            DatalistDisplayPics.DataSource = Common.GetPics(Pid);
            DatalistDisplayPics.DataBind();
            HProtest_BLL.Helper.Utility.ShowMsg(this, PropertyData.MsgType.accept, "عملیات با موفقیت انجام شد.");
        }
        catch {
            HProtest_BLL.Helper.Utility.ShowMsg(this, PropertyData.MsgType.warning, "بروز خطای نامشخص مجدد تلاش کنید.");
        
        }
    }
    public string ValidatePics()
    {
        String[] Validext = { ".jpg", ".gif", ".png", ".bmp" };
        string ext = System.IO.Path.GetExtension(PicUpload.PostedFile.FileName);
        if (Array.IndexOf(Validext, ext.ToLower()) < 0)
        {
            HProtest_BLL.Helper.Utility.ShowMsg(this,PropertyData.MsgType.warning, "فایل وارد شده معتبر نیست!");

            return null;
        }


        long size = PicUpload.PostedFile.ContentLength;
        size = size / 1024;
        if (size > 2000)
        {
            HProtest_BLL.Helper.Utility.ShowMsg(this, PropertyData.MsgType.warning, "حداکثر حجم فایل 2 مگابایت است!");

            //Response.Write("file size must < 2000KB");
            return null;
        }
        return ext;
    }
    protected void btnAddPic_Click(object sender, EventArgs e) {
        if (Request["pid"] != null)//for add
        {

            int pu = PicUpload.PostedFile.ContentLength;
            string extPic = "1";
            if (pu > 0)
                extPic = ValidatePics();
            else
            {
                HProtest_BLL.Helper.Utility.ShowMsg(this, PropertyData.MsgType.warning, "لطفا یک عکس انتخاب کنید.");

                return;
            }

            if (extPic == null) {
                //peygham 
                return; }

            string Pid = Request["pid"].ToString();

            if (!HProtest_BLL.Helper.Utility.IsNumeric(Pid))
            {
                HProtest_BLL.Helper.Utility.ShowMsg(this, PropertyData.MsgType.warning, "اطلاعات آدرس دستکاری شده به لیست محصولات  رفته و مجدد تلاش کنید.");
                return;
            }
            string filename = ManagerData.AddPics(int.Parse(Pid), extPic);

            if (pu > 0)
            {
                PicUploads(filename + extPic);
            }
            if (!string.IsNullOrEmpty(filename))
            {
                DatalistDisplayPics.DataSource = Common.GetPics(Pid);
                DatalistDisplayPics.DataBind();
                HProtest_BLL.Helper.Utility.ShowMsg(this, PropertyData.MsgType.accept, "عملیات با موفقیت انجام شد.");
            }
            else
            {
                HProtest_BLL.Helper.Utility.ShowMsg(this, PropertyData.MsgType.warning, "بروز خطای نامشخص مجدد تلاش کنید.");
            
            }
        }
        else
        {
            
            Response.Redirect("ProductList.aspx");
        }
        }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Manager/Product/ProductList.aspx");
    }
}
