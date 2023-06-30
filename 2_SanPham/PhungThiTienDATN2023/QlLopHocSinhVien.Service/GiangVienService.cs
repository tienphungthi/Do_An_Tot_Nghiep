using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public class GiangVienService : IGiangVienService
    {
        private readonly IGenericRepository<GiangVien> _repository;
        public GiangVienService(IGenericRepository<GiangVien> repository)
        {
            _repository = repository;
        }
        public IEnumerable<GiangVien> GetAllGiangVien()
        {
            return _repository.GetAll();
        }
        public GiangVien GetGiangVien(int id)
        {
            return _repository.GetById(id);
        }
        public void InsertGiangVien(GiangVien gv)
        {
            _repository.Insert(gv);
        }
        public void UpdateGiangVien(GiangVien gv)
        {
            _repository.Update(gv);
        }
        public void DeleteGiangVien(int id)
        {
            _repository.Delete(id);
        }

        public void DeleteGiangVien(string id)
        {
            _repository.Delete(id);
        }
    }
}
