using BusinessObject;
using DataAccess.Models;
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
    /// Interaction logic for AccountProfile.xaml
    /// </summary>
    public partial class AccountProfile : Window
    {
        private readonly AccountObject accountObject;
        private readonly int accountId;

        public AccountProfile(int accountId)
        {
            accountObject = new AccountObject();
            this.accountId = accountId;
            Loaded += LoadDataAccount;
            InitializeComponent();
        }

        private void LoadDataAccount(object sender, RoutedEventArgs e)
        {
            Account account = accountObject.GetAccountById(accountId);
            txtDisplayName.Text = account.Name;
            txtUserName.Text = account.Username;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (!TakeAccount(out Account? account))
            {
                return;
            }
            account!.Id = accountId;
            accountObject.UpdateAccount(account);
            MessageBox.Show("Cập nhật tài khoản thành công.");

        }

        public bool TakeAccount(out Account? validAccount)
        {
            validAccount = null;
            Account account = accountObject.GetAccountById(accountId);
            if (string.IsNullOrWhiteSpace(txtDisplayName.Text))
            {
                MessageBox.Show("Bạn chưa thêm tên cho tài khoản.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("Bạn chưa thêm User Name.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Bạn chưa thêm password.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtPasswordNew.Text))
            {
                MessageBox.Show("Bạn chưa thêm password mới.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (txtPassword.Text != account.Password)
            {
                MessageBox.Show("Bạn nhập mật khẩu cũ sai.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (txtPasswordNew.Text == txtPassword.Text)
            {
                MessageBox.Show("Mật khẩu mới không được giống mật khẩu hiện tại", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (txtPasswordNew.Text != txtPasswordCurent.Text)
            {
                MessageBox.Show("Mật khẩu mới và nhập lại mật khẩu không trùng khớp.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (txtUserName.Text != account.Username)
            {
                using var context = new QuanLyBilliardsClubContext();
                bool account1 = context.Accounts.Any(t => t.Username == txtUserName.Text);
                if (account1)
                {
                    MessageBox.Show($"Tên người dùng  '{txtUserName.Text}' đã tồn tại.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            validAccount = new Account()
                {
                    Name = txtDisplayName.Text,
                    Username = txtUserName.Text,
                    Password = txtPasswordNew.Text
                };
                return true;
            
        }

    }
}
