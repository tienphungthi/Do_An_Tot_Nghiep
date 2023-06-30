using QlLopHocSinhVien.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlLopHocSinhVien.Service
{
    public interface IQuanLyChamCongService
    {

        IEnumerable<QuanLyChamCong> GetAllQuanLyChamCong();
        QuanLyChamCong GetQuanLyChamCong(int id);
        void InsertQuanLyChamCong(QuanLyChamCong qlcc);
        void UpdateQuanLyChamCong(QuanLyChamCong qlcc);
        void DeleteQuanLyChamCong(int id);
    }
}
