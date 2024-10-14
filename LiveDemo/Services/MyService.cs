namespace LiveDemo.Services;

public class MyService
{
    private readonly IHttpContextAccessor httpContext;

    public MyService(IHttpContextAccessor httpContext)
    {
        this.httpContext = httpContext;
    }

    public string GetMessage()
    {
        //httpContext.HttpContext.Session

        return "Hello from MyService!";
    }
}
