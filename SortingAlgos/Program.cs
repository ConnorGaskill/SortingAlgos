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
            int[] largeArr = GenerateRandomArray(10, 1, 1000);
            //stopwatch.Stop();
            //DisplayRuntime(stopwatch);

            // Write your function to test each algorithm here

            SortingAlgoTestBed();

            void SortingAlgoTestBed()
            {
                string nameOfAlgo;
                string sortSpeed;

                stopwatch.Start();

                //QuickSort
                //nameOfAlgo = "QuickSort"; QuickSort(largeArr, 0, largeArr.Length-1);
                //Time Taken: 00:00:00.0849889
                //Worst case O(n^2)
                //Average case O(n log n)

                //QuickSort is a recursive algorithm that sorts based on a pivot point. If the initial pivot is the smallest
                //or largest value in an array, QuickSort will not split the array evenly. If this is done over and over again,
                //such as the case in picking leftmost/rightmost indices in a mostly sorted arrays, Quicksort will need to continuously iterate
                //through the array creating multiple stack frames in the process. In most cases, especially when choosing a pivot around the
                //center of a mostly sorted array, QuickSort preforms the fastest out of all four sorting algorithms here for sorting large arrays.


                //MergeSort
                nameOfAlgo = "MergeSort"; MergeSort(largeArr);
                //Time Taken: 00:00:00.1638807
                //All cases O(n log n)

                //Merge sort is a recursive algorithm that splits an array into binary choices, then rebuilds it. While often slower than QuickSort,
                //Merge sort does not have edge cases thus making it more reliable on large arrays.

                //BubbleSort
                //nameOfAlgo = "BubbleSort"; BubbleSort(largeArr);
                //Time Taken: 00:02:20.9468228
                //Worst case O(n^2)

                //BubbleSort needs to iterate through the array multiple times in order to sort, making it the slowest
                //of the four algorithms tested when it comes to lage arrays. It's okay for smaller arrays, but is still
                //beat by InsertSort.

                //InertionSort
                //nameOfAlgo = "InsertionSort"; InsertionSort(largeArr);
                //Time Taken: 00:00:53.0183073
                //Worst case O(n^2)

                //While sharing the same worst case as BubbleSort, InsertionSort is generally faster since its
                //inner loop is able to resolve earlier and it does not need to cycle through the entire array to move
                //each value. This algorithm performs much faster on mostly sorted arrays, where BubbleSort would not
                //see this benefit. Similar to BubbleSort, InsertSort does not perform well on large arrays, however it tends
                //to perform faster than both MergeSort and QuickSort when it comes to smaller arrays.


                stopwatch.Stop();

                //foreach (int i in largeArr)
                //{
                //    Console.WriteLine(i);
                //}

                sortSpeed = stopwatch.Elapsed.ToString();

                Console.WriteLine("Algorithm: {0} Time Taken {1}", nameOfAlgo, sortSpeed);

                Console.ReadLine();


            }   




            // Write individual functions for each algorithm here (Bubble, Insertion, Merge, and Quick sort)

            void BubbleSort(int[] arr)
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

                return;

            }

            void InsertionSort(int[] inputArray)
            {
                for (int i = 0; i < inputArray.Length - 1; i++)
                {
                    for (int j = i + 1; j > 0; j--)
                    {
                        // Swap if the element at j - 1 position is greater than the element at j position
                        if (inputArray[j - 1] > inputArray[j])
                        {
                            int temp = inputArray[j - 1];
                            inputArray[j - 1] = inputArray[j];
                            inputArray[j] = temp;
                        }
                    }
                }
                return; // Return the sorted array
            }

            void MergeSort(int[] arr)
            {
                if (arr.Length <= 1)
                    return;

                int mid = arr.Length / 2;

                int[] left = new int[mid];
                int[] right = new int[arr.Length - mid];

                for (int i = 0; i < mid; i++)
                    left[i] = arr[i];

                for (int i = mid; i < arr.Length; i++)
                    right[i - mid] = arr[i];

                MergeSort(left);
                MergeSort(right);

                Merge(arr, left, right);
            }

            void Merge(int[] arr, int[] left, int[] right)
            {
                int i = 0, j = 0, k = 0;

                while (i < left.Length && j < right.Length)
                {
                    if (left[i] <= right[j])
                        arr[k++] = left[i++];
                    else
                        arr[k++] = right[j++];
                }

                while (i < left.Length)
                    arr[k++] = left[i++];

                while (j < right.Length)
                    arr[k++] = right[j++];
            }
            void QuickSort(int[] arr, int left, int right)
            {
                if (left < right)
                {
                    int pivot = Partition(arr, left, right);

                    QuickSort(arr, left, pivot - 1);
                    QuickSort(arr, pivot + 1, right);
                }
            }

            // Method to partition the array
            int Partition(int[] arr, int left, int right)
            {
                int pivot = arr[right];
                int i = left - 1;

                for (int j = left; j < right; j++)
                {
                    if (arr[j] <= pivot)
                    {
                        i++;
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }

                int temp1 = arr[i + 1];
                arr[i + 1] = arr[right];
                arr[right] = temp1;

                return i + 1;
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
