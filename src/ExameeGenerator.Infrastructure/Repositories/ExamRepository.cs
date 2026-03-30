using ExameeGenerator.Application.Interfaces;
using ExameeGenerator.Domain;
using Microsoft.EntityFrameworkCore;

namespace ExameeGenerator.Infrastructure.Repositories
{
    internal class ExamRepository : IExamRepository
    {
        private readonly AppDbContext _appDbContext;

        public ExamRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<Exam?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return _appDbContext.Exams.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task SaveAsync(Exam entity, CancellationToken cancellationToken = default)
        {
            await _appDbContext.Exams.AddAsync(entity, cancellationToken);
            await _appDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
