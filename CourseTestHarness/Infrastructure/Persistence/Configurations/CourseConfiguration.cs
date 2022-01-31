using CourseTestHarness.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace CourseTestHarness.Infrastructure.Persistence.Configurations;

public class CourseConfiguration: IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses", "Common");
        builder.Property(s => s.Name).HasColumnName("CourseName");
        builder.Property(s => s.CourseNumber).HasColumnName("CourseNumber");
        builder.Property(s => s.Description).HasColumnName("CourseDescription");

        //builder.Property(s => s.LowGrade).HasColumnName("LowGradeId");
        
        builder.Property(s => s.CreditTypes)
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<string>>(v)
            );
        
        // builder.Property(s => s.Tags)
        //     .HasConversion(
        //         v => JsonConvert.SerializeObject(v),
        //         v => JsonConvert.DeserializeObject<List<string>>(v)
        //     ); 
        //
        // builder.Property(e => e.Status).HasConversion<string>();


    }
    
}

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.ToTable("Subjects", "Common");
        builder.Property(s => s.Name).HasColumnName("SubjectName");
    }
}
