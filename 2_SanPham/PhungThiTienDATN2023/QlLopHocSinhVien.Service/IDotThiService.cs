using QlLopHocSinhVien.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public interface IDotThiService
    {

        IEnumerable<DotThi> GetAllDotThi();
        DotThi GetDotThi(int id);
        void InsertDotThi(DotThi dt);
        void UpdateDotThi(DotThi dt);
        void DeleteDotThi(int id);
    }
}
