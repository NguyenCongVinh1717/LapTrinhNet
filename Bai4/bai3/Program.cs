using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            try
            {
                // Test constructor không tham số + Input
                Student s1 = new Student();
                s1.Input();
                s1.Output();

                Console.WriteLine("-------------------");

                // Test constructor 1 tham số
                Student s2 = new Student("SV001");
                s2.Name = "Nguyen Van A";
                s2.Mark = 8;
                s2.Output();

                Console.WriteLine("-------------------");

                // Test constructor đầy đủ
                Student s3 = new Student("SV002", "Tran Thi B", 9);
                s3.Output();
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi: " + e.Message);
            }
        }
    }
}
