using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HProtest_DAL;
using System.Data;
namespace HProtest_BLL.Manager
{
    public class ManagerData
    {

        public static DataTable GetProductInfo(int ProductTypeID, bool Call)
        {
            Property.AddParametr("@ProductTypeID", ProductTypeID, false);

            return DataFetch.ExecuteSPrDT("GetProductInfo");
        }

        public static DataTable GetProductInfo(int ID = 0, string UserName = "", string Name = "", int ProductTypeID = 0, string AboutProduct = "", string Desp = "", string IsSearchDate = "none", object BeginInsertDateRange = null, object EndInsertDateRange = null,
            int Luxe = -1, int Size = -1, string IsPriceRange = "none", int BeginPriceRange = 0, int EndPriceRange = 0, string IsPointRange = "none", float BeginPointRange = 0, float EndPointRange = 5, float EqulPointRange = 0, string sortDir = "desc", string sortExpression = "tbl_product.id", int pageindex = 0, int pagesize = 10,int Visible=-1,string IsGiftRange="none",int minLimit=0,int maxLimit=999999)
        {
            Property.AddParametr("@ID", ID, true);
            Property.AddParametr("@UserName", UserName, false);
            Property.AddParametr("@Name", Name, false);
            Property.AddParametr("@ProductTypeID", ProductTypeID, false);
            Property.AddParametr("@AboutProduct", AboutProduct, false);
            Property.AddParametr("@Desp", Desp, false);
            Property.AddParametr("@IsSearchDate", IsSearchDate, false);
            Property.AddParametr("@BeginInsertDateRange", BeginInsertDateRange, false);
            Property.AddParametr("@EndInsertDateRange", EndInsertDateRange, false);
            Property.AddParametr("@Luxe", Luxe, false);
            Property.AddParametr("@Size", Size, false);
            Property.AddParametr("@IsPriceRange", IsPriceRange, false);
            Property.AddParametr("@BeginPriceRange", BeginPriceRange, false);
            Property.AddParametr("@EndPriceRange", EndPriceRange, false);
            Property.AddParametr("@IsPointRange", IsPointRange, false);
            Property.AddParametr("@BeginPointRange", BeginPointRange, false);
            Property.AddParametr("@EndPointRange", EndPointRange, false);
            Property.AddParametr("@EqualPointRange", EqulPointRange, false);

            Property.AddParametr("@IsGiftRange", IsGiftRange, false);
            Property.AddParametr("@BeginGiftRange", minLimit, false);
            Property.AddParametr("@EndGiftRange", maxLimit, false);


            Property.AddParametr("@sortExpression", sortExpression, false);
            Property.AddParametr("@sortDir", sortDir, false);
            Property.AddParametr("@Visible", Visible, false);

            Property.AddParametr("@startRowIndex", pageindex, false);
            Property.AddParametr("@maximumRows", pagesize, false);
            Property.AddOUTPUTParametr("@AllCurrentCount", false);

            return DataFetch.ExecuteSPrDT_SaveParams("GetProductInfo");
        }

        public static DataTable GetProductInfo(string id)
        {
            Property.AddParametr("@id", id, true);

            return DataFetch.ExecuteSPrDT("GetProductInfo");
        }
        public static void DeleteProduct(int id)
        {
            Property.AddParametr("@id", id, true);
            DataFetch.ExecuteSPrDR("DeleteProduct");

        }
        public static void DeleteProductPic(int id)
        {
            Property.AddParametr("@id", id, true);
            DataFetch.ExecuteSPrDR("DeleteProductPic");

        }

        public static string AddProduct(string userName,string name, string desp, string AboutProduct, string Video, string MainPic, string ImgType, string VideoType, bool size, bool luxe, int price,string ProductTypeID,bool visible,int ProductCount, bool gift, int from, int to)
        {
            Property.AddParametr("@userName", userName, true);
            Property.AddParametr("@name", name, false);
            Property.AddParametr("@desp", desp, false);
            Property.AddParametr("@aboutproduct", AboutProduct, false);
            Property.AddParametr("@video", Video, false);
            Property.AddParametr("@mainpic", MainPic, false);
            Property.AddParametr("@imgtype", ImgType, false);
            Property.AddParametr("@videotype", VideoType, false);
            Property.AddParametr("@size", Convert.ToBoolean(size), false);
            Property.AddParametr("@luxe", Convert.ToBoolean(luxe), false);

            Property.AddParametr("@price", price, false);
            Property.AddParametr("@ProductTypeID", ProductTypeID, false);
            Property.AddParametr("@visible", visible, false);
            Property.AddParametr("@productcount", ProductCount, false);
            Property.AddParametr("@gift", gift, false);
            Property.AddParametr("@from", from, false);
            Property.AddParametr("@to", to, false);
            Property.AddOUTPUTParametr("@ProductID", false);

            DataFetch.ExecuteSPrDS_SaveParams("AddProduct");
            return Property.myCmd.Parameters["@ProductID"].Value.ToString();
        }

       


         
        public static void UpdateProduct(string ProductID, string name, string desp, string AboutProduct, string Video, string MainPic, string ImgType,
            string VideoType, bool size, bool luxe, int price, string ProductTypeID, string point, string visited, string count, bool visible, int ProductCount, bool gift, int from, int to)
        {
            Property.AddParametr("@name", name, true);
            Property.AddParametr("@id", ProductID, false);
            Property.AddParametr("@desp", desp, false);
            Property.AddParametr("@aboutproduct", AboutProduct, false);
            Property.AddParametr("@video", Video, false);
            Property.AddParametr("@mainpic", MainPic, false);
            Property.AddParametr("@imgtype", ImgType, false);
            Property.AddParametr("@videotype", VideoType, false);
            Property.AddParametr("@size", Convert.ToBoolean(size), false);
            Property.AddParametr("@luxe", Convert.ToBoolean(luxe), false);
            Property.AddParametr("@point", point, false);
            Property.AddParametr("@visited",visited, false);
            Property.AddParametr("@count", count, false);
            Property.AddParametr("@price", price, false);
            Property.AddParametr("@visible", visible, false);
            Property.AddParametr("@productcount", ProductCount, false);
            Property.AddParametr("@gift", gift, false);
            Property.AddParametr("@from", from, false);
            Property.AddParametr("@to", to, false);
            Property.AddParametr("@ProductTypeID", ProductTypeID, false);

            DataFetch.ExecuteSPrDT("UpdateProduct");
        }


