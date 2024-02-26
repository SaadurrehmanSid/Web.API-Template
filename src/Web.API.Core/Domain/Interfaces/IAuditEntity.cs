using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Core.Domain.Interfaces
{
    public interface IAuditEntity
    {
        public DateTimeOffset CreatedDate { get; set; }
        public long? CreatedBy { get; set; }
        public DateTimeOffset? ModifiedDate { get; set; }
        public long? ModifiedBy { get; set; }
    }
}
