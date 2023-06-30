using QlLopHocSinhVien.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public interface ILichLamViecService
    {

        IEnumerable<LichLamViec> GetAllLichLamViec();
        LichLamViec GetLichLamViec(int id);
        void InsertLichLamViec(LichLamViec llv);
        void UpdateLichLamViec(LichLamViec llv);
        void DeleteLichLamViec(int id);
    }
}
