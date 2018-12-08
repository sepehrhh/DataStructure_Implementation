using TestCommon;
using System;
using System.Collections.Generic;

namespace A9
{
    public class ConvertIntoHeap : Processor
    {
        public ConvertIntoHeap(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], Tuple<long, long>[]>)Solve);

        public Tuple<long, long>[] Solve(
            long[] array)
        {
            var swapsList = new List<Tuple<long, long>>();
            var n = array.Length;

            for (int i = n - 1; i > 0; i--)
            {
                int elementIndex;
                if (i % 2 == 0)
                    if (i - 1 >= 0)
                        elementIndex = array[i] > array[i - 1] ? i - 1 : i;
                    else
                        elementIndex = i;
                else
                    if (i + 1 <= n - 1)
                        elementIndex = array[i] > array[i + 1] ? i + 1 : i;
                    else
                        elementIndex = i;

                var parentElementIndex = Parent(i);
                while (parentElementIndex <= n - 1 && elementIndex <= n - 1)
                {
                    if (array[parentElementIndex] > array[elementIndex])
                    {
                        swapsList.Add(new Tuple<long, long>(parentElementIndex, elementIndex));
                        (array[parentElementIndex], array[elementIndex]) = (array[elementIndex], array[parentElementIndex]);
                        parentElementIndex = elementIndex;
                        if (elementIndex * 2 + 2 <= n - 1)
                            if (array[elementIndex * 2 + 1] > array[elementIndex * 2 + 2])
                                elementIndex = elementIndex * 2 + 2;
                            else
                                elementIndex = elementIndex * 2 + 1;
                        else
                            elementIndex = elementIndex * 2 + 1;
                    }

                    else
                        break;
                }
            }

            return swapsList.ToArray();
        }

        private int Parent(int i) => (i + 1) / 2 - 1;
    }
}