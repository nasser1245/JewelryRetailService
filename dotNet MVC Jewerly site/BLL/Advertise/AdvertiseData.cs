using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HProtest_DAL;

namespace HProtest_BLL.Advertise
{
    public class AdvertiseData
    {
        public static DataRow GetAdvertiseById(int Id)
        {
            Property.AddParametr("@AdvertiseId", Id, true);
            return DataFetch.ExecuteSPrDR("GetAdvertiseById");
        }
        public static DataTable GetAdvertiseList(string Username, string Title, DateTime DateFrom, DateTime DateTo, int Visible, int IdFileType, int IdAdvertisePosition, string sortExpression, string sortDir, int startRowIndex, int maximumRows, out int AllCurrentCount)
        {
            Property.AddParametr("@Username", Username, true);
            Property.AddParametr("@Title", Title, false);
            Property.AddParametr("@DateInFrom", DateFrom, false);
            Property.AddParametr("@DateInTo", DateTo, false);
            Property.AddParametr("@Visible", Visible, false);
            Property.AddParametr("@IdFileType", IdFileType, false);
            Property.AddParametr("@IdAdvertisePosition", IdAdvertisePosition, false);
            Property.AddParametr("@sortExpression", sortExpression, false);
            Property.AddParametr("@sortDir", sortDir, false);
            Property.AddParametr("@startRowIndex", startRowIndex, false);
            Property.AddParametr("@maximumRows", maximumRows, false);
            Property.AddOUTPUTParametr("@AllCount", false);
            Property.AddOUTPUTParametr("@AllCurrentCount", false);
            DataTable dt = DataFetch.ExecuteSPrDT_SaveParams("GetAdvertiseList");
            AllCurrentCount = 0;
            if (dt != null)
                if (dt.Rows.Count > 0)
                    if (string.IsNullOrEmpty(Property.myCmd.Parameters["@AllCurrentCount"].Value.ToString()))
                        AllCurrentCount = 0;
                    else
                        AllCurrentCount = int.Parse(Property.myCmd.Parameters["@AllCurrentCount"].Value.ToString());
            return dt;
        }
    }
}
