using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;

namespace LamApi
{
    public class MsSqlDbTool
    {
        private static String CONN_DB = @"Server=YEN-PC\SQLSLAM; Database=dry_run; Trusted_Connection=true";
        private static SqlConnection conn = null;


        /// <summary>
        /// Open database
        /// </summary>
        private static void OpenDb()
        {
            try
            {
                conn = new SqlConnection(CONN_DB);
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: unable to open database " + ex.Message);
            }
        } // end OpenDb


        /// <summary>
        /// Close database
        /// </summary>
        private static void CloseDb()
        {
            if (conn != null)
            {
                conn.Close();
            }
        } // end CloseDb


        /// <summary>
        /// Test database connection
        /// </summary>
        /// <returns></returns>
        public static bool TestConnection()
        {
            bool result = false;
            try
            {
                OpenDb();
                System.Threading.Thread.Sleep(1000);
                CloseDb();
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: unable to TestDbConnection " + ex.Message);
            }
            return (result);
        } // end TestConnection



        /// <summary>
        /// Perform insert statement to database
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static bool PerformInsert(String command)
        {
            return (PerformNonQuery(command));
        } // end PerformInsert



        /// <summary>
        /// Perform update statement to database
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static bool PerformUpdate(String command)
        {
            return (PerformNonQuery(command));
        } // end PerformUpdate


        /// <summary>
        /// Perform delete statement in database
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static bool PerformDelete(String command)
        {
            return (PerformNonQuery(command));
        } // end PerformDelete


        /// <summary>
        /// Perform database statement with no return value
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static bool PerformNonQuery(String command)
        {
            bool result = false;
            try
            {
                OpenDb();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = command;
                cmd.CommandTimeout = 30000;
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: performNonQuery " + ex.Message);
            }
            finally
            {
                CloseDb();
            }
            return (result);
        } // end PerformNonQuery


        /// <summary>
        /// Perform query of database and return a scalar
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static String FetchScalarQuery(String command)
        {
            string result;
            try
            {
                OpenDb();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = command;
                cmd.CommandTimeout = 30000;
                result = Convert.ToString(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: performScalarQuery " + command + "; " + ex.Message);
                result = "Error execute " + command;
            }
            finally
            {
                CloseDb();
            }
            return (result);
        } // end FetchScalarQuery


        /// <summary>
        /// Perform query of database and return data row or vector
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static ArrayList FetchRowQuery(String command)
        {
            SqlDataReader dataReader = null;
            ArrayList result = new ArrayList();
            try
            {
                OpenDb();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = command;
                cmd.CommandTimeout = 30000;
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    result.Add(dataReader.GetString(0));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: performScalarQuery " + command + "; " + ex.Message);
                result = null;
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                }


                CloseDb();
            }

            return (result);
        } // end FetchRowQuery



        /// <summary>
        /// Perform query of database and return a dictionary data table
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static Dictionary<String, String[]> FetchTableQuery(String command)
        {
            SqlDataReader dataReader = null;
            Dictionary<String, String[]> result = new Dictionary<String, String[]>();
            try
            {
                OpenDb();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = command;
                cmd.CommandTimeout = 30000;
                dataReader = cmd.ExecuteReader();

                // get number of table column
                int numColumns = dataReader.FieldCount;

                string[] dataHeaders = new string[numColumns];
                // get table headers
                for (int j = 0; j < numColumns; j++)
                {
                    dataHeaders[j] = dataReader.GetName(j);
                }

                // read table data into an array list 
                ArrayList dataList = new ArrayList();
                while (dataReader.Read())
                {
                    for (int j = 0; j < numColumns; j++)
                    {
                        dataList.Add(dataReader.GetString(j));
                    }
                }

                // get number of rows within table
                int numRows = dataList.Count / numColumns;

                // assign data into dictionary of header and data column
                for (int j = 0; j < numColumns; j++)
                {
                    string[] dataColumn = new string[numRows];
                    int curIdx = 0;
                    foreach (string dataField in dataList)
                    {
                        int remainder = (curIdx % numColumns);
                        if (remainder == j)
                        {
                            dataColumn[curIdx / numColumns] = dataField;
                        }
                        curIdx++;
                    }
                    result[dataHeaders[j]] = dataColumn;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: performScalarQuery " + command + "; " + ex.Message);
                result = null;
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                }
                CloseDb();
            }

            return (result);
        } // end FetchTableQuery


        /// <summary>
        /// Perform query of database and return a DataAdapter
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static SqlDataAdapter FetchDataAdapterQuery(String command)
        {
            SqlDataAdapter result = null;

            try
            {
                OpenDb();
                result = new SqlDataAdapter(command, conn);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: performScalarQuery " + command + "; " + ex.Message);
                result = null;
            }
            finally
            {
                CloseDb();
            }

            return (result);
        } // end FetchDataAdapterQuery
    } // end MsSqlDbTool
}
