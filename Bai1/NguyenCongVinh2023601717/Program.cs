using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenCongVinh2023601717
{
    internal class Program
    {
        public static void Bai1()
        {
            int n;
            Console.Write("Nhập n = ");
            n = int.Parse(Console.ReadLine());

            if (n % 2 == 0)
                Console.WriteLine("n là số chẵn");
            else
                Console.WriteLine("n là số lẻ");

            if (n < 0)
                Console.WriteLine("n là số âm");
            else
                Console.WriteLine("n là số không âm");
        }

        public static void Bai2()
        {
            double dai, rong;
            Console.Write("Nhập chiều dài = ");
            dai = double.Parse(Console.ReadLine());

            Console.Write("Nhập chiều rộng = ");
            rong = double.Parse(Console.ReadLine());

            double chuVi = 2 * (dai + rong);
            double dienTich = dai * rong;

            Console.WriteLine("Chu vi = " + chuVi);
            Console.WriteLine("Diện tích = " + dienTich);
        }

        public static void Bai3a()
        {
            double a, b;
            Console.Write("Nhập a = ");
            a = double.Parse(Console.ReadLine());
            Console.Write("Nhập b = ");
            b = double.Parse(Console.ReadLine());

            if (a == 0)
            {
                if (b == 0)
                    Console.WriteLine("Phương trình vô số nghiệm");
                else
                    Console.WriteLine("Phương trình vô nghiệm");
            }
            else
            {
                double x = -b / a;
                Console.WriteLine("Nghiệm x = " + x);
            }
        }

        public static void Bai3b()
        {
            double a, b, c;
            Console.Write("Nhập a = ");
            a = double.Parse(Console.ReadLine());
            Console.Write("Nhập b = ");
            b = double.Parse(Console.ReadLine());
            Console.Write("Nhập c = ");
            c = double.Parse(Console.ReadLine());

            if (a == 0)
            {
                Console.WriteLine("Đây là phương trình bậc nhất");
                return;
            }

            double delta = b * b - 4 * a * c;

            if (delta < 0)
                Console.WriteLine("Phương trình vô nghiệm");
            else if (delta == 0)
            {
                double x = -b / (2 * a);
                Console.WriteLine("Phương trình có nghiệm kép x = " + x);
            }
            else
            {
                double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                Console.WriteLine("x1 = " + x1);
                Console.WriteLine("x2 = " + x2);
            }
        }

        public static void Bai4()
        {
            double bacLuong, phuCap;
            int ngayCong;

            Console.Write("Nhập bậc lương = ");
            bacLuong = double.Parse(Console.ReadLine());

            Console.Write("Nhập ngày công = ");
            ngayCong = int.Parse(Console.ReadLine());

            Console.Write("Nhập phụ cấp = ");
            phuCap = double.Parse(Console.ReadLine());

            int NCTL;
            if (ngayCong < 25)
                NCTL = ngayCong;
            else
                NCTL = 25 + (ngayCong - 25) * 2;

            double tienLinh = bacLuong * 1490000 * NCTL + phuCap;
            Console.WriteLine("Tiền lĩnh = " + tienLinh);
        }

        public static void Bai5()
        {
            int n;
            Console.Write("Nhập số (1-7) = ");
            n = int.Parse(Console.ReadLine());

            switch (n)
            {
                case 1: Console.WriteLine("Chủ nhật"); break;
                case 2: Console.WriteLine("Thứ hai"); break;
                case 3: Console.WriteLine("Thứ ba"); break;
                case 4: Console.WriteLine("Thứ tư"); break;
                case 5: Console.WriteLine("Thứ năm"); break;
                case 6: Console.WriteLine("Thứ sáu"); break;
                case 7: Console.WriteLine("Thứ bảy"); break;
                default: Console.WriteLine("Số không hợp lệ"); break;
            }
        }

        public static void Bai6()
        {
            int n;
            do
            {
                Console.Write("Nhập số nguyên = ");
                n = int.Parse(Console.ReadLine());
            } while (n <= 0);

            Console.WriteLine("Số nguyên dương: " + n);
        }

        public static void Bai7()
        {
            int n;
            Console.Write("Nhập n = ");
            n = int.Parse(Console.ReadLine());

            bool check = true;

            if (n < 2)
                check = false;
            else
            {
                for (int i = 2; i <= Math.Sqrt(n); i++)
                {
                    if (n % i == 0)
                    {
                        check = false;
                        break;
                    }
                }
            }

            if (check)
                Console.WriteLine("n là số nguyên tố");
            else
                Console.WriteLine("n không phải là số nguyên tố");
        }

        public static void Bai8()
        {
            int n;
            Console.Write("Nhập n = ");
            n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                if (i % 5 == 0)
                    continue;
                Console.Write(i + " ");
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Bai1();
            Bai2();
            Bai3a();
            Bai3b();
            Bai4();
            Bai5();
            Bai6();
            Bai7();
            Bai8();
        }
    }
}
