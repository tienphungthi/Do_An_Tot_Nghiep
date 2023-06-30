using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public class DotThiService : IDotThiService
    {
        private readonly IGenericRepository<DotThi> _repository;
        public DotThiService(IGenericRepository<DotThi> repository)
        {
            _repository = repository;
        }
        public IEnumerable<DotThi> GetAllDotThi()
        {
            return _repository.GetAll();
        }
        public DotThi GetDotThi(int id)
        {
            return _repository.GetById(id);
        }
        public void InsertDotThi(DotThi dt)
        {
            _repository.Insert(dt);
        }
        public void UpdateDotThi(DotThi dt)
        {
            _repository.Update(dt);
        }
        public void DeleteDotThi(int id)
        {
            _repository.Delete(id);
        }
    }
}
