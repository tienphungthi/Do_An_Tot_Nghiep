using Microsoft.AspNetCore.Mvc;
using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Service;

namespace QlLopHocSinhVien.Controllers
{
    public class LopHocController : Controller
    {
        private readonly ILopHocService _LopHocService;

        public LopHocController(ILopHocService LopHocService)
        {
            _LopHocService = LopHocService;
        }




        public IActionResult Index()
        {
            IEnumerable<LopHoc> result = _LopHocService.GetAllLopHoc();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(LopHoc LopHoc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _LopHocService.InsertLopHoc(LopHoc);
                    return Redirect("/LopHoc/Index");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

            }
            return View(LopHoc);

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            LopHoc LopHoc = _LopHocService.GetLopHoc(id);
            if (LopHoc != null)
            {
                return View(LopHoc);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(LopHoc LopHoc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _LopHocService.UpdateLopHoc(LopHoc);
                    return Redirect("/LopHoc/Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(LopHoc);
        }
        public IActionResult Delete(int id)
        {
            _LopHocService.DeleteLopHoc(id);
            return Redirect("/LopHoc/Index");
        }


        //[HttpGet]
        //public IActionResult Search(string name)
        //{

        //    IEnumerable<LopHoc> result = _LopHocService.GetAllLopHoc();
        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        result = result.Where(x => x.TieuDe.Contains(name));

        //    }

        //    return View(result);
        //}
    }
}
