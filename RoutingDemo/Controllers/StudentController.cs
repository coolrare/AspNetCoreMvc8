using Microsoft.AspNetCore.Mvc;

namespace RoutingDemo.Controllers;

[Route("學生")]
public class StudentController : Controller
{
    [HttpGet("")]
    [HttpGet("歡迎入學")]
    public IActionResult Index()
    {
        return View();
    }
}
