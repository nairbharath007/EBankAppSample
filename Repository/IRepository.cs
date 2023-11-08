namespace EBankAppSample.Repository
{
    public interface IRepository<T>
    {
        public IQueryable<T> GetAll();
        public void Detach(T entity);
        public int Add(T entity);
        public T Update(T entity);
        public void Delete(T entity);
    }
}
