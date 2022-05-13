using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.Manager;
using HProtest_BLL.Helper;
using HProtest_BLL;
using System.Web.Services;

public partial class Manager_Product_ProductType : System.Web.UI.Page
{
    //int PageSize = 10;

    //private enum PagingType
    //{
    //    First = 0,
    //    Previuse,
    //    Next,
    //    Last,
    //    none
    //}
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlMenus.DataSource = ManagerData.GetMenuList("-1","0");
            ddlMenus.DataTextField = "Type";
            ddlMenus.DataValueField = "ID";
            ddlMenus.DataBind();

            ddlMenusSearch.Items.Add(new System.Web.UI.WebControls.ListItem("انتخاب کنید", "0"));
            ddlMenusSearch.DataSource = ManagerData.GetMenuList("-1","0");
            ddlMenusSearch.DataTextField = "Type";
            ddlMenusSearch.DataValueField = "ID";
            ddlMenusSearch.DataBind();

            rptProductType.DataSource = ManagerData.GetMenuList(txtMenuSearch.Text);
            rptProductType.DataBind();

        }
    }
    protected void btnAddSubMenu_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(ddlMenus.SelectedValue))
        {
            Utility.ShowMsg(this, PropertyData.MsgType.warning, "نوع زیر منو نمی تواند خالی باشد.");
            return;
        }
        if (string.IsNullOrEmpty(txtTitleSubMenu.Text))
        {
            Utility.ShowMsg(this, PropertyData.MsgType.warning, "عنوان زیر منو نمی تواند خالی باشد.");
            return;
        }
        bool Successed;
        if (hfID.Value != "-1")
        {
            Successed = ManagerData.EditMenu(int.Parse(hfID.Value), txtTitleSubMenu.Text, chkVisibleSubMenu.Checked, int.Parse(ddlMenus.SelectedValue));

        }
        else
        {
            Successed = ManagerData.InsertMenu(txtTitleSubMenu.Text, chkVisibleMenu.Checked, int.Parse(ddlMenus.SelectedValue));
        }
        if (Successed)
        {
            txtTitleSubMenu.Text = "";
            Utility.ShowMsg(this, PropertyData.MsgType.accept, "عملیات با موفقیت انجام شد.");
            rptProductType.DataSource = ManagerData.GetMenuList(txtMenuSearch.Text);
            rptProductType.DataBind();
            if (hfID.Value != "-1")
            {
                hfID.Value = "-1";
                txtTitleSubMenu.Text = "";
                chkVisibleSubMenu.Checked = false;
            }
        }
        else
        {
            Utility.ShowMsg(this, PropertyData.MsgType.warning, "در درج اطلاعات مشکلی پیش آمده است.<br> ممکن است اطلاعات تکراری وارد کرده باشید.");
            Utility.ShowMsg(this, PropertyData.MsgType.warning, "ممکن است اطلاعات تکراری وارد کرده باشید.");
        }
    }
    protected void btnAddMenu_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtTitleMenu.Text))
        {
            Utility.ShowMsg(this, PropertyData.MsgType.warning, "عنوان منو نمی تواند خالی باشد.");
            return;
        }
        bool Successed;
        if (hfID.Value != "-1")
        {
            Successed = ManagerData.EditMenu(int.Parse(hfID.Value), txtTitleMenu.Text, chkVisibleMenu.Checked);

        }
        else
        {
            Successed = ManagerData.InsertMenu(txtTitleMenu.Text, chkVisibleMenu.Checked);
        }


        if (Successed)
        {
            Utility.ShowMsg(this, PropertyData.MsgType.accept, "عملیات با موفقیت انجام شد.");
            rptProductType.DataSource = ManagerData.GetMenuList(txtMenuSearch.Text);
            rptProductType.DataBind();
            if (hfID.Value != "-1")
            {
                hfID.Value = "-1";
                txtMenuSearch.Text = "";
                chkVisibleMenu.Checked = false;
            }
            ddlMenus.DataSource = ManagerData.GetMenu();
            ddlMenus.DataTextField = "type";
            ddlMenus.DataValueField = "id";
            ddlMenus.DataBind();

            ddlMenusSearch.Items.Add(new System.Web.UI.WebControls.ListItem("انتخاب کنید", "0"));
            ddlMenusSearch.DataSource = ManagerData.GetMenuList("-1", "0");
            ddlMenusSearch.DataTextField = "Type";
            ddlMenusSearch.DataValueField = "ID";
            ddlMenusSearch.DataBind();

        }
        else
        {
            Utility.ShowMsg(this, PropertyData.MsgType.warning, "در درج اطلاعات مشکلی پیش آمده است.<br> ممکن است اطلاعات تکراری وارد کرده باشید.");
            //Utility.ShowMsg(this, PropertyData.MsgType.warning, "ممکن است اطلاعات تکراری وارد کرده باشید.");
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        rptProductType.DataSource = ManagerData.GetMenuList(txtMenuSearch.Text,ddlMenusSearch.SelectedValue);
        rptProductType.DataBind();
    }

    public void DeleteMenu_Command(object sender, CommandEventArgs e)
    {
        string[] fields = e.CommandArgument.ToString().Split(',');
        bool Successed;
        if (string.IsNullOrEmpty(fields[1]))
        {
            Successed = ManagerData.DeleteMenu(int.Parse(fields[0]));
            if(!Successed){
                Utility.ShowMsg(this, PropertyData.MsgType.warning, "در حذف منو مشکلی پیش آمده است.");
            }else
                Response.Redirect("~/Manager/Product/ProductType.aspx");
        }
        else{
            Successed = ManagerData.DeleteMenu(int.Parse(fields[0]));
            if(!Successed){
                Utility.ShowMsg(this, PropertyData.MsgType.warning, "در حذف منو مشکلی پیش آمده است.");
            }else
                Utility.ShowMsg(this, PropertyData.MsgType.accept, "عملیات با موفقیت اجرا شد.");
        }

        rptProductType.DataSource = ManagerData.GetMenuList(txtMenuSearch.Text);
        rptProductType.DataBind();
    }
    public void EditCategory_Command(object sender, CommandEventArgs e)
    {
        string[] fields = e.CommandArgument.ToString().Split(',');
        hfID.Value = fields[0];
        txtTitleMenu.Text = txtTitleSubMenu.Text = "";
        if (string.IsNullOrEmpty(fields[2]))
        {
            txtTitleMenu.Text = fields[1];
            chkVisibleMenu.Checked = bool.Parse(fields[3]);
        }
        else
        {
            txtTitleSubMenu.Text = fields[1];
            
            chkVisibleSubMenu.Checked = bool.Parse(fields[3]);
        }
    }

    protected void btnDelSearch_Click(object sender, EventArgs e)
    {
        rptProductType.DataSource = ManagerData.GetMenuList("");
        rptProductType.DataBind();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ProductType.aspx");
    }


    //private int CurrentPageIndex
    //{
    //    get
    //    {
    //        if (ViewState["pageindex"] == null)
    //            ViewState["pageindex"] = 0;
    //        return Convert.ToInt32(ViewState["pageindex"]);
    //    }
    //    set { ViewState["pageindex"] = value; }
    //}

    //private int AllRowCount
    //{
    //    get
    //    {
    //        if (ViewState["rowcount"] == null)
    //            ViewState["rowcount"] = 0;
    //        return Convert.ToInt32(ViewState["rowcount"]);
    //    }
    //    set { ViewState["rowcount"] = value; }
    //}

    //private void BindPagingGrid()
    //{
    //    try
    //    {
    //        int AllCurrentCount = 0;
    //        // اگر مدیر اصلی بود یا اگر مدیر میانی بود باید دسترسی مسئول مدیران را داشته باشد
    //        //if (Page.User.IsInRole("1") || ((HProtest_BLL.AccessLevel.AccessLevel)HttpContext.Current.Session["AccessLevel"]).ManagerAgent == true)
    //        {
    //            rptProductType.DataSource = ManagerData.GetMenuList(txtMenuSearch.Text);
    //            rptProductType.DataBind();

    //                //if (dtPagedArticles != null && dtPagedArticles.Rows.Count > 0)
    //                //{
    //                //    rptArticle.DataSource = dtPagedArticles;
    //                //}
    //                //rptArticle.DataBind();

    //                AllRowCount = AllCurrentCount;
                
    //            lblMsgResultCount.Text = "تعداد ردیف مورد جستجو: ";
    //            lblResultCount.Text = AllRowCount.ToString();
    //        }
    //        //else
    //        //{
    //        //    Utility.ShowMsg(Page, PropertyData.MsgType.warning, "شما اجازه ی دسترسی به این عملیات را ندارید");
    //        //    Response.Redirect(ViewState["GoBackTo"].ToString());

    //        //}
    //    }
    //    catch (Exception ex)
    //    { }
    //}

    //private void SetPager(PagingType Type)
    //{
    //    try
    //    {
    //        int LastPageIndex = 0;

    //        if ((AllRowCount % PageSize) == 0)
    //            LastPageIndex = AllRowCount / PageSize;
    //        else
    //            LastPageIndex = AllRowCount / PageSize + 1;

    //        switch (Type)
    //        {
    //            case PagingType.First:
    //                CurrentPageIndex = 0;
    //                BindPagingGrid();
    //                break;
    //            case PagingType.Previuse:
    //                if (CurrentPageIndex >= 0)
    //                    CurrentPageIndex = CurrentPageIndex - 1;
    //                BindPagingGrid();
    //                break;
    //            case PagingType.Next:
    //                if (CurrentPageIndex + 1 != LastPageIndex)
    //                    CurrentPageIndex = CurrentPageIndex + 1;
    //                BindPagingGrid();
    //                break;
    //            case PagingType.Last:
    //                CurrentPageIndex = LastPageIndex - 1;
    //                BindPagingGrid();
    //                break;
    //            default:
    //                break;
    //        }

    //        if (CurrentPageIndex == 0)
    //            imgbtnFirst.Visible = imgbtnPrev.Visible = false;
    //        else
    //            imgbtnFirst.Visible = imgbtnPrev.Visible = true;

    //        if (CurrentPageIndex + 1 == LastPageIndex)
    //            imgbtnLast.Visible = imgbtnNext.Visible = false;
    //        if (CurrentPageIndex + 1 < LastPageIndex)
    //            imgbtnLast.Visible = imgbtnNext.Visible = true;

    //        lblPagNumber.Text = "صفحه " + (CurrentPageIndex + 1).ToString() + " از " + LastPageIndex.ToString();
    //    }
    //    catch
    //    { }
    //}
    //protected void imgbtnNext_Click(object sender, ImageClickEventArgs e)
    //{
    //    SetPager(PagingType.Next);
    //}

    //protected void imgbtnLast_Click(object sender, ImageClickEventArgs e)
    //{
    //    SetPager(PagingType.Last);
    //}

    //protected void imgbtnPrev_Click(object sender, ImageClickEventArgs e)
    //{
    //    SetPager(PagingType.Previuse);
    //}

    //protected void imgbtnFirst_Click(object sender, ImageClickEventArgs e)
    //{
    //    SetPager(PagingType.First);
    //}
}