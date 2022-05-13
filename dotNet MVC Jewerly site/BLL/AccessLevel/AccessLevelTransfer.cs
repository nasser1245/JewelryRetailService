using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HProtest_DAL;

namespace HProtest_BLL.AccessLevel
{
    public class AccessLevelTransfer
    {
        public static DataTable GetMemberAccessLevel(string id)
        {
            Property.AddParametr("@id", id, true);
            return DataFetch.ExecuteSPrDT("GetMemberAccessLevel");
        }

        public static int EditMemberAccessLevel(string UserName, string AccessLevelList)
        {
            Property.AddParametr("@UserName", UserName, true);
            Property.AddParametr("@AccessLevelList", AccessLevelList, false);
            DataRow dr = DataFetch.ExecuteSPrDR("EditMemberAccessLevel");
            if (dr != null)
                return int.Parse(dr["userid"].ToString());
            else
                return -1;
        }

        public static DataTable GetMemebrAccessLevel(string UserName)
        {
            Property.AddParametr("@UserName", UserName, true);
            return DataFetch.ExecuteSPrDT("GetMemebrAccessLevelList");
        }
    }
}
