using ExameeGenerator.Domain.Exceptions;

namespace ExameeGenerator.Domain
{
    internal class ExamFactory : IExamFactory
    {
        public Exam Create(int count)
        {
            if (count < 20)
                throw new InsufficientCountException("Examee count cannot less then 20!");

            List<Examee> exameeList = new List<Examee>(count);

            for (int i = 0; i < count; i++)
            {
                Examee examee = new Examee(Guid.NewGuid(), i + 1, i);
                exameeList.Add(examee);
            }

            Exam exam = new Exam(Guid.NewGuid());
            exam.AddRange(exameeList);

            return exam;
        }
    }
}
