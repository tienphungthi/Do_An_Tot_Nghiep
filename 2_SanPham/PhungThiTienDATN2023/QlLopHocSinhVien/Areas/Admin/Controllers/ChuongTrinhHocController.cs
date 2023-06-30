using Microsoft.AspNetCore.Mvc;
using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Service;

namespace QlLopHocSinhVien.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChuongTrinhHocController : Controller
    {
        IChuongTrinhHocService chuongTrinhHocService { get; set; }
        public ChuongTrinhHocController(IChuongTrinhHocService chuongTrinhHocService)
        {
            this.chuongTrinhHocService = chuongTrinhHocService;
        }

        [HttpGet]
        public IActionResult Index(string keyword, string status)
        {
            ViewBag.Title = "CHƯƠNG TRÌNH HỌC";
            keyword = string.IsNullOrEmpty(keyword) ? "" : keyword.ToLower();
            status = string.IsNullOrEmpty(status) ? "" : status.ToLower();

            var list = chuongTrinhHocService.GetAllChuongTrinhHoc().Where(x => (x.TrangThai == status || status == "") && 
                                                        (x.MaCth.ToLower().Contains(keyword) ||
                                                        x.TieuDe.ToLower().Contains(keyword) ||
                                                        x.NoiDung.ToLower().Contains(keyword) || keyword == "")).ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            var count = chuongTrinhHocService.GetAllChuongTrinhHoc().ToList().Count();

            ViewBag.Title = "THÊM MỚI CHƯƠNG TRÌNH HỌC";
            ViewBag.Code = $"CTH_{DateTime.Now.ToString("ddMMyy")}_{count + 1}";
            return View();
        }

        public IActionResult Edit(string id)
        {
            ViewBag.Title = "CẬP NHẬT CHƯƠNG TRÌNH HỌC";
            ChuongTrinhHoc item = chuongTrinhHocService.GetAllChuongTrinhHoc().FirstOrDefault(x => x.MaCth == id);
            return View(item);
        }

        public IActionResult Delete(string id)
        {
            try
            {
                ChuongTrinhHoc item = chuongTrinhHocService.GetAllChuongTrinhHoc().FirstOrDefault(x => x.MaCth == id);
                if (item != null)
                {
                    chuongTrinhHocService.DeleteChuongTrinhHoc(id);
                }


                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(ChuongTrinhHoc item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var list = chuongTrinhHocService.GetAllChuongTrinhHoc().Where(x => x.MaCth.ToLower() == item.MaCth.ToLower()).ToList();
                    if (list.Count > 0)
                    {
                        ViewBag.Message = $"Mã cơ sở [{item.MaCth}] đã tồn tại!";
                    }
                    else
                    {
                        chuongTrinhHocService.InsertChuongTrinhHoc(item);

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
        public IActionResult Edit(ChuongTrinhHoc item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    chuongTrinhHocService.UpdateChuongTrinhHoc(item);

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
