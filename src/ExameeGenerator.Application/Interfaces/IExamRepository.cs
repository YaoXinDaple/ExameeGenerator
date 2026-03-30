using ExameeGenerator.Domain;

namespace ExameeGenerator.Application.Interfaces
{
    public interface IExamRepository
    {
        Task SaveAsync(Exam entity, CancellationToken cancellationToken = default);

        Task<Exam?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
