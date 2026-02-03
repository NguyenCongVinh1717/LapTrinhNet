using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai4
{
    internal class Circle
    {
        private double radius;

        // Constructor không tham số
        public Circle()
        {
            radius = 0;
        }

        // Constructor có 1 tham số
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        // Property Radius
        public double Radius
        {
            get { return radius; }
            set
            {
                if (value <= 0)
                {
                    Console.OutputEncoding = Encoding.UTF8;
                    throw new ArgumentException("Bán kính phải lớn hơn 0");
                }
                radius = value;
            }
        }

        // Tính diện tích
        public double Area()
        {
            return Math.PI * radius * radius;
        }

        // Tính chu vi
        public double Perimeter()
        {
            return 2 * Math.PI * radius;
        }

        // Nhập dữ liệu
        public void Input()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.Write("Nhập bán kính: ");
            Radius = double.Parse(Console.ReadLine());
        }

        // Xuất dữ liệu
        public void Output()
        {
            Console.WriteLine($"Bán kính: {Radius}");
            Console.WriteLine($"Diện tích: {Area():0.00}");
            Console.WriteLine($"Chu vi: {Perimeter():0.00}");
        }
    }
}
