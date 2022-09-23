using Microsoft.EntityFrameworkCore;
using RIS_API.Data;
using RIS_API.IRepositories;
using Ris2022.Data;
using Ris2022.Repositories;
using System.Linq;
using System.Linq.Expressions;

namespace Ris2022.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly RISDbContext _context;
        protected readonly DbSet<T> _db;
        public GenericRepository(RISDbContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await _db.Where(expression).ToListAsync();
        }

        //public Task<T> Get(Expression<Func<T, bool>> expression = null, List<string> includes = null)
        //{
        //    throw new NotImplementedException();
        //}
        public async Task<T> GetAsync(Expression<Func<T, bool>> expression, List<string> includes = null)
        {
            IQueryable<T> query = _db;
            if(includes != null)
            {
                foreach(var navProperty in includes)
                {
                    query = query.Include(navProperty);
                }
            }
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        //public Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        //{
        //    throw new NotImplementedException();
        //}
        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {
            IQueryable<T> query = _db;
            if(expression!=null)
            {
                query = query.Where(expression);
            }
            if (includes != null)
            {
                foreach (var navProperty in includes)
                {
                    query = query.Include(navProperty);
                }
            }
            if(orderBy !=null)
            {
                query = orderBy(query);
            }
            return await query.AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task InsertAsync(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task InsertRangeAsync(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public void Remove(T entity)
        {
            _db.Remove(entity);
        }


        public void RemoveRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
