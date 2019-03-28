using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Urms.Admin.Controllers
{
    public class ControllerBase : Controller
    {
  
        // bu metot tüm actionlardan önce çalışır
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
        // bu metot tüm actionlardan sonra çalışır
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
          
            ViewBag.photo = ConfigurationManager.AppSettings["~/Upload"];
            base.OnActionExecuted(filterContext);
        }
    }
}