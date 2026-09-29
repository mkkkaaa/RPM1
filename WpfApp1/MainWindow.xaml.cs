using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using Microsoft.Win32;
using lb_mas;
using lib_5;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private int[] mas;

        public MainWindow()
        {
            InitializeComponent();
        } 
        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Получаем количество элементов массива
                int count = Convert.ToInt32(txtCount.Text);

                // Получаем диапазон случайных чисел
                int range = Convert.ToInt32(txtRange.Text);

                // Проверка корректности ввода
                if (count <= 0 || range <= 0)
                {
                    MessageBox.Show("Введите положительные числа!", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Заполняем массив случайными значениями
                Massiv.InitMas(out mas, count, range);

                // Выводим массив в DataGrid
                dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;

                // Очищаем поле результата
                txtResult.Text = "";
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректные числовые значения!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        } 

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            // Проверка наличия массива
            if (mas == null || mas.Length == 0)
            {
                MessageBox.Show("Сначала заполните массив!", "Предупреждение",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Вычисляем произведение чисел < 3
            long product = Calculation.ProductMas(mas);

            // Выводим результат на форму
            if (product == 0)
            {
                txtResult.Text = "0 < 3";
            }
            else
            {
                txtResult.Text = product.ToString();
            }
        } 
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            if (mas != null)
            {
                Massiv.ClearMas(mas);
                dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
                txtResult.Text = "";
            }
        } 
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (mas == null || mas.Length == 0)
            {
                MessageBox.Show("Нет данных для сохранения!", "Предупреждение",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";

            if (save.ShowDialog() == true)
            {
                Massiv.SaveMas(mas, save.FileName);
                MessageBox.Show("Данные сохранены!", "Информация",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        } 

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";

            if (open.ShowDialog() == true)
            {
                Massiv.OpenMas(out mas, open.FileName);
                dataGrid.ItemsSource = VisualArray.ToDataTable(mas).DefaultView;
                txtResult.Text = "";
            }
        } 

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        } 

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Практическая работа №1\n" +
                "Вариант 5\n\n" +
                "Задание: Ввести n целых чисел.\n" +
                "Найти произведение чисел < 3.\n" +
                "Результат вывести на экран.\n\n" +
                "Оганян эээ",
                "О программе",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
        }
        }

