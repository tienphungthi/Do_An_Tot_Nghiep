using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Models;
using QlLopHocSinhVien.Service;

namespace QlLopHocSinhVien.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KhoaHocController : Controller
    {
        IKhoaHocService khoaHocService { get; set; }

        public KhoaHocController(IKhoaHocService khoaHocService)
        {
            this.khoaHocService = khoaHocService;
        }

        [HttpGet]
        public IActionResult Index(string keyword)
        {
            ViewBag.Title = "KHÓA HỌC";
            keyword = string.IsNullOrEmpty(keyword) ? "" : keyword.ToLower();

            var list = khoaHocService.GetAllKhoaHoc().Where(x => x.MaKh.ToLower().Contains(keyword) ||
                                                            x.TieuDe.ToLower().Contains(keyword) ||
                                                            x.NoiDung.ToLower().Contains(keyword) || keyword == "").ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            var count = khoaHocService.GetAllKhoaHoc().ToList().Count();

            ViewBag.Title = "THÊM MỚI KHÓA HỌC";
            ViewBag.Code = $"KH_{DateTime.Now.ToString("ddMMyy")}_{count + 1}";
            return View();
        }

        public IActionResult Edit(string id)
        {
            KhoaHoc khoaHoc = khoaHocService.GetAllKhoaHoc().FirstOrDefault(x => x.MaKh == id);
            ViewBag.Title = "CẬP NHẬT KHÓA HỌC";
            return View(khoaHoc);
        }

        public IActionResult Delete(string id)
        {
            try
            {
                KhoaHoc khoaHoc = khoaHocService.GetAllKhoaHoc().FirstOrDefault(x => x.MaKh == id);
                if (khoaHoc != null)
                {
                    khoaHocService.DeleteKhoaHoc(id);
                }


                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(KhoaHoc khoaHoc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var coures = khoaHocService.GetAllKhoaHoc().Where(x => x.MaKh.ToLower() == khoaHoc.MaKh.ToLower()).ToList();
                    if (coures.Count > 0)
                    {
                        ViewBag.Message = $"Mã khóa học [{khoaHoc.MaKh}] đã tồn tại!";
                    }
                    else
                    {
                        khoaHocService.InsertKhoaHoc(khoaHoc);

                        return RedirectToAction("Index");
                    }

                }

                return View(khoaHoc);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Edit(KhoaHoc khoaHoc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    khoaHocService.UpdateKhoaHoc(khoaHoc);

                    return RedirectToAction("Index");
                }

                return View(khoaHoc);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
