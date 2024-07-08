using DataAccess.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class BillObject
    {
        public readonly IBillRepository BillRepository;
        public BillObject()
        {
            BillRepository = new BillRepository();
        }

        public List<Bill> GetBill() => BillRepository.GetAll();
        public List<Bill> GetBillByTableId(int tableId) => BillRepository.GetById(tableId);

        public void AddBill(Bill bill) => BillRepository.InsertBill(bill);

        public void UpdateBill(Bill bill) => BillRepository.UpdateBill(bill);

        public void UpdateBillTableId(int billId,int newTableId) => BillRepository.UpdateBillTableId(billId,newTableId);

        public List<Bill> GetBillByDate(DateTime dtpStartDate, DateTime dtpEndDate) => BillRepository.GetBillByDate(dtpStartDate, dtpEndDate);



    }
}
