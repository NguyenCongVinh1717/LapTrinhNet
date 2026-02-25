using CuoiKy3.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CuoiKy3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        QlHocSinhContext db=new QlHocSinhContext();
        public MainWindow()
        {
            InitializeComponent();
            hienThi();
            hienThiCBB();
        }
        private void hienThi()
        {
            var q = from hs in db.HocSinhs
                    join lop in db.Lops
                    on hs.MaLop equals lop.MaLop
                    select new
                    {
                        hs.MaHs,
                        hs.HoTen,
                        hs.NgaySinh,
                        hs.GioiTinh,
                        hs.ConTbls,
                        hs.MaLop,
                        lop.TenLop,
                        Tuoi = (DateOnly.FromDateTime(DateTime.Now).Year - hs.NgaySinh.Value.Year)
                    };
            dgvTT.ItemsSource=q.ToList();
        }
        private void hienThiCBB()
        {
            var q = from lop in db.Lops
                    select lop;
            lopcbb.ItemsSource=q.ToList();
            lopcbb.DisplayMemberPath = "TenLop";
            lopcbb.SelectedValuePath = "MaLop";
            lopcbb.SelectedIndex = 0;
        }
        private bool check()
        {
            if(string.IsNullOrWhiteSpace(matxt.Text)||
                string.IsNullOrWhiteSpace(tentxt.Text)||
                nsdate.SelectedDate == null)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Lỗi");
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (check())
            {
                string ma=matxt.Text;
                bool checkEx = db.HocSinhs.Any(x => x.MaHs == ma);
                if (checkEx)
                {
                    MessageBox.Show("Trùng mã học sinh", "Lỗi");
                    return;
                }
                HocSinh hs=new HocSinh();
                hs.MaHs = ma;
                hs.HoTen=tentxt.Text;
                hs.MaLop=lopcbb.SelectedValue.ToString();
                hs.NgaySinh =DateOnly.FromDateTime(nsdate.SelectedDate.Value);
                hs.GioiTinh = radnam.IsChecked == true ?"Nam":"Nữ";
                hs.ConTbls = checkCTBLS.IsChecked == true ? "Có" : "Không";
                db.HocSinhs.Add(hs);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công", "Thông báo");
                hienThi();
                return;
            }
        }

        private void selection_changed(object sender, SelectionChangedEventArgs e)
        {
            dynamic hs = dgvTT.SelectedItem;
            if (hs != null)
            {
                matxt.Text = hs.MaHs;
                tentxt.Text = hs.HoTen;
                nsdate.SelectedDate = hs.NgaySinh.ToDateTime(TimeOnly.MinValue);
                if (hs.GioiTinh == "Nam")
                {
                    radnam.IsChecked = true;
                }
                else
                {
                    radnu.IsChecked = true;
                }
                if(hs.ConTbls == "Có")
                {
                    checkCTBLS.IsChecked = true;
                }
                else
                {
                    checkCTBLS.IsChecked = false;
                }
                lopcbb.SelectedValue = hs.MaLop;
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (check())
            {
                string ma = matxt.Text;
                HocSinh hs = db.HocSinhs.SingleOrDefault(x => x.MaHs == ma);
                if (hs==null)
                {
                    MessageBox.Show("Không tồn tại", "Lỗi");
                    return;
                }
                hs.HoTen = tentxt.Text;
                hs.MaLop = lopcbb.SelectedValue.ToString();
                hs.NgaySinh = DateOnly.FromDateTime(nsdate.SelectedDate.Value);
                hs.GioiTinh = radnam.IsChecked == true ? "Nam" : "Nữ";
                hs.ConTbls = checkCTBLS.IsChecked == true ? "Có" : "Không";
                db.SaveChanges();
                MessageBox.Show("Sửa thành công", "Thông báo");
                hienThi();
                return;
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult rs = MessageBox.Show("Bạn có chắc muốn xoá", "Xác nhận", MessageBoxButton.YesNo);
            if (rs == MessageBoxResult.Yes)
            {
                string ma=matxt.Text;
                HocSinh hs = db.HocSinhs.SingleOrDefault(x => x.MaHs == ma);
                if (hs == null)
                {
                    MessageBox.Show("Không tồn tại", "Lỗi");
                    return;
                }
                db.HocSinhs.Remove(hs);
                db.SaveChanges();
                MessageBox.Show("Xoá thành công", "Thông báo");
                hienThi();
                return;
            }
        }

        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            string lopH=lopcbb.SelectedValue.ToString();
            var q=from hs in db.HocSinhs
                  join lop in db.Lops
                  on hs.MaLop equals lop.MaLop
                  where hs.MaLop == lopH
                  select new
                  {
                      hs.MaHs,
                      hs.HoTen,
                      hs.NgaySinh,
                      hs.GioiTinh,
                      hs.ConTbls,
                      hs.MaLop,
                      lop.TenLop,
                      Tuoi = (DateOnly.FromDateTime(DateTime.Now).Year - hs.NgaySinh.Value.Year)
                  };
            if(q.ToList().Count()==0)
            {
                MessageBox.Show("Không có học sinh nào", "Thông báo");
                hienThi();
                return;
            }
            dgvTT.ItemsSource = q.ToList();
        }

        private void btnXoaForm_Click(object sender, RoutedEventArgs e)
        {
            matxt.Text = "";
            tentxt.Text = "";
            nsdate.SelectedDate = null;
            radnam.IsChecked = true;
            checkCTBLS.IsChecked = false;
            lopcbb.SelectedIndex=0;
            hienThi();
        }

        private void btnDong_Click(object sender, RoutedEventArgs e)
        {
            Close();    
        }

        private void btnThongKe_Click(object sender, RoutedEventArgs e)
        {
            MyWindow w = new MyWindow();
            w.Show();
        }
    }
}