using System.Reflection;

namespace ExameeGenerator.Tests.Architecture;

public class DependencyArchitectureTests
{
    [Fact]
    public void Domain_Should_Not_Depend_On_Application_Infrastructure_Or_Api()
    {
        var references = GetReferencedAssemblyNames("ExameeGenerator.Domain");

        Assert.DoesNotContain("ExameeGenerator.Application", references);
        Assert.DoesNotContain("ExameeGenerator.Infrastructure", references);
        Assert.DoesNotContain("ExameeGenerator.Api", references);
    }

    [Fact]
    public void Application_Should_Depend_On_Domain_Only_From_Internal_Projects()
    {
        var references = GetReferencedAssemblyNames("ExameeGenerator.Application");

        Assert.Contains("ExameeGenerator.Domain", references);
        Assert.DoesNotContain("ExameeGenerator.Infrastructure", references);
        Assert.DoesNotContain("ExameeGenerator.Api", references);
    }

    [Fact]
    public void Infrastructure_Should_Depend_On_Application_And_Domain_But_Not_Api()
    {
        var references = GetReferencedAssemblyNames("ExameeGenerator.Infrastructure");

        Assert.Contains("ExameeGenerator.Application", references);
        Assert.Contains("ExameeGenerator.Domain", references);
        Assert.DoesNotContain("ExameeGenerator.Api", references);
    }

    [Fact]
    public void Api_Should_Depend_On_Application_And_Infrastructure()
    {
        var references = GetReferencedAssemblyNames("ExameeGenerator.Api");

        Assert.Contains("ExameeGenerator.Application", references);
        Assert.Contains("ExameeGenerator.Infrastructure", references);
    }

    private static string[] GetReferencedAssemblyNames(string assemblyName)
    {
        var assembly = Assembly.Load(assemblyName);
        return assembly.GetReferencedAssemblies().Select(a => a.Name!).ToArray();
    }
}
