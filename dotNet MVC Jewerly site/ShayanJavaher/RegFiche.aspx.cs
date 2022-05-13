using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.Helper;
using HProtest_BLL;
using HProtest_BLL.Basket;
using HProtest_BLL.Member;

public partial class RegFiche : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.User.IsInRole("4"))
        {
            Response.Redirect("~/default.aspx");
        }
        if (!IsPostBack)
        {
            txtPayDate.Text = System.DateTime.Now.ToString();
            System.Data.DataRow dr = MemberData.GetFullMemberInfo(Page.User.Identity.Name);
            
            txtFullName.Text = dr["FirstName"].ToString() + " " + dr["LastName"].ToString();
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/BuyBasket.aspx");
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {

        string AlertMessage = "";
        if (txtSumma.Text.Length < 1)
            AlertMessage += "مبلغ فیش را وارد نمایید<br>";
        if (txtSumma.Text.Length > 0 && !Utility.IsNumeric(txtSumma.Text))
            AlertMessage += "مبلغ فیش عدد است<br>";
        if (txtAccountNo.Text.Length < 1)
            AlertMessage += "شماره حساب واریزی را وارد نمایید<br>";
        if (txtFicheNo.Text.Length < 1)
            AlertMessage += "شماره فیش را وارد نمایید<br>";
        if (txtFullName.Text.Length < 1)
            AlertMessage += "نام کامل خود را وارد نمایید<br>";
        if (txtPayDate.Text.Length < 1)
            AlertMessage += "تاریخ ثبت فیش را وارد نمایید<br>";

        if (AlertMessage != "")
        {
            AlertMessage = "لطفا خطاهای زیر را تصحیح کنید:<br>" + AlertMessage.Substring(0, AlertMessage.Length - 4);
            Utility.ShowMsg(this, PropertyData.MsgType.warning, AlertMessage);
            return;
        }
        if (BasketTransfer.InsertFiche(Page.User.Identity.Name,int.Parse(txtSumma.Text), txtFicheNo.Text,txtAccountNo.Text,txtFullName.Text, txtPayDate.Date.Value,ddlFicheType.SelectedItem.ToString(),txtDescription.Text))
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.accept, " فیش شما با موفقیت ثبت شد. پس از تایید مدیریت سفارش شما ارسال می گردد");
        }
        else
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.warning, " خطایی در ثبت فیش به وجود آمده است؛ دوباره سعی کنید");
        }
    }
}