using System;
using System.Data;
using System.Data.SqlClient;

namespace HProtest_DAL
{
    public class DataFetch
    {
        public static int ExecuteNonSP(string SPName,out bool Successed)
        {
            Property.myCmd.Connection = Property.Connection;
            Property.myCmd.CommandText = SPName;
            Property.myCmd.CommandType = CommandType.StoredProcedure;

            try
            {
                if (Property.myCmd.Connection.State != ConnectionState.Open)
                    Property.myCmd.Connection.Open();

                int affecteRows = Property.myCmd.ExecuteNonQuery();
                Successed = true;
                return affecteRows;
            }
            catch (Exception ex)
            {
                Successed = false;

                return 0;
            }
            finally
            {
                if (Property.myCmd.Connection.State == ConnectionState.Open)
                    Property.myCmd.Connection.Close();

                Property.myCmd.Parameters.Clear();
            }

        }

        public static DataTable ExecuteSPrDT(string SpName)
        {
            Property.myCmd.Connection = Property.Connection;
            Property.myCmd.CommandType = CommandType.StoredProcedure;
            Property.myCmd.CommandText = SpName;

            using (SqlDataAdapter sda = new SqlDataAdapter(Property.myCmd))
            {
                DataTable dt = new DataTable();
                try
                {
                    sda.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    return null;
                }
                finally
                {
                    if (Property.myCmd.Connection.State == ConnectionState.Open)
                        Property.myCmd.Connection.Close();

                    dt.Dispose();

                    Property.myCmd.Parameters.Clear();
                }
            }
        }

        public static DataRow ExecuteSPrDR(string SpName)
        {
            Property.myCmd.Connection = Property.Connection;
            Property.myCmd.CommandType = CommandType.StoredProcedure;
            Property.myCmd.CommandText = SpName;

            using (SqlDataAdapter sda = new SqlDataAdapter(Property.myCmd))
            {
                DataTable dt = new DataTable();
                try
                {
                    sda.Fill(dt);
                    return dt.Rows[0];
                }
                catch (Exception ex)
                {
                    return null;
                }
                finally
                {
                    if (Property.myCmd.Connection.State == ConnectionState.Open)
                        Property.myCmd.Connection.Close();

                    dt.Dispose();

                    Property.myCmd.Parameters.Clear();
                }
            }
        }

        public static DataTable ExecuteSPrDT_SaveParams(string SpName)
        {
            Property.myCmd.Connection = Property.Connection;
            Property.myCmd.CommandType = CommandType.StoredProcedure;
            Property.myCmd.CommandText = SpName;

            using (SqlDataAdapter sda = new SqlDataAdapter(Property.myCmd))
            {
                DataTable dt = new DataTable();
                try
                {
                    sda.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    return null;
                }
                finally
                {
                    if (Property.myCmd.Connection.State == ConnectionState.Open)
                        Property.myCmd.Connection.Close();

                    dt.Dispose();
                }
            }
        }
        //++++//
        public static DataRow ExecuteSPrDR_SaveParams(string SpName)
        {
            Property.myCmd.Connection = Property.Connection;
            Property.myCmd.CommandType = CommandType.StoredProcedure;
            Property.myCmd.CommandText = SpName;

            using (SqlDataAdapter sda = new SqlDataAdapter(Property.myCmd))
            {
                DataTable dt = new DataTable();
                try
                {
                    sda.Fill(dt);
                    return dt.Rows[0];
                }
                catch (Exception ex)
                {
                    return null;
                }
                finally
                {
                    if (Property.myCmd.Connection.State == ConnectionState.Open)
                        Property.myCmd.Connection.Close();

                    dt.Dispose();
                }
            }
        }

        //++++//
        public static DataTable GetDTByCMD(string sqlText)
        {
            DataTable dt = new DataTable();

            Property.myCmd.Connection = Property.Connection;
            Property.myCmd.CommandText = sqlText;
            Property.myCmd.CommandType = CommandType.Text;


            using (SqlDataAdapter sda = new SqlDataAdapter(Property.myCmd))
            {
                try
                {
                    sda.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    return null;
                }
                finally
                {
                    if (Property.myCmd.Connection.State == ConnectionState.Open)
                        Property.myCmd.Connection.Close();

                    sda.Dispose();
                    dt.Dispose();

                    Property.myCmd.Parameters.Clear();
                }
            }
        }
        public static DataSet ExecuteSPrDS_SaveParams(string SpName)
        {
            Property.myCmd.Connection = Property.Connection;
            Property.myCmd.CommandType = CommandType.StoredProcedure;
            Property.myCmd.CommandText = SpName;

            using (SqlDataAdapter sda = new SqlDataAdapter(Property.myCmd))
            {
                DataSet ds = new DataSet();
                try
                {
                    sda.Fill(ds);
                    return ds;
                }
                catch (Exception ex)
                {
                    return null;
                }
                finally
                {
                    if (Property.myCmd.Connection.State == ConnectionState.Open)
                        Property.myCmd.Connection.Close();

                    ds.Dispose();
                }
            }
        }
    }
}
