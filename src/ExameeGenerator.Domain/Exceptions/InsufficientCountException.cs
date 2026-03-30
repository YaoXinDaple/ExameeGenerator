namespace ExameeGenerator.Domain.Exceptions
{
    public class InsufficientCountException : DomainException
    {
        public InsufficientCountException(string message) : base(message)
        {
        }
    }
}
