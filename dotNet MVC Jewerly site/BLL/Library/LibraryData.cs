using System;
using HProtest_DAL;
using System.Data;
using System.Web.UI.WebControls;

namespace HProtest_BLL.Library
{
    public class LibraryData
    {
        public static DataTable GetLibraryList(int IdLibrary, string Username, string Title, string Detail, string Summary,string Link, int IdLibraryCategory,int VisibleCats, int Visible, object DateFrom, object DateTo, int OnlyCurrentDate, string sortExpression,
            string sortDir, int StartRowIndex, int MaxRowCount, out int AllCurrentCount)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@Username", Username, true);
            Property.AddParametr("@Title", Title, false);
            Property.AddParametr("@Detail", Detail, false);
            Property.AddParametr("@Summary", Summary, false);
            Property.AddParametr("@Link", Link, false);
            Property.AddParametr("@IdLibraryCategory", IdLibraryCategory, false);
            Property.AddParametr("@Visible", Visible, false);
            Property.AddParametr("@VisibleCats", VisibleCats, false);
            Property.AddParametr("@DateFrom", DateFrom, false);
            Property.AddParametr("@DateTo", DateTo, false);
            Property.AddParametr("@OnlyCurrentDate", OnlyCurrentDate, false);
            Property.AddParametr("@sortExpression", sortExpression, false);
            
            Property.AddParametr("@sortDir", sortDir, false);
            Property.AddParametr("@maximumRows", MaxRowCount, false);
            Property.AddParametr("@startRowIndex", StartRowIndex, false);

            Property.AddOUTPUTParametr("@AllCurrentCount", false);

            using (DataTable dt = DataFetch.ExecuteSPrDT_SaveParams("GetLibraryList"))
            {
                AllCurrentCount = 0;
                if (dt != null)
                {
                    AllCurrentCount = int.Parse(Property.myCmd.Parameters["@AllCurrentCount"].Value.ToString());
                }

                return dt;
            }
        }

        public static DataRow GetLibrary(int IdLibrary)
        {
            //Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@IdLibrary", IdLibrary, true);
            return DataFetch.ExecuteSPrDR("GetLibrary");
        }


        public static void IncVisitCountLibrary(int IdLibrary)
        {
            Property.AddParametr("@IdLibrary", IdLibrary, true);
            DataFetch.ExecuteSPrDR("IncVisitCountLibrary");
        }

