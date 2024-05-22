using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.API.Application.Features.PublicHoliday.DTOs;
using Web.API.Core.Domain.Entities;

namespace Web.API.Application.Mappings
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            #region  Public Holiday Mapping
            CreateMap<PublicHoliday, PublicHolidayResponseDto>();
            #endregion
        }
    }
}
