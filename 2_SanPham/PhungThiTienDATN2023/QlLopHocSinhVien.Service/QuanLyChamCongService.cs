using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public class QuanLyChamCongService : IQuanLyChamCongService
    {
        private readonly IGenericRepository<QuanLyChamCong> _repository;
        public QuanLyChamCongService(IGenericRepository<QuanLyChamCong> repository)
        {
            _repository = repository;
        }
        public IEnumerable<QuanLyChamCong> GetAllQuanLyChamCong()
        {
            return _repository.GetAll();
        }
        public QuanLyChamCong GetQuanLyChamCong(int id)
        {
            return _repository.GetById(id);
        }
        public void InsertQuanLyChamCong(QuanLyChamCong qlcc)
        {
            _repository.Insert(qlcc);
        }
        public void UpdateQuanLyChamCong(QuanLyChamCong qlcc)
        {
            _repository.Update(qlcc);
        }
        public void DeleteQuanLyChamCong(int id)
        {
            _repository.Delete(id);
        }
    }
}
