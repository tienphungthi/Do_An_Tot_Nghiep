using Microsoft.AspNetCore.Mvc;
using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Service;

namespace QlLopHocSinhVien.Controllers
{
    public class ChuongTrinhHocController : Controller
    {
        private readonly IChuongTrinhHocService _ChuongTrinhHocService;
        public ChuongTrinhHocController(IChuongTrinhHocService ChuongTrinhHocService)
        {
            _ChuongTrinhHocService = ChuongTrinhHocService;
        }
        public IActionResult Index()
        {
            IEnumerable<ChuongTrinhHoc> result = _ChuongTrinhHocService.GetAllChuongTrinhHoc();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ChuongTrinhHoc ChuongTrinhHoc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ChuongTrinhHocService.InsertChuongTrinhHoc(ChuongTrinhHoc);
                    return Redirect("/ChuongTrinhHoc/Index");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

            }
            return View(ChuongTrinhHoc);

        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            ChuongTrinhHoc ChuongTrinhHoc = _ChuongTrinhHocService.GetChuongTrinhHoc(id);
            if (ChuongTrinhHoc != null)
            {
                return View(ChuongTrinhHoc);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(ChuongTrinhHoc ChuongTrinhHoc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ChuongTrinhHocService.UpdateChuongTrinhHoc(ChuongTrinhHoc);
                    return Redirect("/ChuongTrinhHoc/Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(ChuongTrinhHoc);
        }
        public IActionResult Delete(string id)
        {
            _ChuongTrinhHocService.DeleteChuongTrinhHoc(id);
            return Redirect("/ChuongTrinhHoc/Index");
        }


        [HttpGet]
        public IActionResult Search(string name, int? to, int? from)
        {
            
            IEnumerable<ChuongTrinhHoc> result = _ChuongTrinhHocService.GetAllChuongTrinhHoc();
            if (!string.IsNullOrEmpty(name))
            {
                if (to!=null && from !=null)
                {
                    result = result.Where(x => x.TieuDe.Contains(name) && x.TongSoBuoi>=to && x.TongSoBuoi<=from);
                }
                else
                {
                    result = result.Where(x => x.TieuDe.Contains(name));
                }
                
            }
            else
            {
                result = result.Where(x => x.TieuDe.Contains(name) && x.TongSoBuoi >= to && x.TongSoBuoi <= from);
            }
            return View(result);
        }
    }
}
