using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_14
{
    public class Class1
    {
        /// <summary>
        /// Функция для нахождения столбца с наименьшим произведением элементов
        /// </summary>
        /// <param name="matr"-матрица ></param>
        /// <param name="s1"- строка для вывода результатов ></param>
        
        public static void Raschet(int[,] matr, out string s1)
        {
            int i, j;
            s1 = null;
            
            int[] mas = new int[matr.GetLength(0)];
           
            for (j = 0; j < matr.GetLength(1); j++)
            {
                int sum = 0;
                for (i = 0; i < matr.GetLength(0); i++)
                {
                    sum += matr[i, j];
                }
                mas[j] = sum / i;
            }
            for (j = 0; j < matr.GetLength(1); j++)
            {
                int kol = 0;
                for (i = 0; i < matr.GetLength(0); i++)
                {
                    if (matr[i, j] > mas[j]) kol++;
                    
                   
                }
                s1 += $"в {j+1} столбце {kol} элементов больше среднеарфметического {mas[j]}\n ";
        }   }
    }
}
