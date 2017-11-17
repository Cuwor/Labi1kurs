using System;
using System.Diagnostics;
using static System.Console;

namespace Laba3_4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var exit = false;
            while (!exit)
            {
                Clear();
                
                WriteLine("1. Автозаполнение");
                WriteLine("2. Заполнить вручную");
                WriteLine("3. Выход");

                var menu1 = Convert.ToInt32(ReadLine());
                var Width = 0;
                var Heigth = 0;
                switch (menu1)
                {
                    case 1:
                        var arrayAuto = AutoZapolnenie(out Heigth, out Width);
                        menu2(arrayAuto, Width, Heigth);
                        break;
                    case 2:
                        WriteLine("Введите ширину");
                        Width = Convert.ToInt32(ReadLine());
                        WriteLine("Введите высоту");
                        Heigth = Convert.ToInt32(ReadLine());

                        var array = new int[Width, Heigth];
                        for (int i = 0; i < Width; i++)
                        {
                            for (int j = 0; j < Heigth; j++)
                            {
                                WriteLine("Введите элемент а[{0},{1}]",i,j);
                                array[i,j] = Convert.ToInt32(ReadLine());
                            }
                        }
                        menu2(array, Width, Heigth);
                        break;
                    case 3:
                        exit = true;
                        break;
                }
            }
        }


        private static void menu2(int[,] array, int Width, int Heigth)
        {
            Clear();

            WriteLine("1. Обработка данных");
            WriteLine("2. Вывод данных");
            WriteLine("3. В каком столбце есть значение <0?");
            WriteLine("4. Выход");
            var menu2 = Convert.ToInt32(ReadLine());
            switch (menu2)
            {
                case 1:
                    Uporyadochivanie(array, Width, Heigth);
                    break;
                case 2:
                    Show(array, Width, Heigth);
                    break;
                case 3:
                    OtricStolb(array, Width, Heigth);
                    break;
                case 4:
                    Process.GetCurrentProcess().Kill();
                    break;
            }
        }

        private static int[,] AutoZapolnenie(out int Heigth, out int Width)
        {
            var ran = new Random();
            Heigth = ran.Next(1, 20);
            Width = ran.Next(1, 20);
            var array = new int[Width, Heigth];
            //Заполнение
            for (var i = 0; i < array.Length / Heigth; i++)
            {
                for (var j = 0; j < array.Length / Width; j++)
                    array[i, j] = ran.Next(-5, 20);
                var sum = 0;
                for (var j = 0; j < array.Length / Width; j++)
                    sum += Math.Abs(array[i, j]);
            }
            return array;
        }

        private static void Uporyadochivanie(int[,] array, int Width, int Heigth)
        {
            while (true)
            {
                var flag = false;
                for (var i = 0; i < array.Length / Heigth - 1; i++)
                {
                    var First = 0;
                    var Second = 0;
                    for (var j = 0; j < array.Length / Width; j++)
                    {
                        First += Math.Abs(array[i, j]);
                        Second += Math.Abs(array[i + 1, j]);
                    }
                    if (First < Second)
                    {
                        for (var j = 0; j < array.Length / Width; j++)
                        {
                            var buf = array[i, j];
                            array[i, j] = array[i + 1, j];
                            array[i + 1, j] = buf;
                        }
                        flag = true;
                    }
                }
                if (!flag) break;
            }
            Show(array, Width, Heigth);
        }

        private static void OtricStolb(int[,] a, int Width, int Heigth)
        {
            var number = -1;

            for (var i = 0; i < Heigth; i++)
            {
                for (var j = 0; j < Width; j++)
                    if (a[j, i] < 0)
                    {
                        number = i;
                        break;
                    }
                if (number >= 0) break;
            }
            if (number >= 0) WriteLine("Номер отрицательного столбца: " + (number + 1));
            WriteLine("\n==================================================\n");
            WriteLine("Нажмите любую кнопку для возврата");
            ReadKey();
            menu2(a, Width, Heigth);
        }

        private static void Show(int[,] array, int Width, int Heigth)
        {
            WriteLine("Массив:\n");
            for (var i = 0; i < Width; i++)
            {
                var sum = 0;
                for (var j = 0; j < Heigth; j++)
                    sum += Math.Abs(array[i, j]);
                Write("Сумма {0,4} : ", sum);
                for (var j = 0; j < array.Length / Width; j++)
                    Write("{0,4}", array[i, j]);
                WriteLine();
            }
            WriteLine("\n==================================================\n");
            WriteLine("Нажмите любую кнопку для возврата");
            ReadKey();
            menu2(array,Width,Heigth);
        }
    }
}