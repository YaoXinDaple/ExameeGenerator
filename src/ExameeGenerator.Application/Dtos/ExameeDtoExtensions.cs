using ExameeGenerator.Domain;

namespace ExameeGenerator.Application.Dtos
{
    public static class ExameeDtoExtensions
    {
        public static ExameeDto ToDto(this Examee examee)
        {
            return new ExameeDto
            {
                Id = examee.Id,
                Number = examee.Number,
                Order = examee.Order,
            };
        }

        public static IEnumerable<ExameeDto> ToDtos(this IEnumerable<Examee> examees)
        {
            return examees.Select(x => ToDto(x));
        }
    }
}
