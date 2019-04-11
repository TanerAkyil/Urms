using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Urms.Model;
using Urms.Service;

namespace Urms.Admin.Controllers
{
    [Authorize(Roles = "Admin,Teacher")]
    public class DesignationController : ControllerBase
    {
        // GET: Designation
        private readonly IDesignationService designationService;
        public DesignationController(IDesignationService designationService, ApplicationUserManager userManager) : base(userManager)
        {
            this.designationService = designationService;
        }
        // GET: Department
        public ActionResult Index()
        {
            var designations = designationService.GetAll();
            return View(designations);
        }
        public ActionResult Create()
        {
            var designations = new Designation();
            return View(designations);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Designation designation)
        {
            if (ModelState.IsValid)
            { 
                designationService.Insert(designation);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(Guid id)
        {
            var designation = designationService.Find(id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);


        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Designation designation)
        {
            if (ModelState.IsValid)
            {
                var model = designationService.Find(designation.Id);
                model.DesignationName = designation.DesignationName;
                designationService.Update(model);
                return RedirectToAction("Index");

            }
            return View();
        }
        public ActionResult Delete(Guid id)
        {
            designationService.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(Guid id)
        {
            return View(designationService.Find(id));
        }
    }
}