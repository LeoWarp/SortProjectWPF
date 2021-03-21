using System;
using System.IO;

namespace SortProject.Services.Services
{
    public class FileService
    {
        private string WritePath = @"C:\Report.txt";

        /// <summary>
        /// Запись элементов массива в файл до сортировки
        /// </summary>
        /// <param name="result"></param>
        /// <param name="nameSort"></param>
        public void WriteDataFileBeforeSortedArray(string result, string nameSort)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(WritePath, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(nameSort);
                    sw.WriteLine("Коллекция до сортировки:");
                    sw.WriteLine(result);
                    sw.WriteLine(new string('-', 65));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Запись элементов массива в файл после сортировки
        /// </summary>
        /// <param name="result"></param>
        public void WriteDataFileAfterSortedArray(string result)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(WritePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine("Коллекция после сортировки:");
                    sw.WriteLine(result);
                    sw.WriteLine(new string('-', 65));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Чтение данных из файла
        /// </summary>
        /// <returns></returns>
        public string ReadDataFromFile()
        {
            if (File.Exists(WritePath) != false)
            {
                string textFromFile = "";

                using (FileStream fstream = File.OpenRead($"{WritePath}"))
                {
                    byte[] array = new byte[fstream.Length];
                    fstream.Read(array, 0, array.Length);
                    textFromFile = System.Text.Encoding.Default.GetString(array);
                }

                return textFromFile;
            }

            return "";
        }
    }
}
