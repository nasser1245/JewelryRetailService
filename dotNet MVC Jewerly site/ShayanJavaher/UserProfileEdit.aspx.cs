using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.Helper;
using HProtest_BLL.Member;
using HProtest_BLL;

public partial class UserProfileEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.User.IsInRole("4"))
        {
            Response.Redirect("~/default.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                try
                {
                    string User;
                    User = Page.User.Identity.Name;
                    if (Page.User.IsInRole("4"))
                    {
                            System.Data.DataRow drMember = MemberData.GetMember(User);
                            if (drMember != null)
                            {
                                if (User == drMember["UserName"].ToString())
                                {
                                    lblUserName.Text = drMember["UserName"].ToString();
                                    txtName.Text = drMember["FirstName"].ToString();
                                    txtFamily.Text = drMember["LastName"].ToString();
                                    txtMail.Text = drMember["Email"].ToString();
                                    txtTel.Text = drMember["Tel"].ToString();
                                    if(drMember["Sex"].ToString().ToLower() == "true")
                                        ddlSex.SelectedIndex = 1;
                                    else if (drMember["Sex"].ToString().ToLower() == "false")
                                        ddlSex.SelectedIndex = 0;
                                    txtMobile.Text = Server.HtmlDecode(drMember["Mobile"].ToString());
                                    txtZipCode.Text = drMember["ZipCode"].ToString();
                                    txtAddress.Text = drMember["Address"].ToString();
                                    ddlProvince.SelectedIndex = ddlProvince.Items.IndexOf(ddlProvince.Items.FindByText(drMember["Province"].ToString()));
                                    txtCity.Text = drMember["City"].ToString();
                                }
                            }
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        string AlertMessage = "";
        if (txtFamily.Text.Length < 1)
            AlertMessage += " نام خانوادگی خود را وارد نمایید<br>";
        if (txtMail.Text.Length < 1)
            AlertMessage += "  ایمیل خود را وارد نمایید<br>";
        if (txtMail.Text.Length > 0 && !Utility.IsValidEmail(txtMail.Text))
            AlertMessage += "  ایمیل خود را به طور صحیح وارد نمایید<br>";
        if (txtTel.Text.Length < 1)
            AlertMessage += "   شماره تلفن را وارد نمایید<br>";
        if (txtTel.Text.Length > 0 && !Utility.IsNumeric(txtTel.Text))
            AlertMessage += "  شماره تلفن عدد است<br>";
        if (txtMobile.Text.Length > 0 && !Utility.IsNumeric(txtMobile.Text))
            AlertMessage += "  شماره همراه عدد است<br>";
        if (ddlProvince.SelectedValue == "" || txtCity.Text.Length < 1)
            AlertMessage += "  استان و شهر خود را مشخص نمایید<br>";
        if (txtAddress.Text.Length < 1)
            AlertMessage += "   آدرس پستی خود را وارد نمایید<br>";
        if (txtZipCode.Text.Length < 1)
            AlertMessage += "   کد پستی خود را وارد نمایید<br>";
        if (txtZipCode.Text.Length > 0 && !Utility.IsNumeric(txtZipCode.Text))
            AlertMessage += "کدپستی عدد است<br>";

        if (AlertMessage != "")
        {
            AlertMessage = "لطفا خطاهای زیر را تصحیح کنید:<br>" + AlertMessage.Substring(0, AlertMessage.Length - 4);
            Utility.ShowMsg(this, PropertyData.MsgType.warning, AlertMessage);
            //hfShowMsg.Value = AlertMessage;
            return;
        }
        string User="";
        string Province = string.IsNullOrEmpty(ddlProvince.SelectedValue.ToString()) ? "" : ddlProvince.SelectedItem.ToString();
        User = MemberTransfer.EditMember(Page.User.Identity.Name, txtMail.Text, txtName.Text, txtFamily.Text,
                txtTel.Text, txtMobile.Text, txtZipCode.Text, txtAddress.Text, Province,
                txtCity.Text, ddlSex.SelectedValue.ToString());

        if (User != "")
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.accept, "درج اطلاعات با موفقیت انجام گردید");
        }
        else
        {
            AlertMessage = "خطایی در درج اطلاعات به وجود آمده است لطفا مجددا سعی کنید";
            Utility.ShowMsg(this, PropertyData.MsgType.warning, AlertMessage);
            return;
        }
    }
}