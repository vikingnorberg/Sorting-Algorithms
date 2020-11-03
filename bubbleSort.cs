using System;
using System.Diagnostics;

namespace bubbleSort
{
    class bubbleSort
    {
        static void shuffle<T>(T[] array)
        {
            Random rnd = new Random();

	        int n = array.Length;
	        for (int i = 0; i < n; i++)
	        {
	            int r = i + (int)(rnd.NextDouble() * (n - i));
	            T t = array[r];
	            array[r] = array[i];
	            array[i] = t;
	        }
        }
        
        static void swap(int x, int y, int[] array)
        {
            int temp = array[x];
            array[x] = array[y];
            array[y] = temp;
        }

        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();  

            int items = 1000000;

            int[] list = new int[items]; 

            for (int i = 0; i < items; i++)
            {
                list[i] = i;
            }

            shuffle(list);

            stopWatch.Start();
            for (int i = 0; i < items; i++) 
            {
                for (int j = 0; j < items - 1; j++)
                {
                    if (list[j] > list[i]) {
                        swap(i, j, list);
                    } 
                }
            }
            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = String.Format("{0:00}h:{1:00}m:{2:00}s.{3:00}ms",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }
    }
}