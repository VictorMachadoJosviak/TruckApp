using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TruckApp.Domain.Entities.Base;

namespace TruckApp.Repository.Interfaces
{
    public interface IRepositoryBase<T, ID> where T : EntityBase
    {
        IQueryable<T> ListBy(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> ListAndOrderBy<TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TKey>> order, bool asc = true, params Expression<Func<T, object>>[] includeProperties);

        T FindBy(Func<T, bool> where, params Expression<Func<T, object>>[] includeProperties);

        bool Exists(Func<T, bool> where);

        IQueryable<T> List(params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> ListOrderBy<TKey>(Expression<Func<T, TKey>> order, bool asc = true, params Expression<Func<T, object>>[] includeProperties);

        T FindById(ID id, params Expression<Func<T, object>>[] includeProperties);

        T Add(T entity);

        T Edit(T entity);

        void Remove(T entity);

        void AddList(IEnumerable<T> entities);

        int Commit();
    }
}
