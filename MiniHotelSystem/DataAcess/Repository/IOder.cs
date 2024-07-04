using DataAcess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repository
{
    public interface IOder
    {
        public void DeleteOder(int id);
        public List<Order> GetAll();
        public void UpdateOder(Order o);
        public void InsertOder(Order o);
        List<Order> GetOrdersOfCustomer(int customerId);
    }
}
