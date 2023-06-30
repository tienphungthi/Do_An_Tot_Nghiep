using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Models;
using QlLopHocSinhVien.Service;

namespace QlLopHocSinhVien.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class HomeController : Controller
	{
		private ITaiKhoanService taikhoanService;
		private INhanVienService nhanVienService;
		private IGiangVienService giangvienService;
		private IChucVuService chucvuService;

		public HomeController(ITaiKhoanService taikhoanService, INhanVienService nhanVienService,IGiangVienService giangvienService, IChucVuService chucvuService)
		{
			this.taikhoanService = taikhoanService;
			this.nhanVienService = nhanVienService;
			this.giangvienService = giangvienService;
			this.chucvuService = chucvuService;
		}

		public IActionResult Index()
		{
			return View();
		}


		public IActionResult Login()
		{
			return View();
		}

		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
        public IActionResult Login(string username, string password)
        {
			try
			{
				if (ModelState.IsValid)
				{
					password = MaHoaMD5.EncryptPassword(password);
					var account = taikhoanService.GetAllTaiKhoan().FirstOrDefault(x => x.TenTaiKhoan == username && x.MatKhau == password);

					if (account != null)
					{
						NhanVien nhanVien = nhanVienService.GetAllNhanVien().FirstOrDefault(x => x.MaTaiKhoan == account.MaTaiKhoan);

						if (nhanVien != null)
						{
							if (nhanVien.TrangThaiNhanSu != "3")
							{
                                HttpContext.Session.SetString("manv", nhanVien.MaNv);
                                HttpContext.Session.SetString("tennv", nhanVien.Ten);
                                HttpContext.Session.SetString("status", nhanVien.TrangThaiNhanSu == null ? "": nhanVien.TrangThaiNhanSu);

								GiangVien giangVien = giangvienService.GetAllGiangVien().FirstOrDefault(x => x.MaNv == nhanVien.MaNv);
								if (giangVien != null)
								{
                                    HttpContext.Session.SetString("magv", giangVien.MaGv);
                                }

								
								if (string.IsNullOrEmpty(nhanVien.MaCv))
								{
                                    HttpContext.Session.SetString("chucvu", "Amin");
								}
								else
								{
                                    ChucVu chucVu = chucvuService.GetAllChucVu().FirstOrDefault(x => x.MaCv == nhanVien.MaCv);
                                    HttpContext.Session.SetString("chucvu", chucVu.TenCv == null ? "":chucVu.TenCv);
                                }

								return RedirectToAction("Index");
							}
							
						}
					}

                    ViewBag.Message = $"Tên đăng nhập hoặc mật khẩu không đúng!";
                }

				return View();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
            
        }


		[HttpPost]
		public IActionResult Register(NhanVien employee, string? username, string? password)
		{
            try
            {
                if (ModelState.IsValid)
                {
                    TaiKhoan taiKhoan = new TaiKhoan();

                    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    {
                        ViewBag.Message = "Vui lòng nhập đủ các thông tin!";
                    }
                    else
                    {
                        var accout = taikhoanService.GetAllTaiKhoan().Where(x => x.TenTaiKhoan == username).FirstOrDefault();

                        if (accout != null)
                        {
                            ViewBag.Message = $"Tên tài khoản [{username}] đã được sử dụng!";
                        }
                        else
                        {
							var countAcc = taikhoanService.GetAllTaiKhoan().ToList().Count();

							taiKhoan.MaTaiKhoan = $"AC_{DateTime.Now.ToString("ddMMyy")}_{countAcc + 1}";
                            taiKhoan.TenTaiKhoan = username;
                            taiKhoan.MatKhau = MaHoaMD5.EncryptPassword(password);

                            taikhoanService.InsertTaiKhoan(taiKhoan);

                            var countEmployee = nhanVienService.GetAllNhanVien().ToList().Count;

                            employee.MaNv = $"NV_{DateTime.Now.ToString("ddMMyy")}_{countEmployee + 1}";
                            employee.MaTaiKhoan = taiKhoan.MaTaiKhoan;
							employee.TrangThaiNhanSu = "1";
                            nhanVienService.InsertNhanVien(employee);

                            return RedirectToAction("Login");
                        }
                    }

					
                }

                return View();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
