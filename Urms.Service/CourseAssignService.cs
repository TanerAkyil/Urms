using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urms.Data;
using Urms.Model;

namespace Urms.Service
{
    public interface ICourseAssignService
    {
        void Insert(CourseAssign entity);
        void Update(CourseAssign entity);
        void Delete(CourseAssign entity);
        void Delete(Guid id);
        CourseAssign Find(Guid id);
        IEnumerable<CourseAssign> GetAll();
     
    }
    public class CourseAssignService : ICourseAssignService
    {
        private readonly IRepository<CourseAssign> CourseAssignRepository;
        private readonly IUnitOfWork unitOfWork;

        public CourseAssignService(IUnitOfWork unitOfWork, IRepository<CourseAssign> CourseAssignRepository)
        {
            this.unitOfWork = unitOfWork;
            this.CourseAssignRepository = CourseAssignRepository;
        }
        public void Delete(CourseAssign entity)
        {
            CourseAssignRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var CourseAssign = CourseAssignRepository.Find(id);
            if (CourseAssign != null)
            {
                this.Delete(CourseAssign);
            }
        }

        public CourseAssign Find(Guid id)
        {
            return CourseAssignRepository.Find(id);
        }

        public IEnumerable<CourseAssign> GetAll()
        {
            return CourseAssignRepository.GetAll();
        }

  

        public void Insert(CourseAssign entity)
        {
            CourseAssignRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

     

        public void Update(CourseAssign entity)
        {
            var CourseAssign = CourseAssignRepository.Find(entity.Id);
            CourseAssign.CourseId = entity.CourseId;
            CourseAssign.TeacherId = entity.TeacherId;
            CourseAssign.DepartmentId = entity.DepartmentId;
            CourseAssignRepository.Update(CourseAssign);
            unitOfWork.SaveChanges();
        }
    }
}
