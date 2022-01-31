using AutoMapper;
using CourseTestHarness.Contracts;
using CourseTestHarness.Domain;

namespace CourseTestHarness.Profiles;

public class Mappings: Profile
{
    public Mappings()
    {

        CreateMap<Course, UDefCourses>()
            .ForMember(d => d.CourseCode, o =>
                o.MapFrom(s => s.ArchiveCourseCode ?? string.Empty))
            .ForMember(d => d.CourseName, o =>
                o.MapFrom(s => s.Name ?? string.Empty))
            .ForMember(d => d.CipCode, o =>
                o.MapFrom(s => s.CipCode ?? string.Empty))
            .ForMember(d => d.LowGrade, o =>
                o.MapFrom(s => s.LowGrade.Name ?? string.Empty))
            .ForMember(d => d.HighGrade, o =>
                o.MapFrom(s => s.HighGrade.Name ?? string.Empty))
            .ForMember(d => d.IsSpecialEd, o =>
                o.MapFrom(s => s.IsSpecialEducation.ToString() ?? string.Empty))
            .ForMember(d => d.CollegeCourseCode, o =>
                o.MapFrom(s => s.CollegeCourseId ?? string.Empty))
            .ForMember(d => d.EndYear, o =>
                o.MapFrom(s => s.EndYear.ToString() ?? string.Empty))
            .ForMember(d => d.BeginYear, o =>
                o.MapFrom(s => s.BeginYear.ToString() ?? string.Empty))
            .ForMember(d => d.LocallyEditable, o =>
                o.MapFrom(s => s.IsLocallyEditable.ToString() ?? string.Empty))
            .ForMember(d => d.Subject, o =>
                o.MapFrom(s => s.Subject.Name ?? string.Empty))
            .ForMember(d => d.CreditType, o =>
                o.MapFrom(s => string.Join(",", s.CreditTypes) ?? string.Empty))
            .ForMember(d => d.Endorsements, o =>
                o.MapFrom(s => string.Join(",", s.Endorsements.Select(x => x.Endorsement.EndorseCode)) ?? string.Empty))
            ;
    }
    
}