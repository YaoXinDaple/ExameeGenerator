using ExameeGenerator.Application.Interfaces;
using ExameeGenerator.Infrastructure.HealthChecks;
using ExameeGenerator.Infrastructure.Implementations;
using ExameeGenerator.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExameeGenerator.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IThirdPartyService, ThirdPartyService>();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("examdb")));


            // Health checks
            services.AddHealthChecks()
                .AddDbContextCheck<AppDbContext>("database")
                .AddCheck<ExamServiceHealthChecks>("third-party-services");

            return services;
        }
    }
}
