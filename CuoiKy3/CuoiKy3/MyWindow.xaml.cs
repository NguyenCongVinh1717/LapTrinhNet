using CuoiKy3.Models;
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

namespace CuoiKy3
{
    /// <summary>
    /// Interaction logic for MyWindow.xaml
    /// </summary>
    public partial class MyWindow : Window
    {
        QlHocSinhContext db=new QlHocSinhContext();
        public MyWindow()
        {
            InitializeComponent();
            hienThi();
        }
        private void hienThi()
        {
            var q = from lop in db.Lops
                    join hs in db.HocSinhs
                    on lop.MaLop equals hs.MaLop into g
                    select new
                    {
                        lop.MaLop,
                        lop.TenLop,
                        SoHS = g.Count()
                    };
            if (q.ToList().Count == 0)
            {
                MessageBox.Show("Không có học sinh nào", "Thông báo");
                return;
            }
            dgvTK.ItemsSource = q.ToList();
        }
    }
}
