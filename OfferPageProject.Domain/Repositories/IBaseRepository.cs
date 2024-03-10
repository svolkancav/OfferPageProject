using Microsoft.EntityFrameworkCore.Query;
using OfferPageProject.Domain.Entities.Abstract;
using System.Linq.Expressions;

namespace OfferPageProject.Domain.Repositories
{
    public interface IBaseRepository<T> where T : class, IBaseEntity
    {
        Task Create(T entity);

        Task Update(T entity);

        Task Delete(T entity);

        Task<bool> Any(Expression<Func<T, bool>> predicate);

        Task<T> GetDefault(Expression<Func<T, bool>> expression);

        Task<List<T>> GetDefaults(Expression<Func<T, bool>> expression);

        Task<TResult> GetFilteredFirstOrDefault<TResult>
            (Expression<Func<T, TResult>> select,//select
            Expression<Func<T, bool>> where, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);//join

        Task<List<TResult>> GetFilteredList<TResult>(
            Expression<Func<T, TResult>> select,
            Expression<Func<T, bool>> where, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);//join
    }
}
