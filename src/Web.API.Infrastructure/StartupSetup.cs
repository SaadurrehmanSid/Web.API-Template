﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.API.Infrastructure.Data.DAL;

namespace Web.API.Infrastructure
{
    public static class StartupSetup
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString) =>
             //services.AddDbContext<AppDbContext>(options =>
             //    options.UseSqlite(connectionString)); // will be created in web project root
             services.AddDbContext<AppDbContext>(options =>
                  options.UseSqlServer(connectionString), ServiceLifetime.Scoped);

    }

}
