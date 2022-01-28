namespace CourseTestHarness.Domain;

public class ProgramCourse
{
    public int ProgramCourseId { get; set; }
    public int CourseId { get; set; }
    public int ProgramId { get; set; }
    public int? BeginYear { get; set; }
    public int? EndYear { get; set; }
    public Course Course { get; set; }
    public Program Program { get; set; }
}