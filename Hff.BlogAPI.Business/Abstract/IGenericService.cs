using Hff.BlogAPI.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hff.BlogAPI.Business.Abstract
{
    public interface IGenericService<TEntity> where TEntity:class,IEntity,new()
    {
        /// <summary>
        /// Only GetAll
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> GetAllAsync();
        /// <summary>
        /// Get All With Expression
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression);
        /// <summary>
        /// Get All With Sorting and Filtering.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="expression"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, TKey>> keySelector);
        /// <summary>
        /// Get All with Sorting.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task Remove(TEntity entity);
    }
}
