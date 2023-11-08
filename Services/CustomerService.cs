using EBankAppSample.Models;
using EBankAppSample.Repository;
using Microsoft.EntityFrameworkCore;

namespace EBankAppSample.Services
{
    public class CustomerService : ICustomerService
    {
        private IRepository<Customer> _customerRepository;
        private IRepository<Account> _accountRepository;
        private IRepository<Document> _documentRepository;

        public CustomerService(IRepository<Customer> customerRepository, 
            IRepository<Account> accountRepository,
            IRepository<Document> documentRepository)
        {
            _customerRepository = customerRepository;
            _accountRepository = accountRepository;
            _documentRepository = documentRepository;
        }

        public List<Customer> GetAll()
        {
            var customersQuery = _customerRepository.GetAll();
            return customersQuery
                .Where(customer => customer.IsActive) 
                .Include(customer => customer.Accounts
                .Where(account => account.IsActive))
                .Include(customer => customer.Documents)
                .Include(customer => customer.Queries
                .Where(query => query.IsActive))
                .ToList();
        }

        public Customer GetById(int id) 
        {
            var customerQuery = _customerRepository.GetAll();
            var customer = customerQuery
                .Where(customer => customer.CustomerId == id && customer.IsActive == true)
                .FirstOrDefault();
            if (customer != null)
            {
                _customerRepository.Detach(customer);
                
            }
            return customer;
        }

        public int Add(Customer customer)
        {
            return _customerRepository.Add(customer);
        }

        public Customer Update(Customer customer)
        {
            
            return _customerRepository.Update(customer);
        }

        public void Delete(Customer customer) 
        {
            _customerRepository.Delete(customer);
        }
    }
}
