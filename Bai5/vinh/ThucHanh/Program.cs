using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucHanh
{
    internal class Program
    {
        static List<ThiSinhA> list = new List<ThiSinhA>();
        public static bool checkSBD(string sbd)
        {
            foreach (ThiSinhA t in list)
            {
                if (t.Sobaodanh.Equals(sbd))
                {
                    return false;
                }
            }
            return true;
        }
        public static void them()
        {
            ThiSinhA ts = new ThiSinhA();
            Console.WriteLine("Nhập thí sinh muốn thêm: ");
            ts.nhapTT();
            list.Add(ts);
            Console.WriteLine("Thêm thành công");
        }
        public static void hienThi()
        {
            int cnt = 0;
            Console.WriteLine("DANH SÁCH THÍ SINH");
            Console.WriteLine(
                $"{"SBD",-10}{"Họ tên",-25}{"Địa chỉ",-25}{"Toán",-6}{"Lý",-6}{"Hóa",-6}{"Điểm UT",-8}{"Tổng điểm",-10}"
            );

            foreach (ThiSinhA t in list)
            {
                t.xuatTT();
                cnt++;
            }
            if (cnt == 0)
            {
                Console.WriteLine("Không có thí sinh nào!");
            }
        }
        public static void hienThiTheoTongDiem()
        {
            float tongDiem;
            int cnt = 0;
            Console.Write("Nhập tổng điểm: ");
            tongDiem = float.Parse(Console.ReadLine());
            Console.WriteLine(
                $"{"SBD",-10}{"Họ tên",-25}{"Địa chỉ",-25}{"Toán",-6}{"Lý",-6}{"Hóa",-6}{"Điểm UT",-8}{"Tổng điểm",-10}"
            );

            foreach (ThiSinhA t in list)
            {
                if (t.Tongdiem > tongDiem)
                {
                    t.xuatTT();
                    cnt++;
                }
            }
            if (cnt == 0)
            {
                Console.WriteLine("Không có thí sinh nào!");
            }
        }
        public static void hienThiTheoDiaChi()
        {
            string diaChi;
            int cnt = 0;
            Console.Write("Nhập địa chỉ: ");
            diaChi =Console.ReadLine();
            diaChi.ToLower();
            Console.WriteLine(
                $"{"SBD",-10}{"Họ tên",-25}{"Địa chỉ",-25}{"Toán",-6}{"Lý",-6}{"Hóa",-6}{"Điểm UT",-8}{"Tổng điểm",-10}"
            );

            foreach (ThiSinhA t in list)
            {
                if (string.Equals(t.Diachi,diaChi,StringComparison.OrdinalIgnoreCase))

                {
                    t.xuatTT() ;
                    cnt++;
                }
            }
            if (cnt == 0)
            {
                Console.WriteLine("Không có thí sinh nào!");
            }
        }
        public static void timTheoSBD()
        {
            string sbd;
            Console.Write("Nhập số báo danh: ");
            sbd = Console.ReadLine();
            sbd.ToLower();
            int cnt = 0;
            foreach (ThiSinhA t in list)
            {
                if (string.Equals(t.Sobaodanh, sbd, StringComparison.OrdinalIgnoreCase))

                {
                    Console.WriteLine($"Thí sinh có SBD là: {sbd} có thông tin là:");
                    Console.WriteLine(
                        $"{"SBD",-10}{"Họ tên",-25}{"Địa chỉ",-25}{"Toán",-6}{"Lý",-6}{"Hóa",-6}{"Điểm UT",-8}{"Tổng điểm",-10}");
        
                    t.xuatTT();
                    cnt++;
                    return;
                }
            }
            if (cnt == 0)
            {
                Console.WriteLine("Không có thí sinh nào!");
            }
        }
        public static void xoaTheoSBD()
        {
            string sbd;
            Console.Write("Nhập số báo danh cần xóa: ");
            sbd = Console.ReadLine();
            if (checkSBD(sbd) == true)
            {
                Console.WriteLine("Không có thí sinh");
            }
            else
            {
                foreach (ThiSinhA t in list)
                {
                    if(string.Equals(t.Sobaodanh,sbd, StringComparison.OrdinalIgnoreCase))
                    {
                        list.Remove(t);
                        Console.WriteLine("Xóa thành công");
                        break;
                    }
                }
            }
        }
        public static void suaTheoSBD()
        {
            string sbd;
            Console.Write("Nhập số báo danh cần sửa: ");
            sbd = Console.ReadLine();
            if (checkSBD(sbd) == true)
            {
                Console.WriteLine("Không tồn tại thí sinh");
            }
            else
            {
                foreach (ThiSinhA t in list)
                {
                    if (string.Equals(t.Sobaodanh, sbd, StringComparison.OrdinalIgnoreCase))
                    {
                        try
                        {

                            Console.WriteLine("Nhập lại thông tin:");
                            Console.Write("Họ tên: ");
                            t.Hoten = Console.ReadLine();
                            Console.Write("Địa chỉ: ");
                            t.Diachi = Console.ReadLine();
                            Console.Write("Toán: ");
                            t.Toan = float.Parse(Console.ReadLine());
                            Console.Write("Lý: ");
                            t.Ly = float.Parse(Console.ReadLine());
                            Console.Write("Hóa: ");
                            t.Hoa = float.Parse(Console.ReadLine());
                            Console.Write("Điểm ưu tiên: ");
                            t.Diemut = float.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Vui lòng nhập số!");
                            Console.WriteLine("Nhập lại thông tin:");
                            Console.Write("Họ tên: ");
                            t.Hoten = Console.ReadLine();
                            Console.Write("Địa chỉ: ");
                            t.Diachi = Console.ReadLine();
                            Console.Write("Toán: ");
                            t.Toan = float.Parse(Console.ReadLine());
                            Console.Write("Lý: ");
                            t.Ly = float.Parse(Console.ReadLine());
                            Console.Write("Hóa: ");
                            t.Hoa = float.Parse(Console.ReadLine());
                            Console.Write("Điểm ưu tiên: ");
                            t.Diemut = float.Parse(Console.ReadLine());
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Nhập lại thông tin:");
                            Console.Write("Họ tên: ");
                            t.Hoten = Console.ReadLine();
                            Console.Write("Địa chỉ: ");
                            t.Diachi = Console.ReadLine();
                            Console.Write("Toán: ");
                            t.Toan = float.Parse(Console.ReadLine());
                            Console.Write("Lý: ");
                            t.Ly = float.Parse(Console.ReadLine());
                            Console.Write("Hóa: ");
                            t.Hoa = float.Parse(Console.ReadLine());
                            Console.Write("Điểm ưu tiên: ");
                            t.Diemut = float.Parse(Console.ReadLine());

                        }
                        Console.WriteLine("Sửa thành công");
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                string luaChon;
                do
                {
                    Console.WriteLine("--------------------------MENU---------------------------");
                    Console.WriteLine("1.Nhập thí sinh");
                    Console.WriteLine("2.Hiển thị danh sách");
                    Console.WriteLine("3.Hiển thị theo tổng điểm");
                    Console.WriteLine("4.Hiển thị theo địa chỉ");
                    Console.WriteLine("5.Tìm theo số báo danh");
                    Console.WriteLine("6.Xóa theo số báo danh");
                    Console.WriteLine("7.Sửa theo số báo danh");
                    Console.WriteLine("8.Thoát");
                    Console.Write("Nhập lựa chọn của bạn: ");
                    luaChon = Console.ReadLine();
                    if (luaChon.Equals("1"))
                    {
                        them();
                    }
                    else if (luaChon.Equals("2"))
                    {
                        hienThi();
                    }
                    else if (luaChon.Equals("3"))
                    {
                        hienThiTheoTongDiem();
                    }
                    else if (luaChon.Equals("4"))
                    {
                        hienThiTheoDiaChi();
                    }
                    else if (luaChon.Equals("5"))
                    {
                        timTheoSBD();
                    }
                    else if (luaChon.Equals("6"))
                    {
                        xoaTheoSBD();
                    }
                    else if (luaChon.Equals("7"))
                    {
                        suaTheoSBD();
                    }
                    else if (luaChon.Equals("8"))
                    {
                        Console.WriteLine("ĐÃ THOÁT");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Vui lòng chọn theo MENU");
                    }
                } while (!luaChon.Equals("8"));
            }catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
