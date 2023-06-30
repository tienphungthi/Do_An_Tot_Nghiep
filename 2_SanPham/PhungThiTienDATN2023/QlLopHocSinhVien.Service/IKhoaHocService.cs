using QlLopHocSinhVien.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public interface IKhoaHocService
    {

        IEnumerable<KhoaHoc> GetAllKhoaHoc();
        KhoaHoc GetKhoaHoc(string id);
        void InsertKhoaHoc(KhoaHoc kh);
        void UpdateKhoaHoc(KhoaHoc kh);
        void DeleteKhoaHoc(string id);
    }
}
