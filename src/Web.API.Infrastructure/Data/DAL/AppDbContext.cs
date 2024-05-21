using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.API.Core.Domain.Entities;
using Web.API.Core.Domain.Entities.Identity;

namespace Web.API.Infrastructure.Data.DAL
{
    //public class AppDbContext : IdentityDbContext<User,
    //Role,
    //long,
    //UserClaim,
    //UserRole,
    //UserLogin,
    //RoleClaim,
    //UserToken>
    //{
    //    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    //    {
    //    }
    //}
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<PublicHoliday> PublicHolidays { get; set; }
        public DbSet<ExceptionLogs> ExceptionLogs { get; set; }
    }
}
