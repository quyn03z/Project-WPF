using DataAcess.Models;
using DataAcess.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{

    public class AccountLogin
    {
        public int? Id { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public AccountLogin(string role, string email, string password)
        {
            Role = role;
            Email = email;
            Password = password;
        }
    }

    public class CustomerObject
    {
        private readonly ICustomer customer;
        public static AccountLogin? accountLogin;

        public CustomerObject()
        {
            customer = new CustomerRepository();
        }

        public bool Login(string email, string password)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var projectDirectory = Path.GetFullPath(Path.Combine(currentDirectory, "..\\..\\..\\.."));
            var appSettingsPath = Path.Combine(projectDirectory, "DataAcess");

            var builder = new ConfigurationBuilder()
                                .SetBasePath(appSettingsPath)
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfiguration configuration = builder.Build();

            string adminEmail = configuration.GetSection("AdminAccount:Email").Value;
            string adminPassword = configuration.GetSection("AdminAccount:Password").Value;

            if (adminEmail.Equals(email) && adminPassword.Equals(password))
            {
                accountLogin = new AccountLogin("admin", email, password);
                return true;
            }


            Customer account = customer.FindAccountCustomer(email, password);
            if (account == null)
            {
                return false;
            }

            accountLogin = new AccountLogin("normal", email, password);
            accountLogin.Id = account.CustomerId;


            return true;
        }

        public List<Customer> GetCustomer() => customer.GetAll();

        public void AddCustomer(Customer cus) => customer.InsertCustomer(cus);
        public void DeleteCustomer(int cusId) => customer.DeleteCustomer(cusId);
        public void UpdateCustomer(Customer cus) => customer.UpdateCustomer(cus);

        public Customer GetCustomerById(int customerId) => customer.GetCustomerById(customerId);
    }
}
