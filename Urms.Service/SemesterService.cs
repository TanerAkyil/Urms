using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void Delete(Semester entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Semester Find(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Semester> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Semester> GetAllByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Insert(Semester entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Semester> Search(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(Semester entity)
        {
            throw new NotImplementedException();
        }
    }
}
