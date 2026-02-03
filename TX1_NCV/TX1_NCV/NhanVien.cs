using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TX1_NCV
{
    internal class NhanVien:Person
    {
        private string manv;
        private string chucvu;
        private double luongcb;
        private int hesocv;

        public string Manv
        {
            get { return manv; }
            set { manv = value; }
        }
        public string Chucvu
        {
            get { return chucvu; }
            set { chucvu = value; }
        }
        public double Luongcb
        {
            get { return luongcb; }
            set { luongcb = value; }
        }
        public int Hesocv
        {
            get { return hesocv; }
        }

        public override void nhapTT()
        {
            Console.OutputEncoding = Encoding.UTF8;
            base.nhapTT();
            Console.Write("Nhập mã nhân viên: ");
            this.Manv=Console.ReadLine();
            if (Program.checkMa(this.Manv)==false)
            {
                Console.WriteLine("Mã nhân viên bị trùng!");
                return;
            }
            Console.Write("Nhập chức vụ: ");
            this.Chucvu=Console.ReadLine();
            Console.Write("Nhập lương cơ bản: ");
            this.Luongcb=double.Parse(Console.ReadLine());
            if(this.Chucvu.Equals("Giám đốc"))
            {
                this.hesocv = 10;
            }
            else if(this.Chucvu.Equals("Trưởng phòng")|| this.Chucvu.Equals("Phó giám đốc"))
            {
                this.hesocv = 6;
            }
            else if(this.Chucvu.Equals("Phó phòng"))
            {
                this.hesocv = 4;
            }
            else
            {
                this.hesocv = 2;
            }
        }

        public void xuat()
        {
            Console.WriteLine(
                $"{Manv}\t{Hoten}\t{Diachi}\t{Chucvu}\t{Luongcb}\t{hesocv}"
            );
        }

    }
}
