using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urms.Data;
using Urms.Model;

namespace Urms.Service
{
    public interface ISemesterService
    {
        void Insert(Semester entity);
        void Update(Semester entity);
        void Delete(Semester entity);
        void Delete(Guid id);
        Semester Find(Guid id);
        IEnumerable<Semester> GetAll();
        IEnumerable<Semester> GetAllByName(string name);
        IEnumerable<Semester> Search(string name);
    }

    public class SemesterService : ISemesterService
    {
        private readonly IRepository<Semester> semesterRepository;

        private readonly IUnitOfWork unitOfWork;

        public SemesterService(IUnitOfWork unitOfWork, IRepository<Semester> semesterRepository)
        {
            this.unitOfWork = unitOfWork;
            this.semesterRepository = semesterRepository;
        }
        public void Delete(Semester entity)
        {
            semesterRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var semester = semesterRepository.Find(id);
            if (semester != null)
            {
                this.Delete(semester);
            }
        }

        public Semester Find(Guid id)
        {
            return semesterRepository.Find(id);
        }

        public IEnumerable<Semester> GetAll()
        {
            return semesterRepository.GetAll();
        }

        public IEnumerable<Semester> GetAllByName(string name)
        {
            return semesterRepository.GetAll(w => w.SemesterName.Contains(name));
        }

        public void Insert(Semester entity)
        {
            semesterRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<Semester> Search(string name)
        {
            return semesterRepository.GetAll(e => e.SemesterName.Contains(name));
        }

        public void Update(Semester entity)
        {
            var semester = semesterRepository.Find(entity.Id);
            semester.SemesterName = entity.SemesterName;

            semesterRepository.Update(semester);
            unitOfWork.SaveChanges();
        }
    }
}
