using CMP.Data.Models;
using CMP.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CMP.Data.Repository.Implementation
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        protected CMPContext _cmpContext { get; set; }
        public GenericRepo(CMPContext cmpContext)
        {
            this._cmpContext = cmpContext;
        }
        public IQueryable<T> FindAll()
        {
            return this._cmpContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this._cmpContext.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            this._cmpContext.Set<T>().AddAsync(entity);
        }
        public void Update(T entity)
        {
            this._cmpContext.Entry<T>(entity).State = EntityState.Detached;
            this._cmpContext.Set<T>().Update(entity).State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            this._cmpContext.Set<T>().Remove(entity);
        }
    }
}
