using ApiNET.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiNET.Repository
{
    public class Repository<TModel, TDbContext>
        : IRepository<TModel>
        where TModel : BaseModel
        where TDbContext : DbContext
    {
        private readonly TDbContext context;

        public Repository(TDbContext context)
        {
            this.context = context;
        }

        public virtual void Add(TModel entity)
        {
            var table = context.Set<TModel>();
            table.Add(entity);
            context.SaveChanges();
        }

        public virtual void AddBatch(ICollection<TModel> entities)
        {
            var table = context.Set<TModel>();
            foreach (var entity in entities)
            {
                table.Add(entity);
            }
            context.SaveChanges();
        }

        public virtual IQueryable<TModel> FindAll(params Expression<Func<TModel, object>>[] includeProperties)
        {
            IQueryable<TModel> items = context.Set<TModel>();

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }

            return items;
        }

        public IQueryable<TModel> FindAll(Expression<Func<TModel, bool>> predicate, params Expression<Func<TModel, object>>[] includeProperties)
        {
            var table = FindAll(includeProperties);
            return table.Where(predicate);
        }

        public virtual TModel FindById(long id, params Expression<Func<TModel, object>>[] includeProperties)
        {
            var item = FindAll(includeProperties).SingleOrDefault(s => s.Id.Equals(id));

            return item;
        }

        public virtual TModel Remove(long id)
        {
            var entity = FindById(id);
            Remove(entity);
            return entity;
        }

        public virtual void RemoveBatch(ICollection<TModel> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
            }

            context.SaveChanges();
        }

        public virtual void Remove(TModel entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public virtual TModel RemovePhysical(long id)
        {
            var entity = FindById(id);
            context.Remove(entity);
            context.SaveChanges();
            return entity;
        }

        public virtual void Update(TModel entity)
        {
            context.SaveChanges();
        }

        public virtual void UpdateAll(Expression<Func<TModel, object>> updateProperty, object updateValue, Expression<Func<TModel, bool>> predicate)
        {
            var unaryExpression = updateProperty.Body as UnaryExpression;
            var updateType = unaryExpression.Operand.Type;
        }

        public IQueryable<TModel> FromSql(string sqlQuery, params object[] parameters)
        {
            return context.Set<TModel>().FromSql(sqlQuery, parameters);
        }

        public virtual IQueryable<TModel> GetList()
        {
            IQueryable<TModel> items = context.Set<TModel>();
            return items;
        }
    }
}
