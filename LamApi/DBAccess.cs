/* *******************************************************************************************
 * 
 * File: DBAccess.cs
 * 
 * Description: Database tool for Microsoft Access database
 * 
 * Reference: na
 * 
 * Author: S. Lam
 *          ABC Inc.
 *          
 * *******************************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace LamApi
{
    public static class DBAccess
    {
        private static String CONN_DB = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Projects\exer\VS2010\LamApi\MyLabDatabase.accdb;" +
                "Persist Security Info=False";
        private static OleDbConnection conn = null;


        /// <summary>
        /// Open database
        /// </summary>
        private static void OpenDb()
        {
            try
            {
                conn = new OleDbConnection(CONN_DB);
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
            return(PerformNonQuery(command));
        } // end PerformInsert



        /// <summary>
        /// Perform update statement to database
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static bool PerformUpdate(String command)
        {
            return(PerformNonQuery(command));
        } // end PerformUpdate


        /// <summary>
        /// Perform delete statement in database
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static bool PerformDelete(String command)
        {
            return(PerformNonQuery(command));
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
                OleDbCommand cmd = conn.CreateCommand();
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
                OleDbCommand cmd = new OleDbCommand();
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
        public static List<string> FetchListQuery(String command)
        {
            OleDbDataReader dataReader = null;
            List<string> result = new List<string>();
            try
            {
                OpenDb();
                OleDbCommand cmd = new OleDbCommand();
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
                Console.WriteLine("Error: performListQuery " + command + "; " + ex.Message);
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
        public static DataTable FetchTableQuery(String command)
        {
            DataTable result = new DataTable();
            OleDbDataAdapter adapter = FetchDataAdapterQuery(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            result = dataSet.Tables[0];
            string[,] strs = FetchTableData(result);
            return (result);
        } // end FetchTableQuery

        /// <summary>
        /// Get table heading from Table data dictionary
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static List<string> FetchTableHeading(Dictionary<string, string[]> tableDictionary)
        {
            List<string> result = new List<string>();
            foreach (string key in tableDictionary.Keys)
            {
                result.Add(key);
            }
            return (result);
        } // end FetchTableHeading


        /// <summary>
        /// Get table data from Table data dictionary
        /// </summary>
        /// <param name="tableDictionary"></param>
        /// <returns></returns>
        public static string[,] FetchTableData(DataTable table)
        {
            List<string> heading = new List<string>();
            List<string> data = new List<string>();

            // get all data
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    if (i == 0)
                    {
                        heading.Add(table.Columns[j].ColumnName.ToString());
                    }
                    data.Add(row[j].ToString());
                }
            }
            

            int numColumns = heading.Count;
            int numRows = data.Count / numColumns;
            string[,] result = new string[numRows+1, numColumns];
            for (int i = 0; i < numColumns; i++)
            {
                result[0, i] = heading[i];
            }
            for (int i = 0; i < data.Count; i++)
            {
                result[i / numColumns+1,i % numColumns] = data[i];
            }

            return (result);
        }

        /// <summary>
        /// Perform query of database and return a DataAdapter
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static OleDbDataAdapter FetchDataAdapterQuery(String command)
        {
            OleDbDataAdapter result = null;
            
            try
            {
                OpenDb();
                result = new OleDbDataAdapter(command, conn);

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

    } // end class DbAccess

    
}
