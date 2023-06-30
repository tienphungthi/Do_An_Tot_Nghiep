using QlLopHocSinhVien.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public interface IDangKiHocService
    {

        IEnumerable<DangKiHoc> GetAllDangKiHoc();
        DangKiHoc GetDangKiHoc(string id);
        void InsertDangKiHoc(DangKiHoc dkh);
        void UpdateDangKiHoc(DangKiHoc dkh);
        void DeleteDangKiHoc(string id);
        //void DeleteDangKiHoc(int id);
    }
}
