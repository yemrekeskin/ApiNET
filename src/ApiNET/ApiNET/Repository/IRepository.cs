using ApiNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ApiNET.Repository
{
    public interface IRepository<TEntity>
         where TEntity : BaseModel
    {
        TEntity FindById(long id, params Expression<Func<TEntity, object>>[] includeProperties);

        IQueryable<TEntity> FindAll(params Expression<Func<TEntity, object>>[] includeProperties);

        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);

        void Update(TEntity entity);

        void UpdateAll(Expression<Func<TEntity, object>> updateProperty, object updateValue, Expression<Func<TEntity, bool>> predicate = null);

        void Add(TEntity entity);

        void AddBatch(ICollection<TEntity> entities);

        TEntity Remove(long id);

        void RemoveBatch(ICollection<TEntity> entities);

        void Remove(TEntity entity);

        TEntity RemovePhysical(long id);

        IQueryable<TEntity> FromSql(string sqlQuery, params object[] parameters);

        IQueryable<TEntity> GetList();
    }
}