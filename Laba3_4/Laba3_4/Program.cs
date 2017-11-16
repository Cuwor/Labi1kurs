using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                int[,] array = new int[n, n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.WriteLine("Введи a[{0},{1}]", i, j);
                        array[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                }
                Show(array,n);
                //Uporyadochivanie(array, n);
                OtricStolb(array, n);
            }
        }

        static void Uporyadochivanie(int[,] a, int n)
        {
            //for (int i = 0; i < n; i++)
            //    for (int j = 0; j < n; j++)
            //        for (int g = 0; g < n - 1; g++)
            //            if (a[j, g] < a[j, g + 1])
            //            {
            //                int temp = a[j, g];
            //                a[j, g] = a[j, g + 1];
            //                a[j, g + 1] = temp;

            //            }
            //for (int i = 0; i < n; i++)
            //    for (int j = 0; j < n - 1; j++)
            //        for (int g = 0; g < n; g++)
            //            if (a[j, g] < a[j + 1, g])
            //            {
            //                int temp = a[j, g];
            //                a[j, g] = a[j + 1, g];
            //                a[j + 1, g] = temp;
            //            }
            
            Show(a, n);
        }
        static void OtricStolb(int[,] a, int n)
        {
            int stolb = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n - 1; j++)
                    for (int g = 0; g < n; g++)
                        if (a[j, g] < 0 || stolb == 0)
                        {
                            stolb = g+1;
                            break;
                        }
            Console.WriteLine("Номер столбца с отрицательным числом " + stolb);
        }

        static void Show(int[,] a, int n)
        {
            Console.WriteLine("Массив:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(a[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
