namespace CourseTestHarness.Services;

public class BaseResponse
{
    public BaseResponse(string? message, bool success)
    {
        Success = success;
        Message = message;
    }

    public bool Success { get; } = true;
    public string? Message { get; } 
    public List<string> ValidationErrors { get; set; } = new(); 
}