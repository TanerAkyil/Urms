using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urms.Data;
using Urms.Model;

namespace Urms.Service
{   
    public interface IStudentService
    {

        void Insert(Student entity);
        void Update(Student entity);
        void Delete(Student entity);
        void Delete(Guid id);
        Student Find(Guid id);
        IEnumerable<Student> GetAll();
        IEnumerable<Student> GetAllByName(string name);
        IEnumerable<Student> Search(string name);
    }

   public  class StudentService : IStudentService
    {
        private readonly IRepository<Student> studentRepository;

        private readonly IUnitOfWork unitOfWork;

        public StudentService(IUnitOfWork unitOfWork, IRepository<Student> studentRepository)
        {
            this.unitOfWork = unitOfWork;
            this.studentRepository = studentRepository;
        }
        public void Delete(Student entity)
        {
            studentRepository.Delete(entity);
            unitOfWork.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var student = studentRepository.Find(id);
            if (student != null)
            {
                this.Delete(student);
            }
        }

        public Student Find(Guid id)
        {
            return studentRepository.Find(id);
        }

        public IEnumerable<Student> GetAll()
        {
            return studentRepository.GetAll();
        }

        public IEnumerable<Student> GetAllByName(string name)
        {
            return studentRepository.GetAll(w => w.StudentName.Contains(name));
        }

        public void Insert(Student entity)
        {
            studentRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<Student> Search(string name)
        {
            return studentRepository.GetAll(e => e.StudentName.Contains(name));
        }

        public void Update(Student entity)
        {
            var student = studentRepository.Find(entity.Id);
            student.StudentName = entity.StudentName;
            student.Email = entity.Email;
            student.ContactNo = entity.ContactNo;
            student.RegDate = entity.RegDate;
            student.Address = entity.Address;
            student.DeptId = entity.DeptId;
            student.RegNo = entity.RegNo;

            studentRepository.Update(student);
            unitOfWork.SaveChanges();
        }
    }
}
