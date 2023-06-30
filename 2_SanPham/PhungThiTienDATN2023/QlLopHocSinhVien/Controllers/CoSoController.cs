using Microsoft.AspNetCore.Mvc;
using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Service;

namespace QlLopHocSinhVien.Controllers
{
    public class CoSoController : Controller
    {
        private readonly ICoSoService _CoSoService;
        public CoSoController(ICoSoService CoSoService)
        {
            _CoSoService = CoSoService;
        }
        public IActionResult Index()
        {
            IEnumerable<CoSo> result = _CoSoService.GetAllCoSo();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CoSo CoSo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _CoSoService.InsertCoSo(CoSo);
                    return Redirect("/CoSo/Index");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

            }
            return View(CoSo);

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            CoSo CoSo = _CoSoService.GetCoSo(id);
            if (CoSo != null)
            {
                return View(CoSo);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(CoSo CoSo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _CoSoService.UpdateCoSo(CoSo);
                    return Redirect("/CoSo/Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(CoSo);
        }
        public IActionResult Delete(int id)
        {
            _CoSoService.DeleteCoSo(id);
            return Redirect("/CoSo/Index");
        }


        [HttpGet]
        public IActionResult Search(string name)
        {

            IEnumerable<CoSo> result = _CoSoService.GetAllCoSo();
            if (!string.IsNullOrEmpty(name))
            {
                result = result.Where(x => x.DiaChi.Contains(name));

            }

            return View(result);
        }
    }
}
