using EBankAppSample.Models;
using EBankAppSample.Repository;

namespace EBankAppSample.Services
{
    public class AccountService : IAccountService
    {
        private IRepository<Account> _accountRepository;
        public AccountService(IRepository<Account> accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public List<Account> GetAll()
        {
            var accountsQuery = _accountRepository.GetAll();
            return accountsQuery
                .Where(account => account.IsActive)
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
    }
}
