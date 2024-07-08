using DataAccess.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class BillInfoObject
    {

        public readonly IBillInfoRepository BillInfoRepository;
        public BillInfoObject()
        {
            BillInfoRepository = new BillInfoRepository();
        }

        public List<BillInfo> GetBill() => BillInfoRepository.GetAll();


        public List<BillInfo> GetBillInfoByBillId(int billId) => BillInfoRepository.GetBillInfoByBillId(billId);


        public void AddBillInfo(BillInfo billinfo) => BillInfoRepository.InsertBillInfo(billinfo);  

        public void UpdateBillInfo(BillInfo billinfo) => BillInfoRepository.UpdateBillInfo(billinfo);

    }
}
