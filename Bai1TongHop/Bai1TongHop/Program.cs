using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1TongHop
{
    internal class Program
    {
        public static int UCLN(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            while (b != 0)
            {
                int r = a % b;
                a = b;
                b = r;
            }
            return a;
        }

        public static void rutGon()
        {
            int m, n;
            Console.WriteLine("Nhập m=");
            m=int.Parse(Console.ReadLine());
            Console.WriteLine("Nhập n=");
            n=int.Parse(Console.ReadLine());
            if (n == 0)
            {
                Console.WriteLine("n phải khác 0");
                return;
            }
            int ucln=UCLN(m, n);
            m=m/ucln;
            n=n/ucln;
            Console.WriteLine("Phân số sau rút gọn là:"+m+"/"+n);

        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            rutGon();
        }
    }
}
