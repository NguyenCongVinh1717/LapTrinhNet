using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh
{
    internal class ThiSinhA
    {
        private string sobaodanh;
        private string hoten;
        private string diachi;
        private float toan;
        private float ly;
        private float hoa;
        private float diemut;
        private float tongdiem;

        public string Sobaodanh
        {
            get { return sobaodanh; }
            set { sobaodanh = value; }
        }
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
        public float Toan
        {
            get { return toan; }

            set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentException("Điểm phải thuộc 0 đến 10");
                }
                toan = value;
            }
        }
        public float Ly
        {
            get { return ly; }
            set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentException("Điểm phải thuộc 0 đến 10");
                }
                ly = value;
            }
        }
        public float Hoa
        {
            get { return hoa; }
            set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentException("Điểm phải thuộc 0 đến 10");
                }
                hoa = value;
            }
        }
        public float Diemut
        {
            get { return diemut; }
            set { diemut = value; }
        }
        public float Tongdiem
        {
            get
            {
                return toan + ly + hoa + diemut;
            }
        }

        public void nhapTT()
        {
            try
            {
                do
                {
                    Console.Write("Số báo danh: ");
                    this.Sobaodanh = Console.ReadLine();
                    if(Program.checkSBD(this.Sobaodanh) == false)
                    {
                        Console.WriteLine("Trùng mã, nhập lại!");
                    }
                }while(Program.checkSBD(this.Sobaodanh)==false);
                Console.Write("Họ tên: ");
                this.Hoten = Console.ReadLine();
                Console.Write("Địa chỉ: ");
                this.Diachi = Console.ReadLine();
                Console.Write("Toán: ");
                this.Toan = float.Parse(Console.ReadLine());
                Console.Write("Lý: ");
                this.Ly = float.Parse(Console.ReadLine());
                Console.Write("Hóa: ");
                this.Hoa = float.Parse(Console.ReadLine());
                Console.Write("Điểm ưu tiên: ");
                this.Diemut = float.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Vui lòng nhập số!");
                nhapTT();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                nhapTT();
            }
        }
        public void xuatTT()
        {
            Console.WriteLine($"{Sobaodanh,-10}{Hoten,-25}{Diachi,-25}{Toan,-6}{Ly,-6}{Hoa,-6}{Diemut,-8}{Tongdiem,-10}"
);

        }

    }
}
