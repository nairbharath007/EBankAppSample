using EBankAppSample.Models;

namespace EBankAppSample.Services
{
    public interface IQueryService
    {
        public List<Query> GetAll();
        public Query GetById(int id);
        public int Add(Query query);
        public Query Update(Query query);
        public void Delete(Query query);
    }
}
