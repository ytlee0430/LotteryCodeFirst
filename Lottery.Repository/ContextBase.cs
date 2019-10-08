using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Lottery.Repository.Interfaces;
using Z.EntityFramework.Plus;

namespace Lottery.Repository
{
    public class ContextBase<T> where T : class, IEntity
    {
        protected readonly IDatabaseContext _database;

        public ContextBase(IDatabaseContext database)
        {
            _database = database;
        }

        public virtual bool Add(T entity)
        {
            _database.Set<T>().Add(entity);
            return _database.SaveChanges() > 0;
        }

        public virtual bool Add(IEnumerable<T> entitys)
        {
            foreach (var entity in entitys)
                _database.Set<T>().Add(entity);

            return _database.SaveChanges() > 0;
        }

        public virtual T Get(int id)
        {
            return _database.Set<T>().Single(p => p.ID == id);
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> exp)
        {
            return _database.Set<T>().Where(exp);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _database.Set<T>();
        }

        public virtual int GetRowCount(Expression<Func<T, bool>> exp)
        {
            return _database.Set<T>().Where(exp).Count();
        }

        public virtual bool Remove(Expression<Func<T, bool>> exp)
        {
            foreach (var entity in _database.Set<T>().Where(exp))
                _database.Set<T>().Remove(entity);
            return _database.SaveChanges() > 0;
        }

        public virtual bool Remove(T entity)
        {
            _database.Set<T>().Remove(entity);
            return _database.SaveChanges() > 0;
        }

        public virtual bool Update(Expression<Func<T, bool>> exp, Expression<Func<T, T>> updateFactory)
        {
            return _database.Set<T>().Where(exp).Update(updateFactory) > 0;
        }

        public virtual bool Update(T entity)
        {
            var entry = _database.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                var set = _database.Set<T>();
                var attachedEntity = set.Find(entity.ID);

                if (attachedEntity != null)
                {
                    var attachedEntry = _database.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    entry.State = EntityState.Modified;
                }
            }
            return _database.SaveChanges() > 0;
        }

        public virtual bool Update(IEnumerable<T> entitys)
        {
            foreach (var entity in entitys)
            {
                var entry = _database.Entry(entity);
                if (entry.State == EntityState.Detached)
                {
                    var set = _database.Set<T>();
                    var attachedEntity = set.Find(entity.ID);

                    if (attachedEntity != null)
                    {
                        var attachedEntry = _database.Entry(attachedEntity);
                        attachedEntry.CurrentValues.SetValues(entity);
                    }
                    else
                    {
                        entry.State = EntityState.Modified;
                    }
                }
            }
            return _database.SaveChanges() > 0;
        }
    }
}