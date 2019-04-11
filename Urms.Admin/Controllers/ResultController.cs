using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Urms.Model;
using Urms.Service;

namespace Urms.Admin.Controllers
{
    [Authorize(Roles = "Admin,Student,Teacher")]
    public class ResultController : ControllerBase
    {

        private readonly ICourseService courseService;
        private readonly IStudentService studentService;
        private readonly IResultService resultService;

        public ResultController(ICourseService courseService, IStudentService studentService, IResultService resultService, ApplicationUserManager userMananager) : base(userMananager)
        {
            this.courseService = courseService;
            this.studentService = studentService;
            this.resultService = resultService;
        }
        // GET: Result
        public ActionResult Index()
        {
            var results = resultService.GetAll();
            return View(results);
        }
        public ActionResult Create()
        {

            var results = new Result();
            ViewBag.CourseId = new SelectList(courseService.GetAll(), "Id", "CourseName",results.CourseId);
            ViewBag.StudentId = new SelectList(studentService.GetAll(), "Id", "StudentName",results.StudentId);

            return View(results);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Result result)
        {
            if (ModelState.IsValid)
            {

                resultService.Insert(result);
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(courseService.GetAll(), "Id", "CourseName", result.CourseId);
            ViewBag.StudentId = new SelectList(studentService.GetAll(), "Id", "StudentName", result.StudentId);

            return View(result);
        }
        public ActionResult Edit(Guid id)
        {
            var result = resultService.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(courseService.GetAll(), "Id", "CourseName", result.CourseId);
            ViewBag.StudentId = new SelectList(studentService.GetAll(), "Id", "StudentName", result.StudentId);

            return View(result);


        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Result result)
        {
            if (ModelState.IsValid)
            {
                var model = resultService.Find(result.Id);
                model.Grade = result.Grade;
                model.CourseId = result.CourseId;
                model.StudentId = result.StudentId;
                resultService.Update(model);
                return RedirectToAction("Index");

            }
            ViewBag.CourseId = new SelectList(courseService.GetAll(), "Id", "CourseName", result.CourseId);
            ViewBag.StudentId = new SelectList(studentService.GetAll(), "Id", "StudentName", result.StudentId);

            return View(result);
        }
        public ActionResult Delete(Guid id)
        {
            resultService.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(Guid id)
        {
            return View(resultService.Find(id));
        }
    }
}