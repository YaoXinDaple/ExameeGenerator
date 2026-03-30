namespace ExameeGenerator.Application.Dtos
{
    public class ExamDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public IEnumerable<ExameeDto> ExameeDtos { get; set; } = new List<ExameeDto>();
    }
}
