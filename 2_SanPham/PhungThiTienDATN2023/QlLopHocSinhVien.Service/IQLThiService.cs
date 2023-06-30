using QlLopHocSinhVien.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public interface IQLThiService
    {

        IEnumerable<Qlthi> GetAllQLThi();
        Qlthi GetQLThi(int id);
        void InsertQLThi(Qlthi  qlt);
        void UpdateQLThi(Qlthi qlt);
        void DeleteQLThi(int id);
    }
}
