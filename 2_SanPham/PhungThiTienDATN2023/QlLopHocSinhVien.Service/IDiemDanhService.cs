using QlLopHocSinhVien.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public interface IDiemDanhService
    {

        IEnumerable<DiemDanh> GetAllDiemDanh();
        DiemDanh GetDiemDanh(int id);
        void InsertDiemDanh(DiemDanh dd);
        void UpdateDiemDanh(DiemDanh dd);
        void DeleteDiemDanh(int id);
        void DeleteDiemDanh(string id);
    }
}
