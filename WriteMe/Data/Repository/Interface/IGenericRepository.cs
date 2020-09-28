using System.Collections.Generic;

namespace WriteMe.Data.Repository.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
    }
}
