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
            Console.WriteLine(MaximizeSalary6(3, new long[] { 84, 891, 885 }));
        }

        /// <summary>
        /// Money Change
        /// Algorithm Function
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        public static long ChangingMoney1(long money)
        {
            long moneyNum = 0;
            do
            {
                if (money - 10 >= 0)
                    money -= 10;
                else
                {
                    if (money - 5 >= 0)
                        money -= 5;
                    else
                        money -= 1;
                }
                moneyNum++;
            } while (money != 0);
            return moneyNum;
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
            float maxValue = 0;
            List<float> density = new List<float>();
            for (int i = 0; i < values.Length; i++)
                density.Add((float)values[i] / (float)weights[i]);
            var maxDensityIndex = 0;
            do
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
                    capacity = 0;
                }
                density[maxDensityIndex] = -1;
            } while (capacity != 0);
            return (long)maxValue;
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
            var averageDailyClickList = averageDailyClick.ToList();
            var adRevenueList = adRevenue.ToList();
            long averageDailyClickMax;
            long adRevenueMax;
            List<long> revenue = new List<long>();
            for (int i = 0; i < slotCount; i++)
            {
                averageDailyClickMax = averageDailyClickList.Max();
                adRevenueMax = adRevenueList.Max();
                averageDailyClickList.Remove(averageDailyClickMax);
                adRevenueList.Remove(adRevenueMax);
                revenue.Add(averageDailyClickMax * adRevenueMax);
            }
            return revenue.Sum();
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
            while (i <= n)
            {
                if (n - (result + i) > i)
                {
                    resultNums.Add(i);
                    result += i;
                    if (result == n)
                        return resultNums.ToArray();
                }

                else
                {
                    if (resultNums.Count > 0)
                    {
                        resultNums.Add(n - result);
                        return resultNums.ToArray();
                    }
                }

                if (n == i)
                {
                    resultNums.Add(i);
                    return resultNums.ToArray();
                }
                i++;
            }


            return new long[] { 0 };
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
            List<string> numbersList = new List<string>();
            List<string> sortedList = new List<string>();
            foreach (var i in numbers)
                numbersList.Add(i.ToString());
            
            var running = true;
            while (running)
            {
                var max = numbersList.OrderByDescending(x => int.Parse(x)).First();
                foreach (var num in numbersList)
                {
                    if (long.Parse(num + max) > long.Parse(max + num))
                    {
                        max = num;
                    }
                }
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
