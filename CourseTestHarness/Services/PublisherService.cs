using System.Net.Http.Headers;
using AutoMapper;
using CourseTestHarness.Contracts;
using CourseTestHarness.Domain;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;

namespace CourseTestHarness.Services;

public class PublisherService
{
    private readonly ApiSettings _settings;
    private readonly IMapper _mapper;

    public PublisherService(IMapper mapper, ApiSettings settings)
    {
        _mapper = mapper;
        _settings = settings;
    }

    public string BearerToken { get; set; }
    public DateTime TokenExpiration { get; set; }
    public bool TokenHasExpired => TokenExpiration <= DateTime.Now.AddMinutes(-5);

    public async Task<BaseResponse> PublishCourse(Course course)
    {
        if (TokenHasExpired)
            await GetBearerToken(_settings.ApiRequestUrl, _settings.ApiPluginClientId,
                _settings.ClientSecret);

        var dto = _mapper.Map<UDefCourses>(course);
        //HACK: mapping is not correcting missing subject to empty string
        dto.Subject = dto.Subject ?? string.Empty;

        var container = new UDefCoursesContainer
        {
            Name = "u_def_courses",
            Tables = new Tables { UDefCourses = dto }
        };
        
        try
        {
            var post = await _settings.ApiRequestUrl
                .AppendPathSegment("ws/schema/table/u_def_courses")
                .WithOAuthBearerToken(BearerToken)
                .WithHeader("Content-Type", "application/json")
                .PostJsonAsync(container)
                .ReceiveJson();
        
            var postResult = post.result[0];
            var status = postResult.status.ToLower() == "success";
            var message = JsonConvert.SerializeObject(postResult.success_message);
            var response = new BaseResponse(message, status);
            return response;
        }
        catch (FlurlHttpException ex)
        {
            //Log error
            var errorResponse = await ex.GetResponseJsonAsync();
            throw new Exception($"PowerSchool error: {errorResponse.message}",
                new Exception($"Payload Error: {ex.Call.RequestBody}", ex));
        }
    }

    private async Task GetBearerToken(string apiRequestUrl, string pluginClientId, string clientSecret)
    {
        var url = apiRequestUrl;
        var config = new ApiSettings();
        
        var result = await url
            .AppendPathSegment(Uri.EscapeUriString("oauth/access_token"))
            .SetQueryParam("grant_type", "client_credentials")
            .SetQueryParam("client_id", pluginClientId)
            .SetQueryParam("client_secret", clientSecret)
            .WithHeader("Content-Type", "application/x-www-form-urlencoded")
            .PostAsync().ReceiveJson();

        var accessToken = result.access_token;
        var expiresIn = result.expires_in;

        BearerToken = accessToken;
        TokenExpiration = DateTime.Now.AddMilliseconds(int.Parse(expiresIn ?? 0));
    }

    private static HttpClient MethodHeaders(string bearerToken, string endpointUrl)
    {
        var handler = new HttpClientHandler { UseDefaultCredentials = false };
        var client = new HttpClient(handler) { BaseAddress = new Uri(endpointUrl) };

        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + bearerToken);
        return client;
    }
}