        public static DataTable GetProductInfo(int ProductTypeID, string sortDir = "desc", string sortExpression = "tbl_product.id", int pageindex = 0, int pagesize = 10, int Visible = -1)
        {
            Property.AddParametr("@ProductTypeID", ProductTypeID, true);
            Property.AddParametr("@sortExpression", sortExpression, false);
            Property.AddParametr("@sortDir", sortDir, false);
            Property.AddParametr("@Visible", Visible, false);

            Property.AddParametr("@startRowIndex", pageindex, false);
            Property.AddParametr("@maximumRows", pagesize, false);
            Property.AddOUTPUTParametr("@AllCurrentCount", false);
            return DataFetch.ExecuteSPrDT_SaveParams("GetProductInfo");
        }


        public static bool InsertProductPic(string Pic)
        {
            Property.AddParametr("@Pic", Pic, true);
            DataFetch.ExecuteSPrDS_SaveParams("InsertProductPic");
            return true;
        }

        public static bool InsertMenu(string Type, bool Visible, int ParentId = 0)
        {

            Property.AddParametr("@type", Type, true);
            Property.AddParametr("@Visible", Visible, false);
            Property.AddParametr("@parentid", ParentId, false);

            bool Successed;
             DataFetch.ExecuteNonSP("InsertMenu",out Successed);
             return Successed;
        }
        public static DataTable GetMenu(int MenuType = 0, int visible = -1)
        {
            //0---->sar menu ha
            //1---->submenu ha
            Property.AddParametr("@MenuType", MenuType, true);
            Property.AddParametr("@visible", 1, false);
            return DataFetch.ExecuteSPrDT("GetMenu");
        }

        //public static bool InsertNewsStatus(string Type)
        //{
        //    Property.AddParametr("@type", Type, true);
        //    bool Successed;
        //    DataFetch.ExecuteNonSP("InsertNewsType",out Successed);
        //    return Successed;
        //}



        public static DataTable GetMenuList(string Type="-1",string MenuType="0")
        {
            //"-1"      "0"  tamame sar menu hara barmigardanad
            Property.AddParametr("@Type", Type, true);
            Property.AddParametr("@MenuType", MenuType, false);
            return DataFetch.ExecuteSPrDT("GetMenuList");
        }

        public static string AddPics(int ProductID, string ImgType)
        {
            Property.AddParametr("@ProductID", ProductID, true);
            Property.AddParametr("@imgtype", ImgType, false);
            Property.AddOUTPUTParametr("@ProductPicID", false);

            DataFetch.ExecuteSPrDS_SaveParams("AddPics");
            return Property.myCmd.Parameters["@ProductPicID"].Value.ToString();
        }


        public static bool DeleteMenu(int ID)
        {
            Property.AddParametr("@ID", ID, true);
            bool Successed;
            DataFetch.ExecuteNonSP("DeleteMenu", out Successed);
            return Successed;
        }

        public static bool EditMenu(int ID, string Type, bool Visible, int Parent = 0)
        {
            Property.AddParametr("@ID", ID, true);
            Property.AddParametr("@Type", Type, false);
            Property.AddParametr("@Visible", Visible, false);
            if(Parent==0)
            Property.AddParametr("@ParentID", null, false);
            else
                Property.AddParametr("@ParentID", Parent, false);

            bool Successed;
            DataFetch.ExecuteNonSP("EditMenu", out Successed);
            return Successed;

        }

        public static DataTable GetMenuByParent(int id = 0)
        {
            Property.AddParametr("@id", id, true);
            return DataFetch.ExecuteSPrDT("GetMenuByParent");
        }


        
    }
}
