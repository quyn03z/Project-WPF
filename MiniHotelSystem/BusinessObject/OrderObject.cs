using DataAcess.Models;
using DataAcess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class OrderObject
    {
        private readonly IOder order1;

        public OrderObject()
        {
            order1 = new OderRepository();
        }

        public List<Order> GetOrder() => order1.GetAll();

        public void DeleteOrder(int orderId) => order1.DeleteOder(orderId);
        public void UpdateOrder(Order order) => order1.UpdateOder(order);

        public List<Order> GetOrdersOfCustomer(int customerId) => order1.GetOrdersOfCustomer(customerId);

    }
}
