using BusinessObject;
using DataAcess.Models;
using DataAcess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
    /// Interaction logic for CustomersPopup.xaml
    /// </summary>
    public partial class CustomersPopup : Window
    {

        private  CustomerObject customerObject;
        public Action<object, RoutedEventArgs> WindowClosed;
        public event Action DataReloadRequested;
        private readonly Customer existCustomer;

        public CustomersPopup() => InitProp();

        public void InitProp()
        {
            InitializeComponent();
            customerObject = new CustomerObject();
            Loaded += LoadUpdateForm;
        }

        private void LoadUpdateForm(object sender, RoutedEventArgs e)
        {
            if (existCustomer != null)
            {
                txtFullName.Text = existCustomer.CustomerFullName.ToString();
                txtTelePhone.Text = existCustomer.TelePhone.ToString();
                txtEmail.Text = existCustomer.EmailAddress.ToString();
                dtpDate.Text = existCustomer.CustormerBirthday.ToString("yyyy-MM-dd");
                txtPassword.Text = existCustomer.Password.ToString();
                btnAddRoom.Content = "Update";
            }
        }

        public CustomersPopup(Customer c)
        {
                this.existCustomer = c;
                InitProp();
            
        }
        private void btnAddRoom_Click(object sender, RoutedEventArgs e)
        {
            Customer? customer;
            if (!TakeCustomer(out customer))
            {
                return;
            }
            if (existCustomer != null)
            {
                Customer? tempExistCustomer = existCustomer;
                if (!TakeCustomer(out tempExistCustomer))
                {
                    return;
                }
                customer!.CustomerId = existCustomer.CustomerId;
                customerObject.UpdateCustomer(customer);
            }
            else
            {
                customerObject.AddCustomer(customer);
            }

            WindowClosed?.Invoke(sender, e);
            this.Close();
        }


        public bool TakeCustomer(out Customer? validCustomer)
        {
            validCustomer = null;

            if (string.IsNullOrWhiteSpace(txtFullName.Text))
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
                CustomerFullName = txtFullName.Text,
                TelePhone = txtTelePhone.Text,
                EmailAddress = txtEmail.Text,
                CustormerBirthday = DateOnly.Parse(dtpDate.Text),
                CustormetStatus = true,
                Password = txtPassword.Text
            };

            return true;
        }


        private void btnBackRoom_Click(object sender, object e)
        {
            DataReloadRequested?.Invoke();
            this.Close();
        }

    }
}
