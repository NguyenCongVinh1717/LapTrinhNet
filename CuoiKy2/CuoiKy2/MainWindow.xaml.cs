using CuoiKy2.Models;
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
using System.Windows.Xps;

namespace CuoiKy2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        QlduocPhamContext db=new QlduocPhamContext();
        public MainWindow()
        {
            InitializeComponent();
            hienThi();
            hienThiCBB();
        }
        private void hienThi()
        {
            var q = from t in db.Thuocs
                    where t.SoLuong <= 200
                    orderby t.TenThuoc
                    select new
                    {
                        t.MaThuoc,
                        t.TenThuoc,
                        t.MaDm,
                        t.GiaBan,
                        t.SoLuong,
                        ThanhTien=t.GiaBan*t.SoLuong
                    };
            dgvTT.ItemsSource=q.ToList();
        }
        private void hienThiCBB()
        {
            var q = from dm in db.DanhMucThuocs
                    select dm;
            danhmuccbb.ItemsSource=q.ToList();
            danhmuccbb.SelectedValuePath = "MaDm";
            danhmuccbb.DisplayMemberPath = "TenDm";
            danhmuccbb.SelectedIndex = 0;
        }
        private bool check()
        {
            if(string.IsNullOrWhiteSpace(matxt.Text)||
                string.IsNullOrWhiteSpace(tentxt.Text)||
                string.IsNullOrWhiteSpace(giatxt.Text)||
                string.IsNullOrWhiteSpace(soluongtxt.Text))
            {
                MessageBox.Show("Bạn cần điền đầy đủ thông tin", "Lỗi");
                return false;
            }
            if(!double.TryParse(giatxt.Text,out double gia) || gia < 0)
            {
                MessageBox.Show("Giá bán là số thực >0", "Lỗi");
                return false;
            }
            if (!int.TryParse(soluongtxt.Text, out int sl) || sl < 0)
            {
                MessageBox.Show("Số lượng là số nguyên >0", "Lỗi");
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (check())
            {
                string ma=matxt.Text;
                Thuoc t = db.Thuocs.SingleOrDefault(x => x.MaThuoc == ma);
                if(t != null)
                {
                    MessageBox.Show("Mã trùng", "Lỗi");
                    return;
                }
                Thuoc thuoc=new Thuoc();
                thuoc.MaThuoc = ma;
                thuoc.TenThuoc=tentxt.Text;
                thuoc.GiaBan=double.Parse(giatxt.Text);
                thuoc.SoLuong=int.Parse(soluongtxt.Text);
                thuoc.MaDm=danhmuccbb.SelectedValue.ToString();
                db.Thuocs.Add(thuoc);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công", "Thông báo");
                hienThi();
                return;
            }
        }

        private void selection_changed(object sender, SelectionChangedEventArgs e)
        {
            dynamic thuoc = dgvTT.SelectedItem;
            if (thuoc != null)
            {
                matxt.Text = thuoc.MaThuoc;
                tentxt.Text= thuoc.TenThuoc;
                giatxt.Text= thuoc.GiaBan.ToString();
                soluongtxt.Text= thuoc.SoLuong.ToString();
                danhmuccbb.SelectedValue = thuoc.MaDm;
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult rs = MessageBox.Show("Bạn có chắc muốn xoá?", "Xác nhận", MessageBoxButton.YesNo);
            if (rs == MessageBoxResult.Yes)
            {
                if (!string.IsNullOrWhiteSpace(matxt.Text))
                {
                    Thuoc t = db.Thuocs.SingleOrDefault(x => x.MaThuoc == matxt.Text);
                    if (t == null)
                    {
                        MessageBox.Show("Thuốc không tồn tại", "Lỗi");
                        return;
                    }
                    db.Thuocs.Remove(t);
                    db.SaveChanges();
                    MessageBox.Show("Xoá thành công", "Thông báo");
                    hienThi();
                    return;
                }
                else
                {
                    MessageBox.Show("Nhập mã cần xoá", "Lỗi");
                    return;
                }
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (check())
            {
                string ma = matxt.Text;
                Thuoc t = db.Thuocs.SingleOrDefault(x => x.MaThuoc == ma);
                if (t == null)
                {
                    MessageBox.Show("Thuốc không tồn tại", "Lỗi");
                    return;
                }
                t.TenThuoc = tentxt.Text;
                t.GiaBan = double.Parse(giatxt.Text);
                t.SoLuong = int.Parse(soluongtxt.Text);
                t.MaDm = danhmuccbb.SelectedValue.ToString();
                db.SaveChanges();
                MessageBox.Show("Sửa thành công", "Thông báo");
                hienThi();
                return;
            }
        }

        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            string madm = danhmuccbb.SelectedValue.ToString();
            var q=from t in db.Thuocs
                  where t.MaDm == madm
                  select new
                  {
                      t.MaThuoc,
                      t.TenThuoc,
                      t.MaDm,
                      t.GiaBan,
                      t.SoLuong,
                      ThanhTien = t.GiaBan * t.SoLuong
                  };
            if(q.Count()==0)
            {
                MessageBox.Show("Không có thuốc nào", "Thông báo");
                hienThi();
                return;
            }
            else
            {
                dgvTT.ItemsSource = q.ToList();
            }

        }

        private void btnThongKe_Click(object sender, RoutedEventArgs e)
        {
            MyWindow w=new MyWindow();
            w.Show();
        }

        private void btnXoaForm_Click(object sender, RoutedEventArgs e)
        {
            matxt.Text = "";
            tentxt.Text = "";
            giatxt.Text = "";
            soluongtxt.Text = "";
            danhmuccbb.SelectedIndex = 0;
            hienThi();
        }

        private void btnDong_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}