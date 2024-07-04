using DataAcess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Repository
{
    public interface ICustomer
    {

        public void DeleteCustomer(int id);
        public List<Customer> GetAll();
        public void UpdateCustomer(Customer c);
        public void InsertCustomer(Customer c);
        public Customer GetCustomerById(int id);
        public Customer FindAccountCustomer(string username, string password);
    }
}
