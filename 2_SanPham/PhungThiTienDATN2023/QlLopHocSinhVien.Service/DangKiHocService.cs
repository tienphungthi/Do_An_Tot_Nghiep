using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public class DangKiHocService : IDangKiHocService
    {
        private readonly IsGenericRepository<DangKiHoc> _repository;
        public DangKiHocService(IsGenericRepository<DangKiHoc> repository)
        {
            _repository = repository;
        }
        public IEnumerable<DangKiHoc> GetAllDangKiHoc()
        {
            return _repository.GetAll();
        }
        public DangKiHoc GetDangKiHoc(string id)
        {
            return _repository.GetById(id);
        }
        public void InsertDangKiHoc(DangKiHoc dkh)
        {
            _repository.Insert(dkh);
        }
        public void UpdateDangKiHoc(DangKiHoc dkh)
        {
            _repository.Update(dkh);
        }
        public void DeleteDangKiHoc(string id)
        {
            _repository.Delete(id);
        }

        //public DangKiHoc GetDangKiHoc(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public void DeleteDangKiHoc(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
