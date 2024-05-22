using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Application.Features.PublicHoliday.DTOs
{
    public class PublicHolidayResponseDto
    {
        public Guid Id { get; set; }
        public int? SequenceNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Explanation { get; set; } = string.Empty;
        public short? TypeNo { get; set; } = 0;
    }
}
