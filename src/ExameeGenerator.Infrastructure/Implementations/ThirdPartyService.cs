using ExameeGenerator.Application.Interfaces;

namespace ExameeGenerator.Infrastructure.Implementations
{
    internal class ThirdPartyService : IThirdPartyService
    {
        public Task<bool> HealthAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }

        public Task InvokeAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
