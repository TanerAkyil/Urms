using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    public class StudentService : IStudentService
    {
        public void Delete(Student entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Student Find(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAllByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Insert(Student entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> Search(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
