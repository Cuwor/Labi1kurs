using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Laba3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Clear();
                Random ran = new Random();
                int width = ran.Next(1,20);
                var a = new IEnumerable[width];
                int length = ran.Next(1,20);

                for (int i = 0; i < width; i++)
                {
                    var b = new int[length];
                    for (int j = 0; j < length; j++)
                    {
                        b[j] = ran.Next(-2, 20);
                    }
                    a[i] = b;
                }
                
            
                Show(a);
                Uporyadochivanie(a);
                OtricStolb(a);
                ReadKey();
            }
        }

        static void Uporyadochivanie(IEnumerable[] a)
        {
            
            while (true)
            {
                bool flag = false;
                for (int i = 0; i < a.Length - 1; i++)
                {
                    int first = 0;
                    int second = 0;
                    foreach (var current in a[i])
                    {
                        first += Math.Abs((int)current);
                    }
                    foreach (var current in a[i + 1])
                    {
                        second += Math.Abs((int)current);
                    }
                    if (first < second)
                    {
                        var buf = a[i];
                        a[i] = a[i + 1];
                        a[i + 1] = buf;
                        flag = true;
                    }
                }
                if (!flag) break;
            }
            Show(a);
        }
        static void OtricStolb(IEnumerable[] a)
        {
            int maxlength = 0;
            foreach (var current in a)
            {
                if (maxlength < ((int[])current).Length) maxlength = ((int[])current).Length;
            }

            int number = -1;

            for (int i = 0; i < maxlength; i++)
            {
                for (int j = 0; j < a.Length; j++)
                {
                    if (((int[])a[j]).Length > i)
                    {
                        if (((int[])a[j])[i] < 0)
                        {
                            number = i;
                            break;
                        }
                    }
                }
                if (number >= 0) break;
            }
            if (number >= 0) Console.WriteLine("Номер отрицательного столбца: " + (number + 1));
        }

        static void Show(IEnumerable[] a)
        {
            WriteLine("Массив:\n");
            foreach (var current in a)
            {
                foreach (var inserted in current)
                {
                    Write("{0,4}",inserted);
                }
                WriteLine();
            }
            WriteLine("\n==================================================\n");
        }
    }
}
