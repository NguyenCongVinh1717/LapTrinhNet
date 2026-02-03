using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bai2
{
    internal class Program
    {
        public static void bai1()
        {
            float dai, rong;
            Console.WriteLine("Nhập chiều dài: ");
            dai=float.Parse(Console.ReadLine());
            Console.WriteLine("Nhập chiều rộng: ");
            rong=float.Parse(Console.ReadLine());
            if (dai <= 0 || rong <= 0 || rong > dai)
            {
                Console.WriteLine("Độ dài không hợp lệ");
            }
            else
            {
                Console.WriteLine("Chu vi là: " + (dai+rong) * 2);
                Console.WriteLine("Diện tích là: " + dai * rong);
            }


        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            bai1 ();
        }
    }
}
