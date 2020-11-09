﻿using Hff.BlogAPI.DataAccess.Abstract;
using Hff.BlogAPI.DataAccess.Concrete.EntityFrameworkCore.Context;
using Hff.BlogAPI.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hff.BlogAPI.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<TEntity>:IGenericDal<TEntity> where TEntity : class, IEntity, new()
    {
        public async Task AddAsync(TEntity entity)
        {
            using (var context = new BlogContext())
            {
              await context.AddAsync(entity);
                await context.SaveChangesAsync();
            }
        }

        public async  Task<List<TEntity>> GetAllAsync()
        {
            using (var context = new BlogContext())
            {
                return await context.Set<TEntity>().ToListAsync();
            }
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            using (var context = new BlogContext())
            {
                return await context.Set<TEntity>().Where(expression).ToListAsync();
            }
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            using (var context = new BlogContext())
            {
                return await context.Set<TEntity>().Where(expression).FirstOrDefaultAsync();
            }
        }

        public async Task Remove(TEntity entity)
        {
            using (var context = new BlogContext())
            {
                context.Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using (var context = new BlogContext())
            {
                context.Update(entity);
               await context.SaveChangesAsync();
            }
        }
    }
}
