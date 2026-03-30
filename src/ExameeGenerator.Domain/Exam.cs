using ExameeGenerator.Domain.Exceptions;
using ExameeGenerator.Domain.Shared;

namespace ExameeGenerator.Domain
{
    public class Exam : AggregateRoot<Guid>
    {
        private Exam() { }

        public Exam(Guid id,string name) : base(id)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ValidationException(nameof(Name), "exam name cannot be empty");
            }
            Name = name;
            CreateAt = DateTime.Now;
        }

        public string Name { get; private set; } = string.Empty;

        private List<Examee> _examees = new List<Examee>();

        public ICollection<Examee> Examees => _examees;

        internal void AddRange(ICollection<Examee> examees)
        {
            _examees.AddRange(examees);
        }

        public void ReOrderExamee()
        {
            int count = _examees.Count;
            if (count <= 1)
                return;

            var ordered = _examees.OrderBy(x => x.Order).ToList();

            int left = 0;
            int right = count - 1;
            int newOrder = 0;

            while (left <= right)
            {
                ordered[left].UpdateOrder(newOrder++);
                left++;

                if (left <= right)
                {
                    ordered[right].UpdateOrder(newOrder++);
                    right--;
                }
            }
        }
    }
}
