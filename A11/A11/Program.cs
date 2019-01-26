using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A11
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var problem = new BinaryTreeTraversals("");
            var answer = problem.Solve(new long[][] { new long[]{0, -1, 3},
            new long[] { 28, -1, -1 }, new long[]{7, -1, 4},
            new long[] { 22, 2, 1 }, new long[]{15, -1, -1 } });

        }
    }
}
