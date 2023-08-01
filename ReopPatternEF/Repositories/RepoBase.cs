using Microsoft.EntityFrameworkCore;
using RepoPatternUnitOfWork.Constants;
using RepoPatternUnitOfWork.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReopPatternEF.Repositories
{
    public class RepoBase<T> : IBaseRepo<T> where T : class
    {
        protected ApplicationDBContext dBContext;
        public RepoBase(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public IEnumerable<T> GetAll()
        {
            return dBContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return dBContext.Set<T>().Find(id);
        }


        public async Task<T> GetByIdAsync(int id)
        {
            return await dBContext.Set<T>().FindAsync(id);

        }
        public T Find(Expression<Func<T, bool>> match, string[] includes = null)
        {
            IQueryable<T> query = dBContext.Set<T>();
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);
            return query.SingleOrDefault(match);
        }
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string[] includes = null)
        {
            IQueryable<T> query = dBContext.Set<T>();
            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);
            return query.Where(match).ToList();

        }
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, int? take, int? skip,
            Expression<Func<T, object>> orderBy = null, string OrderByDirection = OrderBy.Ascending
            )
        {
            IQueryable<T> query = dBContext.Set<T>().Where(match);
            if (take.HasValue)
                query = query.Take(take.Value);
            if (skip.HasValue)
                query = query.Take(skip.Value);
            if(orderBy != null)
            {
                if (OrderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }
            return query.ToList();
        }
        public T Add (T entity)
        {
            dBContext.Add(entity);
     
            return entity;
            
        }
        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            dBContext.AddRange(entities);
           
            return entities;

        }
   
       public T Update(T entity)
        {
            dBContext.Update(entity);
            return entity;
        }
       public void Delete(T entity)
        {
            dBContext.Set<T>().Remove(entity);
        }
       public void DeleteRange(IEnumerable<T> entities)
        {
            dBContext.Set<T>().RemoveRange(entities);
        }
        public void Attach(T entity)
        {
            dBContext.Set<T>().Attach(entity);
        }
        public int Count()
        {
            return dBContext.Set<T>().Count();
        }
        public int Count(Expression<Func<T, bool>> match)
        {
            return dBContext.Set<T>().Count(match);
        }

        
    }
}
