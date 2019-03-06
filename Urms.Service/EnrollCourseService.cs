using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urms.Data;
using Urms.Model;

namespace Urms.Service
{
    public interface IEnrollCourseService
    {
        void Insert(EnrollCourse entity);
        void Update(EnrollCourse entity);
        void Delete(EnrollCourse entity);
        void Delete(Guid id);
        EnrollCourse Find(Guid id);
        IEnumerable<EnrollCourse> GetAll();
  
    }
    public class EnrollCourseService:IEnrollCourseService
    {
        private readonly IRepository<EnrollCourse> enrollCourseRepository;
        private readonly IUnitOfWork unitOfWork;

        public EnrollCourseService(IUnitOfWork unitOfWork, IRepository<EnrollCourse> enrollCourseRepository)
        {
            this.unitOfWork = unitOfWork;
            this.enrollCourseRepository = enrollCourseRepository;
        }

        public void Delete(EnrollCourse entity)
        {
            enrollCourseRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var course = enrollCourseRepository.Find(id);
            if (course != null)
            {
                this.Delete(course);
            }
        }

        public EnrollCourse Find(Guid id)
        {
            return enrollCourseRepository.Find(id);
        }

        public IEnumerable<EnrollCourse> GetAll()
        {
            return enrollCourseRepository.GetAll();
        }

   

        public void Insert(EnrollCourse entity)
        {
            enrollCourseRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

      

        public void Update(EnrollCourse entity)
        {
            var enrollCourse = enrollCourseRepository.Find(entity.Id);
            enrollCourse.StudentId = entity.StudentId;
            enrollCourse.StudentId = entity.StudentId;
            enrollCourseRepository.Update(enrollCourse);
            unitOfWork.SaveChanges();
        }
    }
}
