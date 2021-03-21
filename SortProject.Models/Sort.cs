using System.Collections.Generic;

namespace SortProject.Models
{
    public abstract class Sort
    {
        // Количество сравнений
        public int NumberOfComparisons { get; set; }

        // Количество перестановок
        public int NumberOfPermutations { get; set; }

        // Время сортировки
        public string SortingTime { get; set; }
    }
}
