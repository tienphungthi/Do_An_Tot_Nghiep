using QlLopHocSinhVien.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public interface IPhongBanService
    {

        IEnumerable<PhongBan> GetAllPhongBan();
        PhongBan GetPhongBan(string id);
        void InsertPhongBan(PhongBan pb);
        void UpdatePhongBan(PhongBan pb);
        void DeletePhongBan(string id);
    }
}
