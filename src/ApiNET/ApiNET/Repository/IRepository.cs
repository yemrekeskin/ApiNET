using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApiNET.Repository
{
    public interface IRepository<TModel>
    {
        TModel Get(long id, params Expression<Func<TModel, object>>[] includeProperties);


        IQueryable<TModel> List(params Expression<Func<TModel, object>>[] includeProperties);
        IQueryable<TModel> List(Expression<Func<TModel, bool>> predicate, params Expression<Func<TModel, object>>[] includeProperties);
        IQueryable<TModel> List(Expression<Func<TModel, bool>> predicate);
        IQueryable<TModel> List(IEnumerable<long> ids);

        void Update(TModel entity);
        void Add(TModel entity);
        void AddBatch(ICollection<TModel> entities);


        TModel Remove(long id);
        void RemoveBatch(ICollection<TModel> entities);
        void Remove(TModel entity);
        void Remove(Expression<Func<TModel, bool>> predicate);

        IQueryable<TModel> FromSql(string sqlQuery, params object[] parameters);

        int SaveChanges();
    }
}
