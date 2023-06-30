using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Service;

namespace QlLopHocSinhVien.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GiangVienController : Controller
    {
        IGiangVienService giangVienService { get; set; }
        INhanVienService nhanVienService { get; set; }
        ITrinhDoService trinhDoService { get; set; }

        public GiangVienController(IGiangVienService giangVienService, INhanVienService nhanVienService, ITrinhDoService trinhDoService)
        {
            this.giangVienService = giangVienService;
            this.nhanVienService = nhanVienService;
            this.trinhDoService = trinhDoService;
        }

        [HttpGet]
        public IActionResult Index(string keyword, string trinhdo)
        {
            ViewBag.Title = "GIẢNG VIÊN";
            ViewBag.TrinhDo = new SelectList(trinhDoService.GetAllTrinhDo(), "MaTrinhDo", "TenTrinhDo");

            keyword = string.IsNullOrEmpty(keyword) ? "" : keyword.ToLower();
            trinhdo = string.IsNullOrEmpty(trinhdo) ? "" : trinhdo;

            var list = giangVienService.GetAllGiangVien().Where(x=>(x.MaTrinhDo == trinhdo || trinhdo == "") &&
                                                                     (x.MaGv.ToLower().Contains(keyword) || keyword == "")).ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            var count = giangVienService.GetAllGiangVien().ToList().Count();

            ViewBag.Title = "THÊM MỚI GIẢNG VIÊN";
            ViewBag.Code = $"GV_{DateTime.Now.ToString("ddMMyy")}_{count + 1}";
            ViewBag.NhanVien = new SelectList(nhanVienService.GetAllNhanVien(), "MaNv", "Ten");
            ViewBag.TrinhDo = new SelectList(trinhDoService.GetAllTrinhDo(), "MaTrinhDo", "TenTrinhDo");
            return View();
        }

        public IActionResult Edit(string id)
        {
            ViewBag.Title = "CẬP NHẬT GIẢNG VIÊN";
            

            GiangVien item = giangVienService.GetAllGiangVien().FirstOrDefault(x => x.MaGv == id);

            ViewBag.NhanVien = new SelectList(nhanVienService.GetAllNhanVien(), "MaNv", "Ten", item.MaNv);
            ViewBag.TrinhDo = new SelectList(trinhDoService.GetAllTrinhDo(), "MaTrinhDo", "TenTrinhDo", item.MaTrinhDo);

            return View(item);
        }

        public IActionResult Delete(string id)
        {
            try
            {
                GiangVien item = giangVienService.GetAllGiangVien().FirstOrDefault(x => x.MaGv == id);
                if (item != null)
                {
                    giangVienService.DeleteGiangVien(id);
                }


                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(GiangVien item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var list = giangVienService.GetAllGiangVien().Where(x => x.MaGv.ToLower() == item.MaGv.ToLower()).ToList();
                    if (list.Count > 0)
                    {
                        ViewBag.Message = $"Mã giảng viên [{item.MaGv}] đã tồn tại!";
                    }
                    else
                    {
                        giangVienService.InsertGiangVien(item);

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
        public IActionResult Edit(GiangVien item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    giangVienService.UpdateGiangVien(item);

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
