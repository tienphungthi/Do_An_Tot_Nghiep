using QlLopHocSinhVien.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public interface ITrinhDoService
    {

        IEnumerable<TrinhDo> GetAllTrinhDo();
        TrinhDo GetTrinhDo(string id);
        void InsertTrinhDo(TrinhDo td);
        void UpdateTrinhDo(TrinhDo td);
        void DeleteTrinhDo(string id);
    }
}
