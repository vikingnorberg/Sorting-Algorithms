using System;
using System.Diagnostics;

namespace combSort
{
    class combSort 
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

        static int getNextGap(int gap) 
        { 
            gap = (gap*10)/13; 
            if (gap < 1) 
            {
                return 1;
            }
            return gap; 
        } 
        
        static void Main(string[] args)
        {
            int items = 20;

            int[] list = new int[items];

            for (int i = 0; i < items; i++) 
            {
                list[i] = i;
            }

            Console.WriteLine("[{0}]", string.Join(", ", list));

            shuffle(list);

            Console.WriteLine("[{0}]", string.Join(", ", list));

            int gap = list.Length;
            bool swapped = false;

            while (gap != 1 || swapped == true) 
            {
                gap = getNextGap(gap);
                swapped = false;

                for (int i = 0; i < list.Length - gap; i++) 
                {
                    if (list[i] > list[i + gap]) 
                    {
                        swap(list[i], list[i + gap], list);
                        swapped = true;
                    }
                }
            }

            Console.WriteLine("[{0}]", string.Join(", ", list));
        }
    }
}