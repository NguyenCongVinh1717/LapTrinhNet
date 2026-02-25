using CuoiKy2.Models;
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

namespace CuoiKy2
{
    /// <summary>
    /// Interaction logic for MyWindow.xaml
    /// </summary>
    public partial class MyWindow : Window
    {
        QlduocPhamContext db=new QlduocPhamContext();
        public MyWindow()
        {
            InitializeComponent();
            hienThi();
        }
        private void hienThi()
        {
            var q = from t in db.Thuocs
                    join dm in db.DanhMucThuocs
                    on t.MaDm equals dm.MaDm
                    group t by new { dm.MaDm, dm.TenDm } into g
                    select new
                    {
                        g.Key.MaDm,
                        g.Key.TenDm,
                        TongTien = g.Sum(t => t.GiaBan * t.SoLuong)
                    };
            dgvTK.ItemsSource = q.ToList();

        }
    }
}
