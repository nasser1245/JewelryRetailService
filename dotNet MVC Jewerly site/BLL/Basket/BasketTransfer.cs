using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HProtest_DAL;
using System.Data;

namespace HProtest_BLL.Basket
{
    public class BasketTransfer
    {


        public static bool UpdateBasketProductCount(string BasketProductID, string Description = "")
        {
            Property.AddParametr("@BasketProductCountList", BasketProductID, true);
            Property.AddParametr("@Description", Description, false);
            bool Successed;
            DataFetch.ExecuteNonSP("UpdateBasketProductCount", out Successed);
            return Successed;

        }

        public static bool UpdateBasketStatus(int BasketID, int BasketStatusID)
        {
            Property.AddParametr("@BasketID", BasketID, true);
            Property.AddParametr("@BasketStatusID", BasketStatusID, false);
            bool Successed;
            DataFetch.ExecuteNonSP("UpdateBasketStatus", out Successed);
            return Successed;

        }

        public static DataSet UpdatePrice(string BasketProductCountList, int BasketID)
        {
            Property.AddParametr("@BasketProductCountList", BasketProductCountList, true);
            Property.AddParametr("@BasketID", BasketID, true);
            using (DataSet ds = DataFetch.ExecuteSPrDS_SaveParams("CalculateSum"))
            {
                return ds;
            }

        }

        public static string InsertBasketProduct(string MemberUserName, int ProductID)
        {

            Property.AddParametr("@MemberUserName", MemberUserName, true);
            Property.AddParametr("@ProductID", ProductID, false);
            DataRow dr = DataFetch.ExecuteSPrDR("InsertBasketProduct");
            if(dr!= null)
                return dr["Count"].ToString();
            return "-1";
        }

        public static bool InsertFiche(string UserName,int Summa, string Serial, string AccountNo, string FullName, DateTime PayDate, string FicheType, string Description)
        {
            Property.AddParametr("@UserName", UserName, true);
            Property.AddParametr("@Summa", Summa, false);
            Property.AddParametr("@Serial", Serial, false);
            Property.AddParametr("@AccountNo", AccountNo, false);
            Property.AddParametr("@FullName", FullName, false);
            Property.AddParametr("@PayDate", PayDate, false);
            Property.AddParametr("@Description", Description, false);
            Property.AddParametr("@FicheType", FicheType, false);
            bool Successed;
            DataFetch.ExecuteNonSP("InsertFiche", out Successed);
            return Successed;
        }

        public static string DeleteBasketProduct(int Id)
        {
            Property.AddParametr("@Id", Id, true);
            DataRow dr = DataFetch.ExecuteSPrDR("DeleteBasketProduct");
            if(dr != null)
                return dr["Count"].ToString();
            return "-1";
        }

        public static bool SelectGift(string BasketID, int GiftID= 0)
        {
            Property.AddParametr("@BasketID", BasketID, true);
            if(GiftID != 0)
                Property.AddParametr("GiftID", GiftID, false);
            bool Successed;
            DataFetch.ExecuteNonSP("SelectGift", out Successed);
            return Successed;
        }
    }

}
