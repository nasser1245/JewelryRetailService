using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.Helper;
using System.Data;
using HProtest_BLL.Opinion;
using System.Globalization;
using HProtest_BLL;

public partial class Manager_Poll_OpinionContent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["AccessLevel"] == null)
            Response.Redirect("~/manager/login.aspx");

        if (Page.User.IsInRole("1") || ((HProtest_BLL.AccessLevel.AccessLevel)HttpContext.Current.Session["AccessLevel"]).NewsAgent == true)
        { 
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["OpinionID"]) && Utility.IsNumeric(Request.QueryString["OpinionID"]))///edit mode
            {
                #region fill contain
                DataRow drOpinion = OpinionData.GetOpinionByID(Int32.Parse(Request.QueryString["OpinionID"]));

                if (drOpinion != null)
                {
                    txtBody.Text = drOpinion["Question"].ToString();
                    txtstartdatepicker.Text = Utility.GetPersianDate((DateTime)(drOpinion["StartDate"]));
                    txtenddatepicker.Text = Utility.GetPersianDate((DateTime)(drOpinion["EndDate"]));

                    txtstartdatepicker.Text = Utility.GetPersianSolarDate((DateTime)(drOpinion["StartDate"]));
                    txtenddatepicker.Text = Utility.GetPersianSolarDate((DateTime)(drOpinion["EndDate"]));
                    Rdcanmultichoice.SelectedValue = drOpinion["HasMultipleAnswer"].ToString() == "True" ? "1" : "0";
                    hfEditingOption.Value = Request.QueryString["OpinionID"];

                    cbIsUnlimited.Checked = drOpinion["IsUnlimited"].ToString() == "True" ? true : false;

                    dlIsEnable.SelectedValue = drOpinion["isEnable"].ToString() == "True" ? "1" : "0";

                    OptionBind();

                }


                #endregion

            }
        }
    }
        else
            Response.Redirect("~/manager/login.aspx");

    }

    public int InsertOpinion()
    {
        int OpinionID = -1;
        PersianCalendar pcal = new PersianCalendar();
        string Username = Page.User.Identity.Name;
        if (string.IsNullOrEmpty(txtBody.Text.Trim()) ||  (cbIsUnlimited.Checked=false && (txtstartdatepicker.Date.Value < txtstartdatepicker.Date.Value)))
        {
            Utility.ShowMsg(this, PropertyData.MsgType.warning, "فیلد ها را ،با توجه به راهنما پر نمایید.");
            return -1;
        }
        #region insert operation
        object StartDate=null,EndDate=null;
        try
        {
            StartDate = txtstartdatepicker.Date.Value;


            EndDate = txtenddatepicker.Date.Value;
        }
        catch {
            StartDate = DateTime.Now.AddYears(-30);
            EndDate = DateTime.Now.AddYears(30);
        }
        OpinionID = OpinionTransfer.OpinionInsert(Username, Server.HtmlEncode(txtBody.Text.Trim()), StartDate, EndDate,
            Int32.Parse(Rdcanmultichoice.SelectedValue.ToString()), cbIsUnlimited.Checked, Int32.Parse(dlIsEnable.SelectedValue));

        if (OpinionID != 0 && OpinionID != -1)
        {
            Utility.ShowMsg(this, PropertyData.MsgType.accept, "عمل درج  نظر سنجی با موفقیت انجام شد.");
            Utility.ShowMsg(this, PropertyData.MsgType.warning, "این نظر سنجی دارای هیچ گزینه ای نیست در صورت نیاز به مرحله ثبت گزینه بروید");
            return OpinionID;
        }
        else
        {
            Utility.ShowMsg(this, PropertyData.MsgType.warning, "خطایی در درج رخ داده است و لطفا لحظاتی بعد مجددا انجام دهید");
            return -1;
        }
        #endregion
    }


    public int editeOpinion()
    {
        try
        {
            PersianCalendar pcal = new PersianCalendar();
            string Username = Page.User.Identity.Name;

            if (string.IsNullOrEmpty(txtBody.Text.Trim()))
            {
                Utility.ShowMsg(this, PropertyData.MsgType.warning, "فیلد به صورت صحیح پر نشده است.با توجه به راهنما فیلد ها را پر نمایید");
                return -1;
            }
            #region Edite operation

            object StartDate = null, EndDate = null;
            try
            {
                StartDate = txtstartdatepicker.Date.Value;


                EndDate = txtenddatepicker.Date.Value;
            }
            catch
            {
                StartDate = DateTime.Now.AddYears(-30);
                EndDate = DateTime.Now.AddYears(30);
            }
            bool result = OpinionTransfer.OpinionEdite(Int32.Parse(Request.QueryString["OpinionID"]), Username, Server.HtmlEncode(txtBody.Text.Trim())
                , StartDate, EndDate, Int32.Parse(Rdcanmultichoice.SelectedValue.ToString()), cbIsUnlimited.Checked, Int32.Parse(dlIsEnable.SelectedValue));
            
            if (result)
            {
                Utility.ShowMsg(this, PropertyData.MsgType.accept, "عمل ویرایش با موفقیت انجام شد");
                return Int32.Parse(Request.QueryString["OpinionID"]);

            }
            else
            {
                Utility.ShowMsg(this, PropertyData.MsgType.warning, "خطایی در ویرایش رخ داده است و لطفا لحظاتی بعد مجددا انجام دهید");
                return -1;
            }

            #endregion
        }
        catch
        {
            Utility.ShowMsg(this, PropertyData.MsgType.warning, "خطایی در ویرایش رخ داده است ،لطفا لحظاتی بعد مجددا انجام دهید");
            return -1;
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Request.QueryString["OpinionID"]))
            hfEditingOption.Value = Convert.ToString(InsertOpinion());
        else if (!string.IsNullOrEmpty(Request.QueryString["OpinionID"]) && Utility.IsNumeric(Request.QueryString["OpinionID"]))
            hfEditingOption.Value = Convert.ToString(editeOpinion());

        OptionBind();
    }

    private void OptionBind()
    {
        if (Utility.IsNumeric(hfEditingOption.Value))
        {
            rptOpinionOption.DataSource = OpinionData.GetOptionList(Int32.Parse(hfEditingOption.Value));
            rptOpinionOption.DataBind();
        }
    }
    protected void btnSaveOption_Click(object sender, EventArgs e)
    {
        int result = 0;

        if (hfActionType.Value == "add")
        {
            if (!string.IsNullOrEmpty(hfEditingOption.Value))
            {
                if (string.IsNullOrEmpty(Server.HtmlEncode(txtOption.Text.Trim())) || string.IsNullOrEmpty(Server.HtmlEncode(TxtOptionOrder.Text.Trim())) || !(Utility.IsNumeric(Server.HtmlEncode(TxtOptionOrder.Text.Trim()))))
                {
                    Utility.ShowMsg(Page, PropertyData.MsgType.warning, "فیلد اطلاعات گزینه ها درست پر نشده است .لطفا بر اساس راهنما فیلد ها را پر نمایید");
                    return;
                }
                else
                {
                    result = OpinionTransfer.OptionInsert(Int32.Parse(hfEditingOption.Value.ToString()), Server.HtmlEncode(txtOption.Text.Trim()), Int32.Parse(Server.HtmlEncode(TxtOptionOrder.Text.Trim())));
                }
            }
            else
            {
                Utility.ShowMsg(Page, PropertyData.MsgType.warning, "لازم است قبل از درج گزینه های نظر سنجی ،نظر سنجی را با فشردن دکمه ثبت اطلاعات ثبت کنید");
                return;
            }
            if (result == -1)
            {
                Utility.ShowMsg(Page, PropertyData.MsgType.warning, "متاسفانه در سیستم،مشکلی پیش بینی نشده به وجود آمد.لطفا لحظاتی بعد مجددا سعی نمایید");
                return;
            }

        }
        if (hfActionType.Value.Contains("edit"))
        {
            string OptionID = hfActionType.Value.Substring(hfActionType.Value.LastIndexOf(",") + 1);
            if (string.IsNullOrEmpty(Server.HtmlEncode(txtOption.Text.Trim())) || string.IsNullOrEmpty(Server.HtmlEncode(txtOption.Text.Trim())) || !(Utility.IsNumeric(Server.HtmlEncode(TxtOptionOrder.Text.Trim()))))
            {
                Utility.ShowMsg(Page, PropertyData.MsgType.warning, "فیلد اطلاعات گزینه ها درست پر نشده است .لطفا بر اساس راهنما فیلد ها را پر نمایید");
                return;
            }
            else
            {
                result = OpinionTransfer.OptionEdite(Int32.Parse(OptionID), Int32.Parse(hfEditingOption.Value.ToString()), Server.HtmlEncode(txtOption.Text.Trim()), Int32.Parse(Server.HtmlEncode(TxtOptionOrder.Text.Trim())), Int32.Parse(hfHitCount.Value.ToString()));
            }
            if (result == -1)
            {
                Utility.ShowMsg(Page, PropertyData.MsgType.warning, "متاسفانه در سیستم،مشکلی پیش بینی نشده به وجود آمد.لطفا لحظاتی بعد مجددا سعی نمایید");
                return;
            }

        }
        OptionBind();


    }

    protected void btnDelete_Ckick(object sender, System.Web.UI.WebControls.CommandEventArgs e)
    {
        if (Utility.IsNumeric(e.CommandArgument.ToString()))
        {
            if (OpinionTransfer.OptionDelete(int.Parse(e.CommandArgument.ToString()), Int32.Parse(hfEditingOption.Value.ToString())))
            {
                OptionBind();
            }
            else
            {

                Utility.ShowMsg(Page, PropertyData.MsgType.warning, "حذف اطلاعات با خطا مواجه شد");
            }
        }
    }

        
}