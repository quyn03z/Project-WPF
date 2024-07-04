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
    /// Interaction logic for RoomsPopup.xaml
    /// </summary>
    public partial class RoomsPopup : Window
    {
        private  RoomInfoObject roomInfoObject;
        private RoomTypeObject? roomTypeObject;
        private List<RoomType> roomTypes;
        public event Action DataReloadRequested;
        private readonly RoomInformation existRoomInfo;
        private RoomInformation _roomInfo;
        public Action<object, RoutedEventArgs> WindowClosed;

        public RoomsPopup() => InitProp();


        public RoomsPopup(RoomInformation r)
        {
            this.existRoomInfo = r;
            InitProp();
        }

        public void InitProp()
        {
            InitializeComponent();
            roomInfoObject = new RoomInfoObject();
            roomTypeObject = new RoomTypeObject();
            Loaded += Load;
            Loaded += LoadUpdateForm;
        }

        private void LoadUpdateForm(object sender, RoutedEventArgs e)
        {
            if (existRoomInfo != null)
            {
                txtRoomId.Text = existRoomInfo.RoomId.ToString();
                txtRoomNumber.Text = existRoomInfo.RoomNumber;
                txtRoomDescription.Text = existRoomInfo.RoomDescription;
                txtRoomMaxCapacity.Text = existRoomInfo.RoomMaxCapacity.ToString();
                txtRoomPrice.Text = existRoomInfo.RoomPricePerDate.ToString();
                cbRoomTypeID.Text = existRoomInfo.RoomTypeId.ToString();
                btnAddRoom.Content = "Update";
            }
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            LoadRoomType();
        }

        public void LoadRoomType()
        {
            roomTypes = roomTypeObject.GetRoomType();
            cbRoomType.ItemsSource = roomTypes;
            cbRoomType.DisplayMemberPath = "RoomTypeName";
            cbRoomTypeID.ItemsSource = roomTypes;
            cbRoomTypeID.DisplayMemberPath = "RoomTypeId";
        }

        public bool TakeRoomInfo(out RoomInformation? validRoomInfo)
        {
            validRoomInfo = null;


            if (string.IsNullOrEmpty(txtRoomNumber.Text))
            {
                MessageBox.Show("Bạn chưa thêm số phòng !!!", "Waring", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }


            if (string.IsNullOrEmpty(txtRoomDescription.Text))
            {
                MessageBox.Show("Bạn chưa thêm mô tả cho phòng !!!", "Waring", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtRoomMaxCapacity.Text))
            {
                MessageBox.Show("Bạn chưa thêm số lượng người ở trong phòng !!!", "Waring", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtRoomPrice.Text))
            {
                MessageBox.Show("Bạn chưa thêm giá cho phòng !!!", "Waring", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtRoomPrice.Text))
            {
                MessageBox.Show("Bạn chưa thêm giá cho phòng !!!", "Waring", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }


            validRoomInfo = new RoomInformation()
            {
                RoomNumber = txtRoomNumber.Text,
                RoomDescription = txtRoomDescription.Text,
                RoomMaxCapacity = int.Parse(txtRoomMaxCapacity.Text),
                RoomStatus = true,
                RoomPricePerDate = decimal.Parse(txtRoomPrice.Text),
                RoomTypeId = int.Parse(cbRoomTypeID.Text),
            };

            return true;
        }



        private void btnAddRoom_Click(object sender, RoutedEventArgs e)
        {
            RoomInformation? roomInfo;
            if (!TakeRoomInfo(out roomInfo))
            {
                return;
            }
            if (existRoomInfo != null)
            {
                roomInfo!.RoomId = existRoomInfo.RoomId;
                roomInfoObject.UpdateRoomInformation(roomInfo);
            }
            else
            {
                roomInfoObject.AddRoomInformation(roomInfo);
            }

            WindowClosed?.Invoke(sender,e);
            this.Close();
        }

        private void btnBackRoom_Click(object sender, RoutedEventArgs e)
        {
            DataReloadRequested?.Invoke();
            this.Close();
        }

        private void cbRoomTypeID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedType = cbRoomTypeID.SelectedItem as RoomType;
            if (selectedType != null)
            {
                cbRoomType.Text = selectedType.RoomTypeName.ToString();
            }
        }

        private void cbRoomType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedType = cbRoomType.SelectedItem as RoomType;
            if (selectedType != null)
            {
                cbRoomTypeID.Text = selectedType.RoomTypeId.ToString();
            }
        }
    }
}
