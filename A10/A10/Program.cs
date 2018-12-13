using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A10
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var problem = new RabinKarp("");
            problem.Solve("aaaaa", "baaaaaaa");
        }
    }
}
