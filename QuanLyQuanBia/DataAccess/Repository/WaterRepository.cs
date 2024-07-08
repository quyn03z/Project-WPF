using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class WaterRepository : IWaterRepository
    {
        public void DeleteWater(int id)
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                Water? deleteWater = context.Water.FirstOrDefault(x => x.Id == id);
                if (deleteWater == null)
                {
                    throw new Exception("No Water was found");
                }
                context.Water.Remove(deleteWater);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Water> GetAll()
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                return context.Water.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Water GetById(int id)
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                return context.Water.FirstOrDefault(x => x.Id == id);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void InsertWater(Water a)
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                context.Water.Add(a);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateWater(Water a)
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                var existingWater = context.Water.Find(a.Id); // Assuming 'Id' is the primary key
                if (existingWater != null)
                {
                    existingWater.Name = a.Name;
                    existingWater.Price = a.Price;
                    // Copy other properties as needed

                    context.Entry(existingWater).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

//          try
//            {
//                using var context = new QuanLyBilliardsClubContext();
//        var existingTable = context.TableBia.Find(a.Id); // Assuming 'Id' is the primary key
//                if (existingTable != null)
//                {
//                    existingTable.IdCategory = a.IdCategory;
//                    // Copy other properties as needed

//                    context.Entry(existingTable).State = EntityState.Modified;
//                    context.SaveChanges();
//                }
//}
//            catch (Exception e)
//            {
//                throw new Exception(e.Message);
//            }

        public List<Water> SearchWater(string search)
        {
            using var context = new QuanLyBilliardsClubContext();
            return context.Water
                          .Where(t => t.Name.Contains(search) || t.Id.ToString().Contains(search))
                          .ToList();
        }

    }
}
