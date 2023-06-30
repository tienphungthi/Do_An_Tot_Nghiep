using Microsoft.AspNetCore.Mvc;
using QlLopHocSinhVien.Service;

namespace QlLopHocSinhVien.Controllers
{
	public class NhanVienController : Controller
	{
        private readonly INhanVienService nhanVienService;
        private readonly IGiangVienService giangvienService;
        private readonly ITrinhDoService trinhdoService;

        public class Teacher
        {
            public string MaNv { get; set; }
            public string HoTen { get; set; }
            public string MaGv { get; set; }
            public string TrinhDo { get; set; }

        }

        public NhanVienController(INhanVienService nhanVienService, IGiangVienService giangvienService, ITrinhDoService trinhdoService)
        {
            this.nhanVienService = nhanVienService;
            this.giangvienService = giangvienService;
            this.trinhdoService = trinhdoService;
        }

        public IActionResult Index()
		{
            var nhanvien = nhanVienService.GetAllNhanVien().ToList();
            var giangvien = giangvienService.GetAllGiangVien().ToList();
            var trinhdo = trinhdoService.GetAllTrinhDo().ToList();

            var listTeacher = (from n in nhanvien
                               join g in giangvien on n.MaNv equals g.MaNv

                               join t in trinhdo on g.MaTrinhDo equals t.MaTrinhDo
                               select new
                               {
                                   n.MaNv,
                                   n.Ten,
                                   g.MaGv,
                                   t.TenTrinhDo
                               }).ToList();

            List<Teacher> teachers = new List<Teacher>();
            foreach (var item in listTeacher)
            {
                Teacher teacher = new Teacher();
                teacher.MaNv = item.MaNv;
                teacher.HoTen = item.Ten;
                teacher.MaGv = item.MaGv;
                teacher.TrinhDo = item.TenTrinhDo;

                teachers.Add(teacher);
            }

            return View(teachers);
		}
	}
}
