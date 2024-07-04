using BusinessObject;
using QuanLyQuanBia;
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

namespace QuyenND_SE1813_AS01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly CustomerObject customerObject;

        public MainWindow()
        {
            InitializeComponent();
            customerObject = new CustomerObject();
            Loaded += CheckRole;

        }

        private void CheckRole(object sender, RoutedEventArgs e)
        {
            if (CustomerObject.accountLogin != null)
            {
                if (CustomerObject.accountLogin.Role.Equals("normal"))
                {
                    btnProfile.Content = "Profile Account";
                }
            }
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerObject.accountLogin != null)
            {
                if (CustomerObject.accountLogin.Role.Equals("normal"))
                {
                    int customerId = CustomerObject.accountLogin.Id ?? 0;
                    ProfileCustomer profileCustomer = new ProfileCustomer(customerId);
                    profileCustomer.Show();
                }
                else
                {
                    Profile profile = new Profile();
                    profile.ShowDialog();
                }
                Close();
            }
        }

        private void btnHotel_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerObject.accountLogin != null)
            {
                if (CustomerObject.accountLogin.Role.Equals("normal"))
                {
                    MessageBox.Show($"Bạn ko phải là admin", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                   
                }
                else
                {
                    HotelWindow hotel = new HotelWindow();
                    hotel.ShowDialog();
                    Close();
                }
            }

        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {

            if (CustomerObject.accountLogin != null)
            {
                if (CustomerObject.accountLogin.Role.Equals("normal"))
                {
                    MessageBox.Show($"Bạn ko phải là admin", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Error);

                }
                else
                {
                    OrderWindow order = new OrderWindow();
                    order.ShowDialog();
                    Close();
                }
            } 
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();  
            login.Show();
            Close();
        }
    }
}