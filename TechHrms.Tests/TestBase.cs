using Microsoft.Extensions.DependencyInjection;
using System;
using TechHrms.Application.CommandHandlers.EmployeeCommandHandlers;
using TechHrms.Infrastructure.Repository.Abstraction;
using TechHrms.Infrastructure.Repository;
using TechHrms.Infrastructure;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace TechHrms.Tests
{
    public abstract class TestBase
    {
        protected IServiceProvider Prepare()
        {
            IConfigurationRoot configurationRoot = GetConfigurationRoot();
            IServiceCollection services = new ServiceCollection();
            string connectionString = configurationRoot.GetConnectionString("TechHrmsDbConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IAdministrationRepository, AdministrationRepository>();
            services.AddMediatR((cfg) => cfg.RegisterServicesFromAssemblies(typeof(CreateEmployeeCommandHandler).Assembly));

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }

        protected IConfigurationRoot GetConfigurationRoot()
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            return configurationRoot;
        }

    }
}
