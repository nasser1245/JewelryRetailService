using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.News;
using HProtest_BLL.Helper;
using HProtest_BLL;
using System.Web.Services;

public partial class Manager_News_NewsGroup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            rptProductType.DataSource = NewsData.GetNewsCategoryList(txtNewsCategorySearch.Text);
            rptProductType.DataBind();
        }
    }

    protected void btnAddMenu_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtTitleNewsCategory.Text))
        {
            Utility.ShowMsg(this, PropertyData.MsgType.warning, "عنوان منو نمی تواند خالی باشد.");
            return;
        }
        bool Successed;
        if (hfID.Value != "-1")
        {
            Successed = NewsData.EditNewsCategory(hfID.Value,txtTitleNewsCategory.Text,chkVisible.Checked);
            
        }
        else
        {
            Successed = NewsData.InsertNewsCategory(txtTitleNewsCategory.Text, chkVisible.Checked);
        }
        
        if (Successed)
        {
            Utility.ShowMsg(this, PropertyData.MsgType.accept, "عملیات با موفقیت انجام شد.");
            rptProductType.DataSource = NewsData.GetNewsCategoryList(txtNewsCategorySearch.Text);
            rptProductType.DataBind();
            if (hfID.Value != "-1")
                hfID.Value = "-1";
        }
        else
            Utility.ShowMsg(this, PropertyData.MsgType.warning, "در درج اطلاعات مشکلی پیش آمده است ممکن است اطلاعات تکراری باشد.");

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        rptProductType.DataSource = NewsData.GetNewsCategoryList(txtNewsCategorySearch.Text);
        rptProductType.DataBind();
    }


    [WebMethod]
    public static int DeleteArticle(string Id)
    {
        try
        {

            if (Id != null && Id != "" && Id != "undefined")
            {
                if (NewsTransfer.DeleteNewsCategory(int.Parse(Id)))
                    return 1;
                else
                    return 0;
            }
            else
            {
                return 0;
            }
        }
        catch
        {
            return 0;
        }

    }

    public void EditCategory_Command(object sender, CommandEventArgs e)
    {
        string[] fields = e.CommandArgument.ToString().Split(',');
        hfID.Value = fields[0];
        txtTitleNewsCategory.Text = fields[1];
        chkVisible.Checked = bool.Parse(fields[2]);
        rptProductType.DataSource = NewsData.GetNewsCategoryList(txtNewsCategorySearch.Text);
        rptProductType.DataBind();

    }
}