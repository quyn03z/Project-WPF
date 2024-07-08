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
    public class BillRepository : IBillRepository
    {
        public void deleteBill(int id)
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                Bill? deleteBill = context.Bills.FirstOrDefault(x => x.Id == id);
                if (deleteBill == null)
                {
                    throw new Exception("No Water was found");
                }
                context.Bills.Remove(deleteBill);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Bill> GetAll()
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                return context.Bills
                    .Where(o => o.Status == 1)
                    .Include(t => t.IdTableBiaNavigation)
                    .OrderByDescending(b => b.Id)
                    .ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Bill> GetBillByDate(DateTime dtpStartDate, DateTime dtpEndDate)
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                return context.Bills
                              .Where(o => o.TimeCheckOut >= dtpStartDate && o.TimeCheckOut <= dtpEndDate)
                              .Include(t => t.IdTableBiaNavigation)
                              .ToList(); 
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Bill GetById(int id)
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                return context.Bills.FirstOrDefault(x => x.IdTableBia == id);

            }
            catch (Exception e)
            { 
                throw new Exception(e.Message);
            }
        }

        public void InsertBill(Bill a)
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                context.Bills.Add(a);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateBill(Bill a)
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                context.Bills.Update(a);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateBillTableId(int billId, int newTableId)
        {
            try
            {
                using (var context = new QuanLyBilliardsClubContext())
                {
                    // Fetch the Bill entity by its ID
                    var billToUpdate = context.Bills.Find(billId);

                    if (billToUpdate != null)
                    {
                        // Update the IdTableBia property
                        billToUpdate.IdTableBia = newTableId;

                        // Mark the entity as modified
                        context.Bills.Update(billToUpdate);

                        // Save changes to the database
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new InvalidOperationException($"Bill with ID {billId} not found.");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error updating bill: {e.Message}");
            }
        }

        List<Bill> IBillRepository.GetById(int tableId)
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                return context.Bills
                    .Where(o => o.IdTableBia == tableId && o.Status == 0)
                    .Include(t => t.IdTableBiaNavigation)
                    .ThenInclude(t => t.IdCategoryNavigation)
                    .ToList();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
