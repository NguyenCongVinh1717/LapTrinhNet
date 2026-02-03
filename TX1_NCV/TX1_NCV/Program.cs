using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TX1_NCV
{
    internal class Program
    {
        private static List<NhanVien> ds=new List<NhanVien>();

        public static bool checkMa(string ma)
        {
            foreach(NhanVien nv in ds)
            {
                if (nv.Manv.Equals(ma)){
                    return false;
                }
            }
            return true;
        }
        public static void themNV()
        {
            Console.WriteLine("Nhập nhân viên muốn thêm:");
            NhanVien nv=new NhanVien();
            nv.nhapTT();
            if (checkMa(nv.Manv) == true)
            {
                ds.Add(nv);
            }
        }
        public static void hienThi()
        {
            if (ds.Count > 0)
            {
                foreach (NhanVien nv in ds)
                {
                    nv.xuat();
                }
            }
            else
            {
                Console.WriteLine("Không có nhân viên nào");
            }
        }
        public static void sapXep()
        {
            for(int i = 0; i < ds.Count; i++)
            {
                for(int j=i+1;j<ds.Count; j++)
                {
                    if (ds[i].Hesocv > ds[j].Hesocv)
                    {
                        NhanVien tmp=ds[i];
                        ds[i]=ds[j];
                        ds[j]=tmp;
                    }
                    else if (ds[i].Hesocv == ds[j].Hesocv)
                    {
                        if (ds[i].Luongcb > ds[j].Luongcb)
                        {
                            NhanVien tmp = ds[i];
                            ds[i] = ds[j];
                            ds[j] = tmp;
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding=Encoding.UTF8;
            string luaChon;
            do
            {
                Console.WriteLine("-----------------MENU-----------------------");
                Console.WriteLine("1.Thêm nhân viên");
                Console.WriteLine("2.Hiển thị");
                Console.WriteLine("3.Sắp xếp");
                Console.WriteLine("4.Thoát");
                Console.Write("Nhập lựa chọn của bạn: ");
                luaChon = Console.ReadLine();
                if (luaChon.Equals("1"))
                {
                    themNV();
                }
                else if (luaChon.Equals("2"))
                {
                    hienThi();
                }
                else if (luaChon.Equals("3"))
                {
                    sapXep();
                    hienThi();
                }
            } while (!luaChon.Equals("4"));
        }
    }
}
