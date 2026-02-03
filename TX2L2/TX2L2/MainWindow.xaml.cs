using System;
using System.Collections.ObjectModel;
using System.Globalization;
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

namespace TX2L2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<SinhVien> ds=new ObservableCollection<SinhVien>();
        List<string> lop = new List<string>() { "Công nghệ thông tin", "Hệ thống thông tin", "Khoa học máy tính" };
        public MainWindow()
        {
            InitializeComponent();
            cbblop.ItemsSource=lop;
            dgvHienThi.ItemsSource = ds;
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtma.Text) ||
    string.IsNullOrWhiteSpace(txthoten.Text) ||
    string.IsNullOrWhiteSpace(txtdiem.Text) ||
    cbblop.SelectedItem == null ||
    datens.SelectedDate == null)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Lỗi");
                return;
            }
            bool checkMa = ds.Any(x => string.Equals(x.masv, txtma.Text, StringComparison.OrdinalIgnoreCase));
            if (checkMa)
            {
                MessageBox.Show("Mã sinh viên bị trùng", "Lỗi");
                return ;
            }
            if (datens.SelectedDate.Value > DateTime.Today.Date)
            {
                MessageBox.Show("Ngày sinh phải trong quá khứ", "Lỗi");
                return ;
            }
            if (!float.TryParse(txtdiem.Text, out float diem) || diem < 0 || diem > 10)
            {
                MessageBox.Show("Điểm phải là số trong khoảng 0,10", "Lỗi");
                return ;
            }
            SinhVien sv = new SinhVien();
                sv.masv= txtma.Text;
                sv.hoten = txthoten.Text;
                sv.ngaysinh = datens.SelectedDate.Value.ToString("dd/MM/yyyy");
                sv.gioitinh= radnam.IsChecked == true ? "Nam" : "Nữ";
                sv.lop = cbblop.SelectedItem.ToString();
                sv.diem = float.Parse(txtdiem.Text);
                ds.Add(sv);
                MessageBox.Show("Thêm thành công", "Thông báo");
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtma.Text)){
                MessageBox.Show("Vui lòng nhập mã", "Thông báo");
                return;
            }
            string ma=txtma.Text;
            SinhVien exist = ds.FirstOrDefault(x => string.Equals(x.masv, ma, StringComparison.OrdinalIgnoreCase));
            if (exist == null)
            {
                MessageBox.Show("Không tồn tại sinh viên", "Lỗi");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtma.Text) ||
string.IsNullOrWhiteSpace(txthoten.Text) ||
string.IsNullOrWhiteSpace(txtdiem.Text) ||
cbblop.SelectedItem == null ||
datens.SelectedDate == null)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Lỗi");
                return;
            }
            if (datens.SelectedDate.Value > DateTime.Today.Date)
            {
                MessageBox.Show("Ngày sinh phải trong quá khứ", "Lỗi");
                return;
            }
            if (!float.TryParse(txtdiem.Text, out float diem) || diem < 0 || diem > 10)
            {
                MessageBox.Show("Điểm phải là số trong khoảng 0,10", "Lỗi");
                return;
            }
            exist.hoten = txthoten.Text;
                exist.ngaysinh = datens.SelectedDate.Value.ToString("dd/MM/yyyy");
                exist.gioitinh = radnam.IsChecked == true ? "Nam" : "Nữ";
                exist.lop = cbblop.SelectedItem.ToString();
                exist.diem = float.Parse(txtdiem.Text);
                MessageBox.Show("Cập nhật thành công", "Thông báo");
            dgvHienThi.Items.Refresh();

            return;


        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            string ma = txtma.Text;
            MessageBoxResult rs=MessageBox.Show($"Bạn có muốn xoá sinh viên mã {ma} này không","Xác nhận",MessageBoxButton.YesNo);
            if (rs == MessageBoxResult.Yes)
            {
                SinhVien exist = ds.FirstOrDefault(x => string.Equals(x.masv, ma, StringComparison.OrdinalIgnoreCase));
                if (exist == null)
                {
                    MessageBox.Show("Không tồn tại sinh viên", "Lỗi");
                    return;
                }
                ds.Remove(exist);
                MessageBox.Show("Xoá thành công", "Thông báo");
                return;
            }
        }

        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            string lop = cbblop.SelectedItem.ToString();
            List<SinhVien> svLop = ds.Where(x => x.lop == lop).ToList();

            if (svLop.Count == 0)
            {
                MessageBox.Show("Không có sinh viên", "Thông báo");
                return;
            }

            TimTheoLop t = new TimTheoLop(svLop);
            t.Show();

        }

        private void btnXoaForm_Click(object sender, RoutedEventArgs e)
        {
            txtma.Clear();
            txthoten.Clear();
            txtdiem.Clear();
            datens.SelectedDate = null;
            cbblop.SelectedIndex = 0;
        }

        private void btnTaiLai_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void click_Cell(object sender, SelectedCellsChangedEventArgs e)
        {
            if (dgvHienThi.SelectedItem == null) return;

            SinhVien sv = dgvHienThi.SelectedItem as SinhVien;
            if (sv == null) return;

            txtma.Text = sv.masv;
            txthoten.Text = sv.hoten;
            txtdiem.Text = sv.diem.ToString();

            // Giới tính
            radnam.IsChecked = sv.gioitinh == "Nam";
            radnu.IsChecked = sv.gioitinh == "Nữ";

            // Lớp
            cbblop.SelectedItem = sv.lop;

            DateTime dt = DateTime.ParseExact(
    sv.ngaysinh,
    "dd/MM/yyyy",
    CultureInfo.InvariantCulture
);
             datens.SelectedDate = dt;
        }
    }
}