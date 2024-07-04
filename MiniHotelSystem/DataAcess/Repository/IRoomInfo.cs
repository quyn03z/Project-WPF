using DataAcess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repository
{
    public interface IRoomInfo
    {
        public void DeleteRoomInfo(int id);
        public List<RoomInformation> GetAll();
        public void UpdateRoomInfo(RoomInformation o);
        public void InsertRoomInfo(RoomInformation o);
    }
}
