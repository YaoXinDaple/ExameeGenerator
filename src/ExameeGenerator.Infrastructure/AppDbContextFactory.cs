using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ExameeGenerator.Infrastructure
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

            var basePath = ResolveApiPath();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile($"appsettings.{env}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetConnectionString("examdb")
                ?? throw new InvalidOperationException("Connection string 'examdb' not found.");

            var builder = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString);

            return new AppDbContext(builder.Options);
        }

        private static string ResolveApiPath()
        {
            var current = Directory.GetCurrentDirectory();

            var candidate1 = Path.GetFullPath(Path.Combine(current, "../ExameeGenerator.Api"));
            if (Directory.Exists(candidate1)) return candidate1;

            var candidate2 = Path.GetFullPath(Path.Combine(current, "src/ExameeGenerator.Api"));
            if (Directory.Exists(candidate2)) return candidate2;

            throw new DirectoryNotFoundException("Cannot locate 'ExameeGenerator.Api' directory.");
        }
    }
}
