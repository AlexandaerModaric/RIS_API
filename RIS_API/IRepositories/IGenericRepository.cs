using System.Linq.Expressions;

namespace RIS_API.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        //Task<IList<T>> GetAll(
        //    Expression<Func<T, bool>> expression = null,
        //    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        //    List<string> includes = null);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<string> includes = null);
        //Task<T> Get(Expression<Func<T, bool>> expression = null,
        //    List<string> includes = null);
        Task<T> GetAsync(Expression<Func<T, bool>> expression,
            List<string> includes = null);
        Task InsertAsync(T entity);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);
        Task InsertRangeAsync(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entity);
    }
}
