using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using MySql.Data.MySqlClient;

namespace LamApi.Dialogs
{
    public  class TestDbTool
    {
        public void testDbConnection()
        {
            DbTool.testConnection();    
        }

        public bool testPerformInsert()
        {
            bool result = false;
            string command = "INSERT INTO `salesrep` (Srepno,Srepname,Srepstreet,Srepcity,Srepprov,Sreppcode,Totcomm,Commrate) VALUES('STL','Stanley Lam', '1187 Gatewood', 'London', 'ON', 'A1B2C3',99.9,9.9)";
            result = DbTool.performInsert(command);
            return (result);
        }


        public bool testPerformUpdate()
        {
            bool result = false;
            string command = "UPDATE `salesrep` SET Srepprov='BC' WHERE Srepno='STL'";
            result = DbTool.performUpdate(command);
            return (result);
        }

        public bool testPerformDelete()
        {
            bool result = false;
            string command = "DELETE FROM `salesrep` WHERE Srepno='STL'";
            result = DbTool.performDelete(command);
            return (result);
        }
        public bool testFetchScalarQuery()
        {
            bool result = false;
            string command = "SELECT Srepname FROM `salesrep` WHERE Srepname='John Doe'";
            string data = DbTool.fetchScalarQuery(command);
            result = true;
            return (result);
        }

        public bool testFetchRowQuery()
        {
            bool result = false;
            string command = "SELECT Srepname FROM `salesrep`";
            ArrayList data = DbTool.fetchRowQuery(command);
            result = true;
            return (result);
        }

        public bool testFetchDictionaryQuery()
        {
            bool result = false;
            string command = "SELECT * FROM `salesrep`";
            Dictionary<string,string[]> data = DbTool.fetchDictionaryQuery(command);
            result = true;
            return (result);
        }

        public bool testFetchDataSetQuery()
        {
            bool result = false;
            string command = "SELECT * FROM `salesrep`";
            MySqlDataAdapter dataSet = DbTool.fetchDataSetQuery(command);
            result = true;
            return (result);
        }

        public bool testAll()
        {
            bool result = false;
            testDbConnection();
            testPerformInsert();
            testPerformUpdate();
            testPerformDelete();
            testFetchScalarQuery();
            testFetchRowQuery();
            testFetchDictionaryQuery();
            testFetchDataSetQuery();
            result = true;
            return (result);
        }
    }
}
