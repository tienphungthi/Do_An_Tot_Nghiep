using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public class HocVienService : IHocVienService
    {
        private readonly IGenericRepository<HocVien> _repository;
        public HocVienService(IGenericRepository<HocVien> repository)
        {
            _repository = repository;
        }
        public IEnumerable<HocVien> GetAllHocVien()
        {
            return _repository.GetAll();
        }
        public HocVien GetHocVien(int id)
        {
            return _repository.GetById(id);
        }
        public void InsertHocVien(HocVien hv)
        {
            _repository.Insert(hv);
        }
        public void UpdateHocVien(HocVien hv)
        {
            _repository.Update(hv);
        }
        public void DeleteHocVien(int id)
        {
            _repository.Delete(id);
        }

        public void DeleteHocVien(string id)
        {
            _repository.Delete(id);
        }
    }
}
