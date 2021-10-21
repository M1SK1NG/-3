using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace LibMas
{
    public class Class2
    {
        /// <summary>
        /// Функция для заполнения матрицы значениями
        /// </summary>
        /// <param name="matr"//матрица ></param>
        /// <param name="column"// число колонок в массиве></param>
        /// <param name="row"// число строк в массиве></param>
        /// <param name="randMax"// рандомизация></param>
        public static void InitArray(out int[,] matr, int column, int row, int randMax)
        {
            Random Rnd; Rnd = new Random();
            matr = new Int32[row, column];
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    matr[i, j] = Rnd.Next(randMax);//заполняем массив случайными значениями в диапозоне от -10
                }
            }
        }
        /// <summary>
        /// Функция для создания матрицы
        /// </summary>
        /// <param name="matr"//массив></param>
        /// <param name="column"//число колонок в массиве></param>
        public static void CreateArray(out int[,] matr, int column, int row)
        {
            matr = new int[row, column];//создаем массив
        }
        
        /// <summary>
        /// Функция для очистки матрицы
        /// </summary>
        /// <param name="matr"//массив></param>
        public static void CleanArray(ref int[,] matr)
        {
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    matr[i, j] = 0;
                }
            }
        }
        /// <summary>
        /// Функция для сохранения матрицы
        /// </summary>
        /// <param name="matr"//массив></param>
        public static void SaveArray(int[,] matr)
        {
            //создаем и настраиваем элемент SaveFileDialog
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";
            DialogResult dialogResult = save.ShowDialog();
            bool t = Convert.ToBoolean(dialogResult);
            //открываем диалоговое окно и при успехе работаем с файлом
            if (t == true)
            {

                StreamWriter file = new StreamWriter(save.FileName);//создаем поток для работы с файлом и указываем ему имя файла
                file.WriteLine(Convert.ToString(matr.GetLength(0)));//записываем размер массива в файл
                file.WriteLine(Convert.ToString(matr.GetLength(1)));//записываем размер массива в файл
                for (int i = 0; i < matr.GetLength(0); i++)
                {
                    for (int j = 0; j < matr.GetLength(1); j++)
                        //записываем элементы массива в файл

                    {
                        file.WriteLine(matr[i, j]);
                    }
                }
                file.Close();
            }
        }
        /// <summary>
        /// Функция для открытия массива
        /// </summary>
        /// <param name="matr"//массив></param>
        public static void OpenArray(out int[,] matr)
        {

            matr = new int[1, 2];
            //создаем и настраиваем элемент OpenFileDialog
            OpenFileDialog open = new OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Все файлы (*.*) | *.* | Текстовые файлы | *.txt";
            open.FilterIndex = 2;
            open.Title = "Открыть таблицы";
            DialogResult dialogResult = open.ShowDialog();
            bool t = Convert.ToBoolean(dialogResult);
            //открываем диалоговое окно и при успехе работаем с файлом
            if (t == true)
            {
                StreamReader file = new StreamReader(open.FileName);//создаем поток для работы с файлом и указываем ему имя файла
                int len = Convert.ToInt32(file.ReadLine());//читаем размер 
                int len1 = Convert.ToInt32(file.ReadLine());
                matr = new Int32[len,len1];//создаем массив
                for (int i = 0; i < matr.GetLength(0); i++)  
                {
                    for (int j = 0; j < matr.GetLength(1); j++)//считываем массив из файла
                    {
                        matr[i, j] = Convert.ToInt32(file.ReadLine());
                    }
                }
                file.Close();
            }
        }
    }
}
