using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public class CoSoService : ICoSoService
    {
        private readonly IGenericRepository<CoSo> _repository;
        public CoSoService(IGenericRepository<CoSo> repository)
        {
            _repository = repository;
        }
        public IEnumerable<CoSo> GetAllCoSo()
        {
            return _repository.GetAll();
        }
        public CoSo GetCoSo(int id)
        {
            return _repository.GetById(id);
        }
        public void InsertCoSo(CoSo cs)
        {
            _repository.Insert(cs);
        }
        public void UpdateCoSo(CoSo cs)
        {
            _repository.Update(cs);
        }
        public void DeleteCoSo(int id)
        {
            _repository.Delete(id);
        }

        public void DeleteCoSo(string id)
        {
            _repository.Delete(id);
        }
    }
}
