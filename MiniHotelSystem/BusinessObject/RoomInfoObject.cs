using DataAcess.Models;
using DataAcess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class RoomInfoObject
    {
        public readonly IRoomInfo roomInfo;

        public RoomInfoObject()
        {
            roomInfo = new RoomInfoRepository();
        }

        public List<RoomInformation> GetRoom() => roomInfo.GetAll();

        public void AddRoomInformation(RoomInformation room) => roomInfo.InsertRoomInfo(room);
        public void DeleteRoomInformation(int roomId) => roomInfo.DeleteRoomInfo(roomId);
        public void UpdateRoomInformation(RoomInformation room) => roomInfo.UpdateRoomInfo(room);

    }
}
