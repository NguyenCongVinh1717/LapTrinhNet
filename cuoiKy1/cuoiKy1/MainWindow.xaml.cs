
using cuoiKy1.Models;
using System.CodeDom.Compiler;
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

namespace cuoiKy1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        QlbanHangContext db=new QlbanHangContext();
        private void hienThi()
        {
            var q = from sp in db.SanPhams
                    join loai in db.LoaiSanPhams
                    on sp.MaLoai equals loai.MaLoai
                    select new
                    {
                        sp.MaSp,
                        sp.TenSp,
                        sp.MaLoai,
                        loai.TenLoai,
                        sp.DonGia,
                        sp.SoLuong,
                        ThanhTien = sp.DonGia * sp.SoLuong,
                    };
            
            dgvTT.ItemsSource = q.ToList();
        }
        private void hienThiCBB()
        {
            var q = from loai in db.LoaiSanPhams
                    select loai;
            loaispcbb.ItemsSource = q.ToList();
            loaispcbb.DisplayMemberPath = "TenLoai";
            loaispcbb.SelectedValuePath = "MaLoai";
            loaispcbb.SelectedIndex = 0;
        }
        public MainWindow()
        {
            InitializeComponent();
            hienThi();
            hienThiCBB();
        }
        private bool check()
        {
            if(string.IsNullOrWhiteSpace(masptxt.Text)||
                string.IsNullOrWhiteSpace(tensptxt.Text)||
                string.IsNullOrWhiteSpace(dongiatxt.Text)||
                string.IsNullOrWhiteSpace(soluongtxt.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Lỗi");
                return false;
            }
            if(!double.TryParse(dongiatxt.Text, out double dg) || dg < 0)
            {
                MessageBox.Show("Giá phải là số thực >0", "Lỗi");
                return false;
            }
            if (!int.TryParse(soluongtxt.Text, out int sl) || sl < 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên >0", "Lỗi");
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (check())
            {
                string ma = masptxt.Text;
                SanPham sp = db.SanPhams.FirstOrDefault(x => x.MaSp == ma);
                if (sp != null)
                {
                    MessageBox.Show("Trùng mã sản phẩm", "Lỗi");
                    return;
                }
                SanPham spN = new SanPham();
                spN.MaSp = ma;
                spN.TenSp = tensptxt.Text;
                spN.MaLoai = loaispcbb.SelectedValue.ToString();
                spN.DonGia = double.Parse(dongiatxt.Text);
                spN.SoLuong = int.Parse(soluongtxt.Text);
                db.SanPhams.Add(spN);
                db.SaveChanges();
                MessageBox.Show("Thêm thành công", "Thông báo");
                hienThi();
                return;
            }
        }

        private void selection_changed(object sender, SelectionChangedEventArgs e)
        {
            dynamic sp = dgvTT.SelectedItem;
            if (sp != null)
            {
                masptxt.Text = sp.MaSp;
                tensptxt.Text= sp.TenSp;
                loaispcbb.SelectedValue=sp.MaLoai;
                dongiatxt.Text=sp.DonGia.ToString();
                soluongtxt.Text=sp.SoLuong.ToString();
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (check())
            {
                string ma=masptxt.Text;
                SanPham spex = db.SanPhams.SingleOrDefault(x => x.MaSp == ma);
                if(spex == null)
                {
                    MessageBox.Show("Không tồn tại sản phẩm", "Lỗi");
                    return;
                }
                spex.TenSp=tensptxt.Text;
                spex.MaLoai=loaispcbb.SelectedValue.ToString();
                spex.DonGia=double.Parse(dongiatxt.Text);
                spex.SoLuong=int.Parse(soluongtxt.Text);
                db.SaveChanges();
                MessageBox.Show("Cập nhật thành công", "Thông báo");
                hienThi();
                return;
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            string ma = masptxt.Text;
            MessageBoxResult rs = MessageBox.Show($"Bạn có chắc muốn xoá sản phẩm {ma} ?","Xác nhận", MessageBoxButton.YesNo);
            if (rs == MessageBoxResult.Yes)
            {
                SanPham spex = db.SanPhams.SingleOrDefault(x => x.MaSp == ma);
                if (spex == null)
                {
                    MessageBox.Show("Không tồn tại sản phẩm", "Lỗi");
                    return;
                }
                db.SanPhams.Remove(spex);
                db.SaveChanges();
                MessageBox.Show("Xoá thành công", "Thông báo");
                hienThi();
                return;
            }
        }

        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            string maloai=loaispcbb.SelectedValue.ToString();
            var q=(from sp in db.SanPhams
                   join loai in db.LoaiSanPhams
                   on sp.MaLoai equals loai.MaLoai
                  where sp.MaLoai== maloai
                   select new
                   {
                       sp.MaSp,
                       sp.TenSp,
                       sp.MaLoai,
                       loai.TenLoai,
                       sp.DonGia,
                       sp.SoLuong,
                       ThanhTien = sp.DonGia * sp.SoLuong,
                   }).ToList();
            if (q.Count() == 0)
            {
                MessageBox.Show($"Không có sản phẩm nào của loại{maloai}","Thông báo");
                return;
            }
            dgvTT.ItemsSource= q;
        }

        private void btnXoaForm_Click(object sender, RoutedEventArgs e)
        {
            masptxt.Text = "";
            tensptxt.Text = "";
            loaispcbb.SelectedIndex = 0;
            dongiatxt.Text = "";
            soluongtxt.Text = "";
            hienThi();
        }

        private void btnDong_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnThongKe_Click(object sender, RoutedEventArgs e)
        {
            new MyWindow().Show();
        }
    }
}