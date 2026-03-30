using ExameeGenerator.Domain.Shared;

namespace ExameeGenerator.Domain
{
    public class Examee : Entity<Guid>
    {
        private Examee() { }

        public Examee(Guid id,int numer,int order) : base(id)
        {
            Number = numer;
            Order = order;
        }

        public int Number { get; private set; }

        public int Order { get; private set; }

        internal void UpdateOrder(int order)
        { 
            Order = order;
        }
    }
}
