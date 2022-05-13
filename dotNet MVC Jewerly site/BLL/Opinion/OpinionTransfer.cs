using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HProtest_DAL;


namespace HProtest_BLL.Opinion
{
    public class OpinionTransfer
    {
        public static int OpinionInsert(string UserName, string Question, object StartDate, object EndDate, int HasmultiAnswer, bool IsUnlimited, int IsEnable)
        {

            Property.AddParametr("@UserName", UserName, true);
            Property.AddParametr("@Question", Question, false);
            Property.AddParametr("@StartDate", StartDate, false);
            Property.AddParametr("@EndDate", EndDate, false);
            Property.AddParametr("@HasMultipleAnswer", HasmultiAnswer, false);
            Property.AddParametr("@IsUnlimited", IsUnlimited, false);
            Property.AddParametr("@IsEnable", IsEnable, false);
            DataRow result = DataFetch.ExecuteSPrDR("OpinionInsert");
            if (result != null)
                return Int32.Parse(result["MyOpinionID"].ToString());
            else
            {
                return -1;
            }
        }
        public static bool OpinionEdite(int OpinionID, string UserName, string Question, object StartDate, object EndDate, int HasmultiAnswer, bool IsUnlimited, int IsEnable)
        {
            Property.AddParametr("@OpinionID", OpinionID, true);
            Property.AddParametr("@UserName", UserName, false);
            Property.AddParametr("@Question", Question, false);
            Property.AddParametr("@StartDate", StartDate, false);
            Property.AddParametr("@EndDate", EndDate, false);
            Property.AddParametr("@HasMultipleAnswer", HasmultiAnswer, false);
            Property.AddParametr("@IsUnlimited", IsUnlimited, false);
            Property.AddParametr("@IsEnable", IsEnable, false);
            bool Successed;

            DataFetch.ExecuteNonSP("OpinionEdit", out Successed);
             return Successed;

        }
        public static bool OpinionDelete(int OpinionID)
        {
            Property.AddParametr("@OpinionID", OpinionID, true);
            bool Successed;
            DataFetch.ExecuteNonSP("OpinionDelete",out Successed);
            return Successed;

        }
        public static int OptionInsert(int OpinionID, string Text, int OptionOrder)
        {
            Property.AddParametr("@OpinionID", OpinionID, true);
            Property.AddParametr("@Text", Text, false);
            Property.AddParametr("@OptionOrder", OptionOrder, false);

            DataRow dr = DataFetch.ExecuteSPrDR("OptionInsert");
            if (dr != null)
                return int.Parse(dr["OptionID"].ToString());
            else
                return -1;
        }
        public static int OptionEdite(int OptionID,int OpinionID, string Text, int OpinionOrder, int Hitcount)
        {
            Property.AddParametr("@OptionID", OptionID, true);
            Property.AddParametr("@OpinionID", OpinionID, false);
            Property.AddParametr("@Text", Text, false);
            Property.AddParametr("@OptionOrder", OpinionOrder, false);
            Property.AddParametr("@Hitcount", Hitcount, false);

            DataRow dr = DataFetch.ExecuteSPrDR("OptionEdite");
            if (dr != null)
                return int.Parse(dr["OptionID"].ToString());
            else
                return -1;
        }
        public static bool OptionDelete(int OptionID,int OpinionID)
        {
            Property.AddParametr("@OptionID", OptionID, true);
            Property.AddParametr("@OpinionID", OpinionID, false);
            bool Successed;
            DataFetch.ExecuteNonSP("OptionDelete", out Successed);
            return Successed;
        }
        public static bool InsertVoterIP(int IP, string VoteList)
        {
            Property.AddParametr("@IP", IP, true);
            Property.AddParametr("@VoteList", VoteList, false);
            bool Successed;            
            DataFetch.ExecuteNonSP("InsertVoterIP", out Successed);
            return Successed;
        }
    }
}
