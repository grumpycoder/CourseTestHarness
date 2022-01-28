using System.Reflection;
using CourseTestHarness.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace CourseTestHarness.Infrastructure.Persistence;

public class ApplicationDbContext: DbContext
{
    private readonly IConfigurationRoot _iConfiguration;
    private readonly string _connectionString;

    public ApplicationDbContext()
    {
        IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        _iConfiguration = builder.Build();
        _connectionString = _iConfiguration.GetConnectionString("DefaultConnection");
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        _ = optionsBuilder.UseSqlServer(_connectionString, providerOptions => providerOptions.CommandTimeout(60))
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    public DbSet<Course> Courses { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}