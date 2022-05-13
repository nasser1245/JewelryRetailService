using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL;
using HProtest_BLL.Helper;
using HProtest_BLL.ContactFAQ;
using ShayanDB_BLL;

public partial class UC_FAQ01 : System.Web.UI.Page
{
    int PageSize = 10;

    private int CurrentPageIndex
    {
        get
        {
            if (string.IsNullOrEmpty(Request["page"]))

                return 1;
            else
                return int.Parse(Request["page"]);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            BindGrid();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtMail.Text.Length > 0 && !Utility.IsValidEmail(txtMail.Text))
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, "ایمیل صحیح نمی باشد<br>");
            return;
        }
        if (Request.Cookies["capResult"] == null)
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, "زمان شما برای وارد کردن کد امنیتی به پایان رسیده مجددا تلاش کنید");
            return;
        }
        if ((HProtest_BLL.Helper.Utility.GetMD5HashText(txtCaptcha.Text.Trim().ToLower()) != Request.Cookies["capResult"].Value.ToString()))
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, "متن وارد شده براي عبارت تصويري اشتباه است !");
            return;
        }

        int FAQID = ContactTransfer.InsertFAQ(txtMail.Text, txtName.Text, ddlProvince.SelectedItem.Value.ToString(), txtCity.Text, txtQuestion.Text);
        if (FAQID > 0)
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.accept, "پیغام شما با موفقیت ثبت شد !");
        }
        else
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, "مشکلی در سیستم به وجود آمده است. بعد از چند لحظه دوباره پیغام خود را ارسال کنید !");
    }
    public void BindGrid(int ISSearchClick = 0)
    {
        try
        {
            int AllCurrentCount = 0;
            rptFAQ.DataSource = ContactData.GetFAQList(out AllCurrentCount, 1, 1, "desc", CurrentPageIndex - 1, PageSize);
            rptFAQ.DataBind();
            int LastPageIndex;
            if ((AllCurrentCount % PageSize) == 0)
                LastPageIndex = AllCurrentCount / PageSize;
            else
                LastPageIndex = AllCurrentCount / PageSize + 1;

            System.Collections.Generic.List<PageItem> PagingArray = HProtest_BLL.Helper.Utility.GetPagingArray(CurrentPageIndex, "FAQ.aSPX?key=ora", LastPageIndex, 3);

            rptPaging.DataSource = PagingArray;
            rptPaging.DataBind();
        }
        catch { }
    }
}