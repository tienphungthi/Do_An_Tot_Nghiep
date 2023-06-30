using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public class TaiKhoanService : ITaiKhoanService
    {
        private readonly IGenericRepository<TaiKhoan> _repository;
        public TaiKhoanService(IGenericRepository<TaiKhoan> repository)
        {
            _repository = repository;
        }
        public IEnumerable<TaiKhoan> GetAllTaiKhoan()
        {
            return _repository.GetAll();
        }
        public TaiKhoan GetTaiKhoan(int id)
        {
            return _repository.GetById(id);
        }
        public void InsertTaiKhoan(TaiKhoan tk)
        {
            _repository.Insert(tk);
        }
        public void UpdateTaiKhoan(TaiKhoan tk)
        {
            _repository.Update(tk);
        }
        public void DeleteTaiKhoan(int id)
        {
            _repository.Delete(id);
        }
    }
}
