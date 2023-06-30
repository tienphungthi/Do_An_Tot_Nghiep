using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public class LopHocService : ILopHocService
    {
        private readonly IGenericRepository<LopHoc> _repository;
        public LopHocService(IGenericRepository<LopHoc> repository)
        {
            _repository = repository;
        }
        public IEnumerable<LopHoc> GetAllLopHoc()
        {
            return _repository.GetAll();
        }
        public LopHoc GetLopHoc(int id)
        {
            return _repository.GetById(id);
        }
        public void InsertLopHoc(LopHoc lh)
        {
            _repository.Insert(lh);
        }
        public void UpdateLopHoc(LopHoc lh)
        {
            _repository.Update(lh);
        }
        public void DeleteLopHoc(int id)
        {
            _repository.Delete(id);
        }

        public void DeleteLopHoc(string id)
        {
            _repository.Delete(id);
        }
    }
}
