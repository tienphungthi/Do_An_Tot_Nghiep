using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public class KhoaHocService : IKhoaHocService
    {
        private readonly IsGenericRepository<KhoaHoc> _repository;
        public KhoaHocService(IsGenericRepository<KhoaHoc> repository)
        {
            _repository = repository;
        }
        public IEnumerable<KhoaHoc> GetAllKhoaHoc()
        {
            return _repository.GetAll();
        }
        public KhoaHoc GetKhoaHoc(string id)
        {
            return _repository.GetById(id);
        }
        public void InsertKhoaHoc(KhoaHoc kh)
        {
            _repository.Insert(kh);
        }
        public void UpdateKhoaHoc(KhoaHoc kh)
        {
            _repository.Update(kh);
        }
        public void DeleteKhoaHoc(string id)
        {
            _repository.Delete(id);
        }
    }
}
