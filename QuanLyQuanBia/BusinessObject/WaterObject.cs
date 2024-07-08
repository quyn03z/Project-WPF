using DataAccess.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class WaterObject
    {
        public readonly IWaterRepository waterRepository;
        public WaterObject()
        {
            waterRepository = new WaterRepository();
        }

        public List<Water> GetWater() => waterRepository.GetAll();

        public void AddWater(Water water) => waterRepository.InsertWater(water);
        public void DeleteWater(int waterId) => waterRepository.DeleteWater(waterId);

        public void UpdateWater(Water water) => waterRepository.UpdateWater(water);
        public void GetWaterById(int waterId) => waterRepository.GetById(waterId);

        public List<Water> SearchWater(string search) => waterRepository.SearchWater(search);
    }
}
