using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShayanDB_BLL;
using HProtest_BLL.Helper;
using HProtest_BLL.News;
using HProtest_BLL.Member;
using HProtest_BLL;

public partial class Manager_UC_ucMemberContent : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]) && (Utility.IsNumeric(Request.QueryString["ID"].ToString())))
                {
                    #region fill contain

                    System.Data.DataRow drMember;
                    drMember = MemberData.GetMember(int.Parse(Request.QueryString["ID"].ToString()));
                    if (drMember != null)
                    {

                        txtName.Text = drMember["FirstName"].ToString();
                        txtFamily.Text = drMember["LastName"].ToString();
                        txtUserName.Enabled = false;
                        txtUserName.Text = drMember["UserName"].ToString();                        
                        txtEmail.Text = drMember["Email"].ToString();
                        txtTel.Text = drMember["Tel"].ToString();
                        txtMobile.Text = Server.HtmlDecode(drMember["Mobile"].ToString());
                        txtZipCode.Text = drMember["ZipCode"].ToString();
                        txtAddress.Text = drMember["Address"].ToString();
                        hfEditType.Value = "2";
                        hfMemberId.Value = Server.HtmlEncode(Request.QueryString["User"]);
                        lblMessage.Text = "وضعیت جاری:در حال ویرایش " + drMember["FirstName"].ToString() + drMember["LastName"].ToString();
                    }
                    else
                    {
                        lblMessage.Text = "وضعیت جاری:در حال درج";
                    }

                    #endregion
                }
                else
                {
                    lblMessage.Text = "وضعیت جاری:در حال درج";
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
        else
        {
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string AlertMessage = "";
        if (txtUserName.Text.Length < 1)
            AlertMessage += "فیلد نام کاربری نمی تواند خالی باشد<br>";
        if (txtUserName.Text.Length > 0 && !Utility.IsValidUserName(txtUserName.Text))
            AlertMessage += "نام کاربری صحیح نمی باشد<br>";
        if(txtEmail.Text.Length >0 && !Utility.IsValidEmail(txtEmail.Text) )
            AlertMessage += "ایمیل را اشتباهی وارد کرده اید<br>";
        if(hfEditType.Value != "2")
            if (txtPassword.Text.Length < 1 ) 
                AlertMessage += "فیلد رمز عبور نمی تواند خالی باشد<br>";
        if ((txtPassword.Text.Length > 0) && (txtPassword.Text != txtPasswordRepeat.Text))
            AlertMessage += "رمز عبور و تکرار رمز عبور باهم برابر نیستند<br>";
        if ((txtPassword.Text.Length > 0) && (!Utility.IsValidPassword(txtPassword.Text)))
            AlertMessage += "رمز عبور معتبر نمی باشد<br>";
     
        if (txtTel.Text.Length > 0 && !Utility.IsNumeric(txtTel.Text))
            AlertMessage += "شماره تلفن عدد است<br>";
        if (txtMobile.Text.Length > 0 && !Utility.IsNumeric(txtMobile.Text))
            AlertMessage += "شماره همراه عدد است<br>";
        if (txtZipCode.Text.Length > 0 && !Utility.IsNumeric(txtZipCode.Text))
            AlertMessage += "کدپستی عدد است<br>";

        if (AlertMessage != "")
        {
            AlertMessage = "لطفا خطاهای زیر را تصحیح کنید<br>" + AlertMessage.Substring(0,AlertMessage.Length-4);
            hfShowMsg.Value = AlertMessage;
            //Utility.ShowMsg(Page, PropertyData.MsgType.warning, AlertMessage);
            return;
        }
        #region insert operation

        string MemberUserName = "";

        if (hfEditType.Value == "1")
        {
            string hashed = "";
            string RandomStr = Utility.GetRandomString();
            using (System.Security.Cryptography.MD5 md5Hash = System.Security.Cryptography.MD5.Create())
            {
                hashed = HProtest_BLL.Helper.Utility.GetMD5Hash(md5Hash, txtPassword.Text + RandomStr.Trim());
            }

            MemberUserName = MemberTransfer.InsertMember(txtUserName.Text, txtEmail.Text, txtName.Text, txtFamily.Text, 3,
                hashed, RandomStr, txtTel.Text, txtMobile.Text, txtZipCode.Text, txtAddress.Text);
        }
        else if (hfEditType.Value == "2")
        {

            string hashed = "";
            string RandomStr = Utility.GetRandomString();
            // پسورد تغییر می کند و حذف می شود

                if (!String.IsNullOrEmpty(txtPassword.Text))
                {
                    using (System.Security.Cryptography.MD5 md5Hash = System.Security.Cryptography.MD5.Create())
                    {
                        hashed = HProtest_BLL.Helper.Utility.GetMD5Hash(md5Hash, txtPassword.Text+ RandomStr.Trim());
                    }
                }
            else
                // پسورد بدون تغییر
                RandomStr = "1";
            MemberUserName = MemberTransfer.EditManager(txtUserName.Text, txtEmail.Text, txtName.Text, txtFamily.Text,
                hashed, RandomStr, txtTel.Text, txtMobile.Text, txtZipCode.Text, txtAddress.Text);
        }
        #endregion


        if (!string.IsNullOrEmpty(MemberUserName))
        {

            Utility.ShowMsg(Page, PropertyData.MsgType.accept, "درج اطلاعات با موفقیت انجام گردید");
            Response.Redirect("~/Manager/Member/MemberList.aspx");
        }
        else
        {

                AlertMessage = "خطایی در درج اطلاعات به وجود آمده است لطفا مجددا سعی کنید";
                hfShowMsg.Value = AlertMessage;
                return;

        }
    }

}