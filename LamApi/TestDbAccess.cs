using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace LamApi
{
    class TestDbAccess
    {
        public void TestDbConnection()
        {
            DBAccess.TestConnection();
        }

        public bool TestPerformInsert()
        {
            bool result = false;
            
            //String command = "INSERT INTO MyTests (ID,Device,DateTime,TestName,TestResult) VALUES(3,'3','16/12/2014 12:00:00 AM','VerifyComm','PASS')";
            String command = "INSERT INTO MyTests (ID,Device,TestName,TestResult) VALUES(3,'3','VerifyComm','PASS')";
            
            
            result = DBAccess.PerformInsert(command);
            return (result);
        }


        public bool TestPerformUpdate()
        {
            bool result = false;
            String command = "UPDATE MyTests SET TestResult='' WHERE TestName='VerifyComm'";
            result = DBAccess.PerformUpdate(command);
            return (result);
        }

        public bool TestPerformDelete()
        {
            bool result = false;
            string command = "DELETE FROM MyTests WHERE TestName='VerifyComm'";
            result = DBAccess.PerformDelete(command);
            return (result);
        }
        public bool TestFetchScalarQuery()
        {
            bool result = false;
            string command = "SELECT TestResult FROM `MyTests` WHERE TestName='SetDevice'";
            string data = DBAccess.FetchScalarQuery(command);
            result = true;
            return (result);
        }

        public bool TestFetchColumnQuery()
        {
            bool result = false;
            string command = "SELECT TestName FROM `MyTests`";
            List<string> data = DBAccess.FetchListQuery(command);
            
            result = true;
            return (result);
        }

        public bool TestFetchTableQuery()
        {
            bool result = false;
            string command = "SELECT * FROM `MyTests`";
            DataTable data = DBAccess.FetchTableQuery(command);
            result = true;
            return (result);
        }

        public bool TestFetchDataSetQuery()
        {
            bool result = false;
            string command = "SELECT * FROM `MyTests`";
            OleDbDataAdapter dataSet = DBAccess.FetchDataAdapterQuery(command);
            result = true;
            return (result);
        }

        public bool TestAll()
        {
            bool result = false;
            TestDbConnection();
            TestPerformInsert();
            TestPerformUpdate();
            //TestPerformDelete();
            TestFetchScalarQuery();
            TestFetchColumnQuery();
            TestFetchTableQuery();
            //TestFetchDataSetQuery();
            result = true;
            return (result);
        }
    } // end class
}
