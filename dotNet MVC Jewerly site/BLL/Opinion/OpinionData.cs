using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HProtest_DAL;

namespace HProtest_BLL.Opinion
{
   public class OpinionData
    {
       public static DataSet getActiveOpinion(int IP=0)
       {
           Property.AddParametr("@IP", IP, true);
           return DataFetch.ExecuteSPrDS_SaveParams("GetActiveOpinion");
       }
       public static DataTable GeOpinionList(string Question, DateTime DateFrom, DateTime DateTo, int Type
     , string sortExpression, string sortDir, int startRowIndex, int maximumRows, out int AllRowCount)
       {
           Property.AddParametr("@Question", Question, true);

           Property.AddParametr("@StartDate", DateFrom, false);
           Property.AddParametr("@EndDate", DateTo, false);
           Property.AddParametr("@HasMultipleAnswer", Type, false);
           Property.AddParametr("@sortExpression", sortExpression, false);
           Property.AddParametr("@sortDir", sortDir, false);
           Property.AddParametr("@startRowIndex", startRowIndex, false);
           Property.AddParametr("@maximumRows", maximumRows, false);

           Property.AddOUTPUTParametr("@AllCount", false);
           DataSet ds = DataFetch.ExecuteSPrDS_SaveParams("OpinionList");

           AllRowCount = int.Parse(!String.IsNullOrEmpty(Property.myCmd.Parameters["@AllCount"].Value.ToString()) ?Property.myCmd.Parameters["@AllCount"].Value.ToString():"0");
           if (ds != null)

               return ds.Tables[0];


           else return null;


       }
       public static DataTable GetAllOpinionList( string Question
     , string sortExpression, string sortDir, int startRowIndex, int maximumRows)
        {
            Property.AddParametr("@Question", Question, true);

            Property.AddParametr("@sortExpression", sortExpression, false);
            Property.AddParametr("@sortDir", sortDir, false);
            Property.AddParametr("@startRowIndex", startRowIndex, false);
            Property.AddParametr("@maximumRows", maximumRows, false);

            Property.AddOUTPUTParametr("@AllCount", false);
            DataSet ds = DataFetch.ExecuteSPrDS_SaveParams("OpinionList");
            if (ds != null)

                return ds.Tables[1];


            else return null;


        }
        public static DataRow GetOpinionByID(int OpinionID)
        {
            Property.AddParametr("@OpinionID", OpinionID, true);
            return DataFetch.ExecuteSPrDR("GetOpinionByID");
        }
        public static DataTable GetOptionList(int OpinionID)
        {
            Property.AddParametr("@OpinionID", OpinionID, true);
            return  DataFetch.ExecuteSPrDT("OptionList");
        }
    }
}
