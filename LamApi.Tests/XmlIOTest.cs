using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;


namespace LamApi.Tests
{
    [TestFixture]
    public class XmlIOTest
    {
        private XmlIO xmlIO = null;

        [SetUp]
        public void Setup()
        {
            xmlIO = new XmlIO();
            xmlIO.InputFilename = @"C:\Projects\exer\VS2010\Data\userInfo.xml";
            xmlIO.OutputFilename = @"C:\Projects\exer\VS2010\Data\userInfoOut.xml";
        }


        [Test]
        public void readFile_valid_returnTrue()
        {
            bool result = xmlIO.readFile();
            Assert.IsTrue(result, "Unable to readFile " + xmlIO.InputFilename);
        }

        [Test]
        public void writeFile_valid_returnTrue()
        {
            bool result = xmlIO.writeFile();
            Assert.IsTrue(result, "Unable to writeFile " + xmlIO.OutputFilename);
        }

        [TearDown]
        public void TearDown()
        {
            xmlIO = null;
        }

    } // end class
}
