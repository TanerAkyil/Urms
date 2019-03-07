using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urms.Data;
using Urms.Model;

namespace Urms.Service
{
    public interface IDesignationService
    {
        void Insert(Designation entity);
        void Update(Designation entity);
        void Delete(Designation entity);
        void Delete(Guid id);
        Designation Find(Guid id);
        IEnumerable<Designation> GetAll();
        IEnumerable<Designation> GetAllByName(string name);
        IEnumerable<Designation> Search(string name);
    }

    public class DesignationService : IDesignationService
    {
        private readonly IRepository<Designation> designationRepository;
        private readonly IUnitOfWork unitOfWork;
        public DesignationService(IUnitOfWork unitOfWork, IRepository<Designation> designationRepository)
        {
            this.unitOfWork = unitOfWork;
            this.designationRepository = designationRepository;
        }
        public void Delete(Designation entity)
        {
            designationRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var course = designationRepository.Find(id);
            if (course != null)
            {
                this.Delete(course);
            }
        }

        public Designation Find(Guid id)
        {
            return designationRepository.Find(id);
        }

        public IEnumerable<Designation> GetAll()
        {
            return designationRepository.GetAll();
        }

        public IEnumerable<Designation> GetAllByName(string name)
        {
            return designationRepository.GetAll(w => w.DesignationName.Contains(name));
        }

        public void Insert(Designation entity)
        {
            designationRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<Designation> Search(string name)
        {
            return designationRepository.GetAll(w => w.DesignationName.Contains(name));
        }

        public void Update(Designation entity)
        {
            var designation = designationRepository.Find(entity.Id);
            designation.DesignationName = entity.DesignationName;
            designationRepository.Update(designation);
            unitOfWork.SaveChanges();
        }
    }
}
