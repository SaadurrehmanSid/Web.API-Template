using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Web.API;
using Web.API.Core;
using Web.API.Infrastructure;
using Web.API.Infrastructure.Data.DAL;
using Web.API.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext(connectionString);

////TODO : We need to extract this in infrastrure layer
//builder.Services.AddDbContext<AppDbContext>(options =>
//                options.UseSqlServer(connectionString), ServiceLifetime.Scoped);

builder.Host.ConfigureContainer<ContainerBuilder>(containterBuilder => 
{
    containterBuilder.RegisterModule(new DefaultCoreModule());
    containterBuilder.RegisterModule(new DefaultInfrastructureModule(builder.Environment.EnvironmentName == "Development"));
});

builder.Services.InstallPdksApplications(builder.Configuration);
builder.Services.InstallRepositories();
builder.Services.InstallPdksServices(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
