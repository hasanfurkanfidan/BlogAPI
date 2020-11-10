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
        Task<TEntity> FindByIdAsync(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task Remove(TEntity entity);
    }
}
