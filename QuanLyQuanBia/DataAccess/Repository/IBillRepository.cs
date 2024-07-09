using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IBillRepository
    {
        public void deleteBill(int id);
        public List<Bill> GetAll();

        List<Bill> GetById(int tableId);
        public void UpdateBill(Bill a);
        public void InsertBill(Bill a);

        public void UpdateBillTableId(int billId,int newTableId);
        List<Bill> GetBillByDate(DateTime dtpStartDate, DateTime dtpEndDate);

        public Bill getBillByBillId(int billId);
    }
}
