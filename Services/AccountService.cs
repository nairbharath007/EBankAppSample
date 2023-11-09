using EBankAppSample.Models;
using EBankAppSample.Repository;
using Microsoft.EntityFrameworkCore;

namespace EBankAppSample.Services
{
    public class AccountService : IAccountService
    {
        private IRepository<Account> _accountRepository;
        private readonly IRepository<Transaction> _transactionRepository;
        public AccountService(IRepository<Account> accountRepository, IRepository<Transaction> transactionRepository)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
        }

        public List<Account> GetAll()
        {
            var accountsQuery = _accountRepository.GetAll();
            return accountsQuery
                .Where(account => account.IsActive)
                .Include(account => account.Transactions
                .Where(transaction => transaction.IsActive))
                .ToList();

        }

        public Account GetById(int id)
        {
            var accountQuery = _accountRepository.GetAll();
            var account = accountQuery
                .Where(account => account.AccountId == id && account.IsActive)
                .FirstOrDefault();
            if(account != null)
            {
                _accountRepository.Detach(account);
            }
            return account;
        }

        public int Add(Account account)
        {
            return _accountRepository.Add(account);
        }

        public Account Update(Account account) 
        {
            return _accountRepository.Update(account);
        }

        public void Delete(Account account)
        {
            _accountRepository.Delete(account);
        }


        public double Deposit(int accountId, double amount)
        {
            var account = GetById(accountId);
            if (account != null)
            {
                account.Balance += amount;
                Update(account);
                return account.Balance;
            }
            return -1; // Account not found
        }

        // Withdraw funds from the account
        public double Withdraw(int accountId, double amount)
        {
            var account = GetById(accountId);
            if (account != null)
            {
                if (account.Balance >= amount)
                {
                    account.Balance -= amount;
                    Update(account);
                    return account.Balance;
                }
                return -2; // Insufficient balance
            }
            return -1; // Account not found
        }

        // Get the balance of the account
        public double GetBalance(int accountId)
        {
            var account = GetById(accountId);
            return account?.Balance ?? -1; // Account not found
        }
    }
}
