using SortProject.Models;
using System;

namespace SortProject.Services.Services
{
    public class ArrayService
    {
        private Random random = new Random();

        /// <summary>
        /// Заполнение массива
        /// </summary>
        public void FillArray()
        {
            if (Context.Array.Length > 1)
            {
                for (int i = 0; i < Context.Array.Length; i++)
                {
                    Context.Array[i] = random.Next(0, 1000);
                }
            }
        }

        /// <summary>
        /// Установка максимального количество элементов в массиве
        /// </summary>
        /// <param name="elements"></param>
        public void SetTheNumberOfElements(int elements) => Context.Array = new int[elements];

        /// <summary>
        /// Получение элементов массива до сортировки
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public string GetElementsArrayBeforeSorted(int[] array)
        {
            var result = "";

            for (int i = 0; i < array.Length; i++)
            {
                if (i % 15 == 0 && i != 0)
                {
                    result += array[i] + " ";
                }
                result += array[i] + " ";
            }

            return result;
        }
    }
}
