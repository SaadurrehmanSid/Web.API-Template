using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.API.Core.Domain.Entities;

namespace Web.API.Core.Domain.Interfaces.Repositories
{
    public interface IPublicHolidayRepository : IGenericEfRepository<PublicHoliday>
    {
    }
}
