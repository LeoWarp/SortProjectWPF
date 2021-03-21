using SortProject.Models.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace SortProject.Models.Sorts
{
    public class InsertionSort : Sort
    {
        public int[] Algorithm(int[] array)
        {
            int n = array.Length;

            int newElement, location;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 1; i < n; i++)
            {
                newElement = array[i];

                location = i - 1;

                while (location >= 0 && array[location] > newElement)
                {
                    array[location + 1] = array[location];
                    location = location - 1;

                    NumberOfComparisons++;
                    NumberOfPermutations += 2;
                }

                array[location + 1] = newElement;
            }

            stopwatch.Stop();
            SortingTime = stopwatch.Elapsed.TotalMilliseconds.ToString();

            return array;
        }
    }
}
