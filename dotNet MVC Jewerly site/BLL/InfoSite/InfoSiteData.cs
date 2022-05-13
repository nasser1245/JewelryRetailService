using System;
using HProtest_DAL;
using System.Data;
using System.Web.UI.WebControls;

namespace HProtest_BLL.InfoSite
{
    public class InfoSiteData
    {


        public static DataRow GetInfoSite(int Id)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@Id", Id, true);
            return DataFetch.ExecuteSPrDR("GetInfo");
        }

        public static int EditInfoSite(int Id, string Text)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@Id", Id, true);
            Property.AddParametr("@Text", Text, false);
            System.Data.DataRow dr = DataFetch.ExecuteSPrDR("EditInfoSite");
            if (dr != null)
                return Id;
            else
                return 0;
        }

    }
}
