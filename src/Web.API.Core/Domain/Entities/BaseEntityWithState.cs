using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Core.Domain.Entities
{
    public abstract class BaseEntityWithState<TId> : BaseEntity<TId>
    {
        public bool IsActive { get; set; }
    }
}
