using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            try
            {
                // Test constructor không tham số + Input
                Circle c1 = new Circle();
                c1.Input();
                c1.Output();

                Console.WriteLine("--------------------");

                // Test constructor có tham số
                Circle c2 = new Circle(5);
                c2.Output();
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi: " + e.Message);
            }
        }
    }
}
