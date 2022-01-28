using CourseTestHarness.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseTestHarness.Infrastructure.Persistence.Configurations;

public class GradeConfiguration: IEntityTypeConfiguration<Grade>
{
    public void Configure(EntityTypeBuilder<Grade> builder)
    {
        builder.ToTable("Grades", "Common");
        builder.Property(s => s.Name).HasColumnName("GradeName");
        builder.Property(s => s.Description).HasColumnName("GradeDescription");
    }
}