using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urms.Data.Builders;
using Urms.Model;

namespace Urms.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseAssign> CourseAssignes { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<EnrollCourse> EnrollCourses { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new CourseBuilder(modelBuilder.Entity<Course>());
            new CourseAssignBuilder(modelBuilder.Entity<CourseAssign>());
            new DepartmentBuilder(modelBuilder.Entity<Department>());
            new DesignationBuilder(modelBuilder.Entity<Designation>());
            new EnrollCourseBuilder(modelBuilder.Entity<EnrollCourse>());
            new ResultBuilder(modelBuilder.Entity<Result>());
            new SemesterBuilder(modelBuilder.Entity<Semester>());
            new StudentBuilder(modelBuilder.Entity<Student>());
            new TeacherBuilder(modelBuilder.Entity<Teacher>());
        }

       
    }
}
