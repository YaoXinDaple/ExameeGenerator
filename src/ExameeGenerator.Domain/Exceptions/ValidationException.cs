namespace ExameeGenerator.Domain.Exceptions
{
    public class ValidationException : DomainException
    {
        public ValidationException(string propertyName,string message)
        : base($"Validation failed for '{propertyName}': {message}") { }
    }
}
