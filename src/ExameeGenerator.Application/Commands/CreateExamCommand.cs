using ExameeGenerator.Application.Dtos;
using ExameeGenerator.Application.Interfaces;
using ExameeGenerator.Domain;

namespace ExameeGenerator.Application.Commands
{
    public sealed record CreateExamCommand(int? Count,string ExamName);

    public sealed class CreateExamCommandHandler
    {
        private readonly IExamRepository _examRepository;
        private readonly IExamFactory _examFactory;
        private readonly IThirdPartyService _thirdPartyService;

        public CreateExamCommandHandler(
            IExamRepository examRepository,
            IExamFactory examFactory,
            IThirdPartyService thirdPartyService)
        {
            _examRepository = examRepository;
            _examFactory = examFactory;
            _thirdPartyService = thirdPartyService;
        }

        public async Task<ExamDto> HandleAsync(CreateExamCommand command, CancellationToken cancellationToken = default)
        {
            int exameeCount = 0;
            if (!command.Count.HasValue || command.Count < 20)
            {
                exameeCount = 20;
            }
            else
            {
                exameeCount = command.Count.Value;
            }

            var exam = _examFactory.Create(exameeCount, command.ExamName);

            await _thirdPartyService.InvokeAsync(cancellationToken);

            await _examRepository.SaveAsync(exam, cancellationToken);

            return exam.ToDto();
        }
    }
}
