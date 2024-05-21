using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Core.Domain.Interfaces
{
    public interface IIncludable
    { }

    public interface IIncludable<out TEntity> : IIncludable
    { }

    public interface IIncludable<out TEntity, out TProperty> : IIncludable<TEntity>
    { }
}
