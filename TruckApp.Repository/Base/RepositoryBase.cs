using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TruckApp.Domain.Entities.Base;
using TruckApp.Infra.Persistence;
using TruckApp.Repository.Interfaces;

namespace TruckApp.Repository.Base
{
    public class RepositoryBase<T, ID> : IRepositoryBase<T, ID> where T : EntityBase
    {
        private readonly DataContext context;
        public RepositoryBase(DataContext _context)
        {
            context = _context;
        }

        public T Add(T entidade)
        {
            return context.Set<T>().Add(entidade).Entity;
        }

        public void AddList(IEnumerable<T> entidades)
        {
            context.Set<T>().AddRange(entidades);
        }

        public int Commit()
        {
            return context.SaveChanges();
        }

        public T Edit(T entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return entity;
        }

        public bool Exists(Func<T, bool> where)
        {
            return context.Set<T>().Any(where);
        }

        public T FindBy(Func<T, bool> where, params Expression<Func<T, object>>[] includeProperties)
        {
            return List(includeProperties).FirstOrDefault(where);
        }

        public T FindById(ID id, params Expression<Func<T, object>>[] includeProperties)
        {
            if (includeProperties.Any())
            {
                return List(includeProperties).FirstOrDefault(x => x.Id.ToString() == id.ToString());
            }

            return context.Set<T>().Find(id);
        }

        public IQueryable<T> ListAndOrderBy<TKey>(Expression<Func<T, bool>> where, Expression<Func<T, TKey>> order, bool asc = true, params Expression<Func<T, object>>[] includeProperties)
        {
            return asc ? ListBy(where, includeProperties).OrderBy(order) : ListBy(where, includeProperties).OrderByDescending(order);
        }

        public IQueryable<T> ListBy(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            return List(includeProperties).Where(where);
        }

        public IQueryable<T> ListOrderBy<TKey>(Expression<Func<T, TKey>> order, bool asc = true, params Expression<Func<T, object>>[] includeProperties)
        {
            return asc ? List(includeProperties).OrderBy(order) : List(includeProperties).OrderByDescending(order);

        }

        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public IQueryable<T> List(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = context.Set<T>();

            if (includeProperties.Any())
            {
                return Include(context.Set<T>(), includeProperties);
            }

            return query;
        }

        private IQueryable<T> Include(IQueryable<T> query, params Expression<Func<T, object>>[] includeProperties)
        {
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }

            return query;
        }
    }
}
