using Microsoft.VisualStudio.TestTools.UnitTesting;
using A3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        /// <summary>
        /// Fibonacci Number
        /// Test
        /// </summary>
        [TestMethod(), Timeout(1000)]
        [DeploymentItem("TestData", "A3_TestData")]
        public void Graded_FibonacciTest()
        {
            TestCommon.TestTools.RunLocalTest("A3", Program.ProcessFibonacci, "TD1");
        }

        /// <summary>
        /// Last Digit of a Large Fibonacci Number
        /// Test
        /// </summary>
        [TestMethod(), Timeout(1000)]
        [DeploymentItem("TestData", "A3_TestData")]
        public void Graded_FibonacciLastDigitTest()
        {
            TestCommon.TestTools.RunLocalTest("A3", Program.ProcessFibonacci_LastDigit, "TD2");
        }

        /// <summary>
        /// Greatest Common Divisor
        /// Test
        /// </summary>
        [TestMethod(), Timeout(1000)]
        [DeploymentItem("TestData", "A3_TestData")]
        public void Graded_GCDTest()
        {
            TestCommon.TestTools.RunLocalTest("A3", Program.ProcessGCD, "TD3");
        }

        /// <summary>
        /// Least Common Multiple
        /// Test
        /// </summary>
        [TestMethod(), Timeout(1000)]
        [DeploymentItem("TestData", "A3_TestData")]
        public void Graded_LCMTest()
        {
            TestCommon.TestTools.RunLocalTest("A3", Program.ProcessLCM, "TD4");
        }

        /// <summary>
        /// Fibonacci Number Again
        /// Test
        /// </summary>
        [TestMethod(), Timeout(1000)]
        [DeploymentItem("TestData", "A3_TestData")]
        public void Graded_FibonacciModTest()
        {
            TestCommon.TestTools.RunLocalTest("A3", Program.ProcessFibonacci_Mod, "TD5");
        }

        /// <summary>
        /// Last Digit of the Sum of Fibonacci Numbers
        /// Test
        /// </summary>
        [TestMethod(), Timeout(1000)]
        [DeploymentItem("TestData", "A3_TestData")]
        public void Graded_FibonacciSumTest()
        {
            TestCommon.TestTools.RunLocalTest("A3", Program.ProcessFibonacci_Sum, "TD6");
        }

        /// <summary>
        /// Last Digit of the Sum of Fibonacci Numbers Again
        /// Test
        /// </summary>
        [TestMethod(), Timeout(1000)]
        [DeploymentItem("TestData", "A3_TestData")]
        public void Graded_FibonacciPartialSumTest()
        {
            TestCommon.TestTools.RunLocalTest("A3", Program.ProcessFibonacci_Partial_Sum, "TD7");
        }

        /// <summary>
        /// Last Digit of the Sum of Squares of Fibonacci Numbers
        /// Test
        /// </summary>
        [TestMethod(), Timeout(1000)]
        [DeploymentItem("TestData", "A3_TestData")]
        public void Graded_FibonacciSumSquaresTest()
        {
            TestCommon.TestTools.RunLocalTest("A3", Program.ProcessFibonacci_Sum_Squares, "TD8");
        }
    }
}