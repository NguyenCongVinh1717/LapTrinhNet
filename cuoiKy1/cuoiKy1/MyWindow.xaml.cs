using cuoiKy1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace cuoiKy1
{
    /// <summary>
    /// Interaction logic for MyWindow.xaml
    /// </summary>
    public partial class MyWindow : Window
    {
        public MyWindow()
        {
            InitializeComponent();
            hienThi();
        }
        QlbanHangContext db=new QlbanHangContext();
        private void hienThi()
        {
            var q = from sp in db.SanPhams
                    join loai in db.LoaiSanPhams
                    on sp.MaLoai equals loai.MaLoai
                    group sp by new { loai.MaLoai, loai.TenLoai } into g
                    select new
                    {
                        maLoai = g.Key.MaLoai,
                        tenLoai = g.Key.TenLoai,
                        TongTien = g.Sum(sp => sp.DonGia * sp.SoLuong)
                    };
            if (q.Count() == 0)
            {
                MessageBox.Show("Không có sản phẩm nào", "Thông báo");
                return;
            }

            dgvTK.ItemsSource = q.ToList();
        }
    }
}
