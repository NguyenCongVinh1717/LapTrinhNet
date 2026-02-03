using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace NCVLT2
{
    internal class Program
    {
        static List<Vehicle> vc = new List<Vehicle>();
        
        public static bool checkExist(string id)
        {
            foreach (Vehicle vehicle in vc)
            {
                if (string.Equals(vehicle.Id, id, StringComparison.OrdinalIgnoreCase))
                {
                  
                    
                    
                    
                    return true;
                }
            }
            return false;
        }
        public static void nhap()
        {
            for(int i=0; i<1; i++)
            {
                Vehicle car = new Car();
                Console.WriteLine($"Nhập ô tô thứ {i+1}");
                car.Input();
                vc.Add(car);
            }
            for (int i = 0; i < 1; i++)
            {
                Vehicle truck = new Truck();
                Console.WriteLine($"Nhập xe tải thứ {i + 1}");
                truck.Input();
                vc.Add(truck);
            }
        }
        public static void hienThi()
        {
            if(vc.Count == 0)
            {
                Console.WriteLine("Không có xe nào trong danh sách");
                return;
            }
            Console.WriteLine($"{"ID",-8} | {"MAKER",-12} | {"MODEL",-12} | {"YEAR",-6} | {"PRICE",10} | {"COLOR/TRUCKLOAD",10}");
            foreach (Vehicle vehicle in vc)
            {
                vehicle.Output();
            }
        }
        public static void timTheoId()
        {
            string id;
            Console.Write("Nhập Id muốn tìm: ");
            id=Console.ReadLine();
            if (checkExist(id) == false)
            {
                Console.WriteLine("Không tồn tại");
            }
            else
            {
                foreach (Vehicle vehicle in vc)
                {
                    if (string.Equals(vehicle.Id, id, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"{"ID",-8} | {"MAKER",-12} | {"MODEL",-12} | {"YEAR",-6} | {"PRICE",10} | {"COLOR/TRUCKLOAD",10}");
                        vehicle.Output();
                    }
                }
            }
        }

        public static void timTheoMaker()
        {
            string maker;
            int cnt = 0;
            Console.Write("Nhập maker muốn tìm: ");
            maker = Console.ReadLine();
            foreach(Vehicle vehicle in vc)
            {
                if(string.Equals(vehicle.Maker, maker, StringComparison.OrdinalIgnoreCase))
                {
                    vehicle.Output();
                    cnt++;
                }
            }
            if( cnt == 0)
            {
                Console.WriteLine("Không có xe nào");
            }
        }
        public static void sapXepTheoGia()
        {
            Console.WriteLine("---------------------------------TRƯỚC KHI SẮP THEO GIÁ---------------------------");
            hienThi();
            Console.WriteLine("---------------------------------SAU KHI SẮP THEO GIÁ-----------------------------");
            for(int i = 0; i < vc.Count; i++)
            {
                for(int j = i + 1; j < vc.Count; j++)
                {
                    if (vc[i].Price > vc[j].Price)
                    {
                        Vehicle tmp=vc[i];
                        vc[i] = vc[j];
                        vc[j] = tmp;
                    }
                }
            }
            hienThi();
        }
        public static void sapXepTheoNam()
        {
            Console.WriteLine("---------------------------------TRƯỚC KHI SẮP THEO NĂM---------------------------");
            hienThi();
            Console.WriteLine("---------------------------------SAU KHI SẮP THEO NĂM-----------------------------");
            for (int i = 0; i < vc.Count; i++)
            {
                for (int j = i + 1; j < vc.Count; j++)
                {
                    if (vc[i].Year > vc[j].Year)
                    {
                        Vehicle tmp = vc[i];
                        vc[i] = vc[j];
                        vc[j] = tmp;
                    }
                }
            }
            hienThi();
        }
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Vehicle v=new Vehicle();
            string chon;
            do
            {
                Console.WriteLine("-------------------------MENU------------------------");
                Console.WriteLine("1. Nhập dữ liệu");
                Console.WriteLine("2. Hiển thị dữ liệu");
                Console.WriteLine("3. Tìm theo mã định danh (ID)");
                Console.WriteLine("4. Tìm theo hãng sản xuất (Maker)");
                Console.WriteLine("5. Sắp xếp theo giá");
                Console.WriteLine("6. Sắp xếp theo năm sản xuất");
                Console.WriteLine("7. Kết thúc chương trình");
                Console.Write("Vui lòng chọn: ");
                chon = Console.ReadLine();

                if (chon.Equals("1"))
                {
                    nhap();
                }
                else if (chon.Equals("2"))
                {
                    hienThi();
                }
                else if (chon.Equals("3"))
                {
                    timTheoId();
                }
                else if (chon.Equals("4"))
                {
                    timTheoMaker();
                }
                else if (chon.Equals("5"))
                {
                    sapXepTheoGia();
                }
                else if (chon.Equals("6"))
                {
                    sapXepTheoNam();
                }
                else if (chon.Equals("7"))
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Vui lòng chọn theo MENU");
                }
            } while (!chon.Equals("7"));
        }
    }
}
