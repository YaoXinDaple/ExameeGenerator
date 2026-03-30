using ExameeGenerator.Application.Commands;
using ExameeGenerator.Application.Interfaces;
using ExameeGenerator.Domain;

namespace ExameeGenerator.Tests.Application;

public class CreateExamCommandHandlerTests
{
    [Fact]
    public async Task HandleAsync_Should_Invoke_ThirdParty_And_Save_Exam()
    {
        var repository = new FakeExamRepository();
        var examFactory = new FakeExamFactory();
        var thirdPartyService = new FakeThirdPartyService();
        var handler = new CreateExamCommandHandler(repository, examFactory, thirdPartyService);

        var result = await handler.HandleAsync(new CreateExamCommand(30, "Math"), CancellationToken.None);

        Assert.True(thirdPartyService.InvokeCalled);
        Assert.True(repository.SaveCalled);
        Assert.Equal(30, examFactory.LastRequestedCount);
        Assert.Equal("Math", examFactory.LastRequestedName);
        Assert.Equal(examFactory.CreatedExamId, result.Id);
    }

    private sealed class FakeExamRepository : IExamRepository
    {
        public bool SaveCalled { get; private set; }

        public Task SaveAsync(Exam entity, CancellationToken cancellationToken = default)
        {
            SaveCalled = true;
            return Task.CompletedTask;
        }

        public Task<Exam?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return Task.FromResult<Exam?>(null);
        }
    }

    private sealed class FakeExamFactory : IExamFactory
    {
        public int LastRequestedCount { get; private set; }
        public string LastRequestedName { get; private set; } = string.Empty;
        public Guid CreatedExamId { get; private set; }

        public Exam Create(int count, string name)
        {
            LastRequestedCount = count;
            LastRequestedName = name;
            CreatedExamId = Guid.NewGuid();
            return new Exam(CreatedExamId, name);
        }
    }

    private sealed class FakeThirdPartyService : IThirdPartyService
    {
        public bool InvokeCalled { get; private set; }

        public Task InvokeAsync(CancellationToken cancellationToken = default)
        {
            InvokeCalled = true;
            return Task.CompletedTask;
        }

        public Task<bool> HealthAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(true);
        }
    }
}
