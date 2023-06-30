using QlLopHocSinhVien.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public interface ICoSoService
    {

        IEnumerable<CoSo> GetAllCoSo();
        CoSo GetCoSo(int id);
        void InsertCoSo(CoSo cs);
        void UpdateCoSo(CoSo cs);
        void DeleteCoSo(int id);
        void DeleteCoSo(string id);
    }
}
