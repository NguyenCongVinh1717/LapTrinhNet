using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhapLieu
{
    internal class Program
    {
        public static void nhapWhile()
        {
            int n;
            Console.Write("Nhập n=");
            n = int.Parse(Console.ReadLine());
            while (n <= 1 || n >= 100)
            {
                Console.WriteLine("n phải nằm trong khoảng 1 đến 100");
                Console.Write("Nhập n=");
                n = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"n={n}");
        }

        public static void nhapDoWhile()
        {
            int n;
            do
            {
                Console.Write("Nhập n=");
                n = int.Parse(Console.ReadLine());
                if(n <= 1 || n >= 100)
                {
                    Console.WriteLine("n phải nằm trong khoảng 1 đến 100");
                    Console.Write("Nhập n=");
                    n = int.Parse(Console.ReadLine());
                }
            }
            while (n <= 1 || n >= 100);
            Console.WriteLine($"n={n}");
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            nhapWhile();
            nhapDoWhile();


        }
    }
}
