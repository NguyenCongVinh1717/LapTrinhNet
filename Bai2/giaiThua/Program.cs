using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace giaiThua
{
    internal class Program
    {
        public static void giaiThua()
        {
            int n;
            int gt = 1;
            Console.WriteLine("Nhập n=");
            n=int.Parse(Console.ReadLine());
            if (n == 0 || n == 1)
            {
                Console.WriteLine("Giai thừa là: " + 1);
            }
            for(int i = 2; i <= n; i++)
            {
                gt *=i;
            }
            Console.WriteLine("Giai thừa là: " + gt);
        }
        public static int giaiThua2(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }
            else
            {
                return n*giaiThua2(n - 1);
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            giaiThua();
            int n;
            Console.WriteLine("Nhập n=");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Giai thừa đệ quy là: " + giaiThua2(n));
        }
    }
}
