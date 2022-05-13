using System;
using HProtest_DAL;
using System.Data;
using System.Web.UI.WebControls;

namespace HProtest_BLL.News
{
    public class NewsData
    {
        public static DataTable GetNewsList(int IdNews, string Username, string Title, string Detail, string Summary, int IdNewsCategory, int IdNewsType, int Visible, object DateFrom, object DateTo, int OnlyCurrentDate, string sortExpression,
            string sortDir, int StartRowIndex, int MaxRowCount, out int AllCurrentCount)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@Username", Username, true);
            Property.AddParametr("@Title", Title, false);
            Property.AddParametr("@Detail", Detail, false);
            Property.AddParametr("@Summary", Summary, false);
            Property.AddParametr("@IdNewsCategory", IdNewsCategory, false);
            Property.AddParametr("@IdNewsType", IdNewsType, false);
            Property.AddParametr("@Visible", Visible, false);
            Property.AddParametr("@DateFrom", DateFrom, false);
            Property.AddParametr("@DateTo", DateTo, false);
            Property.AddParametr("@OnlyCurrentDate", OnlyCurrentDate, false);
            Property.AddParametr("@sortExpression", sortExpression, false);
            
            Property.AddParametr("@sortDir", sortDir, false);
            Property.AddParametr("@maximumRows", MaxRowCount, false);
            Property.AddParametr("@startRowIndex", StartRowIndex, false);

            Property.AddOUTPUTParametr("@AllCurrentCount", false);

            using (DataTable dt = DataFetch.ExecuteSPrDT_SaveParams( "GetNewsList"))
            {
                AllCurrentCount = 0;
                if (dt != null)
                {
                    AllCurrentCount = int.Parse(Property.myCmd.Parameters["@AllCurrentCount"].Value.ToString());
                }

                return dt;
            }
        }

