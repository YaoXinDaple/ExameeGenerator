using ExameeGenerator.Application.Dtos;
using ExameeGenerator.Application.Interfaces;

namespace ExameeGenerator.Application.Queries
{
    public record GetExamByIdQuery(Guid examId);

    public class GetExamByIdQueryHandler
    {
        private readonly IExamRepository _examRepository;

        public GetExamByIdQueryHandler(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        public async Task<ExamDto> HandleAsync(GetExamByIdQuery query)
        {
            var exam = await _examRepository.GetByIdAsync(query.examId);
            return exam.ToDto();
        }
    }
}
