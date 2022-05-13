using System;
using System.Data;
using System.Collections.Generic;
using HProtest_DAL;
using HProtest_BLL;

namespace ShayanDB_BLL
{
    public class GetData
    {
        public static DataTable GetTable(string TableName)
        {
            return DataFetch.GetDTByCMD("select * from " + TableName);
        }

        public static DataTable ExecuteCMD(string CMD)
        {
            Property Property = new Property();
            Property.myCmd.Parameters.Clear();
            return DataFetch.GetDTByCMD(CMD);
        }

        public static DataTable ExecuteSPrDT(string SPName, List<string> Params, List<object> Valuse)
        {
            Property Property = new Property();
            try
            {
                if (Params != null && Valuse != null)
                {
                    if (Params.Count > 0 && Valuse.Count > 0) Property.AddParametr(Params[0], Valuse[0], true);//.GetType() == typeof(int) ? Valuse[0] : Valuse[0].ToString()

                    for (int i = 1; i < Params.Count; i++)
                    {
                        Property.AddParametr(Params[i], Valuse[i].GetType() == typeof(int) ? Valuse[i] : Valuse[i].ToString(), false);
                    }
                }


                return DataFetch.ExecuteSPrDT(SPName);
            }
            catch
            {
                return null;
            }
        }

        //public static DataTable GetTable(string TableName)
        //{
        //    Property Property = new Bime1ir_DAL.Property();
        //    return DataFetch.GetDTByCMD(Property.myCmd,"select * from " + TableName);
        //}

        //public static System.Collections.ArrayList GetConfig(List<PropertyData.ConfigType> ConfigType)
        //{
        //    System.Collections.ArrayList ResultType = new System.Collections.ArrayList();

        //    using (DataTable dtResult = GetTable("tbConfig"))
        //    {
        //        if (dtResult != null && dtResult.Rows.Count > 0)
        //        {
        //            foreach (PropertyData.ConfigType item in ConfigType)
        //                ResultType.Add(dtResult.Rows[0][item.ToString()].ToString().Trim());

        //            return ResultType;
        //        }
        //        else
        //            return null;
        //    }
        //}

        //public static string GetOutputParamValue(string name)
        //{
        //    return Property.myCmd.Parameters[name].Value.ToString();
        //}

        public static void RemoveAddedParams()
        {
            Property.myCmd.Parameters.Clear();
        }
    }
}