        public static DataRow GetNews(int IdNews)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@IdNews", IdNews, true);
            return DataFetch.ExecuteSPrDR("GetNews");
        }
        



        public static DataTable GetNewsCategoryList(int IdNewsCategory, int IdNews, string Title, int Visible,
            string lang, int ParrentId, int IsSubCategory, string sortExpression, string sortDir, int StartRowIndex,
            int MaxRowCount)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@IdNewsCategory", IdNewsCategory, true);
            Property.AddParametr("@Title", Title, false);
            Property.AddParametr("@Visible", Visible, false);
            Property.AddParametr("@IdNews", IdNews, false);
            Property.AddParametr("@lang", lang, false);
            Property.AddParametr("@ParrentId", ParrentId, false);
            Property.AddParametr("@IsSubCategory", IsSubCategory, false);

            Property.AddParametr("@startRowIndex", StartRowIndex, false);
            Property.AddParametr("@sortExpression", sortExpression, false);
            Property.AddParametr("@sortDir", sortDir, false);
            Property.AddParametr("@maximumRows", MaxRowCount, false);
            Property.AddOUTPUTParametr("@AllCount", false);
            Property.AddOUTPUTParametr("@AllCurrentCount", false);
            DataSet ds = DataFetch.ExecuteSPrDS_SaveParams("GetNewsCategoryList");
            return ds.Tables[1];
            
        }
        #region removed
        //public static int GetNewsCategoryListCount(int IdNewsCategory, int IdNews, string Title, int Visible,
        //string lang, int ParrentId, int IsSubCategory  )
        //{
        //    try
        //    {
        //        Property.AddParametr("@IdNewsCategory", IdNewsCategory, true);
        //        Property.AddParametr("@Title", Title, false);
        //        Property.AddParametr("@Visible", Visible, false);
        //        Property.AddParametr("@IdNews", IdNews, false);
        //        Property.AddParametr("@lang", lang, false);
        //        Property.AddParametr("@ParrentId", ParrentId, false);
        //        Property.AddParametr("@IsSubCategory", IsSubCategory, false);

        //        Property.AddParametr("@startRowIndex", -1, false);
        //        Property.AddOUTPUTParametr("@AllCount", SqlDbType.BigInt, false);


        //        using (DataTable dt = DataFetch.ExecuteSPrDT_SaveParams("GetNewsCategoryList"))
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
        public static DataTable GetCategoryOfNews(int IdNews)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@IdNews", IdNews, true);
            return DataFetch.ExecuteSPrDT("GetCategoryOfNews");
        }
        public static DataTable GetNewsCategory()
        {
            Property.myCmd.Parameters.Clear();
            return DataFetch.ExecuteSPrDT("GetNewsCategory");
        }

        public static int GetNewsOwnerMemberType(int Idnews)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@IdNews", Idnews, true);
            DataRow drnewowner = DataFetch.ExecuteSPrDR("GetNewsOwnerMemberType");
            
                if (drnewowner != null)
                    return int.Parse(drnewowner["memberttypeID"].ToString());
                else return 0;
            

        }

        public static DataTable GetCandidNewsCategory(string Username,int ParrentId)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@Username", Username, true);
            Property.AddParametr("@ParrentId", ParrentId, false);
            
            return DataFetch.ExecuteSPrDT("GetCandidNewsCategory");
         
        }

        public static DataTable GetNewsCategoryParrent()
        {
            Property Property = new HProtest_DAL.Property();
            return DataFetch.ExecuteSPrDT("GetNewsCategoryParrent");
        }

        public static DataTable GetNewsTag(int NewsId)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@NewsId", NewsId, true);
           return  DataFetch.ExecuteSPrDT("GetNewsTag");
        }

        public static DataTable GetCascadeNewsCategory()
        {
            Property Property = new HProtest_DAL.Property();
            return DataFetch.ExecuteSPrDT("GetCascadeNewsCategory");
        }
      

        public static DataTable GetNewsCommentList(int parrentId,int newsid,string sendername,string senderemail,int isapproved,string context,
            int senderemailpreview,string sortExpression,string sortDir,int startRowIndex,int maximumRows)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@ParrentId", parrentId, true);
            Property.AddParametr("@NewsId",newsid,false);
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


            DataSet ds = DataFetch.ExecuteSPrDS_SaveParams("GetNewsCommentList");
            return ds.Tables[1];
            
        }
        #region removed
        //public static int GetNewsCommentListCount(int parrentId, int newsid, string sendername, string senderemail, int isapproved, string context,
        //    int senderemailpreview)
        //{
        //    Property.AddParametr("@ParrentId", parrentId, true);
        //    Property.AddParametr("@NewsId", newsid, false);
        //    Property.AddParametr("@SenderName", sendername, false);
        //    Property.AddParametr("@SenderEmail", senderemail, false);
        //    Property.AddParametr("@IsApproved", isapproved, false);
        //    Property.AddParametr("@Context", context, false);
        //    Property.AddParametr("@SenderEmailPreview", senderemailpreview, false);
        //    Property.AddParametr("@startRowIndex", -1, false);

        //    Property.AddOUTPUTParametr("@AllCount", SqlDbType.Int, false);

        //    using(DataTable dt=DataFetch.ExecuteSPrDT_SaveParams("GetNewsCommentList"))
        //    {
        //        if (dt != null)
        //            return dt.Rows.Count;
        //        else
        //            return 0;

        //    }
        //}
        #endregion
        public static DataRow GetNewsCommentByID(int commentId)
        {
            Property Property = new HProtest_DAL.Property();
            Property.AddParametr("@CommentId", commentId, true);
            return DataFetch.ExecuteSPrDR("GetNewsCommentByID");
        }



        public static DataTable GetNewsCategoryList(string Title="")
        {
            Property.AddParametr("@Title", Title, true);
            return DataFetch.ExecuteSPrDT("GetNewsCategoryList");
        }

        public static void SetVisibility(int p)
        {
            throw new NotImplementedException();
        }

        public static bool InsertNewsCategory(string Title, bool Visible)
        {
            Property.AddParametr("@Title", Title, true);
            Property.AddParametr("@Visible", Visible, false);
            bool Successed;
            DataFetch.ExecuteNonSP("InsertNewsCategory", out Successed);
            return Successed;

        }


        public static bool EditNewsCategory(string ID, string Title, bool Visible)
        {
            Property.AddParametr("@ID", ID, true);
            Property.AddParametr("@Title", Title, false);
            Property.AddParametr("@Visible", Visible, false);
            bool Successed;
            DataFetch.ExecuteNonSP("EditNewsCategory", out Successed);
            return Successed;

        }
    }
}
