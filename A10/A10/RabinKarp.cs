using System;
using System.Collections.Generic;
using TestCommon;

namespace A10
{
    public class RabinKarp : Processor
    {
        public RabinKarp(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long[]>)Solve);

        
        protected long PatternHash = 0;

        public long[] Solve(string pattern, string text)
        {
            List<long> occurrences = new List<long>();
            PatternHash = HashingWithChain.PolyHash(pattern, 0,
                pattern.Length, HashingWithChain.BigPrimeNumber,
                HashingWithChain.ChosenX);
            var hashSet = PreComputeHashes(text, pattern.Length,
                HashingWithChain.BigPrimeNumber, HashingWithChain.ChosenX);
            for (int i = 0; i < hashSet.Length; i++)
                if (hashSet[i] == PatternHash)
                    if (String.Equals(text.Substring(i, pattern.Length), pattern))
                        occurrences.Add(i);
            return occurrences.ToArray();
        }


        public static long[] PreComputeHashes(
            string T,
            int P,
            long p,
            long x)
        {
            var hashSet = new long[T.Length - P + 1];
            var subStr = T.Substring(T.Length - P, P);
            hashSet[T.Length - P] = HashingWithChain.PolyHash(subStr, 0,
                P, p, x);

            long pow = 1;
            for (int i = 0; i < P; i++)
                pow = (pow * x) % p;

            for (int i = T.Length - P - 1; i >= 0; i--)
                hashSet[i] = (((x * hashSet[i + 1]) + T[i] - (pow * T[i + P])) % p + p) % p;

            return hashSet;
        }
    }
}
