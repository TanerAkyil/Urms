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
    public class StudentController : ControllerBase
    {
        private readonly IDepartmentService departmentService;
        private readonly IStudentService studentService;

        public StudentController(IDepartmentService departmentService,IStudentService studentService)
        {
            this.departmentService = departmentService;
            this.studentService = studentService;
        }
        // GET: Student
        public ActionResult Index()
        {
            var students = studentService.GetAll();
            return View(students);
        }
        public ActionResult Create()
        {
            var students = new Student();
            ViewBag.DeptId = new SelectList(departmentService.GetAll(), "Id", "DeptName");
            return View(students);
        }
      
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                studentService.Insert(student);
                return RedirectToAction("Index");
            }
            ViewBag.DeptId = new SelectList(departmentService.GetAll(), "Id", "DeptName", student.DeptId);
            return View();
        }
        public ActionResult Edit(Guid id)
        {
            var student = studentService.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeptId = new SelectList(departmentService.GetAll(), "Id", "DeptName", student.DeptId);
            return View(student);


        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                var model = studentService.Find(student.Id);
                model.StudentName = student.StudentName;
                model.Email = student.Email;
                model.ContactNo = student.ContactNo;
                model.RegDate = student.RegDate;
                model.Address = student.Address;
                
                model.RegNo = student.RegNo;
                studentService.Update(model);
                return RedirectToAction("Index");

            }
            ViewBag.DeptId = new SelectList(departmentService.GetAll(), "Id", "DeptName", student.DeptId);
            return View();
        }
        public ActionResult Delete(Guid id)
        {
            studentService.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(Guid id)
        {
            return View(studentService.Find(id));
        }
    }
}