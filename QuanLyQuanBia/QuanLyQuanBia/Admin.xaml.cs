using BusinessObject;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuanLyQuanBia
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        private readonly TableBiaObject tableBiaObject;
        private readonly WaterObject waterObject;
        private readonly AccountObject accountObject;
        private readonly TableCategoryObject categoryObject;
        private readonly BillObject billObject;
        private List<TableCategory> categories;

        public Admin()
        {
            InitializeComponent();
            tableBiaObject = new TableBiaObject();
            waterObject = new WaterObject();
            accountObject = new AccountObject();
            categoryObject = new TableCategoryObject();
            billObject = new BillObject();
            Loaded += Load;

        }

        private void Load(object sender, RoutedEventArgs e)
        {
            LoadTableBia();
            LoadTableWater();
            LoadAccount();
            LoadTableCategory();
            LoadDoanhThu();
        }

        public void LoadTableCategory()
        {
            categories = categoryObject.GetTableCategory();
            cbTableName.ItemsSource = categories;
            cbTableName.DisplayMemberPath = "Name";
            cbIdCategory.ItemsSource = categories;
            cbIdCategory.DisplayMemberPath= "Id";
        }


        public void LoadTableBia()
        {
            dgTable.ItemsSource = tableBiaObject.GetTable();
        }

        public void LoadDoanhThu()
        {
            dgDoanhThu.ItemsSource = billObject.GetBill();
        }

        public void LoadTableWater()
        {
            dgWater.ItemsSource = waterObject.GetWater();
        }

        public void LoadAccount()
        {
            dgAccount.ItemsSource = accountObject.GetAccount();
        }

        private void dgTable_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {    
            var tb = dgTable.SelectedItem as TableBia;
            if (tb != null && tb.IdCategoryNavigation != null)
            {
                txtIdTable.Text = tb.Id.ToString();
                txtNameTable.Text = tb.Name.ToString();
                var selectedCategory = categories.Find(c => c.Id == tb.IdCategoryNavigation.Id);
                if (selectedCategory!= null)
                {
                    txtPriceTable.Text = selectedCategory.Price.ToString();
                    cbTableName.SelectedItem = selectedCategory;
                }
            }
        }

        private void cbTableName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCategory = cbTableName.SelectedItem as TableCategory;
            if (selectedCategory != null)
            {
                txtPriceTable.Text = selectedCategory.Price.ToString();
                cbIdCategory.Text = selectedCategory.Id.ToString();
            }
        }

        public bool TakeTableBia(out TableBia? validTableBia)
        {
            validTableBia = null;
             

            if (string.IsNullOrEmpty(txtNameTable.Text))
            {
                MessageBox.Show("Bạn chưa thêm tên bàn !!!", "Waring", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }


            if (string.IsNullOrEmpty(cbIdCategory.Text))
            {
                MessageBox.Show("Loại Id bàn chưa được chọn !!!", "Waring", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(cbTableName.Text))
            {
                MessageBox.Show("Loại bàn chưa được chọn !!!", "Waring", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            using var context = new QuanLyBilliardsClubContext();
            bool tableExists = context.TableBia.Any(t => t.Name == txtNameTable.Text);
            if (tableExists)
            {
                MessageBox.Show($"A table with the name '{txtNameTable.Text}' already exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            validTableBia = new TableBia()
            {        
                Name = txtNameTable.Text,
                IdCategory = int.Parse(cbIdCategory.Text),
            };

            return true;
        }

        public bool TakeUpdateTableBia(out TableBia? validTableBia)
        {
            validTableBia = null;


            if (string.IsNullOrEmpty(txtNameTable.Text))
            {
                MessageBox.Show("Bạn chưa thêm tên bàn !!!", "Waring", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }


            if (string.IsNullOrEmpty(cbIdCategory.Text))
            {
                MessageBox.Show("Loại Id bàn chưa được chọn !!!", "Waring", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(cbTableName.Text))
            {
                MessageBox.Show("Loại bàn chưa được chọn !!!", "Waring", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            using var context = new QuanLyBilliardsClubContext();
            TableBia table = context.TableBia.FirstOrDefault(t => t.Id == int.Parse(txtIdTable.Text));
            if (txtNameTable.Text != table.Name)
            {
                MessageBox.Show($"Enter table with the name '{table.Name}'", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            validTableBia = new TableBia()
            {   
                IdCategory = int.Parse(cbIdCategory.Text),
            };

            return true;
        }

        private void btnAddTable_Click(object sender, RoutedEventArgs e)
        {
            TableBia? table;
            if (!TakeTableBia( out table))
            {
                return;
            }
            tableBiaObject.AddTableBia(table);
            LoadTableBia();
            
        }
        

        private void cbIdCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCategory = cbIdCategory.SelectedItem as TableCategory;
            if (selectedCategory != null)
            {
                txtPriceTable.Text = selectedCategory.Price.ToString();
                cbTableName.Text = selectedCategory.Name.ToString();
            }
        }

        private void btnUpdateTable_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtIdTable.Text, out int tableId))
            {
                MessageBoxResult result = MessageBox.Show($"Bạn muốn update bàn có Id {tableId}?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        TableBia? table;
                        if (!TakeUpdateTableBia(out table))
                        {
                            return;
                        }
                        table.Id = tableId;          
                        tableBiaObject.UpdateTableBia(table);
                        LoadTableBia();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void btnDeleteTable_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtIdTable.Text, out int tableId))
            {
                MessageBoxResult result = MessageBox.Show($"Bạn muốn xóa bàn có Id {tableId}?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        tableBiaObject.DeleteTableBia(tableId);
                        LoadTableBia();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void btnSearchTable_Click(object sender, RoutedEventArgs e)
        {
            string search = txtSearchTable.Text;
            if (string.IsNullOrEmpty(search))
            {
                MessageBox.Show("Please enter a search term.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                LoadTableBia();
                return;
            }
            try
            {
                List<TableBia> searchResults = tableBiaObject.SearchTableBia(search);
                if (searchResults.Any())
                {
                    dgTable.ItemsSource = searchResults;
                }
                else
                {
                    MessageBox.Show("No tables found matching the search term.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public bool TakeWater(out Water? validWater)
        {
            validWater = null;


            if (string.IsNullOrEmpty(txtNameWater.Text))
            {
                MessageBox.Show("Bạn chưa thêm tên nước !!!", "Waring", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }


            if (string.IsNullOrEmpty(txtPriceWater.Text))
            {
                MessageBox.Show("Bạn chưa thêm giá tiền !!!", "Waring", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }


            using var context = new QuanLyBilliardsClubContext();
            bool tableWater = context.Water.Any(t => t.Name == txtNameWater.Text);
            if (tableWater)
            {
                MessageBox.Show($"Nước có tên '{txtNameWater.Text}' đã tồn tại.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            validWater = new Water()
            {
                Name = txtNameWater.Text,
                Price = double.Parse(txtPriceWater.Text),

            };

            return true;
        }


        public bool TakeUpdateWater(out Water? validWater)
        {
            validWater = null;


            if (string.IsNullOrEmpty(txtNameWater.Text))
            {
                MessageBox.Show("Bạn chưa thêm tên nước !!!", "Waring", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }


            if (string.IsNullOrEmpty(txtPriceWater.Text))
            {
                MessageBox.Show("Bạn chưa thêm giá tiền !!!", "Waring", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }


            validWater = new Water()
            {
                Name = txtNameWater.Text,
                Price = double.Parse(txtPriceWater.Text),

            };

            return true;
        }


        private void btnAddWater_Click(object sender, RoutedEventArgs e)
        {
            Water? water;
            if (!TakeWater(out water))
            {
                return;
            }
            waterObject.AddWater(water);
            LoadTableWater();
        }

        private void btnUpdateWater_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtIdWater.Text, out int waterId))
            {
                MessageBoxResult result = MessageBox.Show($"Bạn muốn update nước có Id {waterId}?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        Water? water;
                        if (!TakeUpdateWater(out water))
                        {
                            return;
                        }
                        water.Id = waterId;
                        waterObject.UpdateWater(water);
                        LoadTableWater();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void btnDeleteWater_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtIdWater.Text, out int waterId))
            {
                MessageBoxResult result = MessageBox.Show($"Bạn muốn xóa nước có Id {waterId}?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        waterObject.DeleteWater(waterId);
                        LoadTableWater();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void btnSearchWater_Click(object sender, RoutedEventArgs e)
        {
            string search = txtSearchWater.Text;
            if (string.IsNullOrEmpty(search))
            {
                MessageBox.Show("Vui lòng nhập cụm từ tìm kiếm.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                LoadTableWater();
                return;
            }
            try
            {
                List<Water> searchResults = waterObject.SearchWater(search);
                if (searchResults.Any())
                {
                    dgWater.ItemsSource = searchResults;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nước phù hợp với cụm từ tìm kiếm.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dgWater_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            var water = dgWater.SelectedItem as Water;
            if (water != null)
            {
                txtIdWater.Text = water.Id.ToString();
                txtNameWater.Text = water.Name.ToString();
                txtPriceWater.Text = water.Price.ToString();
            }
        }

        private void dgAccount_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            var account = dgAccount.SelectedItem as Account;
            if (account != null)
            {
                txtIdAccount.Text = account.Id.ToString();
                txtUserName.Text = account.Username.ToString();
                txtNameAccount.Text = account.Name.ToString();
                txtPassWord.Text = account.Password.ToString();
            }
        }

        public bool TakeAccount(out Account? validAccount)
        {
            validAccount = null;


            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("Bạn chưa thêm UserName !!!", "Waring", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }


            if (string.IsNullOrEmpty(txtNameAccount.Text))
            {
                MessageBox.Show("Bạn chưa thêm NameAccount !!!", "Waring", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtPassWord.Text))
            {
                MessageBox.Show("Bạn chưa thêm PassWord cho tài khoản !!!", "Waring", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }


            using var context = new QuanLyBilliardsClubContext();
            bool account = context.Accounts.Any(t => t.Username == txtUserName.Text);
            if (account)
            {
                MessageBox.Show($"Tên người dùng  '{txtUserName.Text}' đã tồn tại.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            validAccount = new Account()
            {
                Name = txtNameAccount.Text,
                Username = txtUserName.Text,
                Password = txtPassWord.Text,
                Role = 1

            };

            return true;
        }

        private void btnAddAccount_Click(object sender, RoutedEventArgs e)
        {
            Account? account;
            if (!TakeAccount(out account))
            {
                return;
            }
            accountObject.AddAccount(account);
            LoadAccount();
        }


        public bool TakeAccountUpdate(out Account? validAccount)
        {
            validAccount = null;


            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("Bạn chưa thêm UserName !!!", "Waring", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }


            if (string.IsNullOrEmpty(txtNameAccount.Text))
            {
                MessageBox.Show("Bạn chưa thêm NameAccount !!!", "Waring", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtPassWord.Text))
            {
                MessageBox.Show("Bạn chưa thêm PassWord cho tài khoản !!!", "Waring", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }


            validAccount = new Account()
            {
                Name = txtNameAccount.Text,
                Username = txtUserName.Text,
                Password = txtPassWord.Text,
                Role = 1

            };

            return true;
        }

        private void btnUpdateAccount_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtIdAccount.Text, out int accountId))
            {
                MessageBoxResult result = MessageBox.Show($"Bạn muốn update account có Id {accountId}?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        Account? account;
                        if (!TakeAccountUpdate(out account))
                        {
                            return;
                        }
                        account.Id = accountId;
                        accountObject.UpdateAccount(account);
                        LoadAccount();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void btnDeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtIdAccount.Text, out int accountId))
            {
                MessageBoxResult result = MessageBox.Show($"Bạn muốn xóa tài khoản có Id {accountId}?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        accountObject.DeleteAccount(accountId);
                        LoadAccount();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void btnThongKe_Click(object sender, RoutedEventArgs e)
        {
            if (dtpStartDate.SelectedDate == null)
            {
                MessageBox.Show("Bạn vui lòng chọn StartDate.", "Waring", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (dtpEndDate.SelectedDate == null)
            {
                MessageBox.Show("Bạn vui lòng chọn EndDate.", "Waring", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (dtpStartDate.SelectedDate > dtpEndDate.SelectedDate)
            {
                MessageBox.Show("Bạn vui lòng chọn EndDate lớn hơn StartDate.", "Waring", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            List<Bill> bills = billObject.GetBillByDate((DateTime)dtpStartDate.SelectedDate, (DateTime)dtpEndDate.SelectedDate);

            dgDoanhThu.ItemsSource = null;
            dgDoanhThu.ItemsSource = bills;

        }


    }
}
