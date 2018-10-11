using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Fibonacci Number
        /// Algorithm Function
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long Fibonacci(long n)
        {
            List<long> fibo = new List<long>() { 0, 1};
            for (int i = 2; i < n + 1; i++)
                fibo.Add(fibo[i - 2] + fibo[i - 1]);
            return fibo[(int)n];
        }

        /// <summary>
        /// Fibonacci Number
        /// Process Function
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static string ProcessFibonacci(string inStr) =>
            Process(inStr, Fibonacci);

        /// <summary>
        /// Last Didit of a Large Fibonnaci Number
        /// Algorithm Function
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long Fibonacci_LastDigit(long n)
        {
            List<int> fiboNumsLastDigit = new List<int>() { 0, 1};
            for (int i = 2; i < n + 1; i++)
                fiboNumsLastDigit.Add((fiboNumsLastDigit[i - 2] + fiboNumsLastDigit[i - 1]) % 10);
            return fiboNumsLastDigit[(int)n];
        }

        /// <summary>
        /// Last Digit of a Large Fibonacci Number
        /// Process Function
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static string ProcessFibonacci_LastDigit(string inStr) =>
            Process(inStr, Fibonacci_LastDigit);

        /// <summary>
        /// Greatest Common Divisor
        /// Algorithm Function
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static long GCD(long a, long b)
        {
            while(a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }
            if (a != 0)
                return a;
            else
                return b;
        }

        /// <summary>
        /// Greatest Common Divisor
        /// Process Function
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static string ProcessGCD(string inStr) =>
            Process(inStr, GCD);

        /// <summary>
        /// Least Common Multiple
        /// Algorithm Function
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static long LCM(long a, long b)
        {
            return (a * b) / Program.GCD(a, b);
        }

        /// <summary>
        /// Least Common Multiple
        /// Process Function
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static string ProcessLCM(string inStr) =>
            Process(inStr, LCM);

        /// <summary>
        /// Fibonacci Number Again
        /// Algorithm Function
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static long Fibonacci_Mod(long n, long m)
        {
            List<long> pisano = new List<long>() { 0, 1 };
            int index = 0;
            do
            {
                index += 2;
                pisano.Add((pisano[index - 1] + pisano[index - 2]) % m);
                pisano.Add((pisano[index] + pisano[index - 1]) % m);
            }
            while (pisano[index] != 0 || pisano[index + 1] != 1);
            int pisanoNum = pisano.Count - 2;
            n %= pisanoNum;
            return pisano[(int)n];
        }

        /// <summary>
        /// Fibonacci Number Again
        /// Process Function
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static string ProcessFibonacci_Mod(string inStr) =>
           Process(inStr, Fibonacci_Mod);

        /// <summary>
        /// Last Digit of the Sum of Fibonacci Numbers
        /// Algorithm Function
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long Fibonacci_Sum(long n)
        {
            var pisanoNum = 60;
            n %= pisanoNum;
            return (Fibonacci(n + 2) - 1) % 10;
        }

        /// <summary>
        /// Last Digit of the Sum of Fibonacci Numbers
        /// Process Function
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static string ProcessFibonacci_Sum(string inStr) =>
            Process(inStr, Fibonacci_Sum);

        /// <summary>
        /// Last Digit of the Sum of Fibonacci Numbers Again
        /// Algorithm Function
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static long Fibonacci_Partial_Sum(long n, long m)
        {
            var pisanoNum = 60;
            if (n >= m)
            {
                n %= pisanoNum;
                m %= pisanoNum;
                return ((Fibonacci_LastDigit(n + 2) - 1) - (Fibonacci_LastDigit(m + 2) - 1) + Fibonacci_LastDigit(m)) % 10;
            }
            else
            {
                n %= pisanoNum;
                m %= pisanoNum;
                return ((Fibonacci_LastDigit(m + 2) - 1) - (Fibonacci_LastDigit(n + 2) - 1) + Fibonacci_LastDigit(n)) % 10;
            }
        }

        /// <summary>
        /// Last Digit of the Sum of Fibonacci Numbers Again
        /// Process Function
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static string ProcessFibonacci_Partial_Sum(string inStr) =>
            Process(inStr, Fibonacci_Partial_Sum);

        /// <summary>
        /// Last Digit of the Sum of Squares of Fibonacci Numbers
        /// Algrithm Function
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long Fibonacci_Sum_Squares(long n)
        {
            var pisanoNum = 60;
            List<long> pisanoNums = new List<long>() { 0, 1 };
            for (int i = 2; i < pisanoNum; i++)
                pisanoNums.Add((pisanoNums[i - 2] + pisanoNums[i - 1]) % 10);
            long n1 = (n - 1) % pisanoNum;
            long n2 = n % pisanoNum;
            return ((pisanoNums[(int)n1] + pisanoNums[(int)n2]) * pisanoNums[(int)n2]) % 10;
        }

        /// <summary>
        /// Last Digit of the Sum of Squares of Fibonacci Numbers
        /// Process Function
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static string ProcessFibonacci_Sum_Squares(string inStr) =>
            Process(inStr, Fibonacci_Sum_Squares);

        //Processes
        public static string Process(string inStr, Func<long, long> longProcessor)
        {
            long n = long.Parse(inStr);
            return longProcessor(n).ToString();
        }

        public static string Process(string inStr, Func<long, long, long> longProcessor)
        {
            long a = long.Parse(inStr.Split()[0]);
            long b = long.Parse(inStr.Split()[1]);
            return longProcessor(a, b).ToString();
        }
    }
}
