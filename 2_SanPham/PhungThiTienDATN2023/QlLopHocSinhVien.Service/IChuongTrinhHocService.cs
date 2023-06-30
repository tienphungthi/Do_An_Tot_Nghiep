using QlLopHocSinhVien.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public interface IChuongTrinhHocService
    {
        IEnumerable<ChuongTrinhHoc> GetAllChuongTrinhHoc();
        ChuongTrinhHoc GetChuongTrinhHoc(string id);
        void InsertChuongTrinhHoc(ChuongTrinhHoc cth);
        void UpdateChuongTrinhHoc(ChuongTrinhHoc cth);
        void DeleteChuongTrinhHoc(string id);
    }
}
