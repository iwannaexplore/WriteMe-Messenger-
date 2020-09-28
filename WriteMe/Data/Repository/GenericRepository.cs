using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WriteMe.Data.Repository.Interface;

namespace WriteMe.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context = null;
        private readonly DbSet<T> _table = null;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public List<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetById(int id)
        {
            return _table.Find(id);
        }

        public void Insert(T obj)
        {
             _table.Add(obj);
             _context.SaveChanges();
        }

        public void Update(T obj)
        {
            _table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified; 
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            T existing = _table.Find(id);
            _table.Remove(existing);
            _context.SaveChanges();
        }
    }
}