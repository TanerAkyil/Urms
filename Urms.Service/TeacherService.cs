using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Urms.Data;
using Urms.Model;

namespace Urms.Service
{
    public interface ITeacherService
    {
        void Insert(Teacher entity);
        void Update(Teacher entity);
        void Delete(Teacher entity);
        void Delete(Guid id);
        Teacher Find(Guid id);
        IEnumerable<Teacher> GetAll();
        IEnumerable<Teacher> GetAllByName(string name);
        IEnumerable<Teacher> Search(string name);
    }
    public class TeacherService : ITeacherService
    {
        private readonly IRepository<Teacher> teacherRepository;
        private readonly IUnitOfWork unitOfWork;

        public TeacherService(IUnitOfWork unitOfWork, IRepository<Teacher> teacherRepository)
        {
            this.unitOfWork = unitOfWork;
            this.teacherRepository = teacherRepository;

        }
        public void Delete(Teacher entity)
        {
            teacherRepository.Delete(entity);
            unitOfWork.SaveChanges();


        }

        public void Delete(Guid id)
        {
            var teacher = teacherRepository.Find(id);
            if (teacher != null)
            {
                this.Delete(teacher);
            }
        }

        public Teacher Find(Guid id)
        {
            return teacherRepository.Find(id);
        }

        public IEnumerable<Teacher> GetAll()
        {
            return teacherRepository.GetAll();
        }

        public IEnumerable<Teacher> GetAllByName(string name)
        {
            return teacherRepository.GetAll(w => w.TeacherName.Contains(name));
        }

        public void Insert(Teacher entity)
        {
            teacherRepository.Insert(entity);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<Teacher> Search(string name)
        {
            return teacherRepository.GetAll(e => e.TeacherName.Contains(name));
        }

        public void Update(Teacher entity)
        {
            var  teacher = teacherRepository.Find(entity.Id);
            teacher.TeacherName = entity.TeacherName;
            teacher.Address = entity.Address;
            teacher.Email = entity.Email;
            teacher.ContactNo = entity.ContactNo;
            teacher.DesignationId = entity.DesignationId;
            teacher.DeptId = entity.DeptId;
            teacher.DeptId = entity.DeptId;
            teacher.CreaditToBeTaken = entity.CreaditToBeTaken;
            teacher.RemaingCreadit = entity.RemaingCreadit;
            
            teacherRepository.Update(teacher);
            unitOfWork.SaveChanges();
        }
    }
}
