using Microsoft.EntityFrameworkCore;
using SupermarketProA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SupermarketProA.Repository
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private readonly SupermarketContext _context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(SupermarketContext context)
        {
            _context = context;
            this.dbSet = _context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll(
            Expression<Func<TEntity, bool>> filter = null,
            int? limitFor = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;


            if (filter != null) query = query.Where(filter);

            if (limitFor != null) query = query.Take((int)limitFor);

            foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

            return (orderBy != null) ? orderBy(query).ToList() : query.ToList();
        }

        public virtual IEnumerable<TEntity> TakeGetAll(int Nos, Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = dbSet;
            if (filter != null)
                query = query.Where(filter).Take(Nos);
            return query.ToList();
        }

        public virtual TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
                dbSet.Attach(entityToDelete);
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
