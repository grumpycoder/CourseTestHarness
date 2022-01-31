using AutoMapper;
using CourseTestHarness.Contracts;
using CourseTestHarness.Infrastructure.Persistence;
using CourseTestHarness.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


var appSettings = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

ApiSettings settings = new ApiSettings();
appSettings.GetSection("ApiSettings").Bind(settings); //<ApiSettings>(); 

var config = new MapperConfiguration(cfg =>
{
    //cfg.CreateMap<Course, UDefCourses>(); 
    cfg.AddMaps(typeof(Program));
});

var mapper = new Mapper(config);
var publisher = new PublisherService(mapper, settings);

using (var context = new ApplicationDbContext())
{
    var courses = await context.Courses
        .Include(c => c.Endorsements)
        .ThenInclude(c => c.Endorsement)
        .Include(s => s.Subject)
        .Include(s => s.HighGrade) 
        .Include(s => s.LowGrade)
        //.Where(x => x.Endorsements.Any() && x.CourseNumber == "01039GPKPK")
        .Where(m => m.BeginYear >= 2011)
        // .Take(10)
        // .Skip(0)
        .ToListAsync();
    
    foreach (var course in courses)
    {
        var dto = mapper.Map<UDefCourses>(course);
        var response = await publisher.PublishCourse(course);

        Console.WriteLine(course.CourseNumber);
    }
}