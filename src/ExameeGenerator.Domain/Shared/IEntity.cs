namespace ExameeGenerator.Domain.Shared
{
    internal interface IEntity<T>
    {
        T Id { get; }
    }
}
