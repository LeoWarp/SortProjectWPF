using SortProject.Models;
using SortProject.Models.Sorts;
using SortProject.Services.Services;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SortProject
{
    public partial class MainForm : Form
    {
        private ArrayService _arrayService = new ArrayService();
        private FileService _fileService = new FileService();
        private SortService _sortService = new SortService();

        public MainForm()
        {
            InitializeComponent();

            linkLabel1.LinkClicked += linkLabel1_LinkClicked;

            SetMenu();

            if (textBox8.Text == "")
            {
                textBox8.Text = "Данных нет";
            }

            this.MinimumSize = new Size(870, 700);
            this.MaximumSize = new Size(870, 700);
            this.BackColor = Color.Black;

            trackBar1.Scroll += TrackBar_Scroll;
            trackBar1.Maximum = 500;

            FillListSorts();

            listSorts.SelectedIndex = 0;
            listSorts.DropDownStyle = ComboBoxStyle.DropDownList;

            this.ShowInTaskbar = false;
            notifyIcon1.Click += NotifyIcon_Click;

            CustomizeTheIcon();
        }

        private void MainForm_Load(object sender, EventArgs e) { }

        /// <summary>
        /// Сортировка коллекции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortButton_Click(object sender, EventArgs e)
        {
            var selectedSort= listSorts.SelectedItem.ToString();

            var collection = Context.Array;

            if (collection != null)
            {
                if (selectedSort == "Быстрая сортировка")
                {
                    QuickSort quickSort = new QuickSort();

                    var resultSortedArray = _arrayService.GetElementsArrayBeforeSorted(collection);
                    _fileService.WriteDataFileBeforeSortedArray(resultSortedArray, "Быстрая сортировка");

                    collection = quickSort._QuickSort(collection);

                    resultSortedArray = _arrayService.GetElementsArrayBeforeSorted(collection);

                    textBox3.Text = quickSort.SortingTime + "м.с";
                    textBox5.Text = quickSort.NumberOfPermutations.ToString();
                    textBox7.Text = quickSort.NumberOfComparisons.ToString();
                    textBox8.Text = resultSortedArray;

                    _fileService.WriteDataFileAfterSortedArray(resultSortedArray);

                    MessageBox.Show("Данные добавились в файл | Путь - C:\\Report.txt", "Путь к файлу");
                }
                else if (selectedSort == "Сортировка пузырьком")
                {
                    BubbleSort bubbleSort = new BubbleSort();

                    var resultSortedArray = _arrayService.GetElementsArrayBeforeSorted(collection);
                    _fileService.WriteDataFileBeforeSortedArray(resultSortedArray, "Сортировка пузырьком");

                    bubbleSort.Algorithm(collection);

                    resultSortedArray = _arrayService.GetElementsArrayBeforeSorted(collection);

                    textBox3.Text = bubbleSort.SortingTime + "м.с";
                    textBox5.Text = bubbleSort.NumberOfComparisons.ToString();
                    textBox7.Text = bubbleSort.NumberOfPermutations.ToString();
                    textBox8.Text = resultSortedArray;

                    _fileService.WriteDataFileAfterSortedArray(resultSortedArray);

                    MessageBox.Show("Данные добавились в файл | Путь - C:\\Report.txt", "Путь к файлу");
                }
                else if (selectedSort == "Сортировка выбором")
                {
                    InsertionSort insertionSort = new InsertionSort();

                    insertionSort.Algorithm(collection);

                    var resultSortedArray = _arrayService.GetElementsArrayBeforeSorted(collection);
                    _fileService.WriteDataFileBeforeSortedArray(resultSortedArray, "Сортировка выбором");

                    resultSortedArray = _arrayService.GetElementsArrayBeforeSorted(collection);

                    textBox3.Text = insertionSort.SortingTime + "м.с";
                    textBox5.Text = insertionSort.NumberOfComparisons.ToString();
                    textBox7.Text = insertionSort.NumberOfPermutations.ToString();
                    textBox8.Text = resultSortedArray;

                    _fileService.WriteDataFileAfterSortedArray(resultSortedArray);

                    MessageBox.Show("Данные добавились в файл | Путь - C:\\Report.txt", "Путь к файлу");
                }
                else if (selectedSort == "Метод Шелла")
                {
                    ShellMethod shellMethod = new ShellMethod();

                    var resultSortedArray = _arrayService.GetElementsArrayBeforeSorted(collection);
                    _fileService.WriteDataFileBeforeSortedArray(resultSortedArray, "Метод Шелла");

                    shellMethod.Algorithm(collection);

                    resultSortedArray = _arrayService.GetElementsArrayBeforeSorted(collection);

                    textBox3.Text = shellMethod.SortingTime + "м.с";
                    textBox5.Text = shellMethod.NumberOfComparisons.ToString();
                    textBox7.Text = shellMethod.NumberOfPermutations.ToString();
                    textBox8.Text = resultSortedArray;


                    _fileService.WriteDataFileAfterSortedArray(resultSortedArray);

                    MessageBox.Show("Данные добавились в файл | Путь - C:\\Report.txt", "Путь к файлу");
                }
            }
            else
            {
                MessageBox.Show("Сперва заполните коллекцию", "Предупреждение");
            }
        }

        /// <summary>
        /// Заполнение списка сортировок [ComboBox]
        /// </summary>
        public void FillListSorts()
        {
            listSorts.Items.AddRange(new string[]
                {
                    "Быстрая сортировка",
                    "Сортировка выбором",
                    "Сортировка пузырьком",
                    "Метод Шелла"
                });
        }

        /// <summary>
        /// Настройка меню
        /// </summary>
        private void SetMenu()
        {
            ToolStripMenuItem aboutItem = new ToolStripMenuItem("О программе");
            aboutItem.Click += InformationAboutProject_Click;
            menuStrip1.Items.Add(aboutItem);
        }

        /// <summary>
        /// Вывод информации о программе при нажатие кнопки "О программе"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InformationAboutProject_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Хотите быстро отсоритровать коллекцию?\n" +
                "Имеено с помощью этого приложения, вы сможете быстро отсортировать коллекцию.\n" +
                "Не потратив много времени.",
                "Информация о проекте",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
        }

        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// Настройка иконки приложения, которая будет находиться на панели задач
        /// </summary>
        private void CustomizeTheIcon()
        {
            // задаем иконку всплывающей подсказки
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            // задаем текст подсказки
            notifyIcon1.BalloonTipText = "Нажмите, чтобы отобразить окно";
            // устанавливаем зголовк
            notifyIcon1.BalloonTipTitle = "Подсказка";
            // отображаем подсказку 12 секунд
            notifyIcon1.ShowBalloonTip(12);
        }

        private void ClearDataSort_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox5.Clear();
            textBox7.Clear();
        }

        private void TrackBar_Scroll(object sender, EventArgs e)
        {
            ArrayService arrayService = new ArrayService();
            arrayService.SetTheNumberOfElements(trackBar1.Value);
            arrayService.FillArray();
            label2.Text = String.Format("{0}", trackBar1.Value) +  ' ' + "элементов";
        }

        private void AnalyzeSort_Click(object sender, EventArgs e)
        {
            var analyzeShellMethod = _sortService.AnalyzeShellMethod();
            var analyzeBubbleSort = _sortService.AnalyzeBubbleSort();
            var analyzeQuickSort = _sortService.AnalyzeQuickSort();
            var analyzeInsertionSort = _sortService.AnalyzeInsertionSort();

            DataTable dt = new DataTable();
            dt.Columns.Add("Объём выборки");
            dt.Columns.Add("Метод вставками");
            dt.Columns.Add("Быстрая сортировка");
            dt.Columns.Add("Метод обмена");
            dt.Columns.Add("Метод Шелла");

            if (analyzeQuickSort != null)
            {
                #region

                for (int i = 0; i < analyzeQuickSort.Count; i++)
                {
                    DataRow r = dt.NewRow();

                    if (i == 0)
                    {
                        r["Объём выборки"] = 10;
                    }
                    else if (i == 1)
                    {
                        r["Объём выборки"] = 50;
                    }
                    else if (i == 2)
                    {
                        r["Объём выборки"] = 100;
                    }
                    else if (i == 3)
                    {
                        r["Объём выборки"] = 1000;
                    }
                    else if (i == 4)
                    {
                        r["Объём выборки"] = 10000;
                    }
                    else if (i == 5)
                    {
                        r["Объём выборки"] = 10000;
                    }

                    r["Метод вставками"] = analyzeInsertionSort[i];
                    r["Быстрая сортировка"] = analyzeQuickSort[i];
                    r["Метод обмена"] = analyzeBubbleSort[i];
                    r["Метод Шелла"] = analyzeShellMethod[i];

                    dt.Rows.Add(r);
                }

                #endregion

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
                dataGridView1.Size = new Size(610, 123);

                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                dataGridView1.DataSource = dt;
            }
        }

        private void ClearSortData_Click(object sender, EventArgs e)
        {
            textBox8.Clear();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCW1vpw1S8_PHVfDjkIwRB5g");
        }

        private void ReadDataFromFile_Click(object sender, EventArgs e)
        {
            textBox8.Text = _fileService.ReadDataFromFile();
        }
    }
}
