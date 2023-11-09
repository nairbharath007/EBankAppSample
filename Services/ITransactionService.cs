using EBankAppSample.Models;

namespace EBankAppSample.Services
{
    public interface ITransactionService
    {
        public List<Transaction> GetAll();
        public Transaction GetById(int id);
        public int Add(Transaction transaction);
        public Transaction Update(Transaction transaction);
        public void Delete(Transaction transaction);
    }
}
