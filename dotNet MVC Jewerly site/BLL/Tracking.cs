using System;
using System.Data;
using System.Web;
using HProtest_DAL;

namespace HProtest_BLL.Helper 
{

    public class Tracking
    {
        public enum StatType
        {
            Page = 1,
            Site,
            Admin
        }

        public static void GetRequestDetail()
        {
            // Getting ip of visitor
            string ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            // Getting the page which called the script
            string page = HttpContext.Current.Request.ServerVariables["HTTP_REFERER"];
            // Getting Browser Name of Visitor
            string browser = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];
        }

        public static DataTable GetWebStatistic()
        {
            return DataFetch.ExecuteSPrDT("GetWebStatistic");
        }
        public static void IncVisitStats(StatType Type, string USER_AGENT)
        {
            
            try
            {
                if (USER_AGENT == null)
                    return;

                bool isEngin = false;
                string[] engins = new string[19] { "Googlebot", "Slurp", "search.msn.com", "nutch", "simpy", "bot", "ASPSeek", "crawler", "msnbot", "Libwww-perl", "FAST", "Baidu", "bing", "majestic", "spinn3r", "yandex", "ezooms", "Page2RSS", "ahrefs.com" };
                foreach (string item in engins)
                    if (USER_AGENT.ToLower().Contains(item.ToLower()))
                    {
                        isEngin = true;
                        break;
                    }
                if (!isEngin)
                {
                    Property.AddParametr("@Type", (int)Type, true);
                    Property.AddParametr("@Day", DateTime.Now.Day, false);
                    Property.AddParametr("@Month", DateTime.Now.Month, false);
                    bool Successed;
                    DataFetch.ExecuteNonSP("IncVisitStats", out Successed);
                }
                else//that is a search engine
                {
                    try
                    {
                        HttpContext.Current.Session.Abandon();
                    }
                    catch
                    { }
                }
            }
            catch { }
        }
    }
}
