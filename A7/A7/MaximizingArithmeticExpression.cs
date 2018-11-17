using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A7
{
    public class MaximizingArithmeticExpression : Processor
    {
        public MaximizingArithmeticExpression(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long Solve(string expression)
        {
            List<long> digits = new List<long>();
            List<char> operators = new List<char>();

            foreach (var i in expression)
                if (long.TryParse(i.ToString(), out long digit))
                    digits.Add(digit);
                else
                    operators.Add(i);

            long[,] minData = new long[digits.Count, digits.Count];
            long[,] maxData = new long[digits.Count, digits.Count];

            for (int i = 0; i < digits.Count; i++)
            {
                minData[i, i] = digits[i];
                maxData[i, i] = digits[i];
            }

            for (int i = 0; i < digits.Count; i++)
                for (int j = 0; j < digits.Count - i - 1; j++)
                {
                    int k = j + i + 1;
                    var data = MinAndMax(j, k, operators, minData, maxData);
                    minData[j, k] = data.Item1;
                    maxData[j, k] = data.Item2;
                }

            return maxData[0, digits.Count - 1];
        }

        private (long, long) MinAndMax(int i, int j, List<char> operatorsList, long[,] minArray, long[,] maxArray)
        {
            var min = long.MaxValue;
            var max = long.MinValue;
            for (int k = i; k < j; k++)
            {
                var a = Operator(maxArray[i, k], maxArray[k + 1, j], operatorsList[k]);
                var b = Operator(maxArray[i, k], minArray[k + 1, j], operatorsList[k]);
                var c = Operator(minArray[i, k], maxArray[k + 1, j], operatorsList[k]);
                var d = Operator(minArray[i, k], minArray[k + 1, j], operatorsList[k]);
                var operatedDatas = new[] { a, b, c, d };

                min = Math.Min(operatedDatas.Min(), min);
                max = Math.Max(operatedDatas.Max(), max);
            }

            return (min, max);
        }

        private long Operator(long a, long b, char op)
        {
            switch (op)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;

                default:
                    return -1;
            }
        }
    }
}
