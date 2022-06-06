using BNP.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BNP.DataAccess.Repositories
{
    public class GenericRepository : IGenericRepository
    {
        protected readonly ApplicationContext _context;
        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Add(entity);

        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> GetAll<TEntity>(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class
        {
            return GetQueryable<TEntity>(null, orderBy, includeProperties, skip, take).ToList();
        }

        public IQueryable<TEntity> GetQueryable<TEntity>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null) where TEntity : class
        {
            includeProperties = includeProperties ?? string.Empty;
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
               (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

        public IQueryable<TEntity> SelectInclude<TEntity>(Expression<Func<TEntity, object>> include) where TEntity : class
        {
            return _context.Set<TEntity>().Include(include);

        }

        public IQueryable<TEntity> SelectIncludeMany<TEntity>(params Expression<Func<TEntity, object>>[] includes) where TEntity : class
        {
            return _context.Set<TEntity>().IncludeMultiple(includes);

        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Set<TEntity>().Attach(entity);
        }





        //public void Add(TEntity entity)
        //{
        //    _context.Set<TEntity>().Add(entity);
        //}

        //public List<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        //{
        //    return _context.Set<TEntity>().Where(expression).ToList();
        //}

        //public List<TEntity> GetAll()
        //{
        //    return _context.Set<TEntity>().ToList();
        //}


        //public void Remove(TEntity entity)
        //{
        //    _context.Set<TEntity>().Remove(entity);
        //}

    }
}
