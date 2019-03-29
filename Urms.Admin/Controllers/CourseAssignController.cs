using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Urms.Admin.Controllers
{
    public class CourseAssignController : ControllerBase
    {
        public CourseAssignController(ApplicationUserManager userManager):base(userManager)
        {

        }
        // GET: CourseAssign
        public ActionResult Index()
        {
            return View();
        }
    }
}