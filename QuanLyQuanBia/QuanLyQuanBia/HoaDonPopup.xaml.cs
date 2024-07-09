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
    /// Interaction logic for HoaDonPopup.xaml
    /// </summary>
    public partial class HoaDonPopup : Window
    {

        private readonly AccountObject accountObject;
        private readonly BillObject billObject;  
        private readonly BillInfoObject billInfoObject;
        private readonly int accountId;
        private readonly int billId;
        private readonly TimeSpan timePlay;
        private readonly double totalPrice;

        public HoaDonPopup(int accountId,int billId,double totalPrice,TimeSpan timePlay)
        {
            accountObject = new AccountObject();
            this.accountId = accountId;
            this.billId = billId;
            this.totalPrice = totalPrice;
            this.timePlay = timePlay;
            billObject = new BillObject();
            billInfoObject = new BillInfoObject();
            Loaded += Load;
            InitializeComponent();
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            LoadDataAccount();
            LoadBill();
        }

        private void LoadDataAccount()
        {
            Account account = accountObject.GetAccountById(accountId);
            txtEmployeeName.Text = "Nhân viên:      " + account.Name;
        }

        private void LoadBill()
        {
            Bill bill = billObject.getBillByBillId(billId);

            List<BillInfo> billInfos = billInfoObject.GetBillInfoByBillId(billId);

            txtMaHoaDon.Text = "Mã hóa đơn:   " + billId;
            txtNgayLapDon.Text = "Ngày lập đơn: " + bill.TimeCheckOut;
            txtTimePlay.Text = "Thời gian chơi: " + timePlay.ToString(@"hh\:mm\:ss");
            txtTongTien.Text = "Tổng Tiền: " + totalPrice.ToString("N3") + " VND";

            txtTotalPrice.Text = "Tổng tiền:    " + bill.totalPrice.ToString("N3") + " VND";

            lvBillInfo.ItemsSource = billInfos;
        }



    }
}
