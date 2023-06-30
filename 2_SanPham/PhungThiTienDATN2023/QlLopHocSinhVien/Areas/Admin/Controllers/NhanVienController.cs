using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Models;
using QlLopHocSinhVien.Service;

namespace QlLopHocSinhVien.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NhanVienController : Controller
    {
        private INhanVienService nhanVienService;
        private IPhongBanService phongBanService;
        private IChucVuService chucVuService;
        private ITaiKhoanService taiKhoanService;

        public NhanVienController(INhanVienService nhanVienService, IPhongBanService phongBanService, IChucVuService chucVuService, ITaiKhoanService taiKhoanService)
        {
            this.nhanVienService = nhanVienService;
            this.phongBanService = phongBanService;
            this.chucVuService = chucVuService;
            this.taiKhoanService = taiKhoanService;
        }

        [HttpGet]
        public IActionResult Index(string department, string position, string status, string keyword)
        {
            ViewBag.Title = "NHÂN VIÊN";
            ViewBag.Department = new SelectList(phongBanService.GetAllPhongBan(), "MaPb", "TenPb");
            ViewBag.Position = new SelectList(chucVuService.GetAllChucVu(), "MaCv", "TenCv");

            department = string.IsNullOrEmpty(department) ? "" : department;
            position = string.IsNullOrEmpty(position) ? "" : position;
            status = string.IsNullOrEmpty(status) ? "" : status;
            keyword = string.IsNullOrEmpty(keyword) ? "" : keyword;

            var listNV = nhanVienService.GetAllNhanVien().Where(x => (x.MaPb == department || department == "") &&
                                                                      (x.MaCv == position || position == "") &&
                                                                      (x.TrangThaiNhanSu == status || status == "") &&
                                                                      (x.MaNv.ToLower().Contains(keyword.ToLower()) || x.Ten.ToLower().Contains(keyword.ToLower()) || x.Gmail.ToLower().Contains(keyword.ToLower()) || keyword == "")).ToList();
                                                           
            return View(listNV);
        }

        public IActionResult Create()
        {
            ViewBag.PhongBan = new SelectList(phongBanService.GetAllPhongBan(), "MaPb", "TenPb");
            ViewBag.ChucVu = new SelectList(chucVuService.GetAllChucVu(), "MaCv", "TenCv");
            ViewBag.Title = "THÊM MỚI NHÂN VIÊN";
            return View();
        }
        public IActionResult Edit(string id)
        {
            ViewBag.Title = "CẬP NHẬT NHÂN VIÊN";
            NhanVien nhanVien = nhanVienService.GetAllNhanVien().FirstOrDefault(x => x.MaNv == id);
            if (nhanVien != null)
            {
                TaiKhoan taiKhoan = taiKhoanService.GetAllTaiKhoan().FirstOrDefault(x => x.MaTaiKhoan == nhanVien.MaTaiKhoan);

                ViewBag.TenTaiKhoan = taiKhoan == null ? "" : taiKhoan.TenTaiKhoan;
                ViewBag.MatKhau = taiKhoan == null ? "" : MaHoaMD5.DecryptPassword(taiKhoan.MatKhau);

                ViewBag.PhongBan = new SelectList(phongBanService.GetAllPhongBan(), "MaPb", "TenPb", nhanVien.MaPb);
                ViewBag.ChucVu = new SelectList(chucVuService.GetAllChucVu(), "MaCv", "TenCv", nhanVien.MaCv);
            }

            return View(nhanVien);
        }

        public IActionResult Delete(string id)
        {
            try
            {
                NhanVien nhanVien = nhanVienService.GetAllNhanVien().FirstOrDefault(x => x.MaNv == id);
                if (nhanVien != null)
                {
                    nhanVienService.DeleteNhanVien(id);
                }


                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(NhanVien employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var nhanvien = nhanVienService.GetAllNhanVien().Where(x => x.MaNv.ToLower() == employee.MaNv.ToLower()).ToList();
                    if (nhanvien.Count > 0)
                    {
                        ViewBag.Message = $"Mã nhân viên [{employee.MaNv}] đã tồn tại!";
                    }
                    else
                    {
                        employee.TrangThaiNhanSu = "1";
                        nhanVienService.InsertNhanVien(employee);

                        return RedirectToAction("Index");
                    }
                   
                }

                return View(employee);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Edit(NhanVien employee, bool isAccount, string? id, string? username, string? password)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TaiKhoan taiKhoan = new TaiKhoan();

                    if (isAccount) //Cho phép đăng nhập
                    {
                        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                        {
                            ViewBag.Message = "Vui lòng nhập đủ các thông tin!";
                        }
                        else
                        {
                            if (employee.MaTaiKhoan != id) //Kiểm tra mã tài khoản có phải của nhân viên ko
                            {
                                var accout = taiKhoanService.GetAllTaiKhoan().Where(x => x.MaTaiKhoan == id || x.TenTaiKhoan == username).FirstOrDefault();

                                if (accout != null)
                                {
                                    ViewBag.Message = "Tên tài khoản đã được sử dụng!";
                                }
                                else
                                {

                                    taiKhoan.MaTaiKhoan = id;
                                    taiKhoan.TenTaiKhoan = username;
                                    taiKhoan.MatKhau = MaHoaMD5.EncryptPassword(password);

                                    taiKhoanService.InsertTaiKhoan(taiKhoan);
                                }
                            }
                            else
                            {
                                taiKhoan = taiKhoanService.GetAllTaiKhoan().Where(x => x.MaTaiKhoan == id).FirstOrDefault();

                                //taiKhoan.MaTaiKhoan = id;
                                taiKhoan.TenTaiKhoan = username;
                                taiKhoan.MatKhau = MaHoaMD5.EncryptPassword(password);

                                taiKhoanService.UpdateTaiKhoan(taiKhoan);
                            }
                        }
                        
                    }

                    nhanVienService.UpdateNhanVien(employee);

                    return RedirectToAction("Index");
                }

                return View(employee);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
