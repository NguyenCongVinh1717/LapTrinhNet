using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhSach
{
    internal class Program
    {
        public static void xuat(List<int> l)
        {
            foreach (var item in l)
            {
                Console.Write(item);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
        public static void xoaAm(List<int> l)
        {
            int d = 0;
            for (int i = 0; i < l.Count; i++)
            {
                if(l[i] < 0)
                {
                    l.RemoveAt(i);
                    d++;
                }
            }
            if (d == 0){
                Console.WriteLine("Không có phần tử âm");
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding  = Encoding.UTF8;
            List<int> list = new List<int>();
            for(int i = 0; i <=4; i++)
            {
                int n;
                Console.Write($"Nhập phần tử thứ {i+1}:");
                n = int.Parse( Console.ReadLine() );
                list.Add(n);
            }
            Console.WriteLine("---------------Mảng ban đầu--------------");
            xuat(list);
            Console.WriteLine("---------------Sắp tăng--------------");
            list.Sort();
            xuat(list);
            Console.WriteLine("---------------Xóa âm----------------");
            xoaAm(list);
            xuat(list);
            Console.WriteLine("--------------Nhập x bất kì---------");
            int x;
            Console.Write("Nhập x=");
            x= int.Parse( Console.ReadLine());
            list.Add(x);
            list.Sort();
            Console.WriteLine("-------------Danh sách bổ sung---------");
            xuat(list);

        }
    }
}
