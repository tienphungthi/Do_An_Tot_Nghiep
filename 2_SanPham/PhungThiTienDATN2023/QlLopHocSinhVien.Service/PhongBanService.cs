using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public class PhongBanService : IPhongBanService
    {
        private readonly IsGenericRepository<PhongBan> _repository;
        public PhongBanService(IsGenericRepository<PhongBan> repository)
        {
            _repository = repository;
        }
        public IEnumerable<PhongBan> GetAllPhongBan()
        {
            return _repository.GetAll();
        }
        public PhongBan GetPhongBan(string id)
        {
            return _repository.GetById(id);
        }
        public void InsertPhongBan(PhongBan pb)
        {
            _repository.Insert(pb);
        }
        public void UpdatePhongBan(PhongBan pb)
        {
            _repository.Update(pb);
        }
        public void DeletePhongBan(string id)
        {
            _repository.Delete(id);
        }
    }
}
