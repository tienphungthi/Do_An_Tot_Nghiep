using Microsoft.AspNetCore.Mvc;
using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Service;

namespace QlLopHocSinhVien.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoSoController : Controller
    {
        ICoSoService coSoService { get; set; }

        public CoSoController(ICoSoService coSoService)
        {
            this.coSoService = coSoService;
        }

        [HttpGet]
        public IActionResult Index(string keyword)
        {
            ViewBag.Title = "CƠ SỞ";
            keyword = string.IsNullOrEmpty(keyword) ? "" : keyword.ToLower();
            var list = coSoService.GetAllCoSo().Where(x => x.MaCs.ToLower().Contains(keyword) || 
                                                        x.TenCs.ToLower().Contains(keyword) || 
                                                        x.DiaChi.ToLower().Contains(keyword) || keyword == "").ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            var count = coSoService.GetAllCoSo().ToList().Count();

            ViewBag.Title = "THÊM MỚI CƠ SỞ";
            ViewBag.Code = $"CS_{DateTime.Now.ToString("ddMMyy")}_{count + 1}";
            return View();
        }

        public IActionResult Edit(string id)
        {
            ViewBag.Title = "CẬP NHẬT CƠ SỞ";
            CoSo item = coSoService.GetAllCoSo().FirstOrDefault(x => x.MaCs == id);
            return View(item);
        }

        public IActionResult Delete(string id)
        {
            try
            {
                CoSo item = coSoService.GetAllCoSo().FirstOrDefault(x => x.MaCs == id);
                if (item != null)
                {
                    coSoService.DeleteCoSo(id);
                }


                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Create(CoSo item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var list = coSoService.GetAllCoSo().Where(x => x.MaCs.ToLower() == item.MaCs.ToLower()).ToList();
                    if (list.Count > 0)
                    {
                        ViewBag.Message = $"Mã cơ sở [{item.MaCs}] đã tồn tại!";
                    }
                    else
                    {
                        coSoService.InsertCoSo(item);

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
        public IActionResult Edit(CoSo item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    coSoService.UpdateCoSo(item);

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
