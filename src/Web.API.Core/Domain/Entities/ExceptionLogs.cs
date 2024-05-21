using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Core.Domain.Entities
{
    public class ExceptionLogs : BaseEntityWithState<Guid>
    {
        public string Exception { get; set; } = string.Empty;
        public Guid? TenantId { get; set; }
        public Guid? ProjectId { get; set; }
        public string Controller { get; set; } = string.Empty;
        public string Request { get; set; } = string.Empty;
        public bool IsSolved { get; set; }
        public string Explanation { get; set; } = string.Empty;
       
    }
}
