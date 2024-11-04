using Database;
using Microsoft.EntityFrameworkCore;
namespace Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly OracleDbContext _oracleDbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(OracleDbContext oracleDbContext)
        {
            _oracleDbContext = oracleDbContext;
            _dbSet = _oracleDbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _oracleDbContext.Add(entity);
            _oracleDbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _oracleDbContext.Remove(entity);
            _oracleDbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int? id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            _oracleDbContext.Entry(entity).State = EntityState.Modified;

            _oracleDbContext.SaveChanges();
        }
    }
}
