using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.API.Core.Domain.Interfaces.Repositories;
using Web.API.Infrastructure.SqlRepositories;

namespace Web.API.Infrastructure
{
    public static class RepositoryInstaller
    {
        public static void InstallRepositories(this IServiceCollection services)
        {
            services.AddTransient<IPublicHolidayRepository,PublicHolidayRepository>();
        }
    }
}
