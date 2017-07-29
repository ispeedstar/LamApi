using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LamApi.Tests
{
    [TestFixture]
    public class TextIOTests
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
            textIO.ReadFile();
            Assert.IsTrue(true, "Able to readFile " + textIO.InputFilename);
        }

        [Test]
        public void writeFile_valid_returnTrue()
        {
            textIO.WriteFile();
            Assert.IsTrue(true, "Able to writeFile " + textIO.OutputFilename);
        }

        [TearDown]
        public void TearDown()
        {
            textIO = null;
        }
    } // end class TextIOTests
}
