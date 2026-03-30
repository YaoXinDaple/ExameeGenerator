using ExameeGenerator.Application.Dtos;
using ExameeGenerator.Application.Interfaces;
using ExameeGenerator.Domain.Exceptions;

namespace ExameeGenerator.Application.Queries
{
    public record GetExamByIdQuery(Guid ExamId);

    public class GetExamByIdQueryHandler
    {
        private readonly IExamRepository _examRepository;

        public GetExamByIdQueryHandler(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        public async Task<ExamDto> HandleAsync(GetExamByIdQuery query, CancellationToken cancellationToken = default)
        {
            var exam = await _examRepository.GetByIdAsync(query.ExamId, cancellationToken);
            if (exam == null)
            {
                throw new NotFoundException($"Entity Not Found With Id:{query.ExamId}");
            }
            return exam.ToDto();
        }
    }
}
