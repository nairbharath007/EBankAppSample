using EBankAppSample.Models;
using EBankAppSample.Repository;

namespace EBankAppSample.Services
{
    public class QueryService : IQueryService
    {
        private readonly IRepository<Query> _queryRepository;

        public QueryService(IRepository<Query> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public List<Query> GetAll()
        {
            var queriesQuery = _queryRepository.GetAll();
            return queriesQuery
                .Where(query => query.Customer.IsActive && query.IsActive) 
                .ToList();
        }

        public Query GetById(int id)
        {
            var queryQuery = _queryRepository.GetAll();
            var query = queryQuery
                .Where(query => query.QueryId == id && query.Customer.IsActive && query.IsActive) 
                .FirstOrDefault();
            if (query != null)
            {
                _queryRepository.Detach(query);
            }
            return query;
        }

        public int Add(Query query)
        {
            return _queryRepository.Add(query);
        }

        public Query Update(Query query)
        {
            return _queryRepository.Update(query);
        }

        public void Delete(Query query)
        {
            _queryRepository.Delete(query);
        }
    }
}
