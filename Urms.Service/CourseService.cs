using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urms.Data;
using Urms.Model;

namespace Urms.Service
{
    public interface ICourseService
    {
        void Insert(Course entity);
        void Update(Course entity);
        void Delete(Course entity);
        void Delete(Guid id);
        Course Find(Guid id);
        IEnumerable<Course> GetAll();
        IEnumerable<Course> GetAllByName(string name);
        IEnumerable<Course> Search(string name);
    }
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> courseRepository;
        private readonly IUnitOfWork unitOfWork;

        public CourseService(IUnitOfWork unitOfWork, IRepository<Course> courseRepository)
        {
            this.unitOfWork = unitOfWork;
            this.courseRepository = courseRepository;
        }
        public void Delete(Course entity)
        {
            courseRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var course = courseRepository.Find(id);
            if (course != null)
            {
                this.Delete(course);
            }
        }

        public Course Find(Guid id)
        {
            return courseRepository.Find(id);
        }

        public IEnumerable<Course> GetAll()
        {
            return courseRepository.GetAll();
        }

        public IEnumerable<Course> GetAllByName(string name)
        {
            return courseRepository.GetAll(w=>w.CourseName.Contains(name));
        }

        public void Insert(Course entity)
        {
            courseRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<Course> Search(string name)
        {
            return courseRepository.GetAll(e => e.CourseName.Contains(name));
        }

        public void Update(Course entity)
        {
            var course = courseRepository.Find(entity.Id);
            course.CourseCode = entity.CourseCode;
            course.CourseName = entity.CourseName;
            course.Credit = entity.Credit;
            course.SemesterId = entity.SemesterId;
            course.DeptId = entity.DeptId;
            course.TeacherId = entity.TeacherId;
            course.Description = entity.Description;
            courseRepository.Update(course);
            unitOfWork.SaveChanges();
        }
    }
}
