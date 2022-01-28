using CourseTestHarness.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

using (var context = new ApplicationDbContext())
{
    var courses = context.Courses
        .Include(c => c.Endorsements)
        .ThenInclude(c => c.Endorsement)
        .Where(x => x.Endorsements.Any())
        .Take(10)
        .Skip(0)
        .ToList();

    foreach (var course in courses)
    {
        Console.WriteLine(course.CourseNumber);
    }
}