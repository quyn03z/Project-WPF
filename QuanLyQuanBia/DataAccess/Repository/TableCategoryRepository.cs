using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class TableCategoryRepository : ITableCategoryRepository
    {
        public List<TableCategory> GetAll()
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                return context.TableCategories.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
