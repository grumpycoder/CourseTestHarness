using Microsoft.Extensions.Configuration;

namespace CourseTestHarness.Services;

public class ApiSettings 
{
    public ApiSettings()
    {
        // ApiRequestUrl = ConfigurationManager.AppSettings["ApiRequestUrl"];
        // ApiPluginClientId = ConfigurationManager.AppSettings["ApiPluginClientId"];
        // ClientSecret = ConfigurationManager.AppSettings["ClientSecret"];
    }

    public string PublishEndPointURL { get; set; }
    public string ApiRequestUrl { get; set; }
    public string ApiPluginClientId { get; set; }
    public string ClientSecret { get; set; }
}