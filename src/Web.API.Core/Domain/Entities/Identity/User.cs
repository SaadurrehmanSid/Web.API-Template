using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.API.Core.Domain.Interfaces;

namespace Web.API.Core.Domain.Entities.Identity
{
    public class User : IdentityUser<long>, IAuditEntity, ISoftDeleteEntity, IState
    {
        public DateTimeOffset CreatedDate { get; set; }
        public long? CreatedBy { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set;}
    }
}
