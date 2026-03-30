using ExameeGenerator.Domain;

namespace ExameeGenerator.Application.Dtos
{
    public static class ExamDtoExtensions
    {
        public static ExamDto ToDto(this Exam exam)
        {
            return new ExamDto
            {
                Id = exam.Id,
                Name = exam.Name,
                ExameeDtos = exam.Examees.OrderBy(e=>e.Order).ToDtos(),
            };
        }
    }
}
