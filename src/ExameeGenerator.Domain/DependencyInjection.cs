using Microsoft.Extensions.DependencyInjection;

namespace ExameeGenerator.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddSingleton<IExamFactory, ExamFactory>();
            return services;
        }
    }
}
