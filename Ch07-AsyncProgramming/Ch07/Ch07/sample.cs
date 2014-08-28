using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CH07
{
    public static class sample
    {
        public static void EnumThreadsForPID(int PID)
        {
            Process proc = null;
            try
            {
                proc = Process.GetProcessById(PID);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            // 列出指定PID執行緒中每一個執行緒資訊
            Console.WriteLine("執行緒名稱：{0}", proc.ProcessName);
            ProcessThreadCollection threads = proc.Threads;
            foreach (ProcessThread pt in threads)
            {
                string info = string.Format("Thread ID:{0}\t" +
                                            "Start Time:{1}\t" +
                                            "Priority:{2}",
                                            pt.Id,
                                            pt.StartTime,
                                            pt.PriorityLevel);
                Console.WriteLine(info);
            }
            Console.WriteLine("********************");
        }

        public static void Write1To50()
        {
            for (int i = 1; i <= 50; i++)
            {
                Console.Write(i + ",");
            }
        }

        public static void Write51To100()
        {
            for (int i = 51; i <= 100; i++)
            {
                Console.Write(i + ",");
            }
        }

        public static void new10Thread()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(() =>
                {
                    Console.WriteLine(string.Format("{0}:{1}",
                        Thread.CurrentThread.Name, i));
                });
                t.Name = string.Format("執行緒{0}", i);
                t.IsBackground = true;
                t.Start();
            }
            Console.ReadLine();
        }

        public static void new10Thread(int i)
        {
            Thread t = new Thread(() =>
            {
                Console.WriteLine(string.Format("{0}:{1}",
                    Thread.CurrentThread.Name, i));
            });
            t.Name = string.Format("執行緒{0}", i);
            t.IsBackground = true;
            t.Start();
        }

        public static void TaskRun1()
        {
            Task task = Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("From Task.");
            });
            // 因為Task被 Thread.Sleep 暫停，回應 false
            Console.WriteLine(task.IsCompleted);
            // 封鎖執行緒，等待Task完成
            task.Wait();
            // Task已完成，回應 True
            Console.WriteLine(task.IsCompleted);
            Console.ReadLine();
        }

        public static void TaskRun2()
        {
            Task<int> task = Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("From Task.");
                return 1;
            });
            // 如果Task未完成，封鎖執行緒
            int result = task.Result;
            Console.WriteLine(result);
            Console.ReadLine();
        }

        private static Task<int> getN3()
        {
            Task<int> task = Task.Run(() => Enumerable.Range(1, 5000000).Count(n => (n % 3) == 0));
            return task;
        }

        public static void TaskRun3()
        {
            Task<int> task = getN3();
            Console.WriteLine("Task 執行中...");
            Console.WriteLine("整除3的個數有:" + task.Result);
            Console.ReadLine();
        }

        public static void ContinueWith()
        {
            Task<int> task = getN3();
            task.ContinueWith(c =>
            {
                int result = task.Result;
                Console.WriteLine("整除3的個數有:" + result);
            });
            Console.WriteLine("Task 執行中...");
            Console.ReadLine();
        }

        public static void Awaiter()
        {
            Task<int> task = getN3();
            var awaiter = task.GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                int result = awaiter.GetResult();
                Console.WriteLine("整除3的個數有:" + result);
            });

            Console.WriteLine("Task 執行中...");
            Console.ReadLine();
        }

        public static void TaskDelayContinueWith()
        {
            Task<int> task = getN3();
            Task.Delay(2000).ContinueWith(c =>
            {
                int result = task.Result;
                Console.WriteLine("整除3的個數有:" + result);
            });
            Console.ReadLine();
        }

        public static void TaskDelayAwaiter()
        {
            Task<int> task = getN3();
            Task.Delay(2000).GetAwaiter().OnCompleted(() =>
            {
                Console.WriteLine("整除3的個數有:" + task.Result);
            });
            Console.ReadLine();
        }

        public static void ParallelFor()
        {
            int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Parallel.For(0, nums.Length, (i) =>
            {
                Console.WriteLine("索引{0}:陣列{1}", i, nums[i]);
            });
            Console.ReadLine();
        }

        public static void ParallelForEach()
        {
            List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Parallel.ForEach(nums, (i) =>
            {
                Console.WriteLine("集合元素 {0}", i);
            });
            Console.ReadLine();
        }

        public static void ParallelInvoke()
        {
            Parallel.Invoke(() =>
            {
                Console.WriteLine("工作1...");
            },
            () =>
            {
                Console.WriteLine("工作2...");
            },
            () =>
            {
                Console.WriteLine("工作3...");
            });

            Console.ReadLine();
        }
    }
}
