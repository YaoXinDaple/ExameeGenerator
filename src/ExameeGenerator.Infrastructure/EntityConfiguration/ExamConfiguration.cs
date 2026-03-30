using ExameeGenerator.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExameeGenerator.Infrastructure.EntityConfiguration
{
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.ToTable("Exams");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Name).HasMaxLength(128);
            builder.Property(x => x.CreateAt).IsRequired();
            builder.Property(x => x.UpdateAt).IsRequired(false);
            builder.Property(x => x.DeleteTime).IsRequired(false);
            builder.Property(x => x.Version).IsRowVersion();

            builder.HasMany(x=>x.Examees).WithOne().HasForeignKey(x=>x.ExamId).IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
