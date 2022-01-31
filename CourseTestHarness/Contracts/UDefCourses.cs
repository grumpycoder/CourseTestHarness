using Newtonsoft.Json;

namespace CourseTestHarness.Contracts;

 internal class JsonMessage
    {
        public string Message { get; set; } = string.Empty;
    }

    [JsonObject(IsReference = false, Title = "u_def_courses")]
    public class UDefCourses
    {
        [JsonProperty("inow_course_code")] public string CourseCode { get; set; } = string.Empty;

        [JsonProperty("iscareertech")] public string IsCareerTech { get; set; } = string.Empty;

        [JsonProperty("code")] public string CipCode { get; set; } = string.Empty;

        [JsonProperty("course_number")] public string CourseNumber { get; set; } = string.Empty;

        [JsonProperty("course_name")] public string CourseName { get; set; } = string.Empty;

        [JsonProperty("lowgrade")] public string LowGrade { get; set; } = string.Empty;

        [JsonProperty("isspecialed")] public string IsSpecialEd { get; set; } = string.Empty;

        [JsonProperty("collegecoursecode")] public string CollegeCourseCode { get; set; } = string.Empty;

        [JsonProperty("locally_editable")] public string LocallyEditable { get; set; } = string.Empty;

        [JsonProperty("endorsements")] public string Endorsements { get; set; } = string.Empty;

        [JsonProperty("highgrade")] public string HighGrade { get; set; } = string.Empty;

        [JsonProperty("regcoursegroup")] public string Subject { get; set; } = string.Empty;

        [JsonProperty("iscollege")] public string IsCollege { get; set; } = string.Empty;

        [JsonProperty("sched_fullcatalogdescription")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("credit_hours")] public string CreditHours { get; set; } = string.Empty;

        [JsonProperty("credittype")] public string CreditType { get; set; } = string.Empty;

        [JsonProperty("beginyear")] public string BeginYear { get; set; } = string.Empty;

        [JsonProperty("endyear")] public string EndYear { get; set; } = string.Empty;

    }

    [JsonObject(IsReference = false)]
    public class Tables
    {
        [JsonProperty("u_def_courses")] public UDefCourses UDefCourses { get; set; } = new();
    }

    [JsonObject(IsReference = false)]
    public class UDefCoursesContainer
    {
        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; } = string.Empty; 

        [JsonProperty("tables")] public Tables Tables { get; set; } = new(); 
    }