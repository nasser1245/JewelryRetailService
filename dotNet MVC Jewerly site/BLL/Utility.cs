using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using ShayanDB_BLL;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HProtest_BLL.Helper
{
    public class Utility
    {
        public enum MsgType
        {
            accept = 0,
            warning = 1
        }
        public static bool IsValidPicOrSwfExt(string strFilePath)
        {
            if (strFilePath.Contains("?"))
                strFilePath = strFilePath.Substring(0, strFilePath.IndexOf('?'));

            string[] astrValidExtensions = { ".jpg", ".jpeg", ".gif", ".png", ".bmp", ".swf", ".flv" };

            bool isValid = false;
            foreach (string item in astrValidExtensions)
            {
                if (item.ToLower() == System.IO.Path.GetExtension(strFilePath).ToLower())
                    isValid = true;
            }

            return isValid;
        }

        public static System.Collections.Generic.List<PageItem> GetPagingArray(int CurrentPage, string UrlCat, int lastPageIndex, int PrevNextNum)
        {
            System.Collections.Generic.List<PageItem> PagingLinks = new System.Collections.Generic.List<PageItem>();
            if (lastPageIndex != 1 && lastPageIndex != 0)
            {
                if (CurrentPage != 1)
                    PagingLinks.Add(new PageItem { Href = UrlCat + "&page=1", Title = "صفحه اول" });
                else
                    PagingLinks.Add(new PageItem { Href = "#", Title = "[صفحه اول]" });


                int i = (CurrentPage - PrevNextNum) > 1 ? (CurrentPage - PrevNextNum) : 2;
                while (i < CurrentPage)
                {
                    PagingLinks.Add(new PageItem { Href = UrlCat + "&page=" + (i).ToString(), Title = i.ToString() });
                    i++;
                }

                if (CurrentPage != 1 && CurrentPage != lastPageIndex)
                    PagingLinks.Add(new PageItem { Href = "#", Title = "[" + CurrentPage.ToString() + "]" });

                int max = (CurrentPage + PrevNextNum) < (lastPageIndex) ? (CurrentPage + PrevNextNum) : (lastPageIndex);
                i = CurrentPage + 1;
                while (i <= max && i != lastPageIndex)
                {
                    PagingLinks.Add(new PageItem { Href = UrlCat + "&page=" + (i).ToString(), Title = i.ToString() });
                    i++;
                }

                if (CurrentPage != lastPageIndex)
                    PagingLinks.Add(new PageItem { Href = UrlCat + "&page=" + (lastPageIndex).ToString(), Title = "صفحه آخر" });
                else
                    PagingLinks.Add(new PageItem { Href = "#", Title = "[صفحه آخر]" });
            }

            return PagingLinks;
        }

        public static void ShowMsg(System.Web.UI.Page page, PropertyData.MsgType type, string msg)
        {
            string myScript2 = "showMsg('" + type.ToString() + "','" + msg + "');";
            page.ClientScript.RegisterStartupScript(page.GetType(), "myKey1", myScript2, true);
        }

        public static bool IsDateTime(DateTime dt)
        {
            try
            {
                DateTime Tmp = dt;
                return true;
            }
            catch {
                return false;
            }
        }
        public static string GetRandomString()
        {
            string path = System.IO.Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.
            return path;
        }

        public static string GetMD5HashText(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));

                System.Text.StringBuilder sBuilder = new System.Text.StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }

        public static string GetMD5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));

            System.Text.StringBuilder sBuilder = new System.Text.StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public static bool IsValidExt(string strFilePath)
        {
            if (strFilePath.Contains("?"))
                strFilePath = strFilePath.Substring(0, strFilePath.IndexOf('?'));

            string[] astrValidExtensions = { ".jpg", ".jpeg", ".gif", ".png", ".bmp" };

            bool isValid = false;
            foreach (string item in astrValidExtensions)
            {
                if (item.ToLower() == System.IO.Path.GetExtension(strFilePath).ToLower())
                    isValid = true;
            }

            return isValid;
        }

        public static bool IsValidDocExt(string strFilePath)
        {
            if (strFilePath.Contains("?"))
                strFilePath = strFilePath.Substring(0, strFilePath.IndexOf('?'));

            string[] astrValidExtensions = { ".txt", ".zip", ".rar", ".doc", ".docx", ".pdf", ".ppt", ".pptx", ".swf"};
            bool isValid = false;
            foreach (string item in astrValidExtensions)
            {
                if (item.ToLower() == System.IO.Path.GetExtension(strFilePath).ToLower())
                    isValid = true;
            }

            return isValid;
        }
        public static bool IsValidEmail(string address)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(address.Trim()))
                return true;
            else
                return false;
        }

        public static bool IsValidUserName(string UserName)
        {
            string strRegex = "[A-Za-z][A-Za-z0-9_-]{5,20}";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(UserName.Trim()))
                return true;
            else
                return false;
        }

        public static bool IsValidPassword(string Password)
        {
            string strRegex = "[A-Za-z0-9_-]{6,20}";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(Password.Trim()))
                return true;
            else
                return false;
        }

        public static bool IsNumeric(string input)
        {
            try
            {
                int x = int.Parse(input);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool isValidMelliCode(string MelliCode)
        {
            if (MelliCode.Length < 8)
                return false;

            int chk, s, r;

            if (MelliCode.Length == 8)
                MelliCode = "00" + MelliCode;

            if (MelliCode == "0000000000" || MelliCode == "1111111111" || MelliCode == "2222222222" || MelliCode == "3333333333" || MelliCode == "4444444444" || MelliCode == "5555555555" || MelliCode == "6666666666" || MelliCode == "7777777777" || MelliCode == "8888888888" || MelliCode == "9999999999")
                return false;

            chk = int.Parse(MelliCode.Substring(9, 1));

            s = 0;

            for (int i = 0; i < 9; i++)
            {
                s = s + int.Parse(MelliCode.Substring(i, 1)) * (10 - i);
            }

            r = s % 11;

            if ((r < 2 && chk == r) || (r >= 2 && chk == (11 - r)))
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GetPersianDate(object DateTime)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(((DateTime)DateTime)).ToString() + "/" + (pc.GetMonth(((DateTime)DateTime)).ToString().Length < 2 ? "0"+pc.GetMonth(((DateTime)DateTime)).ToString() : pc.GetMonth(((DateTime)DateTime)).ToString()) + "/" + (pc.GetDayOfMonth(((DateTime)DateTime)).ToString().Length<2 ? "0"+pc.GetDayOfMonth(((DateTime)DateTime)).ToString() : pc.GetDayOfMonth(((DateTime)DateTime)).ToString()) ;
        }

        public static string GetTimeOfDate(object DateTime)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetHour(((DateTime)DateTime)).ToString() + ":" + pc.GetMinute(((DateTime)DateTime)).ToString();
        }

        //public static void ShowMsg(System.Web.UI.Page page, PropertyData.MsgType type, string msg)
        //{
        //    string myScript2 = "showMsg('" + type.ToString() + "','" + msg + "');";
        //    page.ClientScript.RegisterStartupScript(page.GetType(), "myKey1", myScript2, true);
        //}

        public static string GetPersianString(string input)
        {
            for (int i = 48; i < 58; i++)
                input = input.Replace(((char)i).ToString(), char.ConvertFromUtf32(i + 1728));

            return input;
        }
        //public enum MsgType
        //{
        //    accept = 0,
        //    warning = 1
        //}
        public static string GetExt(string strFileName)
        {
            if (strFileName.Contains("?"))
                strFileName = strFileName.Substring(0, strFileName.IndexOf('?'));
            string exe = strFileName.Substring(strFileName.LastIndexOf("."));
            return exe;


        }
        public static bool IsValidLink(string Link)
        {
            return Uri.IsWellFormedUriString(Link, UriKind.RelativeOrAbsolute);

        }
        /// <summary>
        /// "0"->false "1"->true
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        /// //++++//
        public static bool ConvertStringToBool(string param)
        {
            return param == "0" ? false : true;
        }

        public static string GetPersianSolarDate(object input)
        {
            DateTime date = (DateTime)(input);
            Persia.SolarDate SolarDate = Persia.Calendar.ConvertToPersian(date);
             return SolarDate.ToString("N");

        }
        public static string GetPersianDated(object input)
        {
            DateTime date = (DateTime)(input);
            Persia.SolarDate SolarDate = Persia.Calendar.ConvertToPersian(date);
            return SolarDate.ToString("D");

        }
        public static string GetPersianDateTime(object DateTime)
        {
            PersianCalendar pc = new PersianCalendar();
            if (!string.IsNullOrEmpty(DateTime.ToString()))
            {
                return pc.GetYear(((DateTime)DateTime)).ToString() + "-" + pc.GetMonth(((DateTime)DateTime)).ToString() + "-" + pc.GetDayOfMonth(((DateTime)DateTime)).ToString() + "</br> ساعت "
                   + pc.GetHour(((DateTime)DateTime)).ToString() + ":" + pc.GetMinute(((DateTime)DateTime)).ToString() + ":" + pc.GetSecond(((DateTime)DateTime)).ToString();
            }
            else return "";

        }

        public static void ClearText(Control Parent)
        {
            foreach (Control c in Parent.Controls) {
                if (c.GetType() == typeof(TextBox)) 
                {
                    ((TextBox)c).Text = "";
                }
            }
        }
        public static bool GarbageCollector() 
        {
            return true;
        }
    }
}
