using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public class LichHocService : ILichHocService
    {
        private readonly IGenericRepository<LichHoc> _repository;
        public LichHocService(IGenericRepository<LichHoc> repository)
        {
            _repository = repository;
        }
        public IEnumerable<LichHoc> GetAllLichHoc()
        {
            return _repository.GetAll();
        }
        public LichHoc GetLichHoc(int id)
        {
            return _repository.GetById(id);
        }
        public void InsertLichHoc(LichHoc lh)
        {
            _repository.Insert(lh);
        }
        public void UpdateLichHoc(LichHoc lh)
        {
            _repository.Update(lh);
        }
        public void DeleteLichHoc(int id)
        {
            _repository.Delete(id);
        }
    }
}
