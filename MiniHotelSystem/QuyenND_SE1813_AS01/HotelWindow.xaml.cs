using BusinessObject;
using DataAcess.Models;
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

namespace QuyenND_SE1813_AS01
{
    /// <summary>
    /// Interaction logic for HotelWindow.xaml
    /// </summary>
    public partial class HotelWindow : Window
    {
        private readonly RoomInfoObject roomInfoObject;
        public Action<object, RoutedEventArgs> WindowClosed;

        public HotelWindow()
        {
            InitializeComponent();
            roomInfoObject = new RoomInfoObject();
            Loaded += Load;
        }


        private void Load(object sender, RoutedEventArgs e)
        {
            LoadRoom();
        }

        public void LoadRoom()
        {
            dgRoom.ItemsSource = null;
            dgRoom.ItemsSource = roomInfoObject.GetRoom();
        }

        private void btnBackHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
        }

        private void btnAddRoom_Click(object sender, RoutedEventArgs e)
        {
            RoomsPopup roomsPopup = new RoomsPopup();
            roomsPopup.DataReloadRequested += RoomsPopup_DataReloadRequested;
            roomsPopup.ShowDialog();
            Close();
        }

        private void RoomsPopup_DataReloadRequested()
        {
            LoadRoom();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            if (button?.DataContext is RoomInformation r)
            {
                RoomsPopup roomsPopup = new RoomsPopup(r);
                roomsPopup.WindowClosed += Load;
                roomsPopup.Show();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            if (button?.DataContext is RoomInformation r)
            {
                MessageBoxResult result = MessageBox.Show($"Bạn muốn xóa bàn có Id {r.RoomNumber}", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    roomInfoObject.DeleteRoomInformation(r.RoomId);
                    LoadRoom(); 
                }
            }
        }

    }
}
