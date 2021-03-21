using SortProject.Models.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace SortProject.Models.Sorts
{
    public class BubbleSort : Sort
    {
        public int[] Algorithm(int[] mas)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int temp;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[i] > mas[j])
                    {
                        NumberOfComparisons++;
                        temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                        NumberOfPermutations += 2;
                    }
                }
            }

            SortingTime = stopwatch.Elapsed.TotalMilliseconds.ToString();

            return mas;
        }
    }
}
