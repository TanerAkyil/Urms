using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urms.Data;
using Urms.Model;

namespace Urms.Service
{
    public interface IDepartmentService
    {
        void Insert(Department entity);
        void Update(Department entity);
        void Delete(Department entity);
        void Delete(Guid id);
        Department Find(Guid id);
        IEnumerable<Department> GetAll();
        IEnumerable<Department> GetAllByName(string name);
        IEnumerable<Department> Search(string name);
    }

    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> departmentRepository;
        private readonly IUnitOfWork unitOfWork;
        public DepartmentService(IUnitOfWork unitOfWork, IRepository<Department> departmentRepository)
        {
            this.unitOfWork = unitOfWork;
            this.departmentRepository = departmentRepository;
        }
        public void Delete(Department entity)
        {
            departmentRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var course = departmentRepository.Find(id);
            if (course != null)
            {
                this.Delete(course);
            }
        }
        public Department Find(Guid id)
        {
            return departmentRepository.Find(id);
        }

        public IEnumerable<Department> GetAll()
        {
            return departmentRepository.GetAll();
        }

        public IEnumerable<Department> GetAllByName(string name)
        {
            return departmentRepository.GetAll(w => w.DeptName.Contains(name));
        }

        public void Insert(Department entity)
        {
            departmentRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<Department> Search(string name)
        {
            return departmentRepository.GetAll(w => w.DeptName.Contains(name));
        }

        public void Update(Department entity)
        {
            var department = departmentRepository.Find(entity.Id);
            department.DeptCode = entity.DeptCode;
            department.DeptName = entity.DeptName;
            departmentRepository.Update(department);
            unitOfWork.SaveChanges();
        }
    }
}
