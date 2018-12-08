using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace A9
{
    public class ParallelProcessing : Processor
    {
        public ParallelProcessing(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], Tuple<long, long>[]>)Solve);

        public class Thread
        {
            public long Index;
            public long StartTime { set; get; }
            public Thread(long index, long currentTime = 0)
            {
                this.Index = index;
                this.StartTime = currentTime;
            }
        }

        public Tuple<long, long>[] Solve(long threadCount, long[] jobDuration)
        {
            var threadsQueue = new List<Thread>((int)threadCount);
            for (int i = 0; i < threadCount; i++)
                threadsQueue.Add(new Thread(i));
            var result = new List<Tuple<long, long>>();

            for (int i = 0; i < jobDuration.Length; i++)
            {
                var peekThread = threadsQueue.First();
                threadsQueue.RemoveAt(0);
                result.Add(new Tuple<long, long>(peekThread.Index, peekThread.StartTime));
                peekThread.StartTime += jobDuration[i];
                threadsQueue.Add(peekThread);
                threadsQueue = threadsQueue.OrderBy(x => x.StartTime).ThenBy(x => x.Index).ToList();
            }
            
            return result.ToArray();
        }
    }
}
