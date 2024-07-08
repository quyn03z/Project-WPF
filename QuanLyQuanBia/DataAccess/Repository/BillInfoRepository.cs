using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class BillInfoRepository : IBillInfoRepository
    {
        public void deleteBillInfo(int id)
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                BillInfo? deleteBillInfo = context.BillInfos.FirstOrDefault(x => x.Id == id);
                if (deleteBillInfo == null)
                {
                    throw new Exception("No Water was found");
                }
                context.BillInfos.Remove(deleteBillInfo);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<BillInfo> GetAll()
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                return context.BillInfos.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<BillInfo> GetBillInfoByBillId(int billId)
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                return context.BillInfos
                    .Where(o => o.IdBill == billId)
                    .Include(t => t.IdBillNavigation)
                    .Include(t => t.IdWaterNavigation)
                    .ToList();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public BillInfo GetById(int id)
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                return context.BillInfos.FirstOrDefault(x => x.Id == id);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void InsertBillInfo(BillInfo a)
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                context.BillInfos.Add(a);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateBillInfo(BillInfo billInfo)
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                context.BillInfos.Update(billInfo);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception($"Error updating BillInfo: {e.InnerException?.Message ?? e.Message}");
            }
        }
    }
}
