using Microsoft.VisualStudio.TestTools.UnitTesting;
using E2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E2.Tests
{
    [TestClass()]
    public class Q4TreeDiameterTests
    {
        public Q4TreeDiameter q4 = new Q4TreeDiameter(10);

        [TestMethod()]
        public void Q4TreeDiameterTest()
        {
            Assert.Inconclusive();
            Q4TreeDiameter td = new Q4TreeDiameter(10, 0);
        }

        [TestMethod()]
        public void TreeHeightTest()
        {
            var height = q4.TreeHeight(0);
            Assert.AreEqual(4, height);
        }

        [TestMethod()]
        public void TreeHeightFromNodeTest()
        {
            var height = q4.TreeHeightFromNode(6);
            Assert.AreEqual(5, height);
        }

        [TestMethod()]
        public void TreeDiameterN2Test()
        {
            Assert.Inconclusive();
        }

        [TestMethod()]
        public void TreeDiameterNTest()
        {
            Assert.Inconclusive();
        }
    }
}