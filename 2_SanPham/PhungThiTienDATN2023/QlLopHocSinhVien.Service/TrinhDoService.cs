using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public class TrinhDoService : ITrinhDoService
    {
        private readonly IsGenericRepository<TrinhDo> _repository;
        public TrinhDoService(IsGenericRepository<TrinhDo> repository)
        {
            _repository = repository;
        }
        public IEnumerable<TrinhDo> GetAllTrinhDo()
        {
            return _repository.GetAll();
        }
        public TrinhDo GetTrinhDo(string id)
        {
            return _repository.GetById(id);
        }
        public void InsertTrinhDo(TrinhDo td)
        {
            _repository.Insert(td);
        }
        public void UpdateTrinhDo(TrinhDo td)
        {
            _repository.Update(td);
        }
        public void DeleteTrinhDo(string id)
        {
            _repository.Delete(id);
        }
    }
}
