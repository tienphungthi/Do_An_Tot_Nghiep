using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public class ChuongTrinhHocService : IChuongTrinhHocService
    {
        private readonly IsGenericRepository<ChuongTrinhHoc> _repository;
        public ChuongTrinhHocService(IsGenericRepository<ChuongTrinhHoc> repository)
        {
            _repository = repository;
        }
        public IEnumerable<ChuongTrinhHoc> GetAllChuongTrinhHoc()
        {
            return _repository.GetAll();
        }
        public ChuongTrinhHoc GetChuongTrinhHoc(string id)
        {
            return _repository.GetById(id);
        }
        public void InsertChuongTrinhHoc(ChuongTrinhHoc cth)
        {
            _repository.Insert(cth);
        }
        public void UpdateChuongTrinhHoc(ChuongTrinhHoc cth)
        {
            _repository.Update(cth);
        }
        public void DeleteChuongTrinhHoc(string id)
        {
            _repository.Delete(id);
        }
    }
}
