using System;
using System.Collections;
using System.Linq;

namespace E2
{
    public class Q3BloomFilter
    {
        BitArray Filter;
        Func<string, int>[] HashFunctions;
        int FilterSize;

        public Q3BloomFilter(int filterSize, int hashFnCount)
        {
            FilterSize = filterSize;
            Random rnd = new Random();
            Filter = new BitArray(filterSize);
            HashFunctions = new Func<string, int>[hashFnCount];
            var randomHashNums = new int[hashFnCount];
            for (int i = 0; i < hashFnCount; i++)
                randomHashNums[i] = rnd.Next();

            for (int i = 0; i < HashFunctions.Length; i++)
            {
                var num = randomHashNums[i];
                HashFunctions[i] = str => MyHashFunction(str, num);
            }
        }

        public int MyHashFunction(string str, int num)
        {
            long sigmaVal = 0;
            long powerVal = 1;
            for (int i = 0; i < str.Length; i++)
            {
                sigmaVal += (str[i] * powerVal) % FilterSize;
                powerVal *= num;
                powerVal %= FilterSize;
            }
            return (int)sigmaVal % FilterSize;
        }

        public void Add(string str)
        {
            foreach (var hashFunc in HashFunctions)
            {
                var idx = hashFunc(str);
                Filter[idx] = true;
                var check = Filter[idx];
            }
        }

        public bool Test(string str)
        {
            foreach (var hashFunc in HashFunctions)
            {
                var idx = hashFunc(str);
                if (!Filter[idx])
                    return false;
            }
            return true;
        }
    }
}