using DataAcess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repository
{
    public class OderRepository : IOder
    {
        public void DeleteOder(int id)
        {
            try
            {
                using var context = new QuanLyHotelContext();
                Order? deleteOrder = context.Orders.FirstOrDefault(x => x.OrderId == id);
                if (deleteOrder == null)
                {
                    throw new Exception("No Room was found");
                }
                context.Orders.Remove(deleteOrder);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Order> GetAll()
        {
            try
            {
                using var context = new QuanLyHotelContext();
                return context.Orders
                    .Include(t => t.Customer)
                    .ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Order> GetOrdersOfCustomer(int customerId)
        {
            try
            {
                using var context = new QuanLyHotelContext();
                return context.Orders
                    .Where(o => o.CustomerId == customerId)
                    .Include(t => t.RoomInformation)
                    .ToList();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void InsertOder(Order o)
        {
            throw new NotImplementedException();
        }

        public void UpdateOder(Order o)
        {
            throw new NotImplementedException();
        }
    }
}
