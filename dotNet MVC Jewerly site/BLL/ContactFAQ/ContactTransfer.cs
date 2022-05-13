using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HProtest_DAL;
using System.Data;

namespace HProtest_BLL.ContactFAQ
{
    public class ContactTransfer
    {
        public static int InsertContactUs(string Email, string Name, string Family, string Tel, string ContactType
    , string Title, string Details)
        {
            Property.AddParametr("@Email", Email, true);
            Property.AddParametr("@Name", Name, false);
            Property.AddParametr("@Family", Family, false);
            Property.AddParametr("@Tel", Tel, false);
            Property.AddParametr("@ContactType", ContactType, false);
            Property.AddParametr("@Title", Title, false);
            Property.AddParametr("@Details", Details, false);

            DataRow dr = DataFetch.ExecuteSPrDR("InsertContactUs");
            if (dr != null)
                return int.Parse(dr["ID"].ToString());
            else
                return -1;
        }
    

            public static int InsertFAQ(string Email, string Name, string Province, string City, string Comment)
        {
            Property.AddParametr("@Email", Email, true);
            Property.AddParametr("@Name", Name, false);
            Property.AddParametr("@Province", Province, false);
            Property.AddParametr("@City", City, false);
            Property.AddParametr("@Comment", Comment, false);
            DataRow dr = DataFetch.ExecuteSPrDR("InsertFAQ");
            if (dr != null)
                return int.Parse(dr["ID"].ToString());
            else
                return -1;
        }



            public static bool EditFAQ(int ID, string Answer, bool Visible= false)
            {
                Property.AddParametr("@ID", ID, true);
                Property.AddParametr("@Answer", Answer, false);
                Property.AddParametr("@Visible", Visible, false);
                bool Successed;
                DataFetch.ExecuteNonSP("EditFAQ",out Successed);
                    return Successed;
            }

            public static bool DeleteFAQ(int ID)
            {
                Property.AddParametr("@ID", ID, true);
                bool Successed;
                DataFetch.ExecuteNonSP("DeleteFAQ", out Successed);
                return Successed;
            }
    }
}
