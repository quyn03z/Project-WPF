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
    public class TableRepository : ITableRepository
    {
        public void DeleteTable(int id)
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                TableBia? deleteTableBia = context.TableBia.FirstOrDefault(x => x.Id == id);
                if (deleteTableBia == null)
                {
                    throw new Exception("No TableBia was found");
                }
                context.TableBia.Remove(deleteTableBia);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<TableBia> GetAll()
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                return context.TableBia
                    .Include(t => t.IdCategoryNavigation)
                    .ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

       


        public void InsertTable(TableBia a)
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                context.TableBia.Add(a);
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Handle database related errors here (e.g., logging, retries)
                throw new Exception($"An error occurred while saving the table: {ex.InnerException.Message}");
            }
            catch (Exception e)
            {
                // Handle other unexpected errors
                throw new Exception($"An unexpected error occurred: {e.Message}");
            }
        }


        public void UpdateTable(TableBia a)
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                var existingTable = context.TableBia.Find(a.Id); // Assuming 'Id' is the primary key
                if (existingTable != null)
                {
                    existingTable.IdCategory = a.IdCategory;
                    // Copy other properties as needed

                    context.Entry(existingTable).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public List<TableBia> SearchTable(string search)
        {
            using var context = new QuanLyBilliardsClubContext();
            return context.TableBia
                          .Where(t => t.Name.Contains(search) || t.IdCategory.ToString().Contains(search))
                          .Include(t => t.IdCategoryNavigation)
                          .ToList();
        }

        public List<TableBia> GetById(int id)
        {
                try
                {
                    using var context = new QuanLyBilliardsClubContext();
                    return context.TableBia
                        .Where(o => o.Id == id)
                        .Include(tb => tb.Bills)
                        .ThenInclude(b => b.IdTableBiaNavigation)
                        .ThenInclude(t => t.IdCategoryNavigation)
                        .ToList();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            
        }

        void ITableRepository.UpdateTableStatus(int tableId)
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                var existingTable = context.TableBia.Find(tableId); // Assuming 'tableId' is the primary key
                if (existingTable != null)
                {
                    existingTable.Status = "Có Người"; // Set the status to indicate the table is occupied
                                                    // existingTable.IsOccupied = true; // Alternatively, if you use a boolean flag

                    context.Entry(existingTable).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public TableBia GetById1(int id)
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                return context.TableBia.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateTableStatus1(int tableId)
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                var existingTable = context.TableBia.Find(tableId); // Assuming 'tableId' is the primary key
                if (existingTable != null)
                {
                    existingTable.Status = "Trống"; // Set the status to indicate the table is occupied
                                                    // existingTable.IsOccupied = true; // Alternatively, if you use a boolean flag

                    context.Entry(existingTable).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
