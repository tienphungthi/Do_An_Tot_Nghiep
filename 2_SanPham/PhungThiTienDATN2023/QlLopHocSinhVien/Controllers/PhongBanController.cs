using Microsoft.AspNetCore.Mvc;
using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Service;

namespace QlLopHocSinhVien.Controllers
{
    public class PhongBanController : Controller
    {
        private readonly IPhongBanService _PhongBanService;
        public PhongBanController(IPhongBanService PhongBanService)
        {
            _PhongBanService = PhongBanService;
        }
        public IActionResult Index()
        {
            IEnumerable<PhongBan> result = _PhongBanService.GetAllPhongBan();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PhongBan PhongBan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _PhongBanService.InsertPhongBan(PhongBan);
                    return Redirect("/PhongBan/Index");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

            }
            return View(PhongBan);

        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            PhongBan PhongBan = _PhongBanService.GetPhongBan(id);
            if (PhongBan != null)
            {
                return View(PhongBan);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(PhongBan PhongBan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _PhongBanService.UpdatePhongBan(PhongBan);
                    return Redirect("/PhongBan/Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(PhongBan);
        }
        public IActionResult Delete(string id)
        {
            _PhongBanService.DeletePhongBan(id);
            return Redirect("/PhongBan/Index");
        }
    }
}
