using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HProtest_DAL;
using System.Data;
using System.IO;
namespace HProtest_BLL
{
    public class Common
    {
        public static bool InsertContactUs(string Name, string Family, string Email,int ContactUsTypeID, string Title, string Details)
        {
            Property.AddParametr("@Name", Name, true);
            Property.AddParametr("@Family", Family, false);
            Property.AddParametr("@Email", Email, false);
            Property.AddParametr("@ContactUsTypeID", ContactUsTypeID, false);
            Property.AddParametr("@Title", Title, false);
            Property.AddParametr("@Details", Details, false);
            bool Successed;
            DataFetch.ExecuteNonSP("InsertContactUs", out Successed);
            return Successed;
        }
        public static DataTable GetMenu(int ParentID)
        {
            Property.AddParametr("@ParentID", ParentID, true);
            
            return DataFetch.ExecuteSPrDT("GetMenu");
        }

        public static void UpdateVisitedNews(int id)
        {

            Property.AddParametr("@id", id, true);
            DataFetch.ExecuteSPrDT("UpdateVisitedNews");
        }

        public static void UpdateVisited(int id)
        {

            Property.AddParametr("@id", id, true);
            DataFetch.ExecuteSPrDT("UpdateVisited");
        }
        public static DataTable GetProductInfo(string sortExtertion, string sortType)
        {
            Property.AddParametr("@sortExtertion", sortExtertion, true);
            Property.AddParametr("@sortType", sortType, false);

            return DataFetch.ExecuteSPrDT("GetProductInfo");
        }

        public static DataTable GetPics(string ProductID) {
            Property.AddParametr("@ProductID", ProductID, true);
            return DataFetch.ExecuteSPrDT("GetPics");
        }
        public static string DeletePics(string id)
        {
            Property.AddParametr("@pid", id, true);
            DataFetch.ExecuteSPrDS_SaveParams("DeletePics");
            return Property.myCmd.Parameters["@ID"].Value.ToString();
        }

        public static bool DelFile(string path)
        {
            try
            {
                File.Delete(path);
                return true;
            }
            catch {
                return false;
            }
        }

        public static string DigitCommo(string str)
        {
            int len = str.Length;
            for (int i = str.Length; i > 3; )
            {
                i -= 3;
                str = str.Insert(i, ",");
            } return str;
        }
        
    }
}
