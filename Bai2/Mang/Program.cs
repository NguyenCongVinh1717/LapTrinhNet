using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mang
{
    internal class Program
    {
        public static void nhapMang(int[] a,int n)
        {
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine($"a[{i}]=");
                a[i]=int.Parse(Console.ReadLine());
            }
        }
        public static void timMinMaxTong(int[] a,int n)
        {
            int m = a[0];
            int M = a[0];
            int S = 0;
            for(int i = 0;i < n; i++)
            {
                if (a[i] < m)
                {
                    m = a[i];
                }
                if(a[i] > M)
                {
                    M= a[i];
                }
                S += a[i];
                
            }
            Console.WriteLine($"Max={M},Min={m},Sum={S}");
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            int n;
            Console.WriteLine("Nhập n=");
            n=int.Parse(Console.ReadLine());
            int[] a=new int[n];
            nhapMang (a,n);
            timMinMaxTong(a,n);
        }
    }
}
