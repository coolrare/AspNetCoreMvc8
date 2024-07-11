using Microsoft.AspNetCore.Mvc;
using ModelBindingDemo.Models;

namespace ModelBindingDemo.Controllers;

public class StudentsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }


    [HttpPost]
    public ActionResult Index(Student data)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Index", new { result = "OK" });
        }

        return View(data);
    }
}
