using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using static System.Console;

namespace Laba7
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
                Menu1();
        }

        private static void Menu1()
        {
            Clear();

            WriteLine("1. Ввод количества вручную");
            WriteLine("2. Ввод количества из файла");
            WriteLine("3. Выход");
            WriteLine("++++++++++++++");
            WriteLine("Любой другой символ чтоб перейти ко вводу количества");

            var menu1 = Convert.ToInt32(ReadLine());
            long count = 0;
            switch (menu1)
            {
                case 1:
                    Clear();
                    WriteLine("Введите количество");
                    count = Convert.ToInt64(ReadLine());
                    Menu2(count);
                    break;
                case 2:
                    Clear();
                    using (var sr = new StreamReader(@"File.txt"))
                    {
                        while (sr.ReadLine() != null)
                            //читаем по одной линии(строке) пока не вычитаем все из потока (пока не достигнем конца файла)
                            ++count;
                    }
                    Menu2(count);
                    break;
                case 3:
                    Process.GetCurrentProcess().Kill();
                    break;
            }
        }

        private static void Menu2(long count)
        {
            var lines = new string[count];
            using (var str = new StreamReader(@"File.txt", Encoding.Default))
            {
                for (var i = 0; i < count; i++)
                    lines[i] = str.ReadLine();
            }

            Clear();

            WriteLine("1. Обработка данных");
            WriteLine("2. Вывод данных с сортировкой по имени");
            WriteLine("3. Вывод данных с сортировкой по длине");
            WriteLine("4. Вывод данных с окончанием ко");
            WriteLine("5. Выход");
            WriteLine("++++++++++++++");
            WriteLine("Любой другой символ чтоб перейти ко вводу количества");
            var menu2 = Convert.ToInt32(ReadLine());

            switch (menu2)
            {
                case 1:
                    Clear();
                    Menu2(count);
                    break;
                case 2:
                    Clear();
                    SortName(lines);
                    WriteLine("====================================");
                    WriteLine("Для возврата нажмите на любую кнопку");
                    ReadKey();
                    break;
                case 3:
                    Clear();
                    SortLength(lines);
                    WriteLine("====================================");
                    WriteLine("Для возврата нажмите на любую кнопку");
                    ReadKey();
                    break;
                case 4:
                    Clear();
                    SortKo(lines);
                    WriteLine("====================================");
                    WriteLine("Для возврата нажмите на любую кнопку");
                    ReadKey();
                    break;
                case 5:
                    Process.GetCurrentProcess().Kill();
                    break;
            }
        }

        private static void Show(string[] lines)
        {
            for (var i = 0; i < lines.Length; i++)
                WriteLine(lines[i]);
        }

        private static void SortName(string[] lines)
        {
            for (var i = 0; i < lines.Length - 1; i++)
            for (var j = i + 1; j < lines.Length; j++)
                if (lines[i].CompareTo(lines[j]) == 1)
                    Sort(i, j, lines);
            Show(lines);
        }

        private static void SortLength(string[] lines)
        {
            for (var i = 0; i < lines.Length - 1; i++)
            for (var j = i + 1; j < lines.Length; j++)
                if (lines[i].Length < lines[j].Length)
                    Sort(i, j, lines);
            Show(lines);
        }

        private static void SortKo(string[] lines)
        {
            foreach (var item in lines)
            {
                var ko = item[item.Length - 2] + "" + item[item.Length - 1];

                if (ko.CompareTo("ко") == 0)
                    WriteLine(item);
            }
        }

        private static void Sort(int i, int j, string[] lines)
        {
            var temp = lines[i];
            lines[i] = lines[j];
            lines[j] = temp;
        }
    }
}