using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.API.Core.Domain.Interfaces;

namespace Web.API.Core.Domain.Entities
{
    public abstract class BaseEntity<TId> :  ISoftDeleteEntity, IAuditEntity
    {
        public TId Id { get; set; } = default!;
        public DateTimeOffset CreatedDate { get; set; }
        public long? CreatedBy {get;set;}
        public DateTimeOffset? ModifiedDate {get;set;}
        public long? ModifiedBy {get;set;}
        public bool IsDeleted {get;set;}
    }

    
}
