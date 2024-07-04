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
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {

        private readonly OrderObject _orderObject;
        public Action<object, RoutedEventArgs> WindowClosed;

        public OrderWindow()
        {
            InitializeComponent();
            _orderObject = new OrderObject();
            Loaded += Load;
        }


        private void Load(object sender, RoutedEventArgs e)
        {
            LoadOrder();
        }

        public void LoadOrder()
        {
            dgOrder.ItemsSource = null;
            dgOrder.ItemsSource = _orderObject.GetOrder();
        }

        private void btnBackHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }

        private void btnDeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            if (button?.DataContext is Order o)
            {
                MessageBoxResult result = MessageBox.Show($"Bạn muốn xóa order có Id {o.OrderId}", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _orderObject.DeleteOrder(o.OrderId);
                    LoadOrder();
                }
            }
        }
    }
}
