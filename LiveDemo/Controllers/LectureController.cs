using LiveDemo.ActionFilters;
using LiveDemo.Models;
using LiveDemo.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult Edit(int id)
        {
            var item = repo.FindOne(id);

            if (item is null)
            {
                return NotFound("找不到課程");
            }

            return View(item);
        }

        [HttpPost("edit/{id}")]
        public ActionResult Edit(int id, Course lecture)
        {
            if (ModelState.IsValid)
            {
                var existingLecture = repo.FindOne(id);
                if (existingLecture is null)
                {
                    return NotFound("找不到課程");
                }

                existingLecture.Title = lecture.Title;
                existingLecture.Credits = lecture.Credits;
                existingLecture.Description = lecture.Description;
                existingLecture.DepartmentId = lecture.DepartmentId;
                existingLecture.Slug = lecture.Slug;
                existingLecture.IsDeleted = lecture.IsDeleted;
                existingLecture.StartDate = lecture.StartDate;

                repo.UnitOfWork.Update(existingLecture);
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(lecture);
        }

        [HttpGet("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var item = repo.FindOne(id);

            if (item is null)
            {
                return NotFound("找不到課程");
            }
            return View(item);

        }

        [HttpDelete("delete/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            var item = repo.FindOne(id);

            if (item is null)
            {
                return NotFound("找不到課程");
                    
            }

            repo.Delete(item);
            repo.UnitOfWork.Commit();
            
            return RedirectToAction("");
        }
    }
}