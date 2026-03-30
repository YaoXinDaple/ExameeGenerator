using ExameeGenerator.Application.Dtos;
using ExameeGenerator.Application.Interfaces;
using ExameeGenerator.Domain.Exceptions;

namespace ExameeGenerator.Application.Commands
{
    public record class ReOrderExameeCommand(Guid ExamId);

    public class ReOrderExameeCommandHandler
    {
        private readonly IExamRepository _examRepository;

        public ReOrderExameeCommandHandler(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        public async Task<ExamDto> HandlAsync(ReOrderExameeCommand command)
        {
            var exam = await _examRepository.GetByIdAsync(command.ExamId);
            if (exam == null) 
            {
                throw new NotFoundException($"Entity Not Found With Id:{command.ExamId}");
            }

            exam.ReOrderExamee();
            return exam.ToDto();
        }
    }
}
