using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    class TeacherService : ITeacherService
    {
        public void Delete(Teacher entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Teacher Find(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Teacher> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Teacher> GetAllByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Insert(Teacher entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Teacher> Search(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(Teacher entity)
        {
            throw new NotImplementedException();
        }
    }
}
