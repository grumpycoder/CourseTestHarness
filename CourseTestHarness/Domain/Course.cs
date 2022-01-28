namespace CourseTestHarness.Domain;

public class Course
{
    public int CourseId { get; set; }
    public string? ArchiveCourseCode { get; set; } = string.Empty;
    public bool? IsCareerTech { get; set; } 
    public string? CipCode { get; set; } = string.Empty;
    public string? CourseNumber { get; set; } = string.Empty;
    public string? CourseName { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public bool? IsSpecialEducation { get; set; } = false;
    public string? CollegeCourseId { get; set; } = string.Empty;
    public bool? IsLocallyEditable { get; set; } = false;
    public List<CourseEndorsement> Endorsements { get; set; } = new List<CourseEndorsement>();
    public int? LowGradeId { get; set; }
    public int? HighGradeId { get; set; }
    public Subject Subject { get; set; }
    public bool? IsCollege { get; set; }
    public decimal? CreditHours { get; set; }
    public List<string>? CreditTypes { get; set; }
    public int? BeginYear { get; set; }
    public int? EndYear { get; set; } 
}