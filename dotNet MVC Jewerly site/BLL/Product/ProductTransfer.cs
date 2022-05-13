using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HProtest_DAL;

namespace HProtest_BLL.Product
{
    public class ProductTransfer
    {
        public static double InsertRate(string ID, string Point)
        {

            Property.AddParametr("@ID", ID, true);
            Property.AddParametr("@Point", Point, false);
            System.Data.DataRow dr= DataFetch.ExecuteSPrDR("InsertRate");
            if (dr != null)
                return double.Parse(dr["Point"].ToString());
            return -1;
        }
    }
}
