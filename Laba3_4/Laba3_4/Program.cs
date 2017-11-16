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
                int[,] array = new int[n,n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        array[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                }
            }
        }

        double SredneeArifm(int[,] arr, int n)
        {
            int sredn = 0;
            for (int i = n-1; i > 0; i--)
            {
                for (int j = n - 1; j > 0; j--)
                {
                    if (j == i)
                    {
                        sredn += arr[i, j];
                    }
                }
            }
            return sredn / n;
        }

        void ZamenaNaGlavnoy()
        {
            
        }
    }
}
