using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.API.Core.Domain.Entities;
using Web.API.Core.Domain.Interfaces.Repositories;
using Web.API.Infrastructure.Data.DAL;

namespace Web.API.Infrastructure.SqlRepositories
{
    public class PublicHolidayRepository : GenericEfRepository<PublicHoliday> ,IPublicHolidayRepository
    {
        private AppDbContext _context;
        public PublicHolidayRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
