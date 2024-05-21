using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.API.SharedKernel.Interfaces;

namespace Web.API.Core.Domain.Entities
{
    public class PublicHoliday : BaseEntityWithState<Guid> ,IAggregateRoot
    {
        public int? SequenceNo { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        [MaxLength(100)]
        public string Explanation { get; set; }

        public short? TypeNo { get; set; }

        [Required]
        public int CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [Required]
        public int TenantId { get; set; }
    }
}
