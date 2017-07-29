using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Collections;
using System.IO;



namespace LamApi
{
    class Program
    {
        static void Main(string[] args)
        {


            DateTime t = new DateTime(2016, 01, 29);
            string str = t.ToShortDateString();

            TestDbAccess testDbAccess = new TestDbAccess();
            testDbAccess.TestAll();

            /*
            ComplexNumber.DoTest();

            CException ex;
            ex = new CException();
            ex.DoException();
            */
            /*
            CException ex = new CException();
            ex.DoException();
            */

            /*
            CThread t = new CThread();
            t.doThread();
             */


            //TextIO textIO = new TextIO();
            //textIO.InputFilename = @"C:\Projects\exer\VS2010\Data\userInfo.txt";
            //textIO.OutputFilename = @"C:\Projects\exer\VS2010\Data\userInfo.out";
            //textIO.ReadFile();
            //textIO.WriteFile();


            //XmlIO xmlIO = new XmlIO();
            //xmlIO.InputFilename = @"C:\Projects\exer\VS2010\Data\userInfo.xml";
            //xmlIO.OutputFilename = @"C:\Projects\exer\VS2010\Data\userInfoOut.xml";
            //xmlIO.ReadFile();
            //xmlIO.WriteFile();
            ////xmlIO.TextReadFile();
            ////xmlIO.textWriteFile();
            //xmlIO.NavXPath();


            //string[] testKeys;
            //string[] testValues;
            //InitializeTestListBox(out testKeys, out testValues);

            //RunTest(textIO, xmlIO, testKeys, testValues);
        } // end Main

        

        private static void RunTest(TextIO textIO, XmlIO xmlIO, string[] testKeys, string[] testValues)
        {
            Dialog.MultiListSelectForm dlg = new Dialog.MultiListSelectForm("Select a test", testValues);
            int[] selectedItems = dlg.selectedItems;

            if (selectedItems != null)
            {
                for (int i = 0; i < selectedItems.Length; i++)
                {
                    switch (testKeys[selectedItems[i]])
                    {
                        case "ReadText":
                            textIO.ReadFile();
                            break;
                        case "WriteText":
                            textIO.WriteFile();
                            break;
                        case "ReadXml":
                            xmlIO.ReadFile();
                            break;
                        case "WriteXml":
                            xmlIO.WriteFile();
                            break;
                        case "TestDb":
                            TestDbTool testDb = new TestDbTool();
                            testDb.TestAll();
                            break;
                        default:
                            break;
                    }
                }
            }
        } // end  RunTest

        private static void InitializeTestListBox(out string[] testKeys, out string[] testValues)
        {
            // Initialize test list box
            Dictionary<string, string> testDict = new Dictionary<string, string>();
            testDict["ReadText"] = "Read text file";
            testDict["WriteText"] = "Write text file";
            testDict["ReadXml"] = "Read XML file";
            testDict["WriteXml"] = "Write XML file";
            testDict["TestDb"] = "Test dbTool";

            testKeys = new string[testDict.Count];
            testValues = new string[testDict.Count];
            int testCount = 0;
            foreach (KeyValuePair<string, string> kvp in testDict)
            {
                testKeys[testCount] = kvp.Key.ToString();
                testValues[testCount] = kvp.Value.ToString();
                testCount++;
            }
        } // end InitializeTestListBox

    } // end class Program
}
