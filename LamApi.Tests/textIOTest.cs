using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LamApi.Tests
{
    [TestFixture]
    public class textIOTest
    {
        private TextIO textIO = null;

        [SetUp]
        public void Setup()
        {
            textIO = new TextIO();
            textIO.InputFilename = @"C:\Projects\exer\VS2010\Data\userInfo.txt";
            textIO.OutputFilename = @"C:\Projects\exer\VS2010\Data\userInfo.out";
        }


        [Test]
        public void readFile_valid_returnTrue()
        {
            bool result = textIO.readFile();
            Assert.IsTrue(result, "Unable to readFile " + textIO.InputFilename);
        }

        [Test]
        public void writeFile_valid_returnTrue()
        {
            bool result = textIO.writeFile();
            Assert.IsTrue(result, "Unable to writeFile " + textIO.OutputFilename);
        }

        [TearDown]
        public void TearDown()
        {
            textIO = null;
        }

    } // end class
}
