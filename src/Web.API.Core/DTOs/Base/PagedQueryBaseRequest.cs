using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Core.DTOs.Base
{
    public class PagedQueryBaseRequest
    {
        public virtual int PageSize { get; set; } = 50;
        public int PageNumber { get; set; } = 1;
        public string? OrderBy { get; set; } = "CreatedDate";
        public bool SortByAscending { get; set; } = false;
        public string? SearchKeyword { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
