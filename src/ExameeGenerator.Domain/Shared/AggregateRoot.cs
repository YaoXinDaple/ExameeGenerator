using System.Collections.ObjectModel;

namespace ExameeGenerator.Domain.Shared
{
    public class AggregateRoot<T> : Entity<T>
    {
        protected AggregateRoot() { }
        protected AggregateRoot(T id):base(id) 
        { }

        private ICollection<DomainEventRecord> _domainEvents = new Collection<DomainEventRecord>();
        public DateTime CreateAt { get; init; }
        public DateTime UpdateAt { get; private set; }
        public DateTime? DeleteTime { get; private set; }

        protected virtual void RaiseEvent(DomainEventRecord record)
        { 
            _domainEvents.Add(record);
        }

        protected virtual void ClearEvents()
        {
            _domainEvents.Clear();
        }

        public virtual IEnumerable<DomainEventRecord> GetDomainEvents()
        {
            return _domainEvents;
        }
    }
}
