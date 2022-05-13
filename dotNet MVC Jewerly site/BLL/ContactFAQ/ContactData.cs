using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HProtest_DAL;

namespace HProtest_BLL.ContactFAQ
{
    public class ContactData
    {
        public static DataSet GetFAQList(out int AllCurrentCount, int Visible = -1, int Answered = -1, string SortDir = "desc", int startRowIndex = 0, int maximumRows=10)
        {
            Property.AddParametr("@Visible", Visible, true);
            Property.AddParametr("@IsAnswered", Answered, false);
            Property.AddParametr("@startRowIndex", startRowIndex, false);
            Property.AddParametr("@maximumRows", maximumRows, false);
            Property.AddParametr("@SortDir", SortDir, false);
            Property.AddOUTPUTParametr("@AllCurrentCount", false);
            using (DataSet dt = DataFetch.ExecuteSPrDS_SaveParams("GetFAQList"))
            {
                AllCurrentCount = 0;
                if (dt != null)
                {
                    if (!string.IsNullOrEmpty(Property.myCmd.Parameters["@AllCurrentCount"].Value.ToString()))
                        AllCurrentCount = int.Parse(Property.myCmd.Parameters["@AllCurrentCount"].Value.ToString());
                }
                return dt;
            }
        }

        public static DataSet GetContactList(out int AllCurrentCount, int Answered = -1, string SortDir = "desc", int startRowIndex = 0, int maximumRows = 10)
        {
            Property.AddParametr("@IsAnswered", Answered, true);
            Property.AddParametr("@SortDir", SortDir, false);
            Property.AddOUTPUTParametr("@AllCurrentCount", false);
            Property.AddParametr("@startRowIndex", startRowIndex, false);
            Property.AddParametr("@maximumRows", maximumRows, false);
            using (DataSet dt = DataFetch.ExecuteSPrDS_SaveParams("GetContactList"))
            {
                AllCurrentCount = 0;
                if (dt != null)
                {
                    if (!string.IsNullOrEmpty(Property.myCmd.Parameters["@AllCurrentCount"].Value.ToString()))
                        AllCurrentCount = int.Parse(Property.myCmd.Parameters["@AllCurrentCount"].Value.ToString());
                }
                return dt;
            }
        }
    }
}
