using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var q2 = new PartitioningSouvenirs("q2");
            q2.Solve(4, new long[] { 3, 3, 3, 3});
        }
    }
}
