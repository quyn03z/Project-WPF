using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{


    public class AccountLogin
    {
        public int? Id { get; set; }
        public int Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public AccountLogin(int role, string email, string password)
        {
            Role = role;
            Email = email;
            Password = password;
        }
    }

    public class AccountObject
    {
        private readonly IAccountRepository _accountRepository;
        public static AccountLogin? accountLogin;
        public AccountObject()
        {
            _accountRepository = new AccountRepository();
        }

        public bool Login(string username, string password)
        {
            Account account = _accountRepository.FindAccount(username, password);
            if (account == null)
            {
                return false;
            }
            if (account.Role == 1)
            {
                accountLogin = new AccountLogin(1, username, password);
            }
            else
            {
                accountLogin = new AccountLogin(2, username, password);
            }
            accountLogin.Id = account.Id;

            return true;
        }


        public List<Account> GetAccount() => _accountRepository.GetAll();

        public void AddAccount(Account account) => _accountRepository.InsertAccount(account);

        public void DeleteAccount(int accountId) => _accountRepository.DeleteAccount(accountId);

        public void UpdateAccount(Account account) => _accountRepository.UpdateAccount(account);

        public Account GetAccountById(int accountId) => _accountRepository.GetById(accountId);


    }
}
