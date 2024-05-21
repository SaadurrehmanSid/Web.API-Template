using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Web.API.Core.Domain.Entities.Identity;
using Web.API.SharedKernel.Interfaces;

namespace Web.API.Core.Domain.Interfaces
{

    public interface IGenericEfRepository<T> : IReadRepository<T> where T : class, IAggregateRoot
    {
        Task<T> AddAsync(T model);
        Task DeleteAsync(long id);
        Task<T?> GetByIdAsync(long id);
        Task UpdateAsync(T model);
        Task UpdateRangeAsync(List<T> model);
        IQueryable<T> Get();
        T? First(Expression<Func<T, bool>>? predicate = null, Func<IIncludable<T>, IIncludable>? includes = null);
        Task<T?> FirstAsync(Expression<Func<T, bool>>? predicate = null, Func<IIncludable<T>, IIncludable>? includes = null);
        Task<T?> LastAsync(Expression<Func<T, bool>>? predicate = null, Func<IIncludable<T>, IIncludable>? includes = null);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        IQueryable<T> GetWithTracking();
        Task<User?> GetClientUser(long clientId, long clientGroupId);
        Task<User?> GetSuperAdmin();
    }
}
