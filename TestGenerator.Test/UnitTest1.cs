using NUnit.Framework;
using System;
using System.IO;
using TestsGeneratorLib;

namespace TestGenerator.Test
{
    public class Tests
    {
        private TestsGeneratorLib.Tests test;
        [SetUp]
        public void Setup()
        {
            test = new TestsGeneratorLib.Tests();
        }

        [Test]
        public void SplitMultipleClassesIntoDifferentFiles()
        {
            test.Generate(Directory.GetCurrentDirectory() + @"\Code", Directory.GetCurrentDirectory() + @"\Test", 5).Wait();
            int expected = 2;
            int actual = Directory.GetFiles(Directory.GetCurrentDirectory() + @"\Test").Length;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IncorrectPathTest()
        {
            string actual = "";
            try
            {
                test.Generate("", Directory.GetCurrentDirectory() + @"\Test", 5).Wait();
            }
            catch (Exception e)
            {
                actual = e.Message;
            }
            string expected = "The path is empty. (Parameter 'path')";
            Assert.AreEqual(expected, actual);
        }
    }
}