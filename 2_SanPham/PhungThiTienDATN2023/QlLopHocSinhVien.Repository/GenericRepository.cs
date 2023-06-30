using Microsoft.EntityFrameworkCore;
using QlLopHocSinhVien.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly GreenEduContext _context;
        private readonly DbSet<T> _entities;
        public GenericRepository(GreenEduContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }
        public T GetById(int id)
        {
            return _entities.Find(id);
        }
        public void Insert(T entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();
        }
        public void Update(T entity)
        {
            _entities.Update(entity);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var entity = GetById(id);
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public void Delete(string code)
        {
            var entity = _entities.Find(code);
            _entities.Remove(entity);
            _context.SaveChanges();
        }


    }
}
