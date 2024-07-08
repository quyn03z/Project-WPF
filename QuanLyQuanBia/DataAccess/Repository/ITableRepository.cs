using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface ITableRepository
    {
        public void DeleteTable(int id);
        public List<TableBia> GetAll();

        List<TableBia> GetById(int id);
        public void UpdateTable(TableBia a);
        public void InsertTable(TableBia a);

        public List<TableBia> SearchTable(string search);
        public TableBia GetById1(int id);
        public void UpdateTableStatus(int tableId);

        public void UpdateTableStatus1(int tableId);

    }
}