        public static DataTable GetLibraryCategoryList(int IdLibraryCategory, int IdLibrary, string Title, int Visible,
            string lang, int ParrentId, int IsSubCategory, string sortExpression, string sortDir, int StartRowIndex,
            int MaxRowCount)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@IdLibraryCategory", IdLibraryCategory, true);
            Property.AddParametr("@Title", Title, false);
            Property.AddParametr("@Visible", Visible, false);
            Property.AddParametr("@IdLibrary", IdLibrary, false);
            Property.AddParametr("@lang", lang, false);
            Property.AddParametr("@ParrentId", ParrentId, false);
            Property.AddParametr("@IsSubCategory", IsSubCategory, false);
            Property.AddParametr("@startRowIndex", StartRowIndex, false);
            Property.AddParametr("@sortExpression", sortExpression, false);
            Property.AddParametr("@sortDir", sortDir, false);
            Property.AddParametr("@maximumRows", MaxRowCount, false);
            Property.AddOUTPUTParametr("@AllCount", false);
            Property.AddOUTPUTParametr("@AllCurrentCount", false);
            DataSet ds = DataFetch.ExecuteSPrDS_SaveParams("GetLibraryCategoryList");
            return ds.Tables[1];
            
        }
        #region removed
        //public static int GetLibraryCategoryListCount(int IdLibraryCategory, int IdLibrary, string Title, int Visible,
        //string lang, int ParrentId, int IsSubCategory  )
        //{
        //    try
        //    {
        //        Property.AddParametr("@IdLibraryCategory", IdLibraryCategory, true);
        //        Property.AddParametr("@Title", Title, false);
        //        Property.AddParametr("@Visible", Visible, false);
        //        Property.AddParametr("@IdLibrary", IdLibrary, false);
        //        Property.AddParametr("@lang", lang, false);
        //        Property.AddParametr("@ParrentId", ParrentId, false);
        //        Property.AddParametr("@IsSubCategory", IsSubCategory, false);

        //        Property.AddParametr("@startRowIndex", -1, false);
        //        Property.AddOUTPUTParametr("@AllCount", SqlDbType.BigInt, false);


        //        using (DataTable dt = DataFetch.ExecuteSPrDT_SaveParams("GetLibraryCategoryList"))
        //        {
        //            if (dt != null)
        //                return int.Parse(dt.Rows.Count.ToString());

        //            else
        //                return 0;
        //        }
        //    }
        //    catch { return 0; }
        //}
        #endregion
        //+++//
        public static DataTable GetCategoryOfLibrary(int IdLibrary)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@IdLibrary", IdLibrary, true);
            return DataFetch.ExecuteSPrDT("GetCategoryOfLibrary");
        }
        public static DataTable GetLibraryCategory()
        {
            Property.myCmd.Parameters.Clear();
            return DataFetch.ExecuteSPrDT("GetLibraryCategory");
        }

        public static int GetLibraryOwnerMemberType(int IdLibrary)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@IdLibrary", IdLibrary, true);
            DataRow drnewowner = DataFetch.ExecuteSPrDR("GetLibraryOwnerMemberType");
            
                if (drnewowner != null)
                    return int.Parse(drnewowner["memberttypeID"].ToString());
                else return 0;
            

        }

        public static DataTable GetCandidLibraryCategory(string Username,int ParrentId)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@Username", Username, true);
            Property.AddParametr("@ParrentId", ParrentId, false);
            
            return DataFetch.ExecuteSPrDT("GetCandidLibraryCategory");
         
        }

        public static DataTable GetLibraryCategoryParrent()
        {
            Property Property = new HProtest_DAL.Property();
            return DataFetch.ExecuteSPrDT("GetLibraryCategoryParrent");
        }

        public static DataTable GetLibraryTag(int LibraryId)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@LibraryId", LibraryId, true);
           return  DataFetch.ExecuteSPrDT("GetLibraryTag");
        }

        public static DataTable GetCascadeLibraryCategory()
        {
            Property Property = new HProtest_DAL.Property();
            return DataFetch.ExecuteSPrDT("GetCascadeLibraryCategory");
        }
      

        public static DataTable GetLibraryCommentList(int parrentId,int Libraryid,string sendername,string senderemail,int isapproved,string context,
            int senderemailpreview,string sortExpression,string sortDir,int startRowIndex,int maximumRows)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@ParrentId", parrentId, true);
            Property.AddParametr("@LibraryId",Libraryid,false);
            Property.AddParametr("@SenderName",sendername,false);
            Property.AddParametr("@SenderEmail",senderemail,false);
            Property.AddParametr("@IsApproved",isapproved,false);
            Property.AddParametr("@Context",context,false);
            Property.AddParametr("@SenderEmailPreview",senderemailpreview,false);
            Property.AddParametr("@sortExpression",sortExpression,false);
            Property.AddParametr("@sortDir",sortDir,false);
            Property.AddParametr("@startRowIndex",startRowIndex,false);
            Property.AddParametr("@maximumRows", maximumRows, false);

            Property.AddOUTPUTParametr("@AllCount", false);
            Property.AddOUTPUTParametr("@AllCurrentCount", false);


            DataSet ds = DataFetch.ExecuteSPrDS_SaveParams("GetLibraryCommentList");
            return ds.Tables[1];
            
        }

        public static DataRow GetLibraryCommentByID(int commentId)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@CommentId", commentId, true);
            return DataFetch.ExecuteSPrDR("GetLibraryCommentByID");
        }



        public static DataTable GetLibraryCategoryList(string Title="")
        {
            Property.AddParametr("@Title", Title, true);
            return DataFetch.ExecuteSPrDT("GetLibraryCategoryList");
        }

        public static void SetVisibility(int p)
        {
            throw new NotImplementedException();
        }

        public static bool InsertLibraryCategory(string Title, bool Visible)
        {
            Property.AddParametr("@Title", Title, true);
            Property.AddParametr("@Visible", Visible, false);
            bool Successed;
            DataFetch.ExecuteNonSP("InsertLibraryCategory", out Successed);
            return Successed;

        }


        public static bool EditLibraryCategory(string ID, string Title, bool Visible)
        {
            Property.AddParametr("@ID", ID, true);
            Property.AddParametr("@Title", Title, false);
            Property.AddParametr("@Visible", Visible, false);
            bool Successed;
            DataFetch.ExecuteNonSP("EditLibraryCategory", out Successed);
            return Successed;

        }
    }
}
