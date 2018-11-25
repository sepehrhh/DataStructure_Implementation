using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A8
{
    public class CheckBrackets : Processor
    {
        public CheckBrackets(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        private readonly List<(char, char)> BracketPairs = 
            new List<(char, char)>()
        {
            ('(', ')'),
            ('{', '}'),
            ('[', ']'),
        };

        public long Solve(string str)
        {
            var openingBrackets = new char[] { '(', '{', '[' };
            var closingBrackets = new char[] { ')', '}', ']' };
            var openingBracketsStack = new Stack<(char, int)>();
            int i;
            for(i = 0; i < str.Length; i++)
            {
                if (Array.IndexOf(openingBrackets, str[i]) <= -1 &&
                    Array.IndexOf(closingBrackets, str[i]) <= -1)
                    continue;
                if (Array.IndexOf(openingBrackets, str[i]) > -1)
                    openingBracketsStack.Push((str[i], i));
                else
                {
                    if (openingBracketsStack.Count == 0)
                        return i + 1;
                    var top = openingBracketsStack.Pop();
                    if (!BracketPairs.Contains((top.Item1, str[i])))
                        return i + 1;
                }
            }
            if (openingBracketsStack.Count == 0)
                return -1;
            else
                return openingBracketsStack.Last().Item2 + 1;
        }
    }
}
