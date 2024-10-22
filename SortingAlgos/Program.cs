using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgos
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Stopwatch stopwatch = Stopwatch.StartNew();

            // usage 100 thousand values
            //stopwatch.Start();
            int[] largeArr = GenerateRandomArray(1000, 1, 1000);
            //stopwatch.Stop();
            //DisplayRuntime(stopwatch);

            // Write your function to test each algorithm here
            stopwatch.Start();

            largeArr 
                //= BubbleSort(largeArr);
                = InsertionSortRecursive(largeArr, largeArr.Length);

            foreach (int i in largeArr)
            {
                Console.WriteLine(i);
            }
            stopwatch.Stop();
            DisplayRuntime(stopwatch);
            Console.ReadLine();



            // Bubble Sort
            // Insertion Sort
            //Merge Sort
            // Quick Sort


            // Write individual functions for each algorithm here (Bubble, Insertion, Merge, and Quick sort)

            int[] BubbleSort(int[] arr)
            {

                int temp;

                for (int j = 0; j <= arr.Length - 2; j++)
                {
                    for (int i = 0; i <= arr.Length - 2; i++)
                    {
                        if (arr[i] > arr[i + 1])
                        {
                            temp = arr[i + 1];
                            arr[i + 1] = arr[i];
                            arr[i] = temp;
                        }
                    }
                }

                return arr;

            }
            int[] InsertionSortRecursive(int[] array, int length)
            {
                if (length <= 1)
                {
                    return array;
                }
                InsertionSortRecursive(array, length - 1);
                var key = array[length - 1];
                var k = length - 2;
                while (k >= 0 && array[k] > key)
                {
                    array[k + 1] = array[k];
                    k = k - 1;
                }
                array[k + 1] = key;
                return array;
            }


            // function
            int[] GenerateRandomArray(int length, int minValue, int maxValue)
            {
                Random rand = new Random();
                int[] array = new int[length];

                for (int i = 0; i < length; i++)
                {
                    array[i] = rand.Next(minValue, maxValue); // Generates a random integer within the specified range
                }

                return array;
            }

            void DisplayRuntime(Stopwatch stopwatch2)
            {
                TimeSpan ts = stopwatch.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                Console.WriteLine("Time Taken: " + elapsedTime);
            }



        }
    }
}
