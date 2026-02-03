using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fibonaci
{
    internal class Program
    {
        public static void fibonaci()
        {
            int n, f1, f2;
            f1 = f2 = 1;
            Console.WriteLine("nhập số nguyên dương n=");
            n=int.Parse(Console.ReadLine());
            if (n >= 1)
            {
                Console.WriteLine(f1+",");
            }
            if(n >= 2)
            {
                Console.WriteLine(f2+",");
            }

            for (int i = 3; i <= n ; i++)
            {
                int f = f1 + f2;
                Console.WriteLine(f+",");
                f1 = f2;
                f2 = f;

            }
        }
        public static int fibonaci2(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }
            else
            {
                return fibonaci2(n-1)+fibonaci2(n-2);
            }
        }
        public static void xuat(int n)
        {
            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine(fibonaci2(i)+",");
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            fibonaci();
            int n;
            Console.WriteLine("nhập số nguyên dương n=");
            n = int.Parse(Console.ReadLine());
            xuat(n);
        }
    }
}
