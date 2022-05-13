using System;
using System.Data;
using System.Web;
using System.Web.Security;
using HProtest_BLL.Member;
using HProtest_DAL;
using ShayanDB_BLL;

namespace HProtest_BLL
{
    public class MemberChecking
    {
        public static bool CheckUserPass(string UserName, string Password)
        {
            Property.AddParametr("@UserName", UserName.ToLower(), true);

            DataRow dr1 = DataFetch.ExecuteSPrDR("CheckUserName");
            if (dr1 != null)
            {
                string hashed = "";
                using (System.Security.Cryptography.MD5 md5Hash = System.Security.Cryptography.MD5.Create())
                {
                    hashed = Helper.Utility.GetMD5Hash(md5Hash, Password + dr1["SaltPassword"].ToString().Trim());
                }

                Property.AddParametr("@UserName", UserName, true);
                Property.AddParametr("@Password", hashed, false);

                DataRow dr2 = DataFetch.ExecuteSPrDR("CheckUserPass");
                if (dr2 != null)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckMelliCode(string MelliCode)
        {
            Property.AddParametr("@MelliCode", MelliCode, true);

            DataRow dr = DataFetch.ExecuteSPrDR("CheckMelliCode");
            if (dr != null)
                return true;
            else
                return false;
        }

        public static bool CheckUserName(string UserName)
        {
            Property.AddParametr("@UserName", UserName.ToLower(), true);

            DataRow dr = DataFetch.ExecuteSPrDR("CheckUserName");
            if (dr != null)
                return true;
            else
                return false;
        }

        public static bool CheckCandidExist(string UserName)
        {
            Property.AddParametr("@UserName", UserName.ToLower(), true);

            DataRow dr = DataFetch.ExecuteSPrDR("CheckCandidExist");
            if (dr != null)
                return true;
            else
                return false;
        }

        public static bool CheckMelliCodeCurrentUser(string MelliCode, string UserName)
        {
            Property.AddParametr("@MelliCode", MelliCode, true);

            DataRow dr = DataFetch.ExecuteSPrDR("CheckMelliCode");
            if (dr != null && dr["UserName"].ToString().Trim() == UserName.Trim().ToLower())
                return true;
            else
                return false;
        }

        public static bool CheckEmailExist(string Email)
        {
            Property.AddParametr("@Email", Email, true);

            DataRow dr = DataFetch.ExecuteSPrDR("CheckEmailExist");
            if (dr != null)
                return true;
            else
                return false;
        }


        public static DataRow GetUserInfo(string UserName)
        {
            Property.AddParametr("@UserName", UserName.ToLower(), true);

            DataRow dr = DataFetch.ExecuteSPrDR("GetQuickMemberInfo");
            if (dr != null)
                return dr;
            else
                return null;
        }

        public static bool IsLocked(string UserName)
        {
            Property.AddParametr("@UserName",UserName, true);
            DataRow dr = DataFetch.ExecuteSPrDR("IsLocked");
            if (dr != null)
                    return bool.Parse(dr["Locked"].ToString());
            return true;
        }

        public static string GetMemberIdentficationID(string UserName)
        {
            Property.AddParametr("@UserName", UserName.ToLower(), true);

            DataRow dr = DataFetch.ExecuteSPrDR("GetMemberIdentficationIDByUserName");
            if (dr != null)
                return dr["Id"].ToString();
            else
                return null;
        }

        public static bool ChangePassword(string UserName, string NewPassword)
        {
            string Password = "";
            string SaltPassword = Helper.Utility.GetRandomString();
            using (System.Security.Cryptography.MD5 md5Hash = System.Security.Cryptography.MD5.Create())
            {
                Password = Helper.Utility.GetMD5Hash(md5Hash, NewPassword + SaltPassword);
            }
            if (!string.IsNullOrEmpty(Password))
            {
                Property.AddParametr("@Username", UserName.ToLower(), true);
                Property.AddParametr("@Password", Password, false);
                Property.AddParametr("@SaltPassword", SaltPassword, false);
                bool Successed;
                    DataFetch.ExecuteNonSP("ChangePassword", out Successed);
                    return Successed;
            }
            else
            {
                return false;
            }
        }
        #region new or changed methodes
        /// <summary>
        /// Role 
        /// در اینجا با 
        /// Role
        /// در دیتابیس متفاوت است
        ///
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public static bool GetMemberStatusID(string UserName, out string role)
        {
            try
            {
                Property.AddParametr("@UserName", UserName, true);
                Property.AddOUTPUTParametr("@MemberStatusID", SqlDbType.NVarChar, 50, false);
                
                DataRow dr= DataFetch.ExecuteSPrDR_SaveParams("GetMemberStatusID");
                if (dr != null)
                {
                    role = Property.myCmd.Parameters["@MemberStatusID"].Value.ToString();
                    GetData.RemoveAddedParams();
                    return true;
                }
                else
                {
                    role = "-1";
                    return false;
                }
               
            }
            catch
            {
                role = "-1";
                return false;
            }
        }


        public static HttpCookie GetTicket(string UserName,string role)
        {
            try
            {
                FormsAuthenticationTicket userTicket = new FormsAuthenticationTicket(1, UserName.ToLower(), DateTime.Now, DateTime.Now.AddMinutes(30), false, role);
                string encTicket = FormsAuthentication.Encrypt(userTicket);
                HttpCookie userCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                if (userTicket.IsPersistent)
                    userCookie.Expires = DateTime.Now.AddMinutes(30);

                return userCookie;
            }
            catch
            { return null; }
        }

        #endregion

        public static string ActivatetionGenerate(string Email, string UserName, out string ID)
        {
            Property.AddParametr("@Email", Email, true);
            Property.AddParametr("@UserName", UserName, false);
            Property.AddOUTPUTParametr("@ID", false);
            DataRow dr = DataFetch.ExecuteSPrDR_SaveParams("ActivatetionGenerate");
            ID = "";
            if (dr != null)
            {
                ID = Property.myCmd.Parameters["@ID"].Value.ToString();
                return dr["Activation"].ToString();

            }
            else
                return "";

        }

        public static string IsValidActivation(string uis, string V0aL)
        {
            Property.AddParametr("@ID",int.Parse(uis),true);
            Property.AddParametr("@ActivateCode", V0aL, false);
            DataRow dr = DataFetch.ExecuteSPrDR_SaveParams("IsValidActivation");
            if (dr != null)
                return dr["UserName"].ToString();
            return null;
        }
    }
}
