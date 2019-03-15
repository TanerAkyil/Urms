using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Urms.Model;
using Urms.Service;

namespace Urms.Admin.Controllers
{
    public class ResultController : Controller
    {
        private readonly ICourseService courseService;
        private readonly IStudentService studentService;
        private readonly IResultService resultService;

        public ResultController(ICourseService courseService, IStudentService studentService, IResultService resultService)
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

            var result = new Result();
            ViewBag.CourseId = new SelectList(resultService.GetAll(), "Id", "CourseName");
            ViewBag.StudentId = new SelectList(resultService.GetAll(), "Id", "StudentName");

            return View(result);
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
            ViewBag.CourseId = new SelectList(resultService.GetAll(), "Id", "CourseName",result.CourseId);
            ViewBag.StudentId = new SelectList(resultService.GetAll(), "Id", "StudentName",result.StudentId);

            return View();
        }
        public ActionResult Edit(Guid id)
        {
            var result = resultService.Find(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(resultService.GetAll(), "Id", "CourseName", result.CourseId);
            ViewBag.StudentId = new SelectList(resultService.GetAll(), "Id", "StudentName", result.StudentId);

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
                resultService.Update(model);
                return RedirectToAction("Index");

            }
            ViewBag.CourseId = new SelectList(resultService.GetAll(), "Id", "CourseName", result.CourseId);
            ViewBag.StudentId = new SelectList(resultService.GetAll(), "Id", "StudentName", result.StudentId);

            return View();
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