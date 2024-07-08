using BusinessObject;
using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    /// Interaction logic for QuanLyTable.xaml
    /// </summary>
    public partial class QuanLyTable : Window
    {
        private readonly TableBiaObject tableBiaObject;
        private readonly AccountObject accountObject;
        private readonly WaterObject waterObject;
        private readonly BillObject billObject;
        private readonly BillInfoObject billInfoObject;  
        private List<Water> water;
        private List<TableBia> tableBia;
        private List<BillInfo> currentBillInfos;
        private Bill currentBill;
        private int? selectedTableId = null;



        public QuanLyTable()
        {
            InitializeComponent();
            tableBiaObject = new TableBiaObject();
            waterObject = new WaterObject();
            billObject = new BillObject();
            billInfoObject = new BillInfoObject();
            Loaded += Load;
        }


        private void Load(object sender, RoutedEventArgs e)
        {
            LoadTable();
            LoadWaterName();
            LoadTableName();
        }

        public void LoadTable()
        {
            wpTable.Children.Clear();
            List<TableBia> tableList = tableBiaObject.GetTable();

            foreach (TableBia table in tableList)
            {
                string status = table.Status;
                Brush backgroundBrush = status == "Trống" ? Brushes.LightGray : Brushes.LightPink;

                // Create a StackPanel to stack content vertically
                StackPanel stackPanel = new StackPanel
                {
                    Orientation = Orientation.Vertical // stack vertically
                };

                // Create text blocks for Name and Status
                TextBlock nameTextBlock = new TextBlock
                {
                    Text = table.Name,
                    FontWeight = FontWeights.Bold, // optional: bold name
                    HorizontalAlignment = HorizontalAlignment.Center
                };

                TextBlock statusTextBlock = new TextBlock
                {
                    Text = table.Status, // non-bold status
                    HorizontalAlignment = HorizontalAlignment.Center
                };

                TextBlock nameTableTextBlock = new TextBlock
                {
                    Text = table.IdCategoryNavigation.Name, // non-bold status
                    HorizontalAlignment = HorizontalAlignment.Center
                };

                // Add text blocks to the stack panel
                stackPanel.Children.Add(nameTextBlock);
                stackPanel.Children.Add(statusTextBlock);
                stackPanel.Children.Add(nameTableTextBlock);

                // Create a button and set its properties
                Button button = new Button
                {
                    Content = stackPanel,
                    Width = 80,
                    Height = 85,
                    Margin = new Thickness(5),
                    Background = backgroundBrush,
                    Tag = table.Id // Store table.Id in the Tag property of the button
                };

                // Attach click event handler to the button
                button.Click += OnTableButtonClick;
                // Add the button to the WrapPanel (or other container) in your UI
                wpTable.Children.Add(button);
            }
        }


        public void ShowBill(int tableId)
        {
            // Clear previous data
            lvBillInfo.ItemsSource = null;
            lvBill.ItemsSource = null;


            // Fetching bill and billInfo data
            var bills = billObject.GetBillByTableId(tableId);
            if (bills != null && bills.Count > 0)
            {
                currentBill = bills.First();
                currentBillInfos = billInfoObject.GetBillInfoByBillId(currentBill.Id);

                lvBill.ItemsSource = bills;
                lvBillInfo.ItemsSource = currentBillInfos;

                // Ensure TimeCheckOut is set to current time if not already set
                if (!currentBill.TimeCheckOut.HasValue)
                {
                    currentBill.TimeCheckOut = DateTime.Now;
                }
            }
            else
            {
                currentBill = null;
                currentBillInfos = new List<BillInfo>();
            }

            UpdateTotalPrice();
        }

        private void UpdateTotalPrice()
        {
            double totalPrice = 0;

            if (currentBillInfos != null && currentBillInfos.Any())
            {
                totalPrice = currentBillInfos
                    .Where(bi => bi.IdWaterNavigation != null)
                    .Sum(bi => bi.IdWaterNavigation.Price * bi.Quantity);
            }

            if (currentBill != null && currentBill.IdTableBiaNavigation != null)
            {
                if (currentBill.IdTableBiaNavigation.IdCategoryNavigation != null)
                {
                    double billiardsPrice = currentBill.IdTableBiaNavigation.IdCategoryNavigation.Price;
                    TimeSpan duration = currentBill.TimeCheckOut.HasValue
                        ? currentBill.TimeCheckOut.Value - currentBill.TimeCheckIn
                        : DateTime.Now - currentBill.TimeCheckIn;

                    double totalBilliardsPrice = (double)duration.TotalHours * billiardsPrice;
                    totalPrice += totalBilliardsPrice;
                }
            }

            int tableId = selectedTableId.Value;
            var bills = billObject.GetBillByTableId(tableId).FirstOrDefault();
            if (bills != null)
            {
                bills.totalPrice = totalPrice;
                billObject.UpdateBill(bills);
            }
            txtTotalPrice.Text = totalPrice.ToString("N3") + " VND";

        }


        private void OnTableButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {     
                selectedTableId = (int)button.Tag;
                lvBillInfo.Tag = selectedTableId;

                // Fetch the current bill for the table
                var bills = billObject.GetBillByTableId(selectedTableId.Value);
                if (bills != null && bills.Count > 0)
                {
                    currentBill = bills.First();
                    // Always update TimeCheckOut to the current time
                    currentBill.TimeCheckOut = DateTime.Now;
                    billObject.UpdateBill(currentBill); // Ensure this method updates the bill in the data store
                }
                else
                {
                    currentBill = null;
                }
                ShowBill(selectedTableId.Value);
            }

        }

        public void LoadWaterName()
        {
            water = waterObject.GetWater();
            cbWater.ItemsSource = water;
            cbWater.DisplayMemberPath = "Name";
            cbWater.SelectedIndex = 0;
        }

        public void LoadTableName()
        {
            tableBia = tableBiaObject.GetTable();
            cbChuyenBan.ItemsSource = tableBia;
            cbChuyenBan.DisplayMemberPath = "Name";
            cbChuyenBan.SelectedValuePath = "Id";
            cbChuyenBan.SelectedIndex = 0;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            int accountId = AccountObject.accountLogin.Id ?? 0;
            AccountProfile f = new AccountProfile(accountId);
            f.ShowDialog();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            if (AccountObject.accountLogin != null )
            {
                if (AccountObject.accountLogin.Role.Equals("admin"))
                {
                    Admin f = new Admin();
                    f.Closed += AdminWindow_Closed;
                    f.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Bạn không phải là admin.");
                }
            }
           
        }

        private void AdminWindow_Closed(object? sender, EventArgs e)
        {
            LoadTable();
            LoadWaterName();
            LoadTableName();
        }

        private void btnAddWater_Click(object sender, RoutedEventArgs e)
        {

            int tableId = selectedTableId ?? -1;
            TableBia table = tableBiaObject.GetTableBiaById1(tableId);

            if (table == null)
            {
                MessageBox.Show("Vui lòng mở bàn trước khi thêm đồ uống.");
                return;
            }

            if (table.Status != "Trống")
            {
                // Lấy item nước đã chọn
                Water selectedWater = cbWater.SelectedItem as Water;
                if (selectedWater == null)
                {
                    MessageBox.Show("Vui lòng chọn đồ uống.");
                    return;
                }

                // Lấy số lượng đã chọn
                ComboBoxItem selectedQuantityItem = cbSoLuong.SelectedItem as ComboBoxItem;
                if (selectedQuantityItem == null)
                {
                    MessageBox.Show("Vui lòng chọn số lượng đồ uống.");
                    return;
                }
                int quantity = int.Parse(selectedQuantityItem.Content.ToString());

                if (currentBill == null)
                {
                    // Tạo một đối tượng Bill mới
                    currentBill = new Bill
                    {
                        TimeCheckIn = DateTime.Now,
                        IdTableBia = tableId 
                    };

                    // thêm bill mới
                    billObject.AddBill(currentBill); 

                    // lấy lại bill mới ra rồi gán cho currentBill
                    currentBill = billObject.GetBillByTableId(tableId).First();
                }

                // Kiểm tra xem nước được chọn đã có trong hóa đơn hiện tại chưa
                var existingBillInfo = currentBillInfos.FirstOrDefault(bi => bi.IdWater == selectedWater.Id);

                if (existingBillInfo != null)
                {
                    // Cập nhật số lượng BillInfo hiện có
                    existingBillInfo.Quantity += quantity;
                    billInfoObject.UpdateBillInfo(existingBillInfo); 
                }
                else
                {
                    // Tạo một đối tượng BillInfo mới
                    BillInfo newBillInfo = new BillInfo
                    {
                        IdBill = currentBill.Id,
                        IdWater = selectedWater.Id,
                        Quantity = quantity,
                    };

                    // Thêm BillInfo mới vào hóa đơn
                    currentBillInfos.Add(newBillInfo);
                    billInfoObject.AddBillInfo(newBillInfo); 
                }

                lvBillInfo.ItemsSource = null;
                lvBillInfo.ItemsSource = currentBillInfos;

                ShowBill(tableId);
                UpdateTotalPrice();
            }
            else
            {
                MessageBox.Show("Bàn chưa được mở !!!");

            }
        }



        private void btnAddTable_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int tableId = selectedTableId ?? -1;

                if (selectedTableId.HasValue)
                {
                   
                    TableBia table = tableBiaObject.GetTableBiaById1(tableId);

                    MessageBoxResult result = MessageBox.Show($"Bạn muốn mở bàn {table.Name} không!", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        if (tableBiaObject != null)
                        {
                            tableBiaObject.UpdateTableStatus(selectedTableId.Value);
                            if (currentBill == null)
                            {
                                // Tạo một đối tượng Bill mới
                                currentBill = new Bill
                                {
                                    TimeCheckIn = DateTime.Now,
                                    IdTableBia = tableId, 
                                    TimeCheckOut = DateTime.Now
                                 };
                                
                                billObject.AddBill(currentBill);  // add thêm bills mới vào

                                currentBill = billObject.GetBillByTableId(tableId).FirstOrDefault(); // lấy bill mới ra 

                            }
                           

                            LoadTable();
                            if (currentBill != null)
                            {
                                lvBill.ItemsSource = new List<Bill> { currentBill }; // Load bill mới vừa thêm vào
                            }

                        }
                        else
                        {
                            MessageBox.Show("TableBiaObject is not initialized.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No table selected. Please select a table first.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }



        private void btnThanhToan_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                if (lvBillInfo.Tag == null || !(lvBillInfo.Tag is int tableId))
                {
                    MessageBox.Show("Invalid table ID.");
                    return;
                }

                MessageBoxResult result = MessageBox.Show($"Bạn muốn thanh toán không?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        // Lấy các hóa đơn liên kết với ID bảng
                        var bills = billObject.GetBillByTableId(tableId);

                        foreach (var bill in bills)
                        {
                            // thanh toán và cập nhật status =  1 (paid)
                            bill.Status = 1;
                            billObject.UpdateBill(bill); 
                        }
                        // Clear 
                        currentBill = null;
                        currentBillInfos = new List<BillInfo>();
                        lvBill.ItemsSource = null;
                        lvBillInfo.ItemsSource = null;
                        txtTotalPrice.Text = "0 VND"; // Reset total price display
                        tableBiaObject.UpdateTableStatus1(tableId);
                        LoadTable();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void btnChuyenBan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectedTableId.HasValue && cbChuyenBan.SelectedValue != null)
                {
                    int sourceTableId = selectedTableId.Value;

                    // Lấy ID bảng mục tiêu đã chọn từ ComboBox
                    int targetTableId;
                    if (int.TryParse(cbChuyenBan.SelectedValue.ToString(), out targetTableId))
                    {
                        TableBia table = tableBiaObject.GetTableBiaById1(sourceTableId);
                        TableBia table1 = tableBiaObject.GetTableBiaById1(targetTableId);
                        if (table.Status == "Có Người" && table1.Status == "Có Người")
                        {
                            MessageBox.Show("Không thể chuyển bàn vì cả hai bàn đều đã được mở.");
                            return;
                        }
                        MessageBoxResult result = MessageBox.Show($"Bạn muốn chuyển bàn {table.Name} sang {table1.Name}", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            // Cập nhật IdTableBia của hóa đơn hiện tại
                            if (currentBill != null)
                            {
                                billObject.UpdateBillTableId(currentBill.Id, targetTableId);

                                // cập nhật trạng thái bảng
                                tableBiaObject.UpdateTableStatus(targetTableId); // Cập nhật bàn mới có người 
                                tableBiaObject.UpdateTableStatus1(sourceTableId); // Cập nhật bàn cũ có trống 

                               
                                LoadTable();

                                lvBill.ItemsSource = billInfoObject.GetBillInfoByBillId(currentBill.Id); 
                            }
                            else
                            {
                                MessageBox.Show("Bàn chưa được mở không chuyển bàn được");

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn bàn hợp lệ");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn bàn muốn chuyển");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bàn chọn bị lỗi bạn hãy thử lại.");
            }
        }

     
    }
}
