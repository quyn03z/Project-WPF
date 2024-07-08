using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IWaterRepository
    {
        public void DeleteWater(int id);
        public List<Water> GetAll();

        public Water GetById(int id);
        public void UpdateWater(Water a);
        public void InsertWater(Water a);
        public List<Water> SearchWater(string search);

    }
}
