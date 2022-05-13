using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HProtest_DAL;
using System.Data;

namespace HProtest_BLL.Basket
{
    public class BasketData
    {

        public static DataSet GetBasketProduct(string UserName, out int BasketID, string UpdateBasketProductCount = "", string Description = "")
        {
            Property.AddParametr("@UserName", UserName, true);
            Property.AddOUTPUTParametr("@BasketID", false);
            Property.AddParametr("@UpdateBasketProductCount", UpdateBasketProductCount, false);
            Property.AddParametr("@Description", Description, false);
            using (DataSet dt = DataFetch.ExecuteSPrDS_SaveParams("GetBasketProduct"))
            {
                BasketID = 0;
                if (dt != null)
                {
                    if (!string.IsNullOrEmpty(Property.myCmd.Parameters["@BasketID"].Value.ToString()))
                    BasketID = int.Parse(Property.myCmd.Parameters["@BasketID"].Value.ToString());
                }
                    return dt;
            }
        }

        public static DataTable GetGiftList(int TotalBuy)
        {
            Property.AddParametr("@TotalBuy", TotalBuy, true);
            using (DataTable dt = DataFetch.ExecuteSPrDT_SaveParams("GetGiftList"))
            {
                return dt;
            }
        }
        public static int GetBasketCount(string UserName)
        {
            Property.AddParametr("@UserName", UserName, true);
            DataRow dt = DataFetch.ExecuteSPrDR("GetBasketCount");
                if (dt != null)
                {
                    return int.Parse(dt["Count"].ToString());
                }
                return 0;
        }

        public static DataTable GetBasketList(string UserName, out int BasketCount, out int PayCount)
        {
            Property.AddParametr("@UserName", UserName, true);
            Property.AddOUTPUTParametr("@BasketCount", false);
            Property.AddOUTPUTParametr("@PayCount", false);
            using (DataTable dt = DataFetch.ExecuteSPrDT_SaveParams("GetBasketList"))
            {
                BasketCount = 0;
                PayCount = 0;
                if (dt != null)
                {
                    if (!string.IsNullOrEmpty(Property.myCmd.Parameters["@BasketCount"].Value.ToString()))
                        BasketCount = int.Parse(Property.myCmd.Parameters["@BasketCount"].Value.ToString());
                    if (!string.IsNullOrEmpty(Property.myCmd.Parameters["@PayCount"].Value.ToString()))
                        PayCount = int.Parse(Property.myCmd.Parameters["@PayCount"].Value.ToString());
                }
                return dt;
            }
        }

        public static DataSet ProcessFactor(int ProcessType, string UserName = "", int BasketID = 0, string FactorID ="" )
        {
            Property.AddParametr("@ProcessType", ProcessType, true);
            Property.AddParametr("@UserName", UserName, false);
            Property.AddParametr("@BasketID", BasketID, false);
            Property.AddParametr("@FactorID", FactorID, false);
            return DataFetch.ExecuteSPrDS_SaveParams("ProcessFactor");
        }


        public static DataTable GetAllBasket( out int AllRow, string FactorID = null, string BeginPostDate = null, string EndPostDate = null, string BeginPayDate = null,
            string EndPayDate = null, string BasketStatusID = null, string UserName = null, string GiftName = null, string BeginPriceRange = null,
            string EndPriceRange = null, string PageNum = null, string PageSize = null)
        {
            Property.AddOUTPUTParametr("@AllRow", true);
            if(!string.IsNullOrEmpty(FactorID))
                Property.AddParametr("@FactorID", FactorID, false);
            if (!string.IsNullOrEmpty(BeginPostDate))
                Property.AddParametr("@BeginPostDate", BeginPostDate, false);
            if (!string.IsNullOrEmpty(EndPostDate))
                Property.AddParametr("@EndPostDate", EndPostDate, false);
            if (!string.IsNullOrEmpty(BeginPayDate))
                Property.AddParametr("@BeginPayDate", BeginPayDate, false);
            if (!string.IsNullOrEmpty(BasketStatusID))
                Property.AddParametr("@BasketStatusID", BasketStatusID, false);
            if (!string.IsNullOrEmpty(UserName))
                Property.AddParametr("@UserName", UserName, false);
            if (!string.IsNullOrEmpty(GiftName))
                Property.AddParametr("@GiftName", GiftName, false);
            if (!string.IsNullOrEmpty(BeginPriceRange))
                Property.AddParametr("@BeginPriceRange", BeginPriceRange, false);
            if (!string.IsNullOrEmpty(EndPriceRange))
                Property.AddParametr("@EndPriceRange", EndPriceRange, false);
            if (!string.IsNullOrEmpty(PageNum))
                Property.AddParametr("@PageNum", PageNum, false);
            if (!string.IsNullOrEmpty(PageSize))
                Property.AddParametr("@PageSize", PageSize, false);
            
            AllRow = 0;
            using (DataTable dt = DataFetch.ExecuteSPrDT_SaveParams("GetAllBasket"))
            {
                if (!string.IsNullOrEmpty(Property.myCmd.Parameters["@AllRow"].Value.ToString()))
                    AllRow = int.Parse(Property.myCmd.Parameters["@AllRow"].Value.ToString());
                return dt;
            }
        }

        public static DataTable GetAllFiche(out int AllRow, string FicheType = null, string FactorID = null, string Serial = null, string BeginPayDate = null, string EndPayDate = null,
    string BeginSummaRange = null, string EndSummaRange = null, string AccountNo = null, string FullName = null, string PageNum = null, string PageSize = null)
        {
            Property.AddOUTPUTParametr("@AllRow", true);
            if (!string.IsNullOrEmpty(FicheType))
                Property.AddParametr("@FicheType", FicheType, false);
            if (!string.IsNullOrEmpty(FactorID))
                Property.AddParametr("@FactorID", FactorID, false);
            if (!string.IsNullOrEmpty(Serial))
                Property.AddParametr("@Serial", Serial, false);
            if (!string.IsNullOrEmpty(BeginPayDate))
                Property.AddParametr("@BeginPayDate", BeginPayDate, false);
            if (!string.IsNullOrEmpty(EndPayDate))
                Property.AddParametr("@EndPayDate", EndPayDate, false);
            if (!string.IsNullOrEmpty(BeginSummaRange))
                Property.AddParametr("@BeginSummaRange", BeginSummaRange, false);
            if (!string.IsNullOrEmpty(EndSummaRange))
                Property.AddParametr("@EndSummaRange", EndSummaRange, false);
            if (!string.IsNullOrEmpty(AccountNo))
                Property.AddParametr("@AccountNo", AccountNo, false);
            if (!string.IsNullOrEmpty(FullName))
                Property.AddParametr("@FullName", FullName, false);
            if (!string.IsNullOrEmpty(PageNum))
                Property.AddParametr("@PageNum", PageNum, false);
            if (!string.IsNullOrEmpty(PageSize))
                Property.AddParametr("@PageSize", PageSize, false);

            AllRow = 0;
            using (DataTable dt = DataFetch.ExecuteSPrDT_SaveParams("GetAllFiche"))
            {
                if (!string.IsNullOrEmpty(Property.myCmd.Parameters["@AllRow"].Value.ToString()))
                    AllRow = int.Parse(Property.myCmd.Parameters["@AllRow"].Value.ToString());
                return dt;
            }
        }
    }

}
