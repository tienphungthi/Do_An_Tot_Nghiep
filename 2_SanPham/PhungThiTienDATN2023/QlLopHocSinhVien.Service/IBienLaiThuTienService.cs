using QlLopHocSinhVien.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public interface IBienLaiThuTienService
    {

        IEnumerable<BienLaiThuTien> GetAllBienLaiThuTien();
        BienLaiThuTien GetBienLaiThuTien(int id);
        void InsertBienLaiThuTien(BienLaiThuTien bltt);
        void UpdateBienLaiThuTien(BienLaiThuTien bltt);
        void DeleteBienLaiThuTien(int id);
    }
}
