using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Models;
using QlLopHocSinhVien.Service;

namespace QlLopHocSinhVien.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HocVienController : Controller
    {
        IHocVienService hocVienService { get; set; }
        ILopHocService lopHocService { get; set; }
        ITaiKhoanService taiKhoanService { get; set; }

        public HocVienController(IHocVienService hocVienService, ILopHocService lopHocService, ITaiKhoanService taiKhoanService)
        {
            this.hocVienService = hocVienService;
            this.lopHocService = lopHocService;
            this.taiKhoanService = taiKhoanService;
        }

        [HttpGet]
        public IActionResult Index(string keyword, string lophoc)
        {
            ViewBag.Title = "HỌC VIÊN";
            

            keyword = string.IsNullOrEmpty(keyword) ? "" : keyword.ToLower();
            lophoc = string.IsNullOrEmpty(lophoc) ? "" : lophoc;

            var list = hocVienService.GetAllHocVien().Where(x => (x.MaLh == lophoc || lophoc == "") &&
                                                                     (x.MaHv.ToLower().Contains(keyword) || 
                                                                      x.HoTen.ToLower().Contains(keyword) ||
                                                                      x.DiaChi.ToLower().Contains(keyword) || keyword == "")).ToList();

            ViewBag.LopHoc = new SelectList(lopHocService.GetAllLopHoc(), "MaLh", "TenLop", lophoc);
            ViewBag.Keywords = keyword;
            return View(list);
        }

        public IActionResult Create()
        {
            var count = hocVienService.GetAllHocVien().ToList().Count();

            ViewBag.Title = "THÊM MỚI HỌC VIÊN";
            ViewBag.Code = $"HV_{DateTime.Now.ToString("ddMMyy")}_{count + 1}";

            ViewBag.LopHoc = new SelectList(lopHocService.GetAllLopHoc(), "MaLh", "TenLop");

            return View();
        }

        public IActionResult Edit(string id)
        {
            ViewBag.Title = "CẬP NHẬT HỌC VIÊN";


            HocVien item = hocVienService.GetAllHocVien().FirstOrDefault(x => x.MaHv == id);

            if (item != null)
            {
                TaiKhoan taiKhoan = taiKhoanService.GetAllTaiKhoan().FirstOrDefault(x => x.MaTaiKhoan == item.MaTaiKhoan);

                ViewBag.TenTaiKhoan = taiKhoan == null ? "" : taiKhoan.TenTaiKhoan;
                ViewBag.MatKhau = taiKhoan == null ? "" : MaHoaMD5.DecryptPassword(taiKhoan.MatKhau);
            }

            ViewBag.LopHoc = new SelectList(lopHocService.GetAllLopHoc(), "MaLh", "TenLop", item.MaLh);

            return View(item);
        }

        public IActionResult Delete(string id)
        {
            try
            {
                HocVien item = hocVienService.GetAllHocVien().FirstOrDefault(x => x.MaHv == id);
                if (item != null)
                {
                    hocVienService.DeleteHocVien(id);
                }


                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(HocVien item, string? username, string? password)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var list = hocVienService.GetAllHocVien().Where(x => x.MaHv.ToLower() == item.MaHv.ToLower()).ToList();
                    if (list.Count > 0)
                    {
                        ViewBag.Message = $"Mã học viên [{item.MaHv}] đã tồn tại!";
                    }
                    else
                    {
                        TaiKhoan taiKhoan = new TaiKhoan();

                        if (!string.IsNullOrEmpty(item.MaTaiKhoan))
                        {
                            var accout = taiKhoanService.GetAllTaiKhoan().Where(x => x.MaTaiKhoan == item.MaTaiKhoan || x.TenTaiKhoan == username).FirstOrDefault();

                            if (accout != null)
                            {
                                ViewBag.Message = "Tên tài khoản đã được sử dụng!";
                            }
                            else
                            {
                                taiKhoan.MaTaiKhoan = item.MaTaiKhoan;
                                taiKhoan.TenTaiKhoan = username;
                                taiKhoan.MatKhau = MaHoaMD5.EncryptPassword(password);

                                taiKhoanService.InsertTaiKhoan(taiKhoan);

                            }
                        }
                            

                        item.MaTaiKhoan = taiKhoan.MaTaiKhoan;
                        hocVienService.InsertHocVien(item);

                        return RedirectToAction("Index");
                    }

                }

                return View(item);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Edit(HocVien item, string? username, string? password)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TaiKhoan taiKhoan = new TaiKhoan();

                    if (!string.IsNullOrEmpty(item.MaTaiKhoan))
                    {
                        var accout = taiKhoanService.GetAllTaiKhoan().Where(x => x.MaTaiKhoan == item.MaTaiKhoan).FirstOrDefault();

                        if (accout != null)
                        {
                            
                            var user = taiKhoanService.GetAllTaiKhoan().Where(x => x.TenTaiKhoan == username).FirstOrDefault();
                            if (user != null)
                            {
                                ViewBag.Message = "Tên tài khoản đã được sử dụng!";
                            }
                            else
                            {
                                taiKhoan.TenTaiKhoan = username;
                                taiKhoan.MatKhau = MaHoaMD5.EncryptPassword(password);

                                taiKhoanService.UpdateTaiKhoan(taiKhoan);
                            }
                        }
                        else
                        {
                            taiKhoan.MaTaiKhoan = item.MaTaiKhoan;
                            taiKhoan.TenTaiKhoan = username;
                            taiKhoan.MatKhau = MaHoaMD5.EncryptPassword(password);

                            taiKhoanService.InsertTaiKhoan(taiKhoan);

                        }
                    }

                    item.MaTaiKhoan = taiKhoan.MaTaiKhoan;
                    hocVienService.UpdateHocVien(item);

                    return RedirectToAction("Index");
                }

                return View(item);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
