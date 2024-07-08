using DataAccess.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class TableCategoryObject
    {
        public readonly ITableCategoryRepository tableCategoryRepository;

        public TableCategoryObject()
        {
            tableCategoryRepository = new TableCategoryRepository();
        }

        public List<TableCategory> GetTableCategory() => tableCategoryRepository.GetAll();

    }
}
