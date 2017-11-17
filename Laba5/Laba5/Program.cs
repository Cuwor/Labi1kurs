using System;
using System.Diagnostics;
using static System.Console;

namespace Laba5
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                Clear();

                WriteLine("1. Ввод данных");
                WriteLine("2. Выход");

                var menu1 = Convert.ToInt32(ReadLine());

                switch (menu1)
                {
                    case 1:
                        Clear();
                        WriteLine("Введите строку: ");
                        var str = ReadLine();
                        Menu2(str);
                        break;
                    case 2:
                        Process.GetCurrentProcess().Kill();
                        break;
                }
            }
        }


        private static void Menu2(string str)
        {
            Clear();

            WriteLine("1. Обработка данных");
            WriteLine("2. Вывод данных");
            WriteLine("3. Выход");
            var menu2 = Convert.ToInt32(ReadLine());
            switch (menu2)
            {
                case 1:
                    Clear();
                    SmallWordSearch(str);
                    Menu2(str);
                    break;
                case 2:
                    Clear();
                    Show(str, SmallWordSearch(str));
                    Menu2(str);
                    break;
                case 3:
                    Process.GetCurrentProcess().Kill();
                    break;
            }
        }

        private static string SmallWordSearch(string str)
        {
            var smallStr = "";
            var minWordLength = 0;
            var strArray = str.Split(' ');
            for (var i = 0; i < strArray.Length; i++)
                if (minWordLength < strArray[i].Length)
                {
                    minWordLength = strArray[i].Length;
                    smallStr = strArray[i];
                }
            return smallStr;
        }

        private static void Show(string str, string smallStr)
        {
            WriteLine("Самое большое слово в строке {0} - это {1}, а длина его = {2}", str, smallStr, smallStr.Length);
            WriteLine("Для возврата нажмите любую кнопку");
            ReadKey();
        }
    }
}