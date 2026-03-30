using ExameeGenerator.Domain.Shared;

namespace ExameeGenerator.Domain
{
    public class Examee : Entity<Guid>
    {
        private Examee() { }

        public Examee(Guid id,Guid  examId,int numer,int order) : base(id)
        {
            Number = numer;
            Order = order;
        }

        public int Number { get; private set; }

        public int Order { get; private set; }

        public Guid ExamId { get; init; }

        internal void UpdateOrder(int order)
        { 
            Order = order;
        }
    }
}
