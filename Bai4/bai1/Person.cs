using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai1
{
    internal class Person
    {
        private string id;
        private string name;
        private int age;
        private string email;
        private string address;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value<18)
                {
                    Console.OutputEncoding = Encoding.UTF8;
                    throw new ArgumentException("Tuổi phải lớn hơn 0");
                }
                age = value;
            }
        }
        //public Person()
        //{

        //}
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public void checkAge()
        {
            Console.OutputEncoding = Encoding.UTF8;
            if (this.Age < 18)
            {
                Console.WriteLine("Bạn còn nhỏ");
            }
            else
            {
                Console.WriteLine("Bạn đủ tuổi bầu cử");
            }
        }
        public void Input()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.Write("Nhập Id: ");
            this.Id=Console.ReadLine();
            Console.Write("Nhập tên: ");
            this.Name=Console.ReadLine();
            Console.Write("Nhập tuổi: ");
            this.Age = int.Parse(Console.ReadLine());
            Console.Write("Nhập email: ");
            this.Email=Console.ReadLine();
            Console.Write("Nhập địa chỉ: ");
            this.Address=Console.ReadLine();
        }
        public void Output()
        {
            Console.WriteLine($"{this.Id}\t{this.Name}\t{this.Age}\t{this.Email}\t{this.Address}");
        }
    }
}
