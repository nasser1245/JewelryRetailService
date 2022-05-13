using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HProtest_BLL.Helper;
using HProtest_BLL.Member;
using HProtest_BLL;

public partial class HomePage_UC_UserPropertiesEdit : System.Web.UI.UserControl
{
    string User;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                User = Page.User.Identity.Name;
                if (Page.User.IsInRole("4"))
                {

                    if (!string.IsNullOrEmpty(Request.QueryString["UserName"]) && (Utility.IsNumeric(Request.QueryString["UserName"].ToString())))
                    {
                        System.Data.DataRow drMember = MemberData.GetMember(int.Parse(Request.QueryString["UserName"].ToString()));
                        if (drMember != null)
                        {
                            if (Request.QueryString["UserName"].ToString() == drMember["UserName"].ToString())
                            {
                                txtName.Text = drMember["FirstName"].ToString();
                                txtFamily.Text = drMember["LastName"].ToString();
                                txtMail.Text = drMember["Email"].ToString();
                                txtTel.Text = drMember["Tel"].ToString();
                                txtMobile.Text = Server.HtmlDecode(drMember["Mobile"].ToString());
                                txtZipCode.Text = drMember["ZipCode"].ToString();
                                txtAddress.Text = drMember["Address"].ToString();
                                ddlProvince.SelectedValue = drMember["Province"].ToString();
                                txtCity.Text = drMember["City"].ToString();
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        string AlertMessage = "";
        if (txtName.Text.Length < 1)
            AlertMessage += "لطفا نام خانوادگی خود را وارد نمایید<br>";
        if (txtMail.Text.Length > 0 && !Utility.IsValidEmail(txtMail.Text))
            AlertMessage += "ایمیل خود را به طور صحیح وارد نمایید<br>";
        if (txtMobile.Text.Length > 0 && !Utility.IsNumeric(txtMobile.Text))
            AlertMessage += "شماره تلفن عدد است<br>";
        if (txtTel.Text.Length > 0 && !Utility.IsNumeric(txtTel.Text))
            AlertMessage += "شماره همراه عدد است<br>";
        if (ddlProvince.SelectedValue == "0" || txtCity.Text.Length < 1)
            AlertMessage += "لطفا استان و شهر خود را مشخص نمایید<br>";
        if (txtAddress.Text.Length < 1)
            AlertMessage += "لطفا آدرس پستی خود را وارد نمایید<br>";
        if (txtZipCode.Text.Length > 0 && !Utility.IsNumeric(txtZipCode.Text))
            AlertMessage += "کدپستی عدد است<br>";

        if (AlertMessage != "")
        {
            AlertMessage = "لطفا خطاهای زیر را تصحیح کنید<br>" + AlertMessage.Substring(0, AlertMessage.Length - 4);
            hfShowMsg.Value = AlertMessage;
            return;
        }

        User = MemberTransfer.EditMember(Request.QueryString["UserName"].ToString(), txtMail.Text, txtName.Text, txtFamily.Text,
                txtTel.Text, txtMobile.Text, txtZipCode.Text, txtAddress.Text, ddlProvince.SelectedValue.ToString(),
                txtCity.Text, ddlSex.SelectedValue.ToString());

        if (User != "")
        {
            Utility.ShowMsg(Page, PropertyData.MsgType.accept, "درج اطلاعات با موفقیت انجام گردید");
        }
        else
        {
            AlertMessage = "خطایی در درج اطلاعات به وجود آمده است لطفا مجددا سعی کنید";
            hfShowMsg.Value = AlertMessage;
            return;
        }
    }
}