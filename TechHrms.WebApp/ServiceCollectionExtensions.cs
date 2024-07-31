using Microsoft.EntityFrameworkCore;
using TechHrms.Infrastructure;
using TechHrms.Infrastructure.Repository;
using TechHrms.Infrastructure.Repository.Abstraction;
using TechHrms.Application.CommandHandlers.EmployeeCommandHandlers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TechHrms.Application.CommandHandlers.AdministrationCommandHandler;
using TechHrms.Application.CommandHandlers.CreatePMCommandHandler;

namespace TechHrms.WebApp
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection InitializeApp(this IServiceCollection serviceCollection, ConfigurationManager configurationManager)
        {
            string connectionString = configurationManager.GetConnectionString("TechHrmsDbConnection");

            serviceCollection.AddHttpContextAccessor();
            serviceCollection.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<IEmployeeRepository, EmployeeRepository>();
            serviceCollection.AddScoped<IAdministrationRepository, AdministrationRepository>();
            serviceCollection.AddScoped<IProjectManagmentRepository, ProjectManagmentRepository>();
            serviceCollection.AddScoped<ITrainingRepository, TrainingRepository>();
            serviceCollection.AddScoped<IHRRaportRepository, HRRaportRepository>();

            serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
                typeof(CreateEmployeeCommandHandler).Assembly,
                typeof(CreatePMCommandHandler).Assembly,
                typeof(CreateAdministrationCommandHandler).Assembly));

            return serviceCollection;
        }

    }
}
