namespace CourseTestHarness.Domain;

public class Course
{
    public int CourseId { get; set; }
    public string? ArchiveCourseCode { get; set; }
    public string? CourseNumber { get; set; }
    public string? CipCode { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? CollegeCourseId { get; set; }
    public bool? IsLocallyEditable { get; set; } = false;
    public bool? IsCareerTech { get; set; } = false;
    public bool? IsSpecialEducation { get; set; } = false;
    public bool? IsCollege { get; set; } = false;
    public bool? IsFitness { get; set; } = false;

    public string? ScedCourseNumber { get; set; }
    public string? StateAttribute1 { get; set; }
    public string? StateAttribute2 { get; set; }

    public int? ScedCategoryId { get; set; }
    public ScedCategory? ScedCategory { get; set; }
    public List<CourseEndorsement> Endorsements { get; set; } = new List<CourseEndorsement>();

    public int? SubjectId { get; set; }
    public Subject? Subject { get; set; }
    public decimal? CreditHours { get; set; }
    public List<string>? CreditTypes { get; set; }
    public int? BeginYear { get; set; }
    public int? EndYear { get; set; } 
    
    public Grade? LowGrade { get; set; }
    public int? LowGradeId { get; set; }

    public Grade? HighGrade { get; set; }
    public int? HighGradeId { get; set; }
    
}