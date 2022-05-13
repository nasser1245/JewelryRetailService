using System;
using HProtest_DAL;
using System.Data;

namespace HProtest_BLL.Library
{
    public class LibraryTransfer
    {
        public static int InsertLibrary(string UserName, string Title, string Summary, string Link, string Detail, string Picture, int Visible, string DateInput,int IdLibraryCategory)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@UserName", UserName, true);
            Property.AddParametr("@Title", Title, false);
            Property.AddParametr("@Summary", Summary, false);
            Property.AddParametr("@Link", Link, false);
            Property.AddParametr("@Detail", Detail, false);
            Property.AddParametr("@Picture", Picture, false);
            Property.AddParametr("@Visible", Visible, false);
            Property.AddParametr("@DateInput", DateInput, false);
            Property.AddParametr("@IdLibraryCategory", IdLibraryCategory, false);
        
            DataRow dr = DataFetch.ExecuteSPrDR("InsertLibrary");
            if (dr != null)
                return int.Parse(dr["id"].ToString());
            else
                return -1;
        }

        public static int EditLibrary(int Id, string Title, string Summary, string Link, string Detail, string Picture, int Visible, string DateInput, int IdLibraryCategory)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@Id", Id, true);
            Property.AddParametr("@Title", Title, false);
            Property.AddParametr("@Summary", Summary, false);
            Property.AddParametr("@Link", Link, false);
            Property.AddParametr("@Detail", Detail, false);
            Property.AddParametr("@PictureExt", Picture, false);
            Property.AddParametr("@Visible", Visible, false);
            Property.AddParametr("@IdLibraryCategory", IdLibraryCategory, false);
            Property.AddParametr("@DateInput", DateInput, false);

            System.Data.DataRow dr = DataFetch.ExecuteSPrDR("EditLibrary");
            if (dr != null)
                return Id;
            else
                return 0;
        }

        public static DataTable DeleteLibrary(int Id)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@Id", Id, true);
            return DataFetch.ExecuteSPrDT("DeleteLibrary");
        }
        
        public static bool InsertLibraryCategory(string Title, int Visible, int Priority, int IdParrent)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@Title", Title, true);
            Property.AddParametr("@Visible", Visible, false);
            Property.AddParametr("@Priority", Priority, false);
            Property.AddParametr("@IdParrent", IdParrent, false);
            bool Successed;
            DataFetch.ExecuteNonSP("InsertLibraryCategory", out Successed);
            return Successed;
        }
        //+++//
        public static bool EditLibraryCategory(int Id, string Title, int Visible, int Priority, int ParrentId)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@Id", Id, true);
            Property.AddParametr("@Title", Title, false);
            Property.AddParametr("@Visible", Visible, false);
            Property.AddParametr("@Priority", Priority, false);
            Property.AddParametr("@ParrentId", ParrentId, false);
            bool Successed;
            DataFetch.ExecuteNonSP("EditLibraryCategory", out Successed);
            return Successed;
        }

        public static bool DeleteLibraryCategory(int IdLibraryCategory)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@ID", IdLibraryCategory, true);
            bool Successed;
            DataFetch.ExecuteNonSP("DeleteLibraryCategory", out Successed);
            return Successed;
        }

        public static bool UpdateLibraryVisitcount(int LibraryID)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@LibraryID", LibraryID, true);
            bool Successed;
            DataFetch.ExecuteNonSP("EditLibraryCategory", out Successed);
            return Successed;
        }
        
    }
}
