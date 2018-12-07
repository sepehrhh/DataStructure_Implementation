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
            var threadsQueue = new Queue<Thread>((int)threadCount);
            for (int i = 0; i < threadCount; i++)
                threadsQueue.Enqueue(new Thread(i));
            var threadsList = new List<Thread>();
            var result = new List<Tuple<long, long>>();

            for (int i = 0; i < jobDuration.Length; i++)
            {
                if (threadsQueue.Count != 0)
                {
                    Thread peekThread = null;
                    if (threadsList.Count != 0)
                    {
                        if (threadsList.First().StartTime < threadsQueue.Peek().StartTime)
                        {
                            peekThread = threadsList.First();
                            threadsList.RemoveAt(0);
                        }
                        else if (threadsList.First().StartTime == threadsQueue.Peek().StartTime)
                        {
                            if (threadsList.First().Index < threadsQueue.Peek().Index)
                            {
                                peekThread = threadsList.First();
                                threadsList.RemoveAt(0);
                            }
                            else
                                peekThread = threadsQueue.Dequeue();
                        }
                        else
                            peekThread = threadsQueue.Dequeue();
                    }
                    else
                        peekThread = threadsQueue.Dequeue();

                    result.Add(new Tuple<long, long>(peekThread.Index, peekThread.StartTime));
                    peekThread.StartTime += jobDuration[i];
                    threadsList.Add(peekThread);
                    threadsList = threadsList.OrderBy(x => x.StartTime).ThenBy(x => x.Index).ToList();
                }
                else
                {
                    for (int j = 0; j < threadCount; j++)
                    {
                        threadsQueue.Enqueue(threadsList.First());
                        threadsList.RemoveAt(0);
                    }
                    var peekThread = threadsQueue.Dequeue();
                    result.Add(new Tuple<long, long>(peekThread.Index, peekThread.StartTime));
                    peekThread.StartTime += jobDuration[i];
                    threadsList.Add(peekThread);
                    threadsList = threadsList.OrderBy(x => x.StartTime).ToList();
                }
            }
            
            return result.ToArray();
        }
    }
}
