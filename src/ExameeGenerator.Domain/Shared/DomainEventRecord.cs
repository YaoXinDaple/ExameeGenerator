namespace ExameeGenerator.Domain.Shared
{
    public record DomainEventRecord
    {
        public DomainEventRecord(object eventData, int eventOrder)
        {
            EventDate = eventData;
            EventOrder = eventOrder;
        }
        public object EventDate { get; }
        public int EventOrder { get; }
    }
}
