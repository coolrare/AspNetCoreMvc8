using LiveDemo.ActionFilters;
using LiveDemo.Models;
using LiveDemo.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace LiveDemo.Controllers
{
    //[計算每個頁面的實際執行時間]
    //[ServiceFilter<計算每個頁面的實際執行時間Attribute>()]
    [Route("members/lecture")]
    public class LectureController : Controller
    {
        private readonly ICourseRepository repo;
        private readonly IDepartmentRepository repoDept;

        public LectureController(ICourseRepository repo, IDepartmentRepository repoDept, IUnitOfWork uow)
        {
            this.repo = repo;
            this.repoDept = repoDept;

            this.repo.UnitOfWork = uow;
            this.repoDept.UnitOfWork = uow;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index(int page = 1)
        {
            var data = repo.FindAll();

            var paged = await data.ToPagedListAsync(page, 4);

            return View(paged);
        }

        [HttpGet("new")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost("new")]
        public ActionResult Create(CourseCreate data)
        {
            if (ModelState.IsValid)
            {
                repo.Add(new Course
                {
                    Title = data.Title,
                    Credits = data.Credits
                });

                // Call API

                repo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            return View(data);
        }

        [HttpGet("info/{slug}")]
        public ActionResult Details(string slug)
        {
            //db.Courses.ToList().ForEach(x =>
            //{
            //    x.Slug = x.Title.ToSlug();
            //});
            //db.SaveChanges();

            var item = repo.FindOne(slug);

            if (item is null)
            {
                return BadRequest("找不到對應的課程");
            }

            item.Title = slug;

            return View(item);
        }

        [HttpGet("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var course = repo.FindOne(id);
            if (course == null)
            {
                return NotFound();
            }

            ViewBag.DepartmentId = new SelectList(repoDept.FindAll(), "DepartmentId", "Name", course.DepartmentId);
            return View(course);
        }

        [HttpPost("edit/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("CourseId,Title,Credits,Description,DepartmentId")] Course course)
        {
            if (id != course.CourseId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    repo.Update(course);
                    repo.UnitOfWork.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!repo.FindAll().Any(c => c.CourseId == course.CourseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.DepartmentId = new SelectList(repoDept.FindAll(), "DepartmentId", "Name", course.DepartmentId);
            return View(course);
        }

        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var course = repo.FindOne(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost("delete/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id, [Bind("CourseId")] Course course)
        {
            if (id != course.CourseId)
            {
                return BadRequest();
            }

            var item = repo.FindOne(id);
            if (item == null)
            {
                return NotFound();
            }

            repo.Delete(item);
            repo.UnitOfWork.Commit();

            return RedirectToAction(nameof(Index));
        }
    }
}
