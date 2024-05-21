using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.API.Application.Common.Helpers;
using Web.API.Core.Domain.Entities.Identity;
using Web.API.Infrastructure.Data.DAL;

namespace Web.API.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void InstallPdksServices(this IServiceCollection services, IConfiguration configuration)
        {

            //services.AddTransient(typeof(IPipelineBehavior<TRequest, TResponse>), typeof(AuthorizationBehaviour<,>));

            RegisterData(services);
            RegisterServiceConnectors(services);
            RegisterServices(services);
            RegisterAuth(services, configuration);

        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IExceptionHelper, ExceptionHelper>();
        }

        private static void RegisterServiceConnectors(IServiceCollection services)
        {
            //services.AddTransient<ISignalRNotifier, SignalRNotifier>();
        }

        private static void RegisterData(IServiceCollection services)
        {
            //services.AddIdentity<User, Role>(options =>
            //{
            //    options.Password.RequireLowercase = true;
            //    options.Password.RequireUppercase = true;
            //    options.Password.RequiredLength = 8;
            //    options.Password.RequireNonAlphanumeric = true;
            //})
            //.AddClaimsPrincipalFactory<ClaimPrincipalFactory>()
            //.AddEntityFrameworkStores<AppDbContext>();
            //.AddUserStore<ExtendedUserStore>()
            //.AddRoleValidator<TenantRoleValidator>()
            //.AddDefaultTokenProviders()
            //.AddTokenProvider(IdentityConstants.RefreshTokenProvider, typeof(DataProtectorTokenProvider<User>));
            //var defaultRoleValidator = services.FirstOrDefault(descriptor => descriptor.ImplementationType == typeof(RoleValidator<Role>));
            //if (defaultRoleValidator != null) { services.Remove(defaultRoleValidator); }
        }

        private static void RegisterAuth(IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
            //var builderService = services.BuildServiceProvider();
            //var claimApplication = builderService.GetRequiredService<IClaimApplication>();
            //services.RegisterPolicy(claimApplication);

            //var jwtOptions = new JwtOptions();
            //configuration.Bind(nameof(JwtOptions), jwtOptions);

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //    .AddJwtBearer(options =>
            //    {
            //        options.RequireHttpsMetadata = false;
            //        options.Events = new JwtBearerEvents();

            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidIssuer = jwtOptions.Issuer,
            //            ValidAudience = jwtOptions.Audience,
            //            IssuerSigningKey = JwtTokenBuilder.CreateSigningKey(jwtOptions.Secret!),
            //            ClockSkew = TimeSpan.Zero,
            //        };
            //    });
        }
    }
}
