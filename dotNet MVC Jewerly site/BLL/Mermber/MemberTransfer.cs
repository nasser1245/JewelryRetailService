using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HProtest_DAL;

namespace HProtest_BLL.Member
{
    public class MemberTransfer
    {
 

        public static string InsertMember(string UserName, string Email, string FirstName,string LastName, int IdMemberStatus, string HashPassword, string SaltPassword
            , string Tel, string Mobile, string ZipCode, string Address, string Picture = "", string Sex= "-1", string Province = "", string City = "")
        {
            Property.AddParametr("@UserName", UserName, true);
            Property.AddParametr("@HashPassword", HashPassword, false);
            Property.AddParametr("@SaltPassword", SaltPassword, false);
            Property.AddParametr("@Email", Email, false);
            Property.AddParametr("@FirstName", FirstName, false);
            Property.AddParametr("@LastName", LastName, false);
            Property.AddParametr("@IdMemberStatus", IdMemberStatus, false);
            Property.AddParametr("@Picture", Picture, false);
            Property.AddParametr("@Tel", Tel, false);
            Property.AddParametr("@Mobile", Mobile, false);
            Property.AddParametr("@ZipCode", ZipCode, false);
            Property.AddParametr("@Address", Address, false);
            Property.AddParametr("@Province", Province, false);
            Property.AddParametr("@City", City, false);
            if(Sex == "0")
                Property.AddParametr("@Sex", false, false);
            else if (Sex == "1")
                Property.AddParametr("@Sex", true, false);
            DataRow dr = DataFetch.ExecuteSPrDR("InsertMember");
            if (dr != null)
                return dr["UserName"].ToString();
            else
                return "";
        }

        public static string EditManager(string UserName, string Email, string FirstName, string LastName, string HashPassword, string SaltPassword
            , string Tel, string Mobile, string ZipCode, string Address)
        {
            Property.AddParametr("@UserName", UserName, true);
            Property.AddParametr("@Email", Email, false);
            Property.AddParametr("@FirstName", FirstName, false);
            Property.AddParametr("@LastName", LastName, false);
            if (SaltPassword != "1")
            {
                Property.AddParametr("@HashPassword", HashPassword, false);
                Property.AddParametr("@SaltPassword", SaltPassword, false);
            }
            Property.AddParametr("@Tel", Tel, false);
            Property.AddParametr("@Mobile", Mobile, false);
            Property.AddParametr("@ZipCode", ZipCode, false);
            Property.AddParametr("@Address", Address, false);
            DataRow dr = DataFetch.ExecuteSPrDR("EditManager");
            if (dr != null)
                return dr["UserName"].ToString();
            else
                return "";
        }

        public static string ChangePassword(string UserName, string NewHash, string NewSalt)
        {
            Property.AddParametr("@UserName", UserName, true);
            Property.AddParametr("@NewHashPassword", NewHash, false);
            Property.AddParametr("@NewSaltPassword", NewSalt, false);
            DataRow dr = DataFetch.ExecuteSPrDR("ChangePassword");
            if (dr != null)
                return dr["UserName"].ToString();
            else
                return "";
        }

        public static string EditMember(string UserName, string Email, string FirstName, string LastName, 
     string Tel, string Mobile, string ZipCode, string Address, string Province, string City, string Sex)
        {
            Property.AddParametr("@UserName", UserName, true);
            Property.AddParametr("@Email", Email, false);
            Property.AddParametr("@FirstName", FirstName, false);
            Property.AddParametr("@LastName", LastName, false);

            Property.AddParametr("@Tel", Tel, false);
            Property.AddParametr("@Mobile", Mobile, false);
            Property.AddParametr("@ZipCode", ZipCode, false);
            Property.AddParametr("@Address", Address, false);
            Property.AddParametr("@Province", Province, false);
            Property.AddParametr("@City", City, false);
            if(Sex == "0")
                Property.AddParametr("@Sex", false, false);
            else if (Sex == "1")
                Property.AddParametr("@Sex", true, false);
            DataRow dr = DataFetch.ExecuteSPrDR("EditMember");
            if (dr != null)
                return dr["UserName"].ToString();
            else
                return "";
        }

        public static int UserDetailPropertyInsert(string UserName, int DetailPropertyID, string Value, bool IsVisible)
        {
            Property.AddParametr("@UserName", UserName, true);
            Property.AddParametr("@DetailPropertyID", DetailPropertyID, false);
            Property.AddParametr("@Value", Value, false);
            Property.AddParametr("@IsVisible", IsVisible, false);

            DataRow dr = DataFetch.ExecuteSPrDR("UserDetailPropertyInsert");
            if (dr != null)
                return int.Parse(dr["UserDetailPropertyID"].ToString());
            else
                return -1;
        }
        public static int UserDetaiPropertyEdit(int UserDetailPropertyID, int DetailPropertyID, string Value, bool IsVisible)
        {
            Property.AddParametr("@UserDetailPropertyID", UserDetailPropertyID, false);
            Property.AddParametr("@DetailPropertyID", DetailPropertyID, false);
            Property.AddParametr("@Value", Value, false);
            Property.AddParametr("@IsVisible", IsVisible, false);

            DataRow dr = DataFetch.ExecuteSPrDR("UserDetaiPropertyEdit");
            if (dr != null)
                return int.Parse(dr["udpId"].ToString());
            else
                return -1;
        }

        public static DataTable DeleteMember(string UserName)
        {
            Property.AddParametr("@UserName", UserName, true);
            return DataFetch.ExecuteSPrDT("DeleteMember");
        }

        public static bool ToggleMember(string UserName)
        {
            Property.AddParametr("@UserName", UserName, true);
            bool Successed;
            DataFetch.ExecuteNonSP("ToggleMember", out Successed);
            return Successed;
        }

        public static bool EditMemberAccessLevel(string UserName, string AccessLevelList)
        {
            Property.AddParametr("@UserName", UserName, true);
            Property.AddParametr("@AccessLevelList", AccessLevelList, false);
            bool Successed;
            DataFetch.ExecuteNonSP("EditMemberAccessLevel", out Successed);
            return Successed;
        }

    }
}
