using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Service;

namespace QlLopHocSinhVien.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LopHocController : Controller
    {
        ILopHocService lopHocService { get; set; }
        IChuongTrinhHocService chuongTrinhHocService { get; set; }
        ICoSoService cosoService { get; set; }
        IKhoaHocService khoahocService { get; set; }
        INhanVienService nhanvienService { get; set; }

        public LopHocController(ILopHocService lopHocService, IChuongTrinhHocService chuongTrinhHocService, ICoSoService cosoService, IKhoaHocService khoahocService, INhanVienService nhanvienService)
        {
            this.lopHocService = lopHocService;
            this.chuongTrinhHocService = chuongTrinhHocService;
            this.cosoService = cosoService;
            this.khoahocService = khoahocService;
            this.nhanvienService = nhanvienService;
        }

        [HttpGet]
        public IActionResult Index(DateTime ds, DateTime de, string macoso, string manv, string makhoahoc,string machuongtringhoc,string keyword)
        {
            ViewBag.CoSo = new SelectList(cosoService.GetAllCoSo(), "MaCs", "TenCs");
            ViewBag.KhoaHoc = new SelectList(khoahocService.GetAllKhoaHoc(), "MaKh", "TieuDe");
            ViewBag.ChuongTrinhHoc = new SelectList(chuongTrinhHocService.GetAllChuongTrinhHoc(), "MaCth", "TieuDe");
            ViewBag.NhanVien = new SelectList(nhanvienService.GetAllNhanVien(), "MaNv", "Ten");

            ViewBag.DateStart = new DateTime(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month, 1).ToString("yyyy-MM-dd");
            ViewBag.DateEnd = DateTime.Now.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");

            macoso = string.IsNullOrEmpty(macoso) ? "" : macoso;
            manv = string.IsNullOrEmpty(manv) ? "" : manv;
            makhoahoc = string.IsNullOrEmpty(makhoahoc) ? "" : makhoahoc;
            machuongtringhoc = string.IsNullOrEmpty(machuongtringhoc) ? "" : machuongtringhoc;
            keyword = string.IsNullOrEmpty(keyword) ? "" : keyword.ToLower();
            keyword = string.IsNullOrEmpty(keyword) ? "" : keyword.ToLower();

            var list = lopHocService.GetAllLopHoc().Where(x=> (x.MaCs == macoso || macoso == "") &&
                                                                (x.MaNv == manv || manv == "") &&
                                                                (x.MaKh == makhoahoc || makhoahoc == "") &&
                                                                (x.MaChuongTrinhHoc == machuongtringhoc || machuongtringhoc == "") &&
                                                                (x.MaLh.ToLower().Contains(keyword) || x.TenLop.ToLower().Contains(keyword)))
                                                   .ToList();                     
            return View(list);
        }

        public IActionResult Create()
        {
            var count = lopHocService.GetAllLopHoc().ToList().Count();

            ViewBag.Title = "THÊM MỚI LỚP HỌC";
            ViewBag.Code = $"LH_{DateTime.Now.ToString("ddMMyy")}_{count + 1}";

            ViewBag.CoSo = new SelectList(cosoService.GetAllCoSo(), "MaCs", "TenCs");
            ViewBag.KhoaHoc = new SelectList(khoahocService.GetAllKhoaHoc(), "MaKh", "TieuDe");
            ViewBag.ChuongTrinhHoc = new SelectList(chuongTrinhHocService.GetAllChuongTrinhHoc(), "MaCth", "TieuDe");
            ViewBag.NhanVien = new SelectList(nhanvienService.GetAllNhanVien(), "MaNv", "Ten");

            return View();
        }

        public IActionResult Edit(string id)
        {
            ViewBag.Title = "CẬP NHẬT LỚP HỌC";
            LopHoc item = lopHocService.GetAllLopHoc().FirstOrDefault(x => x.MaLh == id);
            if (item != null)
            {
                ViewBag.CoSo = new SelectList(cosoService.GetAllCoSo(), "MaCs", "TenCs", item.MaCs);
                ViewBag.KhoaHoc = new SelectList(khoahocService.GetAllKhoaHoc(), "MaKh", "TieuDe", item.MaKh);
                ViewBag.ChuongTrinhHoc = new SelectList(chuongTrinhHocService.GetAllChuongTrinhHoc(), "MaCth", "TieuDe", item.MaChuongTrinhHoc);
                ViewBag.NhanVien = new SelectList(nhanvienService.GetAllNhanVien(), "MaNv", "Ten", item.MaNv);
            }

            return View(item);
        }

        public IActionResult Delete(string id)
        {
            try
            {
                LopHoc item = lopHocService.GetAllLopHoc().FirstOrDefault(x => x.MaLh == id);
                if (item != null)
                {
                    lopHocService.DeleteLopHoc(id);
                }


                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(LopHoc item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var list = lopHocService.GetAllLopHoc().Where(x => x.MaLh.ToLower() == item.MaLh.ToLower()).ToList();
                    if (list.Count > 0)
                    {
                        ViewBag.Message = $"Mã lớp học [{item.MaLh}] đã tồn tại!";
                    }
                    else
                    {
                        lopHocService.InsertLopHoc(item);

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
        public IActionResult Edit(LopHoc item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    lopHocService.UpdateLopHoc(item);

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
