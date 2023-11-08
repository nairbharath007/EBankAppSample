using EBankAppSample.Data;
using Microsoft.EntityFrameworkCore;

namespace EBankAppSample.Repository
{
    public class EntityRepository<T> : IRepository<T> where T : class
    {
        private MyContext _context;
        private DbSet<T> _table;

        public EntityRepository(MyContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable();
        }

        public void Detach(T entity)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }
        public int Add(T entity)
        {
            _table.Add(entity);
            return _context.SaveChanges();
        }

        public T Update(T entity)
        {
            _table.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            //Soft Delete--> if IsActive property exists
            var isActiveProperty = entity.GetType().GetProperty("IsActive");
            if (isActiveProperty != null)
            {
                isActiveProperty.SetValue(entity, false);
                _table.Update(entity);
            }
            else
                //hard delete
                _table.Remove(entity);
            _context.SaveChanges();
        }
    }
}
