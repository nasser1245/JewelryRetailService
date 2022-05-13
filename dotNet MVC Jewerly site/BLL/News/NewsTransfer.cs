using System;
using HProtest_DAL;
using System.Data;

namespace HProtest_BLL.News
{
    public class NewsTransfer
    {
        public static int InsertNews(string UserName, string Title, string Summary, string Detail, string Picture, int Visible, string DateInput,int IdNewsCategory,int IdNewsType)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@UserName", UserName, true);
            Property.AddParametr("@Title", Title, false);
            Property.AddParametr("@Summary", Summary, false);
            Property.AddParametr("@Detail", Detail, false);
            Property.AddParametr("@PictureExt", Picture, false);
            Property.AddParametr("@Visible", Visible, false);
            Property.AddParametr("@DateInput", DateInput, false);
            Property.AddParametr("@IdNewsCategory", IdNewsCategory, false);
            Property.AddParametr("@IdNewsType", null, false);
        
            DataRow dr = DataFetch.ExecuteSPrDR("InsertNews");
            if (dr != null)
                return int.Parse(dr["id"].ToString());
            else
                return -1;
        }

        public static int EditNews(int Id, string Title, string Summary, string Detail, string Picture, int Visible, string DateInput, int IdNewsCategory, int IdNewsType)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@Id", Id, true);
            Property.AddParametr("@Title", Title, false);
            Property.AddParametr("@Summary", Summary, false);
            Property.AddParametr("@Detail", Detail, false);
            Property.AddParametr("@PictureExt", Picture, false);
            Property.AddParametr("@Visible", Visible, false);
            Property.AddParametr("@IdNewsCategory", IdNewsCategory, false);
            Property.AddParametr("@IdNewsType", IdNewsType, false);
            Property.AddParametr("@DateInput", DateInput, false);

            System.Data.DataRow dr = DataFetch.ExecuteSPrDR("EditNews");
            if (dr != null)
                return Id;
            else
                return 0;
        }

        public static DataTable DeleteNews(int Id)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@Id", Id, true);
            return DataFetch.ExecuteSPrDT("DeleteNews");
        }
        
        public static bool InsertNewsCategory(string Title, int Visible, int Priority, int IdParrent)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@Title", Title, true);
            Property.AddParametr("@Visible", Visible, false);
            Property.AddParametr("@Priority", Priority, false);
            Property.AddParametr("@IdParrent", IdParrent, false);
            bool Successed;
            DataFetch.ExecuteNonSP("InsertNewsCategory", out Successed);
            return Successed;
        }
        //+++//
        public static bool EditNewsCategory(int Id, string Title, int Visible, int Priority, int ParrentId)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@Id", Id, true);
            Property.AddParametr("@Title", Title, false);
            Property.AddParametr("@Visible", Visible, false);
            Property.AddParametr("@Priority", Priority, false);
            Property.AddParametr("@ParrentId", ParrentId, false);
            bool Successed;
            DataFetch.ExecuteNonSP("EditNewsCategory", out Successed);
            return Successed;
        }

        public static bool DeleteNewsCategory(int IdNewsCategory)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@ID", IdNewsCategory, true);
            bool Successed;
            DataFetch.ExecuteNonSP("DeleteNewsCategory", out Successed);
            return Successed;
        }

        public static bool UpdateNewsVisitcount(int NewsID)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@NewsID", NewsID, true);
            bool Successed;
            DataFetch.ExecuteNonSP("EditNewsCategory", out Successed);
            return Successed;
        }
        
    }
}
