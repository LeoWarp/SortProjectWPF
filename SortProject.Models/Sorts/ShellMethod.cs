using SortProject.Models.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace SortProject.Models.Sorts
{
    public class ShellMethod : Sort
    {
        public int[] Algorithm(int[] mass)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int n = mass.Length;

            int i, j, step;
            int tmp;
            for (step = n / 2; step > 0; step /= 2)
            {
                for (i = step; i < n; i++)
                {
                    tmp = mass[i];
                    for (j = i; j >= step; j -= step)
                    {
                        if (tmp < mass[j - step])
                        {
                            NumberOfComparisons++;
                            NumberOfPermutations++;
                            mass[j] = mass[j - step];
                        }
                        else
                        {
                            break;
                        }
                    }
                    mass[j] = tmp;
                    NumberOfPermutations++;
                }
            }

            stopwatch.Stop();
            SortingTime = stopwatch.Elapsed.TotalMilliseconds.ToString();

            return mass;
        }
    }
}
