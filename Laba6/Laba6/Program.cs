using System;
using System.Diagnostics;
using static System.Console;

namespace Laba6
{
    class Program
    {
        private static void Main(string[] args)
        {
            WriteLine("Введите количество телевизоров");
            var count = Convert.ToInt32(ReadLine());
            var tel = new Tv[count];
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
                        Zapolnenie(count, tel);
                        Menu2(count, tel);
                        break;
                    case 2:
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
            WriteLine("3. Выход");
            var menu2 = Convert.ToInt32(ReadLine());
            switch (menu2)
            {
                case 1:
                    Clear();
                    Menu2(count, tel);
                    break;
                case 2:
                    Clear();
                    Show(tel);
                    Menu2(count, tel);
                    break;
                case 3:
                    Process.GetCurrentProcess().Kill();
                    break;
            }
        
            
            
        }

        static void Zapolnenie(int count, Tv[] tel)
        {
            WriteLine("Заполните данные");
            for (int i = 0; i < count; i++)
            {
                WriteLine("Введите фирму");
                tel[i].Firm = ReadLine();
                WriteLine("Введите диагональ");
                tel[i].Length = Convert.ToDouble(ReadLine());
                WriteLine("Введите цвет");
                tel[i].Color = ReadLine();
                WriteLine("Введите цену");
                tel[i].Price = Convert.ToInt32(ReadLine());
                if (tel[i].Length < 14)
                {
                    tel[i].Small = true;
                }
                else
                {
                    tel[i].Small = false;
                }
            }
        }

        static void Show(Tv[] tel)
        {
            foreach (var tv in tel)
            {
                if (tv.Small)
                {
                    WriteLine("Фирма {0}, диагональ {1}, цвет {2}, цена {3}, подходит для установки в малогабаритных помещениях", tv.Firm, tv.Length, tv.Color, tv.Price);
                }
                else
                {
                    WriteLine("Фирма {0}, диагональ {1}, цвет {2}, цена {3}, не подходит для установки в малогабаритных помещениях", tv.Firm, tv.Length, tv.Color, tv.Price);
                }
            }
        }
    }

    

    struct Tv
    {
        public string Firm;
        public double Length;
        public string Color;
        public int Price;
        public bool Small;
    }
}

