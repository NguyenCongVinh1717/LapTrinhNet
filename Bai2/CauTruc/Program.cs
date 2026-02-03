using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CauTruc
{
    internal class Program
    {
        struct HocSinh
        {
            public string hoTen {  get; set; }
            public int tuoi {  get; set; }
            public bool gioiTinh {get; set; }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            int n, tuoiTong;
            tuoiTong = 0;
            Console.WriteLine("Nhập n=");
            n=int.Parse(Console.ReadLine());
            HocSinh[] a=new HocSinh[n];
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine("Nhập thông tin cho học sinh thứ: " + (i + 1));
                Console.WriteLine("Họ tên: ");
                a[i].hoTen=Console.ReadLine();
                Console.WriteLine("Tuổi: ");
                a[i].tuoi = int.Parse(Console.ReadLine());
                Console.WriteLine("Giới tính: ");
                a[i].gioiTinh = bool.Parse(Console.ReadLine());
            }

            for(int i = 0; i < n; i++)
            {
                Console.WriteLine("Thông tin học sinh thứ " + (i + 1));
                Console.WriteLine(a[i].hoTen);
                Console.WriteLine(a[i].tuoi);
                Console.WriteLine(a[i].gioiTinh);
            }
            for (int i = 0; i < n; i++)
            {
                tuoiTong += a[i].tuoi;
            }
            Console.WriteLine("Tổng số tuổi của "+n+" học sinh là: "+tuoiTong);

        }
    }
}
