using System;
using System.Linq;
using System.Linq.Expressions;

namespace App.Template.Domain.Contracts.Repository
{
    public interface IRepository<T>
    {
        T FindById(Guid id);
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}