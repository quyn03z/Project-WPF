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
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window
    {

        private readonly CustomerObject customerObject;
        public Action<object, RoutedEventArgs> WindowClosed;

        public Profile()
        {
            InitializeComponent();
            customerObject = new CustomerObject();
            Loaded += Load;
        }



        private void Load(object sender, RoutedEventArgs e)
        {
            LoadCustomer();
        }

        public void LoadCustomer()
        {
            dgCustomer.ItemsSource = null;
            dgCustomer.ItemsSource = customerObject.GetCustomer();
        }







        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            CustomersPopup cusPopup = new CustomersPopup();
            // roomsPopup.DataReloadRequested += RoomsPopup_DataReloadRequested;
            cusPopup.ShowDialog();
            Close();
        }

        private void btnBackHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            if (button?.DataContext is Customer c)
            {
                MessageBoxResult result = MessageBox.Show($"Bạn muốn xóa customer có Id {c.CustomerId}", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    customerObject.DeleteCustomer(c.CustomerId);
                    LoadCustomer();
                }
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            if (button?.DataContext is Customer c)
            {
                CustomersPopup cusPopup = new CustomersPopup(c);
                cusPopup.WindowClosed += Load;
                cusPopup.Show();
            }
        }
    }
}
