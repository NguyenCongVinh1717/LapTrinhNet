using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuoi
{
    internal class Program
    {
        public static void xuatChuoi(string a)
        {
            for(int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }
        }

        public static void xuatChuoiBoTrang(string a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i].Equals(' '))
                {
                    continue;
                }
                Console.WriteLine(a[i]);
            }
        }
        public static void demKyTu(string a)
        {
            int[] dem = new int[256];
            for (int i = 0; i < a.Length; i++)
            {
                dem[(int)a[i]]++;
            }

            Console.WriteLine("Số lần xuất hiện của mỗi ký tự:");
            for (int i = 0; i < 256; i++)
            {
                if (dem[i] > 0)
                {
                    Console.WriteLine($"Ký tự '{(char)i}' : {dem[i]} lần");
                }
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            string a;
            Console.WriteLine("Nhập chuỗi: ");
            a= Console.ReadLine();
            xuatChuoi(a);
            Console.WriteLine("--------------------------------");
            xuatChuoiBoTrang(a);
            Console.WriteLine("--------------------------------");
            demKyTu(a);
        }
    }
}
