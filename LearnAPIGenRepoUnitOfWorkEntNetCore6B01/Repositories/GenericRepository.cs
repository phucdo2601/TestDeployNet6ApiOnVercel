using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Interfaces;
using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public GenericRepository(LearnUOfWorkVPSCSharpContext context)
        {
            Context = context;
        }

        public LearnUOfWorkVPSCSharpContext Context { get; }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }

        public IQueryable<T> FindAll()
        {
            return Context.Set<T>().AsNoTracking();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }
        /**
         * AsNoTracking:
         * Trả về một truy vấn mới mà ở đó các thực thể sẽ không được cached trong DBContext (Thừa kế từ DBQuery)
         * Những thực thể trả vềnhư AsNoTracking sẽ không được theo dõi bởi DBContext. 
         * Điều này sẽ làm tăng hiệu năng đáng kể cho những thực thể read only.
         */
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition)
        {
            return Context.Set<T>().AsNoTracking().Where(condition);
        }

        public IQueryable<T> FindInclude(params Expression<Func<T, object>>[] includes)
        {
            var query = Context.Set<T>().AsNoTracking();
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }

        public IQueryable<T> FindIncludeByCondition(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes)
        {
            var query = Context.Set<T>().AsNoTracking().Where(condition);
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void RemoveAll(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }
    }
}
