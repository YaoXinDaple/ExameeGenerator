using ExameeGenerator.Application.Interfaces;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;

namespace ExameeGenerator.Infrastructure.HealthChecks
{
    public sealed class ExamServiceHealthChecks : IHealthCheck
    {
        private readonly ILogger<ExamServiceHealthChecks> _logger;
        private readonly IThirdPartyService _thirdPartyService;

        public ExamServiceHealthChecks(ILogger<ExamServiceHealthChecks> logger, IThirdPartyService thirdPartyService)
        {
            _logger = logger;
            _thirdPartyService = thirdPartyService;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var response = await _thirdPartyService.HealthAsync(cancellationToken);

                if (response)
                    return HealthCheckResult.Healthy("ExamService is reachable.");

                return HealthCheckResult.Degraded(
                    $"ExamService is unhealthy.");
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "third party check failed.");
                return HealthCheckResult.Unhealthy(
                    "ExamService is unreachable.",
                    exception: ex);
            }
        }
    }
}
