using QlLopHocSinhVien.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public interface IGiangVienService
    {

        IEnumerable<GiangVien> GetAllGiangVien();
        GiangVien GetGiangVien(int id);
        void InsertGiangVien(GiangVien cv);
        void UpdateGiangVien(GiangVien cv);
        void DeleteGiangVien(int id);
        void DeleteGiangVien(string id);
    }
}
