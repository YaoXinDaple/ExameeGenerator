namespace ExameeGenerator.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }

        public override string StackTrace => string.Empty;
        public new Exception? InnerException => null;
    }
}
