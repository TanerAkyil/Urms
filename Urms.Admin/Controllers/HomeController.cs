using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Urms.Service;

namespace Urms.Admin.Controllers
{
    [Authorize]
    public class HomeController : ControllerBase
    {
        private readonly ITeacherService teacherservice;
        private readonly IStudentService studentService;
        private readonly IDepartmentService departmentService;
        private readonly ICourseService courseService;
        
        public HomeController(ApplicationUserManager userManager, ITeacherService teacherservice, IStudentService studentService, IDepartmentService departmentService, ICourseService courseService) : base(userManager)
        {
            this.teacherservice = teacherservice;
            this.studentService = studentService;
            this.departmentService = departmentService;
            this.courseService = courseService;
        }
        public ActionResult Index()
        {
            var s = User.Identity.Name;
            ViewBag.DepartmentCount = departmentService.GetAll().Count();
            ViewBag.StudentCount = studentService.GetAll().Count();
            ViewBag.TeacherCount = teacherservice.GetAll().Count();
            ViewBag.CourseCount = courseService.GetAll().Count();
            ViewBag.UserCount = userManager.Users.Count();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}