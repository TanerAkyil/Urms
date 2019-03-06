using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urms.Data;
using Urms.Model;

namespace Urms.Service
{
    public interface IResultService
    {
        void Insert(Result entity);
        void Update(Result entity);
        void Delete(Result entity);
        void Delete(Guid id);
        Result Find(Guid id);
        IEnumerable<Result> GetAll();
      
    }
    public class ResultService : IResultService
    {
        private readonly IRepository<Result> resultRepository;
        private readonly IUnitOfWork unitOfWork;
        public ResultService(IUnitOfWork unitOfWork, IRepository<Result> categoryRepository)
        {
            this.unitOfWork = unitOfWork;
            this.resultRepository = categoryRepository;
        }
        public void Delete(Result entity)
        {
            resultRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var course = resultRepository.Find(id);
            if (course != null)
            {
                this.Delete(course);
            }
        }

        public Result Find(Guid id)
        {
            return resultRepository.Find(id);
        }

        public IEnumerable<Result> GetAll()
        {
            return resultRepository.GetAll();
        }

     

        public void Insert(Result entity)
        {
            resultRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

    

        public void Update(Result entity)
        {
            var result = resultRepository.Find(entity.Id);
            result.StudentId = entity.StudentId;
            result.CourseId = entity.CourseId;
            result.Grade = entity.Grade;
            
            resultRepository.Update(result);
            unitOfWork.SaveChanges();
        }
    }
}
