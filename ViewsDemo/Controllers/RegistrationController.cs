using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using ViewsDemo.Models;

namespace ViewsDemo.Controllers;

public class RegistrationController : Controller
{
    public IActionResult Index()
    {
        var data = new List<RegistrationViewModel>();
        data.Add(new RegistrationViewModel()
        {
            Id = "A001",
            FirstName = "John",
            LastName = "Doe",
            RegisterDate = DateTime.Now
        });

        return View(data);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(RegistrationViewModel data)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Index");
        }

        return View(data);
    }

    public ActionResult Details(string id)
    {
        ViewData.Model = new RegistrationViewModel()
        {
            Id = id,
            FirstName = "John",
            LastName = "Doe",
            RegisterDate = DateTime.Now
        };

        return View();
    }
}
