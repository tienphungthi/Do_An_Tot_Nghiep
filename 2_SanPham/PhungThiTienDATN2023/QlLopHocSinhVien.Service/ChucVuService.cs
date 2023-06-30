using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public class ChucVuService : IChucVuService
    {
        private readonly IsGenericRepository<ChucVu> _repository;
        public ChucVuService(IsGenericRepository<ChucVu> repository)
        {
            _repository = repository;
        }
        public IEnumerable<ChucVu> GetAllChucVu()
        {
            return _repository.GetAll();
        }
        public ChucVu GetChucVu(string id)
        {
            return _repository.GetById(id);
        }
        public void InsertChucVu(ChucVu cv)
        {
            _repository.Insert(cv);
        }
        public void UpdateChucVu(ChucVu cv)
        {
            _repository.Update(cv);
        }
        public void DeleteChucVu(string id)
        {
            _repository.Delete(id);
        }
    }
}
