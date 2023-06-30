using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public class QLThiService : IQLThiService
    {
        private readonly IGenericRepository<Qlthi> _repository;
        public QLThiService(IGenericRepository<Qlthi> repository)
        {
            _repository = repository;
        }
        public IEnumerable<Qlthi> GetAllQLThi()
        {
            return _repository.GetAll();
        }
        public Qlthi GetQLThi(int id)
        {
            return _repository.GetById(id);
        }
        public void InsertQLThi(Qlthi qlt)
        {
            _repository.Insert(qlt);
        }
        public void UpdateQLThi(Qlthi qlt)
        {
            _repository.Update(qlt);
        }
        public void DeleteQLThi(int id)
        {
            _repository.Delete(id);
        }
    }
}
