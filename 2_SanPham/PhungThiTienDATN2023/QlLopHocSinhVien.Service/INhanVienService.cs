using QlLopHocSinhVien.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public interface INhanVienService
    {

        IEnumerable<NhanVien> GetAllNhanVien();
        NhanVien GetNhanVien(int id);
        void InsertNhanVien(NhanVien nv);
        void UpdateNhanVien(NhanVien nv);
        void DeleteNhanVien(int id);
        void DeleteNhanVien(string code);
    }
}
