using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhSachBTVN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            List<string> ThanhPho = new List<string>();

            // 2. Thêm 5 thành phố
            ThanhPho.Add("Hà Nội");
            ThanhPho.Add("Hồ Chí Minh");
            ThanhPho.Add("Hải Phòng");
            ThanhPho.Add("Đà Nẵng");
            ThanhPho.Add("Cần Thơ");

            // 3. Sắp xếp tăng
            ThanhPho.Sort();

            Console.WriteLine("Danh sách thành phố sau khi sắp xếp:");
            foreach (string tp in ThanhPho)
            {
                Console.WriteLine(tp);
            }

            // 4. Xóa "Hà Nội"
            ThanhPho.Remove("Hà Nội");

            // 5. Thêm 5 thành phố
            ThanhPho.Add("Biên Hòa");
            ThanhPho.Add("Nha Trang");
            ThanhPho.Add("Vũng Tàu");
            ThanhPho.Add("Huế");
            ThanhPho.Add("Buôn Ma Thuột");

            // 6. In
            Console.WriteLine("\nDanh sách thành phố sau khi cập nhật:");
            foreach (string tp in ThanhPho)
            {
                Console.WriteLine(tp);
            }
        }
    }
}
