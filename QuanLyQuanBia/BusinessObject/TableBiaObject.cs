using DataAccess.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class TableBiaObject
    {
        public readonly ITableRepository tableRepository;

        public TableBiaObject()
        {
            tableRepository = new TableRepository();
        }

        public List<TableBia> GetTable() => tableRepository.GetAll();

        public void AddTableBia(TableBia table) => tableRepository.InsertTable(table);

        public void DeleteTableBia(int tableId) => tableRepository.DeleteTable(tableId);

        public void UpdateTableBia(TableBia table) => tableRepository.UpdateTable(table);

        public List<TableBia> GetTableBiaById(int tableId) => tableRepository.GetById(tableId);

        public TableBia GetTableBiaById1(int tableId) => tableRepository.GetById1(tableId);

        public List<TableBia> SearchTableBia(string search) => tableRepository.SearchTable(search);

        public void UpdateTableStatus(int tableId) => tableRepository.UpdateTableStatus(tableId);

        public void UpdateTableStatus1(int tableId) => tableRepository.UpdateTableStatus1(tableId);

    }
}
