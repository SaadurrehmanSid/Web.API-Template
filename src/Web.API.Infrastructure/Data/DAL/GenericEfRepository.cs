using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Web.API.Core.Domain.Entities.Identity;
using Web.API.Core.Domain.Interfaces;
using Web.API.Core.Extensions;
using Web.API.SharedKernel.Interfaces;

namespace Web.API.Infrastructure.Data.DAL
{
    public class GenericEfRepository<T> : RepositoryBase<T>, IGenericEfRepository<T>, SharedKernel.Interfaces.IRepository<T> where T : class, IAggregateRoot
    {
        private readonly AppDbContext _dbContext;

        public GenericEfRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> AddAsync(T model)
        {
            return await base.AddAsync(model);
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            return await base.AddRangeAsync(entities);
        }

        public async Task DeleteAsync(long id)
        {
            var model = await base.GetByIdAsync(id);
            await base.DeleteAsync(model!);
        }

        public async Task<T?> GetByIdAsync(long id)
        {
            return await base.GetByIdAsync(id);
        }

        public IQueryable<T> Get()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> GetWithTracking()
        {
            return _dbContext.Set<T>();
        }


        public async Task UpdateAsync(T model)
        {
            await base.UpdateAsync(model);
        }
        public async Task UpdateRangeAsync(List<T> model)
        {
            await base.UpdateRangeAsync(model);
        }

        public virtual T? First(Expression<Func<T, bool>>? predicate = null,
                                       Func<IIncludable<T>, IIncludable>? includes = null)
        {
            var dbSet = _dbContext.Set<T>() as IQueryable<T>;

            if (includes != null)
            {
                dbSet = dbSet.IncludeMultiple(includes);
            }

            return predicate == null
                       ? dbSet.FirstOrDefault()
                       : dbSet.FirstOrDefault(predicate);
        }

        public virtual Task<T?> LastAsync(Expression<Func<T, bool>>? predicate = null,
                                       Func<IIncludable<T>, IIncludable>? includes = null)
        {
            var dbSet = _dbContext.Set<T>() as IQueryable<T>;

            if (includes != null)
            {
                dbSet = dbSet.IncludeMultiple(includes);
            }

            return predicate == null
                       ? dbSet.LastOrDefaultAsync()
                       : dbSet.LastOrDefaultAsync(predicate);
        }

        public virtual Task<T?> FirstAsync(Expression<Func<T, bool>>? predicate = null,
                                  Func<IIncludable<T>, IIncludable>? includes = null)
        {
            var dbSet = _dbContext.Set<T>() as IQueryable<T>;

            if (includes != null)
            {
                dbSet = dbSet.IncludeMultiple(includes);
            }

            return predicate == null
                       ? dbSet.FirstOrDefaultAsync()
                       : dbSet.FirstOrDefaultAsync(predicate);
        }

        public Task<User?> GetClientUser(long clientId, long clientGroupId)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetSuperAdmin()
        {
            throw new NotImplementedException();
        }
    }
}
