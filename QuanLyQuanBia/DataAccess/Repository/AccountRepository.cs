using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public void DeleteAccount(int id)
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                Account? deleteAccount = context.Accounts.FirstOrDefault(x => x.Id == id);
                if (deleteAccount == null)
                {
                    throw new Exception("No Water was found");
                }
                context.Accounts.Remove(deleteAccount);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Account FindAccount(string username, string password)
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                return context.Accounts.FirstOrDefault(x => x.Username == username && x.Password == password);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Account> GetAll()
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                return context.Accounts.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Account GetById(int id)
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                return context.Accounts.FirstOrDefault(x => x.Id == id);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void InsertAccount(Account a)
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                context.Accounts.Add(a);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateAccount(Account a)
        {
            try
            {
                using var context = new QuanLyBilliardsClubContext();
                var existingAccount = context.Accounts.Find(a.Id); // Assuming 'Id' is the primary key
                if (existingAccount != null)
                {
                    existingAccount.Username = a.Username;
                    existingAccount.Name = a.Name;
                    existingAccount.Password = a.Password;
                    // Copy other properties as needed

                    context.Entry(existingAccount).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
