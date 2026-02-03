using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1VeNha
{
    internal class Program
    {
        public static void Bai1()
        {
            Console.WriteLine("Hello World");
        }
        public static void Bai2()
        {
            Console.WriteLine("Mèo con đi học");
            Console.WriteLine("Hôm nay trời nắng chang chang");
            Console.WriteLine("Mèo con đi học chẳng mang thứ gì");
            Console.WriteLine("Chỉ mang một cái bút chì");
            Console.WriteLine("Và mang một mẩu bánh mì con con.");
        }

        public static void Bai3()
        {
            double a, b, c;
            Console.Write("Nhập cạnh a = ");
            a = double.Parse(Console.ReadLine());

            Console.Write("Nhập cạnh b = ");
            b = double.Parse(Console.ReadLine());

            Console.Write("Nhập cạnh c = ");
            c = double.Parse(Console.ReadLine());

            if (a > 0 && b > 0 && c > 0 && a + b > c && a + c > b && b + c > a)
            {
                double chuVi = a + b + c;
                double p = chuVi / 2;
                double dienTich = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

                Console.WriteLine("Chu vi = " + chuVi);
                Console.WriteLine("Diện tích = " + dienTich);
            }
            else
            {
                Console.WriteLine("Ba cạnh không tạo thành tam giác");
            }
        }

        public static void Bai4()
        {
            Console.Write("Nhập họ tên: ");
            string hoTen = Console.ReadLine();

            Console.Write("Nhập điểm: ");
            double diem = double.Parse(Console.ReadLine());

            Console.WriteLine("HỌ TÊN: " + hoTen.ToUpper());

            if (diem >= 8)
                Console.WriteLine("Xếp loại: Giỏi");
            else if (diem >= 6.5)
                Console.WriteLine("Xếp loại: Khá");
            else if (diem >= 5)
                Console.WriteLine("Xếp loại: Trung bình");
            else
                Console.WriteLine("Xếp loại: Yếu");
        }

        public static void Bai5()
        {
            int n;
            Console.Write("Nhập n = ");
            n = int.Parse(Console.ReadLine());

            int tong1 = 0;
            for (int i = 1; i <= n; i++)
                tong1 += i;

            double tong2 = 0;
            for (int i = 1; i <= n; i++)
                tong2 += 1.0 / i;

            Console.WriteLine("S = 1 + 2 + ... + n = " + tong1);
            Console.WriteLine("S = 1 + 1/2 + ... + 1/n = " + tong2);
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Bai1();
            Bai2();
            Bai3();
            Bai4();
            Bai5();

        }
    }
}
