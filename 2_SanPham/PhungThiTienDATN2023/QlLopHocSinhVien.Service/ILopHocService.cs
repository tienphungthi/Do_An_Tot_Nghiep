using QlLopHocSinhVien.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public interface ILopHocService
    {

        IEnumerable<LopHoc> GetAllLopHoc();
        LopHoc GetLopHoc(int id);
        void InsertLopHoc(LopHoc lh);
        void UpdateLopHoc(LopHoc lh);
        void DeleteLopHoc(int id);
        void DeleteLopHoc(string id);
    }
}
