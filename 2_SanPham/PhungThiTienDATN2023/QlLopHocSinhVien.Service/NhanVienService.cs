using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public class NhanVienService : INhanVienService
    {
        private readonly IGenericRepository<NhanVien> _repository;
        public NhanVienService(IGenericRepository<NhanVien> repository)
        {
            _repository = repository;
        }
        public IEnumerable<NhanVien> GetAllNhanVien()
        {
            return _repository.GetAll();
        }
        public NhanVien GetNhanVien(int id)
        {
            return _repository.GetById(id);
        }
        public void InsertNhanVien(NhanVien nv)
        {
            _repository.Insert(nv);
        }
        public void UpdateNhanVien(NhanVien nv)
        {
            _repository.Update(nv);
        }
        public void DeleteNhanVien(int id)
        {
            _repository.Delete(id);
        }

        public void DeleteNhanVien(string manv)
        {
            _repository.Delete(manv);
        }
    }
}
