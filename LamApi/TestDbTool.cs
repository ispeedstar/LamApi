using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using MySql.Data.MySqlClient;

namespace LamApi
{
    /// <summary>
    /// Class to perform various database command test
    /// </summary>
    public class TestDbTool
    {
        public void TestDbConnection()
        {
            DbTool.TestConnection();
        }

        public bool TestPerformInsert()
        {
            bool result = false;
            String command = "INSERT INTO `salesrep` (Srepno,Srepname,Srepstreet,Srepcity,Srepprov,Sreppcode,Totcomm,Commrate) VALUES('STL','Stanley Lam', '1187 Gatewood', 'London', 'ON', 'A1B2C3',99.9,9.9)";
            result = DbTool.PerformInsert(command);
            return (result);
        }


        public bool TestPerformUpdate()
        {
            bool result = false;
            String command = "UPDATE `salesrep` SET Srepprov='BC' WHERE Srepno='STL'";
            result = DbTool.PerformUpdate(command);
            return (result);
        }

        public bool TestPerformDelete()
        {
            bool result = false;
            string command = "DELETE FROM `salesrep` WHERE Srepno='STL'";
            result = DbTool.PerformDelete(command);
            return (result);
        }
        public bool TestFetchScalarQuery()
        {
            bool result = false;
            string command = "SELECT Srepname FROM `salesrep` WHERE Srepname='John Doe'";
            string data = DbTool.FetchScalarQuery(command);
            result = true;
            return (result);
        }

        public bool TestFetchRowQuery()
        {
            bool result = false;
            string command = "SELECT Srepname FROM `salesrep`";
            ArrayList data = DbTool.FetchRowQuery(command);
            result = true;
            return (result);
        }

        public bool TestFetchDictionaryQuery()
        {
            bool result = false;
            string command = "SELECT * FROM `salesrep`";
            Dictionary<string, string[]> data = DbTool.FetchTableQuery(command);
            result = true;
            return (result);
        }

        public bool TestFetchDataSetQuery()
        {
            bool result = false;
            string command = "SELECT * FROM `salesrep`";
            MySqlDataAdapter dataSet = DbTool.FetchDataAdapterQuery(command);
            result = true;
            return (result);
        }

        public bool TestAll()
        {
            bool result = false;
            TestDbConnection();
            TestPerformInsert();
            TestPerformUpdate();
            TestPerformDelete();
            TestFetchScalarQuery();
            TestFetchRowQuery();
            TestFetchDictionaryQuery();
            TestFetchDataSetQuery();
            result = true;
            return (result);
        }

    } // end class TestDbTool
}
