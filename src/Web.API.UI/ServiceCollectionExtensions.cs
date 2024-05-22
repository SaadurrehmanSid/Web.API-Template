using FluentValidation;
using MediatR;
using System.Reflection;
using Web.API.Application.Common.Behavior;

namespace Web.API
{
    public static class ServiceCollectionExtensions
    {
        public static void InstallPdksApplications(this IServiceCollection services, IConfiguration Configuration)
        {

            var assembly = AppDomain.CurrentDomain.Load("Web.API.Application");
            services.AddMediatR(_ => _.RegisterServicesFromAssembly(assembly));
            services.AddValidatorsFromAssembly(assembly);
            services.AddAutoMapper(assembly);
            //services.AddScoped(typeof(IExcelImportService<>), typeof(ExcelImporterService<>));
        }
    }
}
