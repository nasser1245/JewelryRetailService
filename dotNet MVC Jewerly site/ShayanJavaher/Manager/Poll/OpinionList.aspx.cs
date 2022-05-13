using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Globalization;
using ShayanDB_BLL;


public partial class Manager_Poll_OpinionList : System.Web.UI.Page
{
    /// ////////for paging
    /// </summary>


    string sortDir = "desc", sortExpression = "OpinionID";
    int PageSize = 15;

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
        if (HttpContext.Current.Session["AccessLevel"] == null)
            Response.Redirect("~/manager/login.aspx");

        if (Page.User.IsInRole("1") || ((HProtest_BLL.AccessLevel.AccessLevel)HttpContext.Current.Session["AccessLevel"]).NewsAgent == true)
        {
            if (!Page.IsPostBack)
            {
                txtQuestion.Text = Request["Question"] != null ? Request["Question"].ToString() : "";
                txtstartdatepicker.Text = Request["startdatetext"] != null ? Request["startdatetext"].ToString() : "";
                txtenddatepicker.Text = Request["enddatetext"] != null ? Request["enddatetext"].ToString() : "";
                txtstartdatepicker.Text = Request["startdate"] != null ? Request["startdate"].ToString().Replace('-', '/') : "";
                txtenddatepicker.Text = Request["enddate"] != null ? Request["enddate"].ToString().Replace('-', '/') : "";
                ddltype.SelectedValue = Request["type"] != null ? Request["type"].ToString() : "-1";
                rptOpinionList.DataSource = BindPagingGrid();
                rptOpinionList.DataBind();
            }
        }
        else
            Response.Redirect("~/manager/login.aspx");
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Manager/Poll/OpinionList.aspx?" + "Question=" + txtQuestion.Text + "&type=" + ddltype.SelectedValue + "&startdate=" + txtstartdatepicker.Text.Replace('/', '-') +
    "&enddate=" + txtenddatepicker.Text.Replace('/', '-') + "&startdatetext=" + txtstartdatepicker.Text +
    "&enddatetext=" + txtenddatepicker.Text);
    }
    protected DataTable BindPagingGrid()
    {
        DateTime DateFrom = new DateTime(1753, 1, 1);
        DateTime DateTo = new DateTime(9999, 1, 1);
        PersianCalendar pcal = new PersianCalendar();

        int AllRowCount = 0;
        using (DataTable dtList = HProtest_BLL.Opinion.OpinionData.GeOpinionList(txtQuestion.Text.Trim(),
            (!string.IsNullOrEmpty(txtstartdatepicker.Text) ? txtstartdatepicker.Date.Value:DateFrom)
            , (!string.IsNullOrEmpty(txtenddatepicker.Text) ? txtenddatepicker.Date.Value : DateTo)
           , Int32.Parse(ddltype.SelectedValue.ToString()), sortExpression, sortDir, CurrentPageIndex - 1,PageSize, out AllRowCount))
        {
            int LastPageIndex;
            if ((AllRowCount % PageSize) == 0)
                LastPageIndex = AllRowCount / PageSize;
            else
                LastPageIndex = AllRowCount / PageSize + 1;

            ///////////////////////////فیلترها باید فرستاده شود 
            System.Collections.Generic.List<PageItem> PagingArray = HProtest_BLL.Helper.Utility.GetPagingArray(CurrentPageIndex, "OpinionList.aspx?" + "Question=" + txtQuestion.Text
                + "& type=" + ddltype.SelectedValue + "&startdate=" + txtstartdatepicker.Text.Replace('/', '-') +
                "&enddate=" + txtenddatepicker.Text.Replace('/', '-') + "&startdatetext=" + txtstartdatepicker.Text +
                "&enddatetext=" + txtenddatepicker.Text, LastPageIndex, 3);

            rptPaging.DataSource = PagingArray;
            rptPaging.DataBind();


            if (dtList != null && dtList.Rows.Count > 0)
            {
                rptOpinionList.Visible = true;
                return dtList;


            }
            else
            {

                rptOpinionList.Visible = false;
                return dtList;
            }



        }

    }

    [WebMethod]
    public static int DeleteOpinion(string Id)
    {
        string Username = HttpContext.Current.User.Identity.Name;


        try
        {
            if (Id != null && Id != "" && Id != "undefined")
            {
                //if (HttpContext.Current.Session["Action"] != null && ((HProtest_BLL.Action.Action)HttpContext.Current.Session["Action"]).InsertSpeech == false)
                //{
                //    //Utility.ShowMsg(page1, PropertyData.MsgType.warning, "شما اجازه ی دسترسی به این عملیات را ندارید");
                //    return 0;
                //}
                bool result = HProtest_BLL.Opinion.OpinionTransfer.OpinionDelete(Int32.Parse(Id));
                if (result)
                {
                    //Bime1ir_BLL.Log.LogTransfer.Log_Insert(Username, "DeleteOpinion", "tbOpinion", DateTime.Now, HttpContext.Current.Request.UserHostAddress.ToString(), result, "OpinionDelete");
                    // Utility.ShowMsg(page1, PropertyData.MsgType.accept, "عمل حذف با موفقیت انجام شد");
                    return 1;
                }
                else
                {
                    // Utility.ShowMsg(page1, PropertyData.MsgType.warning, "خطایی در حذف سخن رخ داده است و لطفا لحظاتی بعد مجددا انجام دهید");
                    return -1;
                }
            }
            else
            {
                throw new ApplicationException("Error");
            }
        }
        catch
        {
            throw new ApplicationException("Error");
        }
        //rptSpeechList.DataSource = BindPagingGrid();
        //rptSpeechList.DataBind();

    }
}