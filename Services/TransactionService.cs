using EBankAppSample.Models;
using EBankAppSample.Repository;


namespace EBankAppSample.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IRepository<Transaction> _transactionRepository;

        public TransactionService(IRepository<Transaction> transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public List<Transaction> GetAll()
        {
            var transactionsQuery = _transactionRepository.GetAll();
            return transactionsQuery
                .Where(transaction => transaction.IsActive)
                .ToList();
        }

        public Transaction GetById(int id)
        {
            var transactionQuery = _transactionRepository.GetAll();
            return transactionQuery.FirstOrDefault(t => t.TransactionId == id);
        }

        public int Add(Transaction transaction)
        {
            return _transactionRepository.Add(transaction);
        }

        public Transaction Update(Transaction transaction)
        {
            return _transactionRepository.Update(transaction);
        }

        public void Delete(Transaction transaction)
        {
            _transactionRepository.Delete(transaction);
        }
    }
}
