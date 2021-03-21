using SortProject.Models.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace SortProject.Models.Sorts
{
    public class QuickSort : Sort
    {
        static void Swap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
        }

        private int Partition(int[] array, int minIndex, int maxIndex)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                NumberOfComparisons++;
                if (array[i] < array[maxIndex])
                {
                    NumberOfPermutations += 2;
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;

            Swap(ref array[pivot], ref array[maxIndex]);

            stopWatch.Stop();
            SortingTime = stopWatch.Elapsed.TotalMilliseconds.ToString();

            return pivot;
        }

        public int[] _QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            _QuickSort(array, minIndex, pivotIndex - 1);
            _QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        public int[] _QuickSort(int[] array)
        {
            return _QuickSort(array, 0, array.Length - 1);
        }
    }
}
