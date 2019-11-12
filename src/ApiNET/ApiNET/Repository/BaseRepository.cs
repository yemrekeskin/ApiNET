using ApiNET.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiNET.Repository
{
    public abstract class BaseRepository<TModel>
         : IRepository<TModel>
         where TModel : BaseModel
    {
        private readonly DbContext context;

        public BaseRepository(DbContext context)
        {
            this.context = context;
        }

        public BaseRepository()
        {
            this.context = new ApplicationDbContext();
        }


        public virtual void Add(TModel entity)
        {
            var table = context.Set<TModel>();
            table.Add(entity);
            this.SaveChanges();
        }

        public virtual void AddBatch(ICollection<TModel> entities)
        {
            var table = context.Set<TModel>();
            foreach (var entity in entities)
            {
                table.Add(entity);
            }
            this.SaveChanges();
        }

        public virtual IQueryable<TModel> List(params Expression<Func<TModel, object>>[] includeProperties)
        {
            IQueryable<TModel> entities = context.Set<TModel>().AsNoTracking();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    entities = entities.Include(includeProperty);
                }
            }
            return entities;
        }

        public virtual IQueryable<TModel> List(Expression<Func<TModel, bool>> predicate)
        {
            var table = this.List();
            var result = table.Where(predicate);
            return result;
        }

        public virtual IQueryable<TModel> List(Expression<Func<TModel, bool>> predicate, params Expression<Func<TModel, object>>[] includeProperties)
        {
            var table = this.List(includeProperties);
            var result = table.Where(predicate);
            return result;
        }

        public virtual TModel Get(long id, params Expression<Func<TModel, object>>[] includeProperties)
        {
            var table = this.List(includeProperties);
            var result = table.SingleOrDefault(d => d.Id == id);
            return result;
        }

        public virtual TModel Remove(long id)
        {
            TModel entity = this.Get(id);
            this.Remove(entity);
            return entity;
        }

        public virtual void Remove(TModel entity)
        {
            this.context.Set<TModel>().Remove(entity);
            this.context.SaveChanges();
        }

        public virtual void RemoveBatch(ICollection<TModel> entities)
        {
            foreach (var entity in entities)
            {
                this.Remove(entity);
            }
            this.context.SaveChanges();
        }

        public virtual void Update(TModel entity)
        {
            this.context.Set<TModel>().Update(entity);
            this.SaveChanges();
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public IQueryable<TModel> List(IEnumerable<long> ids)
        {
            var table = this.List().Where(d => ids.Contains(d.Id));
            return table;
        }

        public void Remove(Expression<Func<TModel, bool>> predicate)
        {
            var result = this.List(predicate).ToList();
            this.RemoveBatch(result);
        }

        public IQueryable<TModel> FromSql(string sqlQuery, params object[] parameters)
        {
            return context.Set<TModel>().AsNoTracking().FromSql(sqlQuery, parameters);
        }
    }
}
