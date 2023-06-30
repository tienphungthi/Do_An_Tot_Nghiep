using QlLopHocSinhVien.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public interface IHocVienService
    {

        IEnumerable<HocVien> GetAllHocVien();
        HocVien GetHocVien(int id);
        void InsertHocVien(HocVien hv);
        void UpdateHocVien(HocVien hv);
        void DeleteHocVien(int id);
        void DeleteHocVien(string id);
    }
}
