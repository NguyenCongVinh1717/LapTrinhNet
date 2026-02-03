using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai3
{
    internal class Student
    {
        private string id;
        private string name;
        private int mark;
        private int scholarship;

        // Constructor không tham số
        public Student()
        {
            id = "";
            name = "";
            mark = 0;
            scholarship = 0;
        }

        // Constructor 1 tham số (id)
        public Student(string id)
        {
            this.Id = id;
        }

        // Constructor đầy đủ tham số
        public Student(string id, string name, int mark)
        {
            this.Id = id;
            this.Name = name;
            this.Mark = mark; // tự động tính scholarship
        }

        // Property Id
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        // Property Name
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        // Property Mark
        public int Mark
        {
            get { return mark; }
            set
            {
                if (value < 0 || value > 10)
                {
                    Console.OutputEncoding = Encoding.UTF8;
                    throw new ArgumentException("Điểm phải từ 0 đến 10");
                }

                mark = value;

                // Tính học bổng
                if (mark > 8)
                    scholarship = 500;
                else if (mark >= 7)
                    scholarship = 300;
                else
                    scholarship = 0;
            }
        }

        // Property Scholarship (chỉ đọc)
        public int Scholarship
        {
            get { return scholarship; }
        }

        // Nhập dữ liệu
        public void Input()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.Write("Nhập mã sinh viên: ");
            Id = Console.ReadLine();

            Console.Write("Nhập họ tên: ");
            Name = Console.ReadLine();

            Console.Write("Nhập điểm: ");
            Mark = int.Parse(Console.ReadLine());
        }

        // Xuất dữ liệu
        public void Output()
        {
            Console.WriteLine($"{Id}\t{Name}\t{Mark}\t{Scholarship}");
        }
    }
}
