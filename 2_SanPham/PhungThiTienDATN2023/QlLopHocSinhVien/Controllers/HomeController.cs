using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Models;
using QlLopHocSinhVien.Service;
using System.Diagnostics;

namespace QlLopHocSinhVien.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ITaiKhoanService taiKhoanService;
        private readonly INhanVienService nhanVienService;

        private readonly IKhoaHocService khoaHocService;
        private readonly IGiangVienService giangvienService;
        private readonly ITrinhDoService trinhdoService;

        public HomeController(ILogger<HomeController> logger, ITaiKhoanService taiKhoanService, INhanVienService nhanVienService, IKhoaHocService khoaHocService, IGiangVienService giangvienService,ITrinhDoService trinhdoService)
        {
            _logger = logger;
            this.taiKhoanService = taiKhoanService;
            this.nhanVienService = nhanVienService;
            this.khoaHocService = khoaHocService;
            this.giangvienService = giangvienService;
            this.trinhdoService = trinhdoService;
        }

        public IActionResult Index()
        {
            var listCourses = khoaHocService.GetAllKhoaHoc().Take(6).ToList();

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
            var tuple = new Tuple<List<KhoaHoc>, List<Teacher>>(listCourses, teachers);

            return View(tuple);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = taiKhoanService.GetAllTaiKhoan().FirstOrDefault(x => x.TenTaiKhoan == username && x.MatKhau == password);
            if (user == null)
            {
                ViewBag.Error = "Tài khoản hoặc mật khẩu không đúng!";
            }
            else
            {
				HttpContext.Session.SetString("accountcode", user.MaTaiKhoan);

				NhanVien nhanVien = nhanVienService.GetAllNhanVien().FirstOrDefault(x => x.MaTaiKhoan == user.MaTaiKhoan);
                if (nhanVien != null)
                {
					HttpContext.Session.SetString("code", nhanVien.MaNv);
                    HttpContext.Session.SetString("fullname", nhanVien.Ten);
                }
                return RedirectToAction("Index");
            }

            return View(user);
            
        }

		[HttpPost]
		public IActionResult Register(TaiKhoan taiKhoan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string password = "";
                    if (string.IsNullOrEmpty(taiKhoan.MatKhau))
                    {
                        ViewBag.Message = "Vui lòng nhập mật khẩu!";
                    }
                    else
                    {
                        password = taiKhoan.MaTaiKhoan;
                    }
                    taiKhoan.MatKhau = MaHoaMD5.EncryptPassword(password);
                    taiKhoanService.InsertTaiKhoan(taiKhoan);
                    return RedirectToAction("Login");
                }

                //return View(taiKhoan);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(taiKhoan);
        }

        public class Teacher
        {
            public string MaNv { get; set; } 
            public string HoTen { get; set; } 
            public string MaGv { get; set; } 
            public string TrinhDo { get; set; } 
            
        }
    }
}