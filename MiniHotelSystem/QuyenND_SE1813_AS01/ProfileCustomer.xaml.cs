using BusinessObject;
using DataAcess.Models;
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

namespace QuyenND_SE1813_AS01
{
    /// <summary>
    /// Interaction logic for ProfileCustomer.xaml
    /// </summary>
    public partial class ProfileCustomer : Window
    {
        private readonly CustomerObject customerObject;
        private readonly OrderObject orderObject;
        private readonly int CustomerId;
        public ProfileCustomer(int CustomerId)
        {
            customerObject = new CustomerObject();
            orderObject = new OrderObject();
            this.CustomerId = CustomerId;
            Loaded += LoadDataCustomer;
            InitializeComponent();
        }

        private void LoadDataCustomer(object sender, RoutedEventArgs e)
        {
            Customer cusmoter = customerObject.GetCustomerById(CustomerId);

            txtFullName1.Text = cusmoter.CustomerFullName ;
            txtTelePhone.Text = cusmoter.TelePhone ;
            txtEmail.Text = cusmoter.EmailAddress ;
            txtPassword.Text = cusmoter.Password;
            dtpDate.Text = cusmoter.CustormerBirthday.ToString("yyyy-MM-dd");

            lvOrderHistory.ItemsSource = orderObject.GetOrdersOfCustomer(CustomerId);
        }

        private void btnBackRoom_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();   
            window.Show();
            Close();
        }

        public bool TakeCustomer(out Customer? validCustomer)
        {
            validCustomer = null;

            if (string.IsNullOrWhiteSpace(txtFullName1.Text))
            {
                MessageBox.Show("Bạn chưa thêm tên !!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtTelePhone.Text))
            {
                MessageBox.Show("Bạn chưa thêm số điện thoại !!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Bạn chưa thêm email !!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(dtpDate.Text))
            {
                MessageBox.Show("Bạn chưa thêm birthday !!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Bạn chưa thêm mật khẩu !!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            validCustomer = new Customer()
            {
                CustomerFullName = txtFullName1.Text,
                TelePhone = txtTelePhone.Text,
                EmailAddress = txtEmail.Text,
                CustormerBirthday = DateOnly.Parse(dtpDate.Text),
                CustormetStatus = true,
                Password = txtPassword.Text 
            };

            return true;
        }

        private void btnAddRoom_Click(object sender, RoutedEventArgs e)
        {
            if (!TakeCustomer(out Customer? customer))
            {
                return;
            }
            customer!.CustomerId = CustomerId;
            customerObject.UpdateCustomer(customer);
        }
    }
}
