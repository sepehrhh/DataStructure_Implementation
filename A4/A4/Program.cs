using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MaximizeSalary6(2, new long[] { 12, 21 });
        }

        /// <summary>
        /// Money Change
        /// Algorithm Function
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        public static long ChangingMoney1(long money)
        {
            return money / 10 + (money % 10) / 5 + money % 5;
        }

        /// <summary>
        /// Money Change
        /// Process Function
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static string ProcessChangingMoney1(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>) ChangingMoney1);

        /// <summary>
        /// Maximum Value of the Loot
        /// Algorithm Function
        /// </summary>
        /// <param name="capacity"></param>
        /// <param name="weights"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static long MaximizingLoot2(
            long capacity, long[] weights, long[] values)
        {
            var density = weights.Zip(values, (weight, value) => (float)value / (float)weight).ToList();
            float maxValue = 0;
            var maxDensityIndex = 0;

            while (true)
            {
                maxDensityIndex = density.IndexOf(density.Max());
                if (weights[maxDensityIndex] < capacity)
                {
                    maxValue += values[maxDensityIndex];
                    capacity -= weights[maxDensityIndex];
                }
                else
                {
                    maxValue += density[maxDensityIndex] * capacity;
                    return (long)maxValue;
                }
                density[maxDensityIndex] = -1;
            }
        }

        /// <summary>
        /// Maximum Value of the Loot
        /// Process Function
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static string ProcessMaximizingLoot2(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>)MaximizingLoot2);

        /// <summary>
        /// Maximizing Revenue in Online Ad Placement
        /// Algorithm Function
        /// </summary>
        /// <param name="slotCount"></param>
        /// <param name="adRevenue"></param>
        /// <param name="averageDailyClick"></param>
        /// <returns></returns>
        public static long MaximizingOnlineAdRevenue3(long slotCount,
            long[] adRevenue, long[] averageDailyClick)
        {
            return adRevenue.OrderByDescending(x => x).Zip(averageDailyClick.OrderByDescending(x => x),
                (revenue, dailyClick) => revenue * dailyClick).Sum();
        }

        /// <summary>
        /// Maximizing Revenue in Online Ad Placement
        /// Process Function
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static string ProcessMaximizingOnlineAdRevenue3(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>)MaximizingOnlineAdRevenue3);

        /// <summary>
        /// Collecting Signatures
        /// Algorithm Function
        /// </summary>
        /// <param name="tenantCount"></param>
        /// <param name="startTimes"></param>
        /// <param name="endTimes"></param>
        /// <returns></returns>
        public static long CollectingSignatures4(long tenantCount,
            long[] startTimes, long[] endTimes)
        {
            List<(long, long)> segments = new List<(long, long)>();
            for (int i = 0; i < tenantCount; i++)
                segments.Add((startTimes[i], endTimes[i]));
            segments.Sort((x, y) => x.Item2.CompareTo(y.Item2));
            long chosenPoint = 0;
            long result = 0;
            while (segments.Count != 0)
            {
                chosenPoint = segments[0].Item2;
                do
                {
                    segments.Remove(segments[0]);
                    if (segments.Count == 0)
                        return result + 1;
                } while (chosenPoint <= segments[0].Item2 &&
                chosenPoint >= segments[0].Item1);
                result++;
            }
            return 0;
        }

        /// <summary>
        /// Collecting Signatures
        /// Process Function
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static string ProcessCollectingSignatures4(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>)CollectingSignatures4);

        /// <summary>
        /// Maximum Number Of Prizes
        /// Algorithm Function
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long[] MaximizeNumberOfPrizePlaces5(long n)
        {
            List<long> resultNums = new List<long>();
            long result = 0;
            long i = 1;
            while (n - (result + i) > i && result != n)
            {
                resultNums.Add(i);
                result += i;
                i++;
            }
            resultNums.Add(n - result);

            return resultNums.ToArray();
        }

        /// <summary>
        /// Maximum Number Of Prizes
        /// Process Function
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static string ProcessMaximizeNumberOfPrizePlaces5(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[]>)MaximizeNumberOfPrizePlaces5);

        /// <summary>
        /// Maximum Salary
        /// Algorithm Function
        /// </summary>
        /// <param name="n"></param>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static string MaximizeSalary6(long n, long[] numbers)
        {
            List<string> sortedList = new List<string>();
            var numbersList = numbers.Select(x => x.ToString()).ToList();
            var running = true;

            while (running)
            {
                var max = numbersList.OrderByDescending(x => int.Parse(x)).First();
                foreach (var num in numbersList)
                    if (long.Parse(num + max) > long.Parse(max + num))
                        max = num;
                sortedList.Add(max);
                numbersList.Remove(max);
                if (sortedList.Count == numbers.Length)
                    running = false;
            }

            return String.Join("", sortedList); 
        }

        /// <summary>
        /// Maximum Salary
        /// Process Function
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static string ProcessMaximizeSalary6(string inStr) =>
            TestTools.Process(inStr, MaximizeSalary6);
    }
}
