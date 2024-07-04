using DataAcess.Models;
using DataAcess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class RoomTypeObject
    {
        public readonly IRoomTypeRepository roomTypeRepository;
        public RoomTypeObject()
        {
            roomTypeRepository = new RoomTypeRepository();
        }

        public List<RoomType> GetRoomType() => roomTypeRepository.GetAll();
    }
}
