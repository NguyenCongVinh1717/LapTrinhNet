using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mang
{
    internal class Program
    {
        public static void nhapMang(int n, int[] a)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write($"a[{i}]=");
                a[i] = int.Parse(Console.ReadLine());
            }
        }
        public static int tinhTongLe(int n, int[] a)
        {
            int tong = 0;
            for(int i = 0; i < n; i++)
            {
                if (a[i] % 2 != 0)
                {
                    tong += a[i];
                }
            }
            return tong;
        }
        public static void xuatMang(int n, int[] a)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(a[i]);
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int n;
            Console.Write("Nhập n=");
            n = int.Parse(Console.ReadLine());
            while (n <= 0)
            {
                Console.WriteLine("n phải >0");
                Console.Write("Nhập n=");
                n = int.Parse(Console.ReadLine());
            }
            int[] a = new int[n];
            nhapMang(n,a);
            Console.WriteLine("-------------Mảng ban đầu------------------");
            xuatMang(n,a);
            Console.WriteLine("-------------Tổng các phần tử lẻ-----------");
            Console.Write($"Tổng lẻ={tinhTongLe(n,a)}"); 

        }
    }
}
