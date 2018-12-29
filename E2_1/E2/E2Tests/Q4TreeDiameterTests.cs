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
        public Q4TreeDiameter q4;

        [TestMethod()]
        public void Q4TreeDiameterTest()
        {
            q4 = new Q4TreeDiameter(10);
        }

        [TestMethod()]
        public void TreeHeightTest()
        {
            q4 = new Q4TreeDiameter(10);
            var height = q4.TreeHeight(0);
            Assert.AreEqual(4, height);
        }

        [TestMethod()]
        public void TreeHeightFromNodeTest()
        {
            q4 = new Q4TreeDiameter(10);
            var height = q4.TreeHeightFromNode(3);
            Assert.AreEqual(5, height);
            height = q4.TreeHeightFromNode(5);
            Assert.AreEqual(6, height);
            height = q4.TreeHeightFromNode(6);
            Assert.AreEqual(5, height);
            height = q4.TreeHeightFromNode(7);
            Assert.AreEqual(4, height);
        }

        [TestMethod()]
        public void TreeDiameterN2Test()
        {
            q4 = new Q4TreeDiameter(10);
            var diameter = q4.TreeDiameterN2();
            Assert.AreEqual(6, diameter);
        }

        [TestMethod()]
        public void TreeDiameterNTest()
        {
            q4 = new Q4TreeDiameter(10);
            var diameter = q4.TreeDiameterN2();
            Assert.AreEqual(6, diameter);
        }
    }
}