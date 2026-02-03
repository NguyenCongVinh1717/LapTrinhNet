using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhToan
{
    internal class Program
    {
        public static float tong(float a,float b)
        {
            return a + b;
        }
        public static float hieu(float a, float b)
        {
            return a - b;
        }
        public static float tich(float a, float b)
        {
            return a * b;
        }
        public static float chia(float a, float b)
        {
            return a / b;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            float a, b;
            char pt;
            Console.WriteLine("Nhập 2 số thực:");
            Console.Write("a=");
            a =float.Parse(Console.ReadLine());
            Console.Write("b=");
            b = float.Parse(Console.ReadLine());
            Console.WriteLine("Nhập phép tính:");
            pt=char.Parse(Console.ReadLine());
            if (pt == '+')
            {
                Console.WriteLine($"tong={tong(a, b)}");
            }
            else if (pt =='-')
            {
                Console.WriteLine($"hieu={hieu(a, b)}");
            }
            else if (pt == '*')
            {
                Console.WriteLine($"tich={tich(a, b)}");
            }
            else if(pt == '/')
            {
                if(b==0)
                {
                    Console.WriteLine("So bi chia phai khac 0");
                    return;
                }
                Console.WriteLine($"thuong={chia(a,b)}");
            }
            else
            {
                return;
            }


        }
    }
}
