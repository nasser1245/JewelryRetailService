using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.ContactFAQ;
using ShayanDB_BLL;
using HProtest_BLL.Helper;
using HProtest_BLL;

public partial class Manager_FAQ : System.Web.UI.Page
{

    int PageSize = 5;

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
        if (!IsPostBack)
        {
            if (HttpContext.Current.Session["AccessLevel"] == null)
                Response.Redirect("~/manager/login.aspx");

            if (Page.User.IsInRole("1") || ((HProtest_BLL.AccessLevel.AccessLevel)HttpContext.Current.Session["AccessLevel"]).SupportAgent == true)
            {
                BindGrid();
            }
            else
                Response.Redirect("~/manager/login.aspx");
        }
    }

    public void BindGrid(int ISSearchClick = 0)
    {
        int AllCurrentCount = 0;
        rptFAQ.DataSource = ContactData.GetFAQList(out AllCurrentCount,-1,-1,"desc",CurrentPageIndex-1,PageSize);
        rptFAQ.DataBind();
        int LastPageIndex;
        if ((AllCurrentCount % PageSize) == 0)
            LastPageIndex = AllCurrentCount / PageSize;
        else
            LastPageIndex = AllCurrentCount / PageSize + 1;

        int tmpCurrentPageIndex = 0;
        if (ISSearchClick == 1)
        {
            tmpCurrentPageIndex = 1;
        }

        System.Collections.Generic.List<PageItem> PagingArray = HProtest_BLL.Helper.Utility.GetPagingArray(tmpCurrentPageIndex != 0 ? tmpCurrentPageIndex : CurrentPageIndex, "FAQ.aSPX?key=ora", LastPageIndex, 3);

        rptPaging.DataSource = PagingArray;
        rptPaging.DataBind();
    }

    protected void rptFAQ_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        Button Clicked = ((Button)e.CommandSource);
        foreach(RepeaterItem ri in rptFAQ.Items){
            Button Butt = (Button)ri.FindControl("btnSubmit");
            if (Butt == Clicked)
            {
                CheckBox Chk = (CheckBox)ri.FindControl("chkVisible");
                TextBox Txt = (TextBox)ri.FindControl("txtAnswer");
                HiddenField Hidden = (HiddenField)ri.FindControl("hfID");
                if (ContactTransfer.EditFAQ(int.Parse(Hidden.Value.ToString()), Txt.Text, Chk.Checked))
                {
                    Utility.ShowMsg(this, PropertyData.MsgType.accept, "تغییرات با موفقیت اعمال شد");
                    return;
                }
                else
                {
                    Utility.ShowMsg(this, PropertyData.MsgType.accept, "مشکلی در ارتباط با سرور به وجود آمده است. لطفا مجددا تلاش فرمایید");
                    return;
                }
                      
            }
        }
    }
}