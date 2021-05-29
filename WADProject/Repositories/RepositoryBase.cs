using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WADProject.Models;

namespace WADProject.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RestaurantContext RestaurantContext { get; set; }

        protected RepositoryBase(RestaurantContext restaurantContext)
        {
            this.RestaurantContext = restaurantContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.RestaurantContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RestaurantContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.RestaurantContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.RestaurantContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.RestaurantContext.Set<T>().Remove(entity);
        }

    }
    
}

