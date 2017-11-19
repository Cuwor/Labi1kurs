using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using static System.Console;

namespace Laba6
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                Clear();
                WriteLine("Введите количество телевизоров будет введено или содержится в файле");
                var count = Convert.ToInt32(ReadLine());
                var tel = new Tv[count];
                Clear();

                WriteLine("1. Ввод данных вручную");
                WriteLine("2. Ввод данных из файла");
                WriteLine("3. Выход");
                WriteLine("++++++++++++++");
                WriteLine("Любой другой символ чтоб перейти ко вводу количества");

                var menu1 = Convert.ToInt32(ReadLine());

                switch (menu1)
                {
                    case 1:
                        Clear();
                        Zapolnenie(count, tel);
                        Menu2(count, tel);
                        break;
                    case 2:
                        Clear();
                        ZapolnenieIzFaila(count, tel);
                        Menu2(count, tel);
                        break;
                    case 3:
                        Process.GetCurrentProcess().Kill();
                        break;
                }
            }
        }


        private static void Menu2(int count, Tv[] tel)
        {
            Clear();

            WriteLine("1. Удаление данных");
            WriteLine("2. Вывод данных");
            WriteLine("3. Сортировка");
            WriteLine("4. Запись в файл");
            WriteLine("5. Выход");
            WriteLine("++++++++++++++");
            WriteLine("Любой другой символ чтоб перейти ко вводу количества");
            var menu2 = Convert.ToInt32(ReadLine());

            switch (menu2)
            {
                case 1:
                    Clear();
                    RemoveElement(tel);
                    Menu2(count, tel);
                    break;
                case 2:
                    Clear();
                    Show(tel);
                    WriteLine("====================================");
                    WriteLine("Для возврата нажмите на любую кнопку");
                    ReadKey();
                    Menu2(count, tel);
                    break;
                case 3:
                    Clear();
                    WriteLine("1. Сортировка фирм");
                    WriteLine("2. Сортировка длины");
                    WriteLine("3. Сортировка цвета");
                    WriteLine("4. Сортировка цены");
                    WriteLine("5. Сортировка входимости в малогабаритные");
                    var menu3 = Convert.ToInt32(ReadLine());
                    MenuSort(menu3, tel, count);
                    break;
                case 4:
                    ZapisVFail(count, tel);
                    Menu2(count, tel);
                    break;
                case 5:
                    Process.GetCurrentProcess().Kill();
                    break;
            }
        }

        private static void MenuSort(int menu3, Tv[] tel, int count)
        {
            switch (menu3)
            {
                case 1:
                    Clear();
                    SortFirm(tel);
                    Menu2(count, tel);
                    break;
                case 2:
                    Clear();
                    SortLength(tel);
                    Menu2(count, tel);
                    break;
                case 3:
                    Clear();
                    SortColor(tel);
                    Menu2(count, tel);
                    break;
                case 4:
                    Clear();
                    SortPrice(tel);
                    Menu2(count, tel);
                    break;
                case 5:
                    Clear();
                    SortSmall(tel);
                    Menu2(count, tel);
                    break;
            }
        }

        private static void SortFirm(Tv[] tel)
        {
            for (var i = 0; i < tel.Length - 1; i++)
            for (var j = i + 1; j < tel.Length; j++)
                if (tel[i].Firm.CompareTo(tel[j].Firm) == 1)
                    Sort(i, j, tel);
        }

        private static void SortLength(Tv[] tel)
        {
            for (var i = 0; i < tel.Length - 1; i++)
            for (var j = i + 1; j < tel.Length; j++)
                if (tel[i].Length > tel[j].Length)
                    Sort(i, j, tel);
        }

        private static void SortColor(Tv[] tel)
        {
            for (var i = 0; i < tel.Length - 1; i++)
            for (var j = i + 1; j < tel.Length; j++)
                if (tel[i].Color.CompareTo(tel[j].Color) == 1)
                    Sort(i, j, tel);
        }

        private static void SortPrice(Tv[] tel)
        {
            for (var i = 0; i < tel.Length - 1; i++)
            for (var j = i + 1; j < tel.Length; j++)
                if (tel[i].Price < tel[j].Price)
                    Sort(i, j, tel);
        }

        private static void SortSmall(Tv[] tel)
        {
            for (var i = 0; i < tel.Length - 1; i++)
            for (var j = i + 1; j < tel.Length; j++)
                if (!tel[i].Small)
                    Sort(i, j, tel);
        }

        private static void Sort(int i, int j, Tv[] tel)
        {
            var temp1 = tel[i].Firm;
            tel[i].Firm = tel[j].Firm;
            tel[j].Firm = temp1;
            var temp2 = tel[i].Length;
            tel[i].Length = tel[j].Length;
            tel[j].Length = temp2;
            var temp3 = tel[i].Color;
            tel[i].Color = tel[j].Color;
            tel[j].Color = temp3;
            var temp4 = tel[i].Price;
            tel[i].Price = tel[j].Price;
            tel[j].Price = temp4;
            var temp5 = tel[i].Small;
            tel[i].Small = tel[j].Small;
            tel[j].Small = temp5;
        }

        private static void RemoveElement(Tv[] tel)
        {
            WriteLine("Введите элемент, который вы желаете удалить");
            Show(tel);
            var remover = Convert.ToInt32(ReadLine());
            for (var i = 0; i < tel.Length; i++)
                if (i == remover)
                    tel[i].Removed = true;
        }

        private static void Zapolnenie(int count, Tv[] tel)
        {
            WriteLine("Заполните данные");
            for (var i = 0; i < count; i++)
            {
                WriteLine("Введите фирму|диагональ|цвет|цену");

                tel[i] = new Tv(ReadLine().Split('|'));
            }
        }

        private static void ZapolnenieIzFaila(int count, Tv[] tel)
        {
            using (var reader = new StreamReader("File.txt", Encoding.Default))
            {
                for (var i = 0; i < count; i++)
                    tel[i] = new Tv(reader.ReadLine().Split('|'));
            }
        }

        private static void ZapisVFail(int count, Tv[] tv)
        {
            {
                var str = new string[count];
                for (var i = 0; i < count; i++)
                    Stringing(tv, i, str);
                for (var i = 0; i < count; i++)
                    File.WriteAllLines("output.txt", str);
            }
        }

        private static void Show(Tv[] tv)
        {
            var str = new string[tv.Length];
            for (var i = 0; i < tv.Length; i++)
            {
                Stringing(tv, i, str);
                WriteLine(str[i]);
            }
        }

        private static void Stringing(Tv[] tv, int i, string[] str)
        {
            if (tv[i].Removed == false)
                if (tv[i].Small)
                    str[i] = i +
                             ") Фирма " + tv[i].Firm + ", диагональ " + tv[i].Length + ", цвет " + tv[i].Color +
                             ", цена " + tv[i].Price + ", подходит для установки в малогабаритных помещениях";
                else
                    str[i] = i +
                             ") Фирма " + tv[i].Firm + ", диагональ " + tv[i].Length + ", цвет " + tv[i].Color +
                             ", цена " + tv[i].Price + ", не подходит для установки в малогабаритных помещениях";
        }
    }


    internal struct Tv
    {
        public string Firm;
        public double Length;
        public string Color;
        public int Price;
        public bool Small;
        public bool Removed;

        public Tv(string[] args)
        {
            Firm = args[0];
            Length = int.Parse(args[1]);
            Color = args[2];
            Price = int.Parse(args[3]);
            if (Length < 14)
                Small = true;
            else
                Small = false;
            Removed = false;
        }
    }
}