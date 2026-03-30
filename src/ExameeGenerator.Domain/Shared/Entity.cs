namespace ExameeGenerator.Domain.Shared
{
    public class Entity<T> : IEntity<T>
    {
        protected Entity() { }
        protected Entity(T id)
        {
            Id = id;
        }
        public T Id { get; protected set; } = default!;
    }
}
