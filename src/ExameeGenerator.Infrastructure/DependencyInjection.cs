using ExameeGenerator.Application.Interfaces;
using ExameeGenerator.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ExameeGenerator.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IExamRepository, ExamRepository>();

            return services;
        }
    }
}
