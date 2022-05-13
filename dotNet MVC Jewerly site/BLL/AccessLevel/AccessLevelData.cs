using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HProtest_DAL;
using System.Data;

namespace HProtest_BLL.AccessLevel
{
    public class AccessLevelData
    {
        public static AccessLevel FillMemberAccessLevel(string UserName)
        {
            Property.AddParametr("@UserName", UserName, true);
            try
            {
                DataTable DTAccessLevel = DataFetch.ExecuteSPrDT("GetMemberAccessLevel");
                AccessLevel CurrentAccess = new AccessLevel();
                for (int i = 0; i < DTAccessLevel.Rows.Count; i++)
                {
                    switch (DTAccessLevel.Rows[i][2].ToString())
                    {
                        case "1":
                            CurrentAccess.ProductAgent = true;
                            break;
                        case "2":
                            CurrentAccess.NewsAgent = true;
                            break;
                        case "3":
                            CurrentAccess.SellAgent = true;
                            break;
                        case "4":
                            CurrentAccess.UserAgent = true;
                            break;
                        case "5":
                            CurrentAccess.AdvertiseAgent = true;
                            break;
                        case "6":
                            CurrentAccess.LibraryAgent = true;
                            break;
                        case "7":
                            CurrentAccess.SupportAgent = true;
                            break;
                        case "10":
                            CurrentAccess.ManagerAgent = true;
                            break;
                    }
                }
                return CurrentAccess;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
    }
}
