using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public class BienLaiThuTienService : IBienLaiThuTienService
    {
        private readonly IGenericRepository<BienLaiThuTien> _repository;
        public BienLaiThuTienService(IGenericRepository<BienLaiThuTien> repository)
        {
            _repository = repository;
        }
        public IEnumerable<BienLaiThuTien> GetAllBienLaiThuTien()
        {
            return _repository.GetAll();
        }
        public BienLaiThuTien GetBienLaiThuTien(int id)
        {
            return _repository.GetById(id);
        }
        public void InsertBienLaiThuTien(BienLaiThuTien bltt)
        {
            _repository.Insert(bltt);
        }
        public void UpdateBienLaiThuTien(BienLaiThuTien bltt)
        {
            _repository.Update(bltt);
        }
        public void DeleteBienLaiThuTien(int id)
        {
            _repository.Delete(id);
        }
    }
}
