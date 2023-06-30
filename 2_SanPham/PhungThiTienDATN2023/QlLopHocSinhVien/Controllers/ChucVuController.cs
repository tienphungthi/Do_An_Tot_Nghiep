using Microsoft.AspNetCore.Mvc;
using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Service;

namespace QlLopHocSinhVien.Controllers
{
    public class ChucVuController : Controller
    {
        private readonly IChucVuService _ChucVuService;
        public ChucVuController(IChucVuService ChucVuService)
        {
            _ChucVuService = ChucVuService;
        }
        public IActionResult Index()
        {
            IEnumerable<ChucVu> result = _ChucVuService.GetAllChucVu();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ChucVu ChucVu)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ChucVuService.InsertChucVu(ChucVu);
                    return Redirect("/ChucVu/Index");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

            }
            return View(ChucVu);

        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            ChucVu ChucVu = _ChucVuService.GetChucVu(id);
            if (ChucVu != null)
            {
                return View(ChucVu);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(ChucVu ChucVu)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ChucVuService.UpdateChucVu(ChucVu);
                    return Redirect("/ChucVu/Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(ChucVu);
        }
        public IActionResult Delete(string id)
        {
            _ChucVuService.DeleteChucVu(id);
            return Redirect("/ChucVu/Index");
        }
    }
}
