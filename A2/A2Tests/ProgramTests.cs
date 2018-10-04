using Microsoft.VisualStudio.TestTools.UnitTesting;
using A2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A2.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        [DeploymentItem("TestData", "A2_TestData")]
        public void GradedTest_Correctness()
        {
            TestTools.RunLocalTest("A2", Program.Process);
        }

        [TestMethod(), Timeout(500)]
        [DeploymentItem("TestData", "A2_TestData")]
        public void GradedTest_Performance()
        {
            TestTools.RunLocalTest("A2", Program.Process);
        }

        [TestMethod()]
        public void GradedTest_Stress()
        {
            var startTime = DateTime.Now;
            while (DateTime.Now.Subtract(startTime).Seconds < 5)
            {
                Random random = new Random();
                int numbersLength = random.Next(2, 20);
                List<int> numbers = new List<int>();
                for(int i = 0; i < numbersLength; i++)
                    numbers.Add(random.Next(10000));
                var naiveAlgorithmResult = Program.NaiveMaxPairwiseProduct(numbers);
                var fastAlgorithmResult = Program.FastMaxPairwiseProduct(numbers);
                Assert.IsTrue(naiveAlgorithmResult == fastAlgorithmResult);
            }
        }

    }
}