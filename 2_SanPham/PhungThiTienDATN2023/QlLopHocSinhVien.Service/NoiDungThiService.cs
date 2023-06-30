using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public class NoiDungThiService : INoiDungThiService
    {
        private readonly IGenericRepository<NoiDungThi> _repository;
        public NoiDungThiService(IGenericRepository<NoiDungThi> repository)
        {
            _repository = repository;
        }
        public IEnumerable<NoiDungThi> GetAllNoiDungThi()
        {
            return _repository.GetAll();
        }
        public NoiDungThi GetNoiDungThi(int id)
        {
            return _repository.GetById(id);
        }
        public void InsertNoiDungThi(NoiDungThi ndt)
        {
            _repository.Insert(ndt);
        }
        public void UpdateNoiDungThi(NoiDungThi ndt)
        {
            _repository.Update(ndt);
        }
        public void DeleteNoiDungThi(int id)
        {
            _repository.Delete(id);
        }
    }
}
