using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Urms.Data;
using Urms.Model;
using Urms.Service;

namespace Urms.Admin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();


            //db context 'i  mi scoped( yani request bazlı) olarak register et
            builder.RegisterType<ApplicationDbContext>().InstancePerRequest();

            // generic repository geçici instance olarak register et
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerDependency();
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication.User.Identity).As<System.Security.Principal.IIdentity>();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();
            //servisleri register et
            builder.RegisterType(typeof(CourseAssignService)).As(typeof(ICourseAssignService)).InstancePerDependency();
            builder.RegisterType(typeof(CourseService)).As(typeof(ICourseService)).InstancePerDependency();
            builder.RegisterType(typeof(DepartmentService)).As(typeof(IDepartmentService)).InstancePerDependency();
            builder.RegisterType(typeof(DesignationService)).As(typeof(IDesignationService)).InstancePerDependency();
            builder.RegisterType(typeof(EnrollCourseService)).As(typeof(IEnrollCourseService)).InstancePerDependency();
            builder.RegisterType(typeof(ResultService)).As(typeof(IResultService)).InstancePerDependency();
            builder.RegisterType(typeof(SemesterService)).As(typeof(ISemesterService)).InstancePerDependency();
            builder.RegisterType(typeof(StudentService)).As(typeof(IStudentService)).InstancePerDependency();
            builder.RegisterType(typeof(TeacherService)).As(typeof(ITeacherService)).InstancePerDependency();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.Register(c => new UserStore<ApplicationUser>(c.Resolve<ApplicationDbContext>())).AsImplementedInterfaces().InstancePerRequest();
            builder.Register(c => new RoleStore<IdentityRole>(c.Resolve<ApplicationDbContext>())).InstancePerRequest();
           /* builder.RegisterType<ApplicationRoleManager>().AsSelf().InstancePerRequest();*/
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>();
            builder.Register(c => new IdentityFactoryOptions<ApplicationUserManager>
            {
                DataProtectionProvider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("Application​")
            });

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
