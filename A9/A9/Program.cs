using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var problem = new ParallelProcessing("");
            problem.Solve(2, new long[] { 1, 2, 3, 4, 5});
        }
    }
}
