using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chuoi
{
    internal class Program
    {
        public static void ktDX(string s)
        {
            int d = 0;
            int l = 0;
            int r = s.Length - 1;
            while (l < r)
            {
                if (s[l] == s[r])
                {
                    d++;
                }
                l++;
                r--;
            }
            if (d == s.Length / 2)
            {
                Console.WriteLine("Mảng đối xứng");
            }
            else
            {
                Console.WriteLine("Mảng k đối xứng");
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string s;
            Console.Write("Nhập chuỗi s:");
            s= Console.ReadLine();
            ktDX(s);

        }
    }
}
