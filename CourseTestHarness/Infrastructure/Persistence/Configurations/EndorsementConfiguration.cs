using CourseTestHarness.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseTestHarness.Infrastructure.Persistence.Configurations;

public class EndorsementConfiguration : IEntityTypeConfiguration<Endorsement>
{
    public void Configure(EntityTypeBuilder<Endorsement> builder)
    {
        builder.ToView("v_Endorsements", "Common");
        builder.HasKey(s => s.EndorsementId);
        builder.Property(c => c.EndorsementId).HasColumnName("EndorseId");
    }
}