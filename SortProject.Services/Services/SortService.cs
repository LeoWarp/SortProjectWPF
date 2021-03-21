using SortProject.Models.Sorts;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SortProject.Services.Services
{
    public class SortService
    {
        private Random random = new Random();

        private void FillArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 1000);
            }
        }

        private void CheckSpeedShellMethod(int[] array, ref string result)
        {
            ShellMethod shellMethod = new ShellMethod();
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            array = shellMethod.Algorithm(array);

            stopwatch.Stop();

            result = stopwatch.Elapsed.TotalMilliseconds.ToString() + ' ' + "м/c";
        }

        private void CheckSpeedBubbleSort(int[] array, ref string result)
        {
            BubbleSort bubbleSort = new BubbleSort();
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            array = bubbleSort.Algorithm(array);

            stopwatch.Stop();

            result = stopwatch.Elapsed.TotalMilliseconds.ToString() + ' ' + "м/c";
        }

        private void CheckSpeedInsertionSort(int n, int[] array, ref string result)
        {
            InsertionSort insertionSort = new InsertionSort();
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            array = insertionSort.Algorithm(array);

            stopwatch.Stop();

            result = stopwatch.Elapsed.TotalMilliseconds.ToString() + ' ' + "м/c";
        }

        private void CheckSpeedQuickSort(int[] array, ref string result)
        {
            QuickSort quickSort = new QuickSort();
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            array = quickSort._QuickSort(array);

            stopwatch.Stop();

            result = stopwatch.Elapsed.TotalMilliseconds.ToString() + ' ' + "м/c";
        }

        public List<string> AnalyzeQuickSort()
        {
            List<string> results = new List<string>();

            string result = "";

            int[] array = new int[10000];

            FillArray(array);

            for (int i = 0; i < array.Length; i++)
            {
                if (i == 10)
                {
                    CheckSpeedQuickSort(array, ref result);
                    results.Add(result);
                }
                else if (i == 50)
                {
                    CheckSpeedQuickSort(array, ref result);
                    results.Add(result);
                }
                else if (i == 100)
                {
                    CheckSpeedQuickSort(array, ref result);
                    results.Add(result);
                }
                else if (i == 1000)
                {
                    CheckSpeedQuickSort(array, ref result);
                    results.Add(result);
                }
                else if (i == 9999)
                {
                    CheckSpeedQuickSort(array, ref result);
                    results.Add(result);
                }
            }

            return results;
        }

        public List<string> AnalyzeInsertionSort()
        {
            List<string> results = new List<string>();

            string result = "";

            int[] array = new int[10000];

            FillArray(array); // Заполнение массива рандомными значениями

            for (int i = 0; i < array.Length; i++)
            {
                if (i == 10)
                {
                    CheckSpeedInsertionSort(10, array, ref result);
                    results.Add(result);
                }
                else if (i == 50)
                {
                    CheckSpeedInsertionSort(50, array, ref result);
                    results.Add(result);
                }
                else if (i == 100)
                {
                    CheckSpeedInsertionSort(100, array, ref result);
                    results.Add(result);
                }
                else if (i == 1000)
                {
                    CheckSpeedInsertionSort(1000, array, ref result);
                    results.Add(result);
                }
                else if (i == 9999)
                {
                    CheckSpeedInsertionSort(9999, array, ref result);
                    results.Add(result);
                }
            }

            return results;
        }

        public List<string> AnalyzeBubbleSort()
        {
            List<string> results = new List<string>();

            string result = "";

            int[] array = new int[10000];

            FillArray(array);

            for (int i = 0; i < array.Length; i++)
            {
                if (i == 10)
                {
                    CheckSpeedBubbleSort(array, ref result);
                    results.Add(result);
                }
                else if (i == 50)
                {
                    CheckSpeedBubbleSort(array, ref result);
                    results.Add(result);
                }
                else if (i == 100)
                {
                    CheckSpeedBubbleSort(array, ref result);
                    results.Add(result);
                }
                else if (i == 1000)
                {
                    CheckSpeedBubbleSort(array, ref result);
                    results.Add(result);
                }
                else if (i == 9999)
                {
                    CheckSpeedBubbleSort(array, ref result);
                    results.Add(result);
                }
            }

            return results;
        }

        public List<string> AnalyzeShellMethod()
        {
            List<string> results = new List<string>();

            string result = "";

            int[] array = new int[10000];

            FillArray(array);

            for (int i = 0; i < array.Length; i++)
            {
                if (i == 10)
                {
                    CheckSpeedShellMethod(array, ref result);
                    results.Add(result);
                }
                else if (i == 50)
                {
                    CheckSpeedShellMethod(array, ref result);
                    results.Add(result);
                }
                else if (i == 100)
                {
                    CheckSpeedShellMethod(array, ref result);
                    results.Add(result);
                }
                else if (i == 1000)
                {
                    CheckSpeedShellMethod(array, ref result);
                    results.Add(result);
                }
                else if (i == 9999)
                {
                    CheckSpeedShellMethod(array, ref result);
                    results.Add(result);
                }
            }

            return results;
        }
    }
}
