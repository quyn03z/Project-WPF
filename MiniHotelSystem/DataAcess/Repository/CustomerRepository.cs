using DataAcess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repository
{
    public class CustomerRepository : ICustomer
    {

        public Customer FindAccountCustomer(string email, string password)
        {
            try
            {
                using var context = new QuanLyHotelContext();
                return context.Customers.FirstOrDefault(x => x.EmailAddress == email && x.Password == password);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void DeleteCustomer(int id)
        {
            try
            {
                using var context = new QuanLyHotelContext();
                Customer? deleteCustomer = context.Customers.FirstOrDefault(x => x.CustomerId == id);
                if (deleteCustomer == null)
                {
                    throw new Exception("No Customer was found");
                }
                context.Customers.Remove(deleteCustomer);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Customer> GetAll()
        {
            try
            {
                using var context = new QuanLyHotelContext();
                return context.Customers.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void InsertCustomer(Customer c)
        {
            try
            {
                using var context = new QuanLyHotelContext();
                context.Customers.Add(c);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateCustomer(Customer updatedCustomer)
        {
            try
            {
                using var context = new QuanLyHotelContext();
                var existingCustomer = context.Customers.SingleOrDefault(c => c.CustomerId == updatedCustomer.CustomerId);

                if (existingCustomer != null)
                {
                    existingCustomer.CustomerFullName = updatedCustomer.CustomerFullName;
                    existingCustomer.TelePhone = updatedCustomer.TelePhone;
                    existingCustomer.EmailAddress = updatedCustomer.EmailAddress;
                    existingCustomer.CustormerBirthday = updatedCustomer.CustormerBirthday;
                    existingCustomer.Password = updatedCustomer.Password;

                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Customer not found.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Customer GetCustomerById(int id)
        {
            try
            {
                using var context = new QuanLyHotelContext();
                return context.Customers.FirstOrDefault(c => c.CustomerId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
