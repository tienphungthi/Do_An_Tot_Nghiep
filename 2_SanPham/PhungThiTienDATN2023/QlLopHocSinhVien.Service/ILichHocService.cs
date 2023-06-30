using QlLopHocSinhVien.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public interface ILichHocService
    {

        IEnumerable<LichHoc> GetAllLichHoc();
        LichHoc GetLichHoc(int id);
        void InsertLichHoc(LichHoc lh);
        void UpdateLichHoc(LichHoc lh);
        void DeleteLichHoc(int id);
    }
}
