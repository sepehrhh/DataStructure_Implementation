using Microsoft.VisualStudio.TestTools.UnitTesting;
using A1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TestCommon;

namespace A1.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void AddTest()
        {
            Assert.AreEqual(15, Program.Add(10, 5));
            Assert.AreEqual(7, Program.Add(3, 4));
            Assert.AreEqual(-4, Program.Add(9, -13));
        }

        [TestMethod(), Timeout(1000)]
        [DeploymentItem("TestData", "A1_TestData")]
        public void GradedTest()
        {
            TestTools.RunLocalTest("A1", Program.Process);
        }
    }
}