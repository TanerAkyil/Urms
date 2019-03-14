using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Urms.Model;
using Urms.Service;

namespace Urms.Admin.Controllers
{
    public class SemesterController : Controller
    {
        private readonly ISemesterService semesterService;

        public SemesterController(ISemesterService semesterService)
        {
            this.semesterService = semesterService;
        }
        // GET: Semester
        public ActionResult Index()
        {
            var semesters = semesterService.GetAll();
            return View(semesters);
        }
        public ActionResult Create()
        {
            var semesters = new Semester();
            return View(semesters);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Semester semester)
        {
            if (ModelState.IsValid)
            {
                semesterService.Insert(semester);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(Guid id)
        {
            var semester = semesterService.Find(id);
            if (semester == null)
            {
                return HttpNotFound();
            }
            return View(semester);


        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Semester semester)
        {
            if (ModelState.IsValid)
            {
                var model = semesterService.Find(semester.Id);
                model.SemesterName = semester.SemesterName;
                semesterService.Update(model);
                return RedirectToAction("Index");

            }
            return View();
        }
        public ActionResult Delete(Guid id)
        {
            semesterService.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(Guid id)
        {
            return View(semesterService.Find(id));
        }
    }
}