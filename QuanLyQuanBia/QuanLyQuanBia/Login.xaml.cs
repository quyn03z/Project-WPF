using BusinessObject;
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
        private readonly AccountObject accountObject;

        public Login()
        {
            InitializeComponent();
            accountObject = new AccountObject();
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
            if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Password))
            {
                MessageBox.Show("Please input all fields", "Login");
            }

            bool IsLogin = accountObject.Login(txtUserName.Text, txtPassword.Password);

            if (IsLogin)
            {

                QuanLyTable table = new QuanLyTable();
                this.Hide();
                table.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Login false username or password incorrect", "Login");
            }       
        }

    }
}
