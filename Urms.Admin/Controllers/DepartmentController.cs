using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Urms.Model;
using Urms.Service;

namespace Urms.Admin.Controllers
{
    [Authorize]
    
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }
        // GET: Department
        public ActionResult Index()
        {
            var departments = departmentService.GetAll();
            return View(departments);
        }
        public ActionResult Create()
        {
            var departments = new Department();
            return View(departments);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                departmentService.Insert(department);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(Guid id)
        {
            var department = departmentService.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);


        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                var model = departmentService.Find(department.Id);
                model.DeptCode = department.DeptCode;
                model.DeptName = department.DeptName;
                model.IsActive = department.IsActive;
                departmentService.Update(model);
                return RedirectToAction("Index");

            }
            return View();
        }
        public ActionResult Delete(Guid id)
        {
            departmentService.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(Guid id)
        {
            return View(departmentService.Find(id));
        }
    }
}