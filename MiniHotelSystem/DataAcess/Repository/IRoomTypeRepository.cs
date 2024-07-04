using DataAcess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repository
{
    public interface IRoomTypeRepository
    {
        public List<RoomType> GetAll();
    }
}
