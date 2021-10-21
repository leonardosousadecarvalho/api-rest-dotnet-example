using System;
using System.Linq;
using System.Linq.Expressions;
using App.Template.Domain.Contracts.Repository;
using App.Template.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace App.Template.Infra.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApiContext _context;
        public Repository(ApiContext context)
        {
            _context = context;
        }
        public IQueryable<T> FindAll(bool trackChanges = false) =>
            !trackChanges
            ? _context.Set<T>()
            : _context.Set<T>().AsNoTracking();  
        public T FindById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }
        public System.Linq.IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false) =>
            !trackChanges
           ? _context.Set<T>().Where(expression)
           : _context.Set<T>().Where(expression).AsNoTracking();
        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges(); ;
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}