using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TX1_NCV
{
    internal class Person
    {
        private string hoten;
        private string diachi;
        
        public string Hoten
        {
            get { return hoten; }
            set { hoten = value; }
        }
        public string Diachi
        {
            get { return diachi; }
            set { diachi = value; }
        }
        public Person() { }
        public Person(string hoten, string diachi)
        {
            this.hoten = hoten;
            this.diachi = diachi;
        }
        public virtual void nhapTT()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Nhập họ tên: ");
            this.Hoten=Console.ReadLine();
            Console.Write("Nhập địa chỉ: ");
            this.Diachi=Console.ReadLine();
        }
    }
}
