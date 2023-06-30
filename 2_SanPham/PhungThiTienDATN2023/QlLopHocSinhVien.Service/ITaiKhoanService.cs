using QlLopHocSinhVien.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public interface ITaiKhoanService
    {

        IEnumerable<TaiKhoan> GetAllTaiKhoan();
        TaiKhoan GetTaiKhoan(int id);
        void InsertTaiKhoan(TaiKhoan tk);
        void UpdateTaiKhoan(TaiKhoan tk);
        void DeleteTaiKhoan(int id);
    }
}
