using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamGiac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            float a, b, c;
            do
            {
                Console.WriteLine("Nhập vào 3 cạnh của tam giác");
                Console.Write("a=");
                a = float.Parse(Console.ReadLine());
                Console.Write("b=");
                b = float.Parse(Console.ReadLine());
                Console.Write("c=");
                c = float.Parse(Console.ReadLine());
                if(a < 0 || b < 0 || c < 0 || a + b < c || b + c < a || a + c < b)
                {
                    Console.WriteLine("Độ dài k hợp lệ, nhập lại:");
                    Console.Write("a=");
                    a = float.Parse(Console.ReadLine());
                    Console.Write("b=");
                    b = float.Parse(Console.ReadLine());
                    Console.Write("c=");
                    c = float.Parse(Console.ReadLine());
                }
            }
            while(a<0||b<0||c<0||a+b<c||b+c<a||a+c<b);
            float p = (a + b + c) / 2;
            Console.WriteLine($"Chu vi là {p * 2}");
            Console.WriteLine($"Diện tích là {Math.Sqrt(p*(p-a)*(p-b)*(p-c))}");
        }
    }
}
