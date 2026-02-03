using System.Collections.ObjectModel;
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

namespace TX2L1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<NhanVien> ds = new ObservableCollection<NhanVien>();
        List<string> pb = new List<string>{ "Tổ chức", "Kế hoạch", "Vật tư" };
        public MainWindow()
        {
            InitializeComponent();
            cbbpb.ItemsSource = pb;
            dgNhanVien.ItemsSource = ds;
        }
        public bool checkMa(string ma)
        {
            return ds.Any(x => string.Equals(x.manv, ma, StringComparison.OrdinalIgnoreCase));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtma.Text)||
                string.IsNullOrWhiteSpace(txtten.Text)||
                string.IsNullOrWhiteSpace(txthsl.Text)
                )
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Lỗi");
                return;
            }
            if(checkMa(txtma.Text))
            {
                MessageBox.Show("Mã nhân viên bị trùng", "Lỗi");
                return;
            }
            if(!double.TryParse(txthsl.Text, out double hsl)||hsl<0){
                MessageBox.Show("Hệ số lương phải là số không âm", "Lỗi");
                return;
            }
            if (datens.SelectedDate.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Ngày sinh phải bé hơn hiện tại", "Lỗi");
                return;
            }
            NhanVien nv=new NhanVien();
            nv.manv = txtma.Text;
            nv.hoten=txtten.Text;
            nv.gioitinh = radNam.IsChecked == true ? "Nam" : "Nữ";
            nv.ngaysinh = datens.SelectedDate.Value.ToString("dd/MM/yyyy");
            nv.phongban = cbbpb.SelectedItem.ToString();
            nv.hesoluong=double.Parse(hsl.ToString());
            ds.Add(nv);
            MessageBox.Show("Thêm thành công", "Thông báo");

        }

        private void xoaformBtn_Click(object sender, RoutedEventArgs e)
        {
            txtma.Text = " ";
            txtten.Text = " ";
            txthsl.Text = " ";
            datens.SelectedDate = null;
            cbbpb.SelectedItem = null;
            radNam.IsChecked = true;
        }

        private void xoaBtn_Click(object sender, RoutedEventArgs e)
        {
            string ma = txtma.Text;
            MessageBoxResult d =MessageBox.Show("Bạn có chắc muốn xoá nhân viên này","Xác nhận",MessageBoxButton.YesNo);

            if (d == MessageBoxResult.Yes)
            {
                NhanVien nv = ds.FirstOrDefault(x => string.Equals(x.manv, ma, StringComparison.OrdinalIgnoreCase));
                if (nv == null)
                {
                    MessageBox.Show("Không tồn tại nhân viên", "Lỗi");
                    return;
                }
                ds.Remove(nv);
                MessageBox.Show("Xoá thành công", "Thông báo");
                return;
            }
        }
    }
}