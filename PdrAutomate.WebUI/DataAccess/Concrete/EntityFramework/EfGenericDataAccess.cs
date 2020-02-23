using Microsoft.EntityFrameworkCore;
using PdrAutomate.WebUI.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PdrAutomate.WebUI.DataAccess.Concrete.EntityFramework
{
    public class EfGenericDataAccess<T> : IGenericDataAccess<T> where T : class
    {
        protected readonly DbContext context;

        public EfGenericDataAccess(DbContext ctx)
        {
            context = ctx;
        }
        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public void Edit(T entity)
        {
            context.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }

        public T Get(int id)
        {
            return context.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
