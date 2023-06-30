using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Repository
{
    public interface IsGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(string id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(string id);
    }
}
