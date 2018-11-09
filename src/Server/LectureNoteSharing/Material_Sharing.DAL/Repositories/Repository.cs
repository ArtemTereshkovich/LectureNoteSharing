using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Material_Sharing.DAL.Data;
using Material_Sharing.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Material_Sharing.DAL.Repositories{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected ApplicationDataBaseContext _dataBaseContext;
        protected DbSet<TEntity> _DbSet;
        public Repository(ApplicationDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
            _DbSet = _dataBaseContext.Set<TEntity>(); 
        }
        public virtual TEntity Add(TEntity entity)
        {
            return _DbSet.Add(entity).Entity;
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            _DbSet.AddRange(entities);
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _DbSet.Where(predicate);
        }

        public virtual TEntity Get(string id)
        {
            return _DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _DbSet.ToList();
        }

        public virtual TEntity Remove(TEntity entity)
        {
            return _DbSet.Remove(entity).Entity;
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _DbSet.RemoveRange(entities);
        }

        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _DbSet.SingleOrDefault(predicate);
        }

        public virtual TEntity Update(TEntity entity)
        {
            return _DbSet.Update(entity).Entity;
        }
    }
}