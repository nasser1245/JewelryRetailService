using System;
using HProtest_DAL;
using System.Data;


namespace HProtest_BLL.Member
{
    public class MemberData
    {
        public static DataTable GetUserInfo()
        {
            return DataFetch.ExecuteSPrDT("GetUserInfo");
        }

        public static DataRow GetFullMemberInfo(string UserName)
        {
            Property.AddParametr("@UserName", UserName, true);
            return DataFetch.ExecuteSPrDR("GetFullMemberInfo");
        }
        
        public static bool InsertUser(string UserName, string Password, string Name,string Family)
        {
            Property.AddParametr("@UserName", UserName, true);
            Property.AddParametr("@Password", Password, false);
            Property.AddParametr("@Name", Name, false);
            Property.AddParametr("@Family", Family, false);

            DataFetch.ExecuteSPrDS_SaveParams("InsertUser");
            return true;
        }
        



        public static DataTable GetMemberList(string UserName, string FirstName, string LastName, string Email, string MemberType
    , string sortExpression, string sortDir, int startRowIndex, int maximumRows, ref int AllCurrentCount)
        {
            Property.AddParametr("@UserName", UserName, true);
            Property.AddParametr("@FirstName", FirstName, false);
            Property.AddParametr("@LastName", LastName, false);
            Property.AddParametr("@Email", Email, false);
            Property.AddParametr("@MemberType", MemberType, false);
            Property.AddParametr("@sortExpression", sortExpression, false);
            Property.AddParametr("@sortDir", sortDir, false);
            Property.AddParametr("@startRowIndex", startRowIndex, false);
            Property.AddParametr("@maximumRows", maximumRows, false);

            Property.AddOUTPUTParametr("@AllCurrentCount", false);

            DataSet ds = DataFetch.ExecuteSPrDS_SaveParams("GetMemberList");
            AllCurrentCount= int.Parse(Property.myCmd.Parameters["@AllCurrentCount"].Value.ToString());
            if (ds != null)

                return ds.Tables[0];


            else return null;

        }
        /// <summary>
        ///  
        /// </summary>
        /// <param name="UseName"></param>
        /// <param name="DetailPropertyId">for edit mode</param>
        /// <returns></returns>
        public static DataTable GetDetailPropertyByUserName(string UserName, int DetailPropertyId)
        {
            Property.AddParametr("@UserName", UserName, true);
            Property.AddParametr("@DetailPropertID", DetailPropertyId, false);

            return DataFetch.ExecuteSPrDT("GetDetailPropertyByUserName");
        }

        public static DataTable GetUserDetailProperty(string UserName)
        {
            Property.AddParametr("@UserName", UserName, true);
            return DataFetch.ExecuteSPrDT("GetUserDetailProperty");
        
        }

        public static DataRow GetUserSpecification(string UserName)
        {
            Property.AddParametr("@UserName", UserName, true);
             return DataFetch.ExecuteSPrDR("GetUserSpecification");
             
        }

        public static DataRow GetMember(int IdMember=0)
        {
                Property.AddParametr("@Id", IdMember, true);
                return DataFetch.ExecuteSPrDR("GetMember");
        }

        public static DataRow GetMember(string UserNameMember)
        {
            Property.AddParametr("@Username", UserNameMember, true);
            return DataFetch.ExecuteSPrDR("GetMemberByUserName");
        }

        public static DataTable GetMemberAccessLevelList(string UserName, ref bool isIt)
        {
            Property.AddParametr("@UserName", UserName, true);
            Property.AddOUTPUTParametr("@isIt",SqlDbType.Bit, false);
            DataTable dt= DataFetch.ExecuteSPrDT_SaveParams("GetMemberAccessLevelList");
            isIt= bool.Parse(Property.myCmd.Parameters["@isIt"].Value.ToString());
            return dt;
        }
        
    }
}
