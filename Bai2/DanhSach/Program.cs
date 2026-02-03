using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhSach
{
    internal class Program
    {
        public static bool ktraSNT(int n)
        {
            bool check = true;
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    check= false;
                    break;
                }
            }
            return check;
        }
        public static void DanhSach()
        {
            int n;
            Console.WriteLine("Nhập n=");
            n = int.Parse(Console.ReadLine());
            int[] a=new int[n];
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine("a["+i+"]=");
                a[i]=int.Parse(Console.ReadLine());
            }
            for(int i = 0; i < n; i++)
            {
                if (a[i] % 2 == 0){
                    Console.WriteLine("Số chẵn: " + a[i]);
                }
                if(a[i] %2 != 0)
                {
                    Console.WriteLine("Số lẻ: " + a[i]);
                }
                if (ktraSNT(a[i]))
                {
                    Console.WriteLine("Số NT: " + a[i]);
                }
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            DanhSach();
        }
    }
}
