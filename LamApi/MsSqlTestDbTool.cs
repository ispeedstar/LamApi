using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;

namespace LamApi
{
    public class MsSqlTestDbTool
    {
        public void TestDbConnection()
        {
            MsSqlDbTool.TestConnection();
        }

        public bool TestPerformInsert()
        {
            bool result = false;
            String command = "INSERT INTO salesrep (Srepno,Srepname,Srepstreet,Srepcity,Srepprov,Sreppcode,Totcomm,Commrate) VALUES('STL','Stanley Lam', '1187 Gatewood', 'London', 'ON', 'A1B2C3',99.9,9.9)";
            result = MsSqlDbTool.PerformInsert(command);
            return (result);
        }


        public bool TestPerformUpdate()
        {
            bool result = false;
            String command = "UPDATE salesrep SET Srepprov='BC' WHERE Srepno='STL'";
            result = MsSqlDbTool.PerformUpdate(command);
            return (result);
        }

        public bool TestPerformDelete()
        {
            bool result = false;
            string command = "DELETE FROM salesrep WHERE Srepno='STL'";
            result = MsSqlDbTool.PerformDelete(command);
            return (result);
        }
        public bool TestFetchScalarQuery()
        {
            bool result = false;
            string command = "SELECT Srepname FROM salesrep WHERE Srepname='John Doe'";
            string data = MsSqlDbTool.FetchScalarQuery(command);
            result = true;
            return (result);
        }

        public bool TestFetchRowQuery()
        {
            bool result = false;
            string command = "SELECT Srepname FROM salesrep";
            ArrayList data = MsSqlDbTool.FetchRowQuery(command);
            result = true;
            return (result);
        }

        public bool TestFetchDictionaryQuery()
        {
            bool result = false;
            string command = "SELECT * FROM salesrep";
            Dictionary<string, string[]> data = MsSqlDbTool.FetchTableQuery(command);
            result = true;
            return (result);
        }

        public bool TestFetchDataSetQuery()
        {
            bool result = false;
            string command = "SELECT * FROM salesrep";
            SqlDataAdapter dataSet = MsSqlDbTool.FetchDataAdapterQuery(command);
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
    } // end MsSqlTestDbTool
}
