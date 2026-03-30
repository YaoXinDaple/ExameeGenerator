using ExameeGenerator.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExameeGenerator.Infrastructure.EntityConfiguration
{
    public class ExameeConfiguration : IEntityTypeConfiguration<Examee>
    {
        public void Configure(EntityTypeBuilder<Examee> builder)
        {
            builder.ToTable("Examees");
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Number).IsRequired();
            builder.Property(x => x.Order).IsRequired();
            builder.Property(x => x.ExamId).IsRequired();

            builder.HasIndex(x => x.ExamId);
        }
    }
}
