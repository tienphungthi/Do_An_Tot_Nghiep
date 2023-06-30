using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public class DiemDanhService : IDiemDanhService
    {
        private readonly IGenericRepository<DiemDanh> _repository;
        public DiemDanhService(IGenericRepository<DiemDanh> repository)
        {
            _repository = repository;
        }
        public IEnumerable<DiemDanh> GetAllDiemDanh()
        {
            return _repository.GetAll();
        }
        public DiemDanh GetDiemDanh(int id)
        {
            return _repository.GetById(id);
        }
        public void InsertDiemDanh(DiemDanh dd)
        {
            _repository.Insert(dd);
        }
        public void UpdateDiemDanh(DiemDanh dd)
        {
            _repository.Update(dd);
        }
        public void DeleteDiemDanh(int id)
        {
            _repository.Delete(id);
        }

        public void DeleteDiemDanh(string id)
        {
            _repository.Delete(id);
        }
    }
}
