using QlLopHocSinhVien.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public interface IChucVuService
    {

        IEnumerable<ChucVu> GetAllChucVu();
        ChucVu GetChucVu(string id);
        void InsertChucVu(ChucVu cv);
        void UpdateChucVu(ChucVu cv);
        void DeleteChucVu(string id);
    }
}
