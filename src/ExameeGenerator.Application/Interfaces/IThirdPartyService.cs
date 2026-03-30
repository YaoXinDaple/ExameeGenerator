namespace ExameeGenerator.Application.Interfaces
{
    public interface IThirdPartyService
    {
        Task InvokeAsync(CancellationToken cancellationToken = default);

        Task<bool> HealthAsync(CancellationToken cancellationToken = default);
    }
}
