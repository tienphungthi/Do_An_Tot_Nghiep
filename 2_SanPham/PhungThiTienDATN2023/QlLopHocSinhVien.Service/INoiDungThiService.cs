using QlLopHocSinhVien.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public interface INoiDungThiService
    {

        IEnumerable<NoiDungThi> GetAllNoiDungThi();
        NoiDungThi GetNoiDungThi(int id);
        void InsertNoiDungThi(NoiDungThi ndt);
        void UpdateNoiDungThi(NoiDungThi ndt);
        void DeleteNoiDungThi(int id);
    }
}
