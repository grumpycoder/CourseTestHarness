using CourseTestHarness.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseTestHarness.Infrastructure.Persistence.Configurations;

public class CourseEndorsementConfiguration : IEntityTypeConfiguration<CourseEndorsement>
{
    public void Configure(EntityTypeBuilder<CourseEndorsement> builder)
    {
        builder.ToTable("CourseEndorsements", "Common");
        builder.Property(s => s.EndorsementId).HasColumnName("EndorseId");
        //builder.HasKey(s => s.CourseEndorsementId); 
    }
}