using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HProtest_DAL;

namespace HProtest_BLL.Advertise
{
    public class AdvertiseTransfer
    {
        public static int AdvertiseInsert(string Username, string Tite, string Link, int Visible, int IdFileType, int IdAdvertisePosition, int AdsHeight,string Pic)
        {
            Property.AddParametr("@UserName", Username, true);
            Property.AddParametr("@Title", Tite, false);
            Property.AddParametr("@Link", Link, false);
            //Property.AddParametr("@DateInput", , false);
            Property.AddParametr("@Visible", Visible, false);
            Property.AddParametr("@IdFileType", IdFileType, false);
            Property.AddParametr("@IdAdvertisePosition", IdAdvertisePosition, false);
            Property.AddParametr("@AdsHeight", AdsHeight, false);
            Property.AddParametr("@Pic", Pic, false);

            return int.Parse(DataFetch.ExecuteSPrDR("InsertAdvertise")["Id"].ToString());
        }

        public static int EditAdvertise(int Id, string Tite, string Link, int Visible, int IdFileType, int IdAdvertisePosition, int AdsHeight, string Pic)
        {
            Property.AddParametr("@Id", Id, true);
            Property.AddParametr("@Title", Tite, false);
            Property.AddParametr("@Link", Link, false);
            //Property.AddParametr("@DateInput", , false);
            Property.AddParametr("@Visible", Visible, false);
            Property.AddParametr("@IdFileType", IdFileType, false);
            Property.AddParametr("@IdAdvertisePosition", IdAdvertisePosition, false);
            Property.AddParametr("@AdsHeight", AdsHeight, false);
            Property.AddParametr("@Pic", Pic, false);

            return int.Parse(DataFetch.ExecuteSPrDR("EditAdvertise")["Id"].ToString());
        }

        public static System.Data.DataRow DeleteAdvertise(int Id)
        {
            Property.AddParametr("@Id", Id, true);
            return DataFetch.ExecuteSPrDR("DeleteAdvertise");
            
        }
    }
}
