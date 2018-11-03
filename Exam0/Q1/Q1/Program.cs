using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public class Program
    {
        private static Dictionary<int, char[]> D =
            new Dictionary<int, char[]>
            {
                [0] = new char[] { '+' },
                [1] = new char[] { '_', ',', '@' },
                [2] = new char[] { 'A', 'B', 'C' },
                [3] = new char[] { 'D', 'E', 'F' },
                [4] = new char[] { 'G', 'H', 'I' },
                [5] = new char[] { 'J', 'K', 'L' },
                [6] = new char[] { 'M', 'N', 'O' },
                [7] = new char[] { 'P', 'Q', 'R', 'S' },
                [8] = new char[] { 'T', 'U', 'V' },
                [9] = new char[] { 'W', 'X', 'Y', 'Z' },
            };


        public static string[] GetNames(int[] phone)
        {
            var names = new List<string>();
            var answers = new List<string>();
            foreach (var ch in D[phone[0]])
                names.Add(ch.ToString());

            for (var i = 1; i < phone.Length; i++)
                names = UpdateAnswers(phone[i], names);

            return names.ToArray();
        }

        private static List<string> UpdateAnswers(int num, List<string> numElements)
        {
            var answers = new List<string>();
            foreach (var i in numElements)
                foreach (var j in D[num])
                    answers.Add(i + j);
            return answers;
        }

        static void Main(string[] args)
        {
            int[] phoneNumber = new int[] {0, 9, 1, 2, 2, 2, 4, 2, 5, 2, 5 };

            foreach (var i in GetNames(phoneNumber))
                Console.WriteLine(i);

            // چاپ یک رشته حرفی برای شماره تلفن
            //for (int i=0; i< phoneNumber.Length; i++)
            //    Console.Write(D[phoneNumber[i]][0]);
            //Console.WriteLine();
        }


    }
}
