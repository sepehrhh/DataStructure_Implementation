using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A5
{
    public class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Binary Search
        /// Algorithm Function
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static long[] BinarySearch1(long[] a , long [] b)
        {
            var result = new List<long>();
            
            foreach (var searchElement in b)
            {
                int searchLowBound = 0;
                int searchHighBound = a.Length - 1;
                while (searchLowBound <= searchHighBound)
                {
                    int midElementIndex = (searchLowBound + searchHighBound) / 2;
                    if (searchElement == a[midElementIndex])
                    {
                        result.Add(midElementIndex);
                        break;
                    }
                    else if (searchElement < a[midElementIndex])
                        searchHighBound = midElementIndex - 1;
                    else
                        searchLowBound = midElementIndex + 1;
                }
                if (searchLowBound > searchHighBound)
                    result.Add(-1);
            }
            return result.ToArray();
        }
        
        /// <summary>
        /// Binary Search
        /// Process Function
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static string ProcessBinarySearch1(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[]>)BinarySearch1);

        /// <summary>
        /// Majority Element
        /// Algorithm Function
        /// </summary>
        /// <param name="n"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static long MajorityElement2(long n, long[] a)
        {
            return FindMajority(a).Item1;
        }

        private static (int, long) FindMajority(long[] nums)
        {
            if (nums.Length == 2)
                if (nums[0] == nums[1])
                    return (1, nums[0]);
                else
                    return (0, 0);
            else if (nums.Length == 1)
                return (0, 0);
            var numsFirstHalve = nums.Take(nums.Length / 2).ToArray();
            var numsSecondHalve = nums.Skip(nums.Length / 2).ToArray();
            var element1 = FindMajority(numsFirstHalve);
            var element2 = FindMajority(numsSecondHalve);
            if (element1.Item1 == 1 && (numsSecondHalve.Contains(element1.Item2) || nums.Length % 2 != 0))
                return (1, element1.Item2);
            else if (element2.Item1 == 1 && (numsFirstHalve.Contains(element2.Item2) || nums.Length % 2 != 0))
                return (1, element2.Item2);
            else
                return (0, 0);
        }

        /// <summary>
        /// Majority Element
        /// Process Function
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static string ProcessMajorityElement2(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)MajorityElement2);

        /// <summary>
        /// Improving Quick Sort
        /// Algorithm Function
        /// </summary>
        /// <param name="n"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static long[] ImprovingQuickSort3(long n, long[] a)
        {
            QuickSort(a, 0, a.Length - 1);
            return a;
        }

        public static void QuickSort(long[] array, long low, long high, long[] secondArray = null)
        {
            if (low < high)
            {
                var p = Partition(array, low, high, secondArray);
                QuickSort(array, low, p.Item1 - 1, secondArray);
                QuickSort(array, p.Item2 + 1, high, secondArray);
            }
        }

        public static (long, long) Partition(long[] array, long low, long high, long[] secondArray = null)
        {
            var pivot = array[low];
            var m1 = low;
            var m2 = low;
            for (var i = low + 1; i <= high; i++)
            {
                if (array[i] < pivot && m2 != array.Length - 1)
                {
                    (array[i], array[m2 + 1]) = (array[m2 + 1], array[i]);
                    (array[m2 + 1], array[m1]) = (array[m1], array[m2 + 1]);
                    if (secondArray != null)
                    {
                        (secondArray[i], secondArray[m2 + 1]) = (secondArray[m2 + 1], secondArray[i]);
                        (secondArray[m2 + 1], secondArray[m1]) = (secondArray[m1], secondArray[m2 + 1]);
                    }
                    m1++;
                    if (m2 <= m1)
                        m2++;
                }
                else if (array[i] == pivot && m2 != array.Length - 1)
                {
                    (array[i], array[m2 + 1]) = (array[m2 + 1], array[i]);
                    if (secondArray != null)
                        (secondArray[i], secondArray[m2 + 1]) = (secondArray[m2 + 1], secondArray[i]);
                    m2++;
                }
            }
            
            return (m1, m2);
        }

        /// <summary>
        /// Improving Quick Sort
        /// Process Function
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static string ProcessImprovingQuickSort3(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)ImprovingQuickSort3);

        /// <summary>
        /// Number Of Inversions
        /// Algorithm Function
        /// </summary>
        /// <param name="n"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static long NumberofInversions4(long n, long[] a)
        {
            return MergeSort(a.ToList()).Item2;
        }

        private static (List<long>, long) MergeSort(List<long> a)
        {
            if (a.Count <= 1)
                return (a, 0);

            var firstHalve = a.Take(a.Count / 2).ToList();
            var secondHalve = a.Skip(a.Count / 2).ToList();

            var leftResult = MergeSort(firstHalve);
            var rightResult = MergeSort(secondHalve);
            
            var mergeResult = Merge(leftResult.Item1, rightResult.Item1);
            return (mergeResult.Item1, leftResult.Item2 + rightResult.Item2 +
                mergeResult.Item2);
        }

        private static (List<long>, long) Merge(List<long> leftList, List<long> rightList)
        {
            long inversions = 0;
            var sortedList = new List<long>();
            int i = 0, j = 0;
            while (i < leftList.Count && j < rightList.Count)
            {
                if (leftList[i] <= rightList[j])
                {
                    sortedList.Add(leftList[i]);
                    i++;
                }
                else
                {
                    sortedList.Add(rightList[j]);
                    inversions += leftList.Count() - i;
                    j++;
                }
            }
            if (i < leftList.Count)
                sortedList.AddRange(leftList.GetRange(i, leftList.Count - i));
            else if (j < rightList.Count)
                sortedList.AddRange(rightList.GetRange(j, rightList.Count - j));
            return (sortedList, inversions);
        }

        /// <summary>
        /// Number Of Inversions
        /// Process Function
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static string ProcessNumberofInversions4(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)NumberofInversions4);

        /// <summary>
        /// Organizing Lottery
        /// Algorithm Function
        /// </summary>
        /// <param name="points"></param>
        /// <param name="startSegments"></param>
        /// <param name="endSegment"></param>
        /// <returns></returns>
        public static long[] OrganizingLottery5(long[] points, long[] startSegments,
            long[] endSegments)
        {
            long Left = 1;
            long Point = 2;
            long Right = 3;

            var pointsDic = new Dictionary<long, long>();
            var allPoints = new List<Tuple<long, int>>();

            foreach (var i in startSegments)
                allPoints.Add(Tuple.Create(i, 1));

            foreach (var i in points)
                if (!pointsDic.ContainsKey(i))
                {
                    pointsDic.Add(i, 0);
                    allPoints.Add(Tuple.Create(i, 2));
                }

            foreach (var i in endSegments)
                allPoints.Add(Tuple.Create(i, 3));

            var leftCount = 0;
            allPoints = allPoints.OrderBy(p => p.Item1).ToList();

            for (int i = 0; i < allPoints.Count; i++)
            {
                if (allPoints[i].Item2 == Left)
                    leftCount++;
                else if (allPoints[i].Item2 == Right)
                    leftCount--;
                else if (allPoints[i].Item2 == Point)
                    if (pointsDic[allPoints[i].Item1] == 0)
                        pointsDic[allPoints[i].Item1] += leftCount;
            }

            var result = new List<long>();
            foreach (var i in points)
                result.Add(pointsDic[i]);

            return result.ToArray();
        }

        /// <summary>
        /// Organizing Lottery
        /// Process Function
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static string ProcessOrganizingLottery5(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long[], long[]>)OrganizingLottery5);
        

        /// <summary>
        /// Closest Points
        /// Algorithm Function
        /// </summary>
        /// <param name="n"></param>
        /// <param name="xPoints"></param>
        /// <param name="yPoints"></param>
        /// <returns></returns>
        public static double ClosestPoints6(long n, long[] xPoints, long[] yPoints)
        {
            return Math.Round(MinimumDistance(xPoints, yPoints), 4);
        }

        internal class Point
        {
            public long X { get; set; }
            public long Y { get; set; }
        }

        private static double Distance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow((p1.X - p2.X), 2) + Math.Pow((p1.Y - p2.Y), 2));
        }

        private static List<Point> GetPoints(long[] xPoints, long[] yPoints)
        {
            var points = new List<Point>();
            for (int i = 0; i < xPoints.Length; i++)
            {
                var p = new Point
                {
                    X = xPoints[i],
                    Y = yPoints[i]
                };
                points.Add(p);
            }
            return points;
        }

        private static double MinimumDistance(long[] xPoints, long[] yPoints)
        {
            var points = GetPoints(xPoints, yPoints);
            points.Sort((x, y) => x.X.CompareTo(y.X));
            return PointsMinDistance(points);
        }

        private static double PointsMinDistance(List<Point> points)
        {
            var size = points.Count;
            var halfSize = (int)(size / 2);
            if (size < 3)
            {
                var minDistance = double.MaxValue;
                for (int i = 0; i < points.Count; i++)
                    for (int j = i + 1; j < points.Count; j++)
                        minDistance = Math.Min(minDistance, Distance(points[i], points[j]));
                return minDistance;
            }
               
            var leftPoints = points.Take(halfSize).ToList();
            var rightPoints = points.Skip(halfSize).ToList();

            var leftMin = PointsMinDistance(leftPoints);
            var rightMin = PointsMinDistance(rightPoints);
            var seperatedMin = Math.Min(leftMin, rightMin);
            var sepratorLine = (leftPoints.Last().X + rightPoints[0].X) / 2;
            var commonMin = CommonMinDistance(leftPoints, rightPoints, sepratorLine, seperatedMin);
            return Math.Min(seperatedMin, commonMin);
        }

        private static double CommonMinDistance(List<Point> leftPoints, List<Point> rightPoints, long seperatorLine, double seperatedMin)
        {
            var leftSide = new List<Point>();
            var rightSide = new List<Point>();
            for (int i = 0; i < leftPoints.Count; i++)
                if (Math.Abs(leftPoints[i].X - seperatorLine) <= seperatedMin)
                    leftSide.Add(leftPoints[i]);
            for (int i = 0; i < rightPoints.Count; i++)
                if (Math.Abs(rightPoints[i].X - seperatorLine) <= seperatedMin)
                    rightSide.Add(rightPoints[i]);
            var allPoints = leftSide.Concat(rightSide).ToList();
            allPoints.Sort((x, y) => x.Y.CompareTo(y.Y));
            var result = seperatedMin;
            for (int i = 0; i < allPoints.Count; i++)
                for (int j = i + 1; j < Math.Min(i + 8, allPoints.Count); j++)
                    if (Math.Abs(allPoints[i].Y - allPoints[j].Y) <= seperatedMin)
                        result = Math.Min(result, Distance(allPoints[i], allPoints[j]));
            return result;
        }


        /// <summary>
        /// Closest Points
        /// Process Function
        /// </summary>
        /// <param name="inStr"></param>
        /// <returns></returns>
        public static string ProcessClosestPoints6(string inStr) =>
           TestTools.Process(inStr, (Func<long, long[], long[], double>)
               ClosestPoints6);

    }
}
