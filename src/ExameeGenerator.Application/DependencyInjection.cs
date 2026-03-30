using ExameeGenerator.Application.Commands;
using ExameeGenerator.Application.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace ExameeGenerator.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddScoped<CreateExamCommandHandler>();
            services.AddScoped<GetExamByIdQueryHandler>();

            return services;
        }
    }
}
