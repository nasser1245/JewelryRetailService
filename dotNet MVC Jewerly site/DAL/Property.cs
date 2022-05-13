using System;
using System.Data.SqlClient;

namespace HProtest_DAL
{
    public  class Property
    {
        public static SqlConnection Connection
        {
            get
            {
                SqlConnection slC = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["LocalCnn"]);//HostCnn
                return slC;
            }
        }

        public static SqlCommand myCmd = new SqlCommand();

        public static void AddParametr(string name, object value, bool IsNewInstance)
        {
            if (IsNewInstance)
            {
                myCmd.Parameters.Clear();
            }
            myCmd.Parameters.AddWithValue(name, value);
        }

        public static void AddOUTPUTParametr(string name, System.Data.SqlDbType type, bool IsNewInstance)
        {
            if (IsNewInstance)
            {
                myCmd.Parameters.Clear();
            }

            myCmd.Parameters.Add(name, type).Direction = System.Data.ParameterDirection.Output;
        }
        public static void AddOUTPUTParametr(string name, System.Data.SqlDbType type,int size, bool IsNewInstance)
        {
            if (IsNewInstance)
            {
                myCmd.Parameters.Clear();
            }

            myCmd.Parameters.Add(name, type,size).Direction = System.Data.ParameterDirection.Output;
        }
        public static void AddOUTPUTParametr(string name, bool IsNewInstance)
        {
            if (IsNewInstance)
            {
                myCmd.Parameters.Clear();
            }

            myCmd.Parameters.Add(name, System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
        }
  
    }
}
