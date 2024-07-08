using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IBillInfoRepository
    {
        public void deleteBillInfo(int id);
        public List<BillInfo> GetAll();


        List<BillInfo> GetBillInfoByBillId(int billId);

        public BillInfo GetById(int id);
        public void UpdateBillInfo(BillInfo a);
        public void InsertBillInfo(BillInfo a);



    }
}
