using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A10
{
    public class HashingWithChain : Processor
    {
        public HashingWithChain(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, string[], string[]>)Solve);

        protected Dictionary<long, List<string>> HashTable;
        protected int BucketCount;

        public string[] Solve(long bucketCount, string[] commands)
        {
            BucketCount = (int)bucketCount;
            HashTable = new Dictionary<long, List<string>>(BucketCount);
            List<string> result = new List<string>();
            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var arg = toks[1];

                switch (cmdType)
                {
                    case "add":
                        Add(arg);
                        break;
                    case "del":
                        Delete(arg);
                        break;
                    case "find":
                        result.Add(Find(arg));
                        break;
                    case "check":
                        result.Add(Check(int.Parse(arg)));
                        break;
                }
            }
            return result.ToArray();
        }

        public const long BigPrimeNumber = 1000000007;
        public const long ChosenX = 263;

        public static long PolyHash(
            string str, int start, int count,
            long p = BigPrimeNumber, long x = ChosenX)
        {
            long sigmaVal = 0;
            long powerVal = 1;
            for (int i = start; i < start + count; i++)
            {
                sigmaVal += (str[i] * powerVal) % p;
                powerVal *= x;
                powerVal %= p;
            }
            return sigmaVal % p;
        }

        public void Add(string str)
        {
            var hashCode = PolyHash(str, 0, str.Length) % BucketCount;
            if (!HashTable.ContainsKey(hashCode))
                HashTable.Add(hashCode, new List<string>());
            if (!HashTable[hashCode].Contains(str))
                HashTable[hashCode].Insert(0, str);
        }

        public string Find(string str)
        {
            var hashCode = PolyHash(str, 0, str.Length) % BucketCount;
            if (HashTable.ContainsKey(hashCode))
                if (HashTable[hashCode].Contains(str))
                    return "yes";
            return "no";
        }

        public void Delete(string str)
        {
            var hashCode = PolyHash(str, 0, str.Length) % BucketCount;
            if (HashTable.ContainsKey(hashCode))
                if (HashTable[hashCode].Contains(str))
                    HashTable[hashCode].Remove(str);
        }

        public string Check(int i)
        {
            if (HashTable.ContainsKey(i))
                if (HashTable[i].Count != 0)
                    return String.Join(" ", HashTable[i]);
            return "-";
        }
    }
}
