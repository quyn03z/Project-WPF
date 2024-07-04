
using BusinessObject;
using QuyenND_SE1813_AS01;
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


namespace QuanLyQuanBia
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        private readonly CustomerObject customerObject; 

        //private readonly Custor
        public Login()
        {
            InitializeComponent();
            customerObject = new CustomerObject();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            // Hiển thị thông báo trước khi đóng ứng dụng
            MessageBoxResult result = MessageBox.Show("Bạn có muốn thoát chương trình?", "Thoát chương trình", MessageBoxButton.YesNo, MessageBoxImage.Error);

            // Nếu người dùng chọn "Yes", đóng ứng dụng
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPassword.Password))
            {
                MessageBox.Show("Please input all fields", "Login");
            }

            bool IsLogin = customerObject.Login(txtEmail.Text, txtPassword.Password);

            if (IsLogin)
            {
                MainWindow table = new MainWindow();
                this.Hide();
                table.ShowDialog();
                this.Show();
                Close();

            }
            else
            {
                MessageBox.Show("Login false username or password incorrect", "Login");
            }
        }
    }
}
