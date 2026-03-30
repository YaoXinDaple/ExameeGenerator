using ExameeGenerator.Domain;
using ExameeGenerator.Domain.Exceptions;
using ExameeGenerator.Domain.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace ExameeGenerator.Tests.Domain;

public class DomainTests
{
    [Fact]
    public void AddDomain_Should_Register_IExamFactory_As_Singleton()
    {
        var services = new ServiceCollection();
        services.AddDomain();
        using var provider = services.BuildServiceProvider();

        var factory1 = provider.GetRequiredService<IExamFactory>();
        var factory2 = provider.GetRequiredService<IExamFactory>();

        Assert.Same(factory1, factory2);
    }

    [Fact]
    public void ExamFactory_Create_Should_Create_Exam_With_Expected_Examees()
    {
        var services = new ServiceCollection();
        services.AddDomain();
        using var provider = services.BuildServiceProvider();
        var factory = provider.GetRequiredService<IExamFactory>();

        var exam = factory.Create(20, "Midterm");

        Assert.Equal("Midterm", exam.Name);
        Assert.Equal(20, exam.Examees.Count);
    }

    [Fact]
    public void ExamFactory_Create_Should_Throw_When_Count_Is_Less_Than_20()
    {
        var services = new ServiceCollection();
        services.AddDomain();
        using var provider = services.BuildServiceProvider();
        var factory = provider.GetRequiredService<IExamFactory>();

        Assert.Throws<InsufficientCountException>(() => factory.Create(19, "Midterm"));
    }

    [Fact]
    public void Exam_Ctor_Should_Throw_When_Name_Is_Empty()
    {
        Assert.Throws<ValidationException>(() => new Exam(Guid.NewGuid(), " "));
    }

    [Fact]
    public void Exam_GetDomainEvents_Should_Be_Empty_By_Default()
    {
        var exam = new Exam(Guid.NewGuid(), "Final");

        var events = exam.GetDomainEvents();

        Assert.Empty(events);
    }

    [Fact]
    public void ReOrderExamee_Should_Reorder_As_0_NMinus1_1_NMinus2()
    {
        var services = new ServiceCollection();
        services.AddDomain();
        using var provider = services.BuildServiceProvider();
        var factory = provider.GetRequiredService<IExamFactory>();

        var exam = factory.Create(20, "Final");

        exam.ReOrderExamee();

        var orderedNumbers = exam.Examees
            .OrderBy(x => x.Order)
            .Select(x => x.Number)
            .ToArray();

        var expected = new[]
        {
            1, 20, 2, 19, 3, 18, 4, 17, 5, 16,
            6, 15, 7, 14, 8, 13, 9, 12, 10, 11
        };

        Assert.Equal(expected, orderedNumbers);
    }

    [Fact]
    public void Examee_Ctor_Should_Set_Id_Number_And_Order()
    {
        var id = Guid.NewGuid();
        var examId = Guid.NewGuid();

        var examee = new Examee(id, examId, 12, 5);

        Assert.Equal(id, examee.Id);
        Assert.Equal(12, examee.Number);
        Assert.Equal(5, examee.Order);
    }

    [Fact]
    public void DomainEventRecord_Ctor_Should_Set_Values()
    {
        var payload = new { Name = "evt" };

        var record = new DomainEventRecord(payload, 2);

        Assert.Equal(payload, record.EventDate);
        Assert.Equal(2, record.EventOrder);
    }
}
