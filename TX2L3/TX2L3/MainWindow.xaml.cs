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

namespace TX2L3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<NhanVien> ds=new ObservableCollection<NhanVien>();
        List<string> phong = new List<string>() { "Phòng nhân sự", "Phòng quản lý", "Phòng giám đốc" };
        public MainWindow()
        {
            InitializeComponent();
            dgvHT.ItemsSource = ds;
            cbbphong.ItemsSource = phong;
        }
        bool checkMa(string ma)
        {
            return ds.Any(x => string.Equals(x.manv, txtma.Text, StringComparison.OrdinalIgnoreCase));
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtma.Text)||
                string.IsNullOrWhiteSpace(txtten.Text)||
                string.IsNullOrWhiteSpace(txthsl.Text)||
                cbbphong.SelectedItem==null||
                datans.SelectedDate == null)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Lỗi");
                return;
            }
            if (checkMa(txtma.Text)){
                MessageBox.Show("Mã nhân viên đã tồn tại", "Lỗi");
                return;
            }
            if ((datans.SelectedDate.Value.Date > DateTime.Today.Date))
            {
                MessageBox.Show("Ngày sinh phải trong quá khứ", "Lỗi");
                return;
            }
            if(!float.TryParse(txthsl.Text,out float hsl) || hsl < 0)
            {
                MessageBox.Show("Hệ số lương phải là số thực >=0", "Lỗi");
                return;
            }
            NhanVien nv=new NhanVien();
            nv.manv= txtma.Text;
            nv.hoten= txtten.Text;
            nv.ngaysinh = datans.SelectedDate.Value.ToString("dd/MM/yyyy");
            nv.gioitinh = radnam.IsChecked == true ? "Nam" : "Nữ";
            nv.phongban = cbbphong.SelectedItem.ToString();
            nv.hesoluong=float.Parse(txthsl.Text);
            ds.Add(nv);
            MessageBox.Show("Thêm thành công", "Thông báo");
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            string ma=txtma.Text;
            NhanVien ex=ds.FirstOrDefault(x =>string.Equals(x.manv,ma,StringComparison.OrdinalIgnoreCase));
            if(ex==null)
            {
                MessageBox.Show("Nhân viên không tồn tại", "Lỗi");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtma.Text) ||
    string.IsNullOrWhiteSpace(txtten.Text) ||
    string.IsNullOrWhiteSpace(txthsl.Text) ||
    cbbphong.SelectedItem == null ||
    datans.SelectedDate == null)
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Lỗi");
                return;
            }
            if ((datans.SelectedDate.Value.Date > DateTime.Today.Date))
            {
                MessageBox.Show("Ngày sinh phải trong quá khứ", "Lỗi");
                return;
            }
            if (!float.TryParse(txthsl.Text, out float hsl) || hsl < 0)
            {
                MessageBox.Show("Hệ số lương phải là số thực >=0", "Lỗi");
                return;
            }
            ex.hoten = txtten.Text;
            ex.ngaysinh = datans.SelectedDate.Value.ToString("dd/MM/yyyy");
            ex.gioitinh = radnam.IsChecked == true ? "Nam" : "Nữ";
            ex.phongban = cbbphong.SelectedItem.ToString();
            ex.hesoluong = float.Parse(txthsl.Text);
            MessageBox.Show("Cập nhật thành công", "Thông báo");
            dgvHT.Items.Refresh();
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            string ma = txtma.Text;
            MessageBoxResult rs = MessageBox.Show($"Bạn có chắc muốn xoá nhân viên mã {ma} này không", "Xác nhận", MessageBoxButton.YesNo);
            if (rs == MessageBoxResult.Yes)
            {
                NhanVien ex = ds.FirstOrDefault(x => string.Equals(x.manv, ma, StringComparison.OrdinalIgnoreCase));
                if (ex == null)
                {
                    MessageBox.Show("Nhân viên không tồn tại", "Lỗi");
                    return;
                }
                ds.Remove(ex);
                MessageBox.Show("Xoá thành công", "Thông báo");
            }
        }

        private void btnTim_Click(object sender, RoutedEventArgs e)
        {
            string phong = cbbphong.SelectedItem.ToString();

            List<NhanVien> kq=ds.Where(x=>string.Equals(x.phongban, phong, StringComparison.OrdinalIgnoreCase)).ToList();
            if (kq.Count == 0)
            {
                MessageBox.Show("Không có nhân viên nào", "Thông báo");
                return;
            }
            TimTheoPhong obj=new TimTheoPhong(kq);
            obj.Show();
        }

        private void btnXoaForm_Click(object sender, RoutedEventArgs e)
        {
            txtma.Clear();
            txtten.Clear();
            txthsl.Clear();
            cbbphong.SelectedIndex = 0;
            radnam.IsChecked = true;
            datans.SelectedDate = null;
        }

        private void btnDong_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void selection_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (dgvHT.SelectedItem == null)
            {
                return;
            }
            NhanVien nv=dgvHT.SelectedItem as NhanVien;
            if(nv != null)
            {
                txtma.Text = nv.manv;
                txtten.Text=nv.hoten;
                datans.SelectedDate = DateTime.ParseExact(nv.ngaysinh, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (nv.gioitinh == "Nam")
                {
                    radnam.IsChecked = true;
                }
                else
                {
                    radnu.IsChecked = true;
                }
                cbbphong.SelectedItem = nv.phongban;
                txthsl.Text =nv.hesoluong.ToString();
            }
        }
    }
}