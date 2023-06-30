using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public class LichLamViecService : ILichLamViecService
    {
        private readonly IGenericRepository<LichLamViec> _repository;
        public LichLamViecService(IGenericRepository<LichLamViec> repository)
        {
            _repository = repository;
        }
        public IEnumerable<LichLamViec> GetAllLichLamViec()
        {
            return _repository.GetAll();
        }
        public LichLamViec GetLichLamViec(int id)
        {
            return _repository.GetById(id);
        }
        public void InsertLichLamViec(LichLamViec llv)
        {
            _repository.Insert(llv);
        }
        public void UpdateLichLamViec(LichLamViec llv)
        {
            _repository.Update(llv);
        }
        public void DeleteLichLamViec(int id)
        {
            _repository.Delete(id);
        }
    }
}