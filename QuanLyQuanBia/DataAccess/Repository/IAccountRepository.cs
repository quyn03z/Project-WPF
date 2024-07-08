using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IAccountRepository
    {
        public void DeleteAccount(int id);
        public List<Account> GetAll();

        public Account GetById(int id);
        public void UpdateAccount(Account a);
        public void InsertAccount(Account a);

        public Account FindAccount(string username,string password);
    }
}
