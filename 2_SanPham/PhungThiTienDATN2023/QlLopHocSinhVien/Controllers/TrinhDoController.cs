using Microsoft.AspNetCore.Mvc;
using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Service;

namespace QlLopHocSinhVien.Controllers
{
    public class TrinhDoController : Controller
    {
        private readonly ITrinhDoService _TrinhDoService;
        public TrinhDoController(ITrinhDoService TrinhDoService)
        {
            _TrinhDoService = TrinhDoService;
        }
        public IActionResult Index()
        {
            IEnumerable<TrinhDo> result = _TrinhDoService.GetAllTrinhDo();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TrinhDo TrinhDo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _TrinhDoService.InsertTrinhDo(TrinhDo);
                    return Redirect("/TrinhDo/Index");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

            }
            return View(TrinhDo);

        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            TrinhDo TrinhDo = _TrinhDoService.GetTrinhDo(id);
            if (TrinhDo != null)
            {
                return View(TrinhDo);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(TrinhDo TrinhDo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _TrinhDoService.UpdateTrinhDo(TrinhDo);
                    return Redirect("/TrinhDo/Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(TrinhDo);
        }
        public IActionResult Delete(string id)
        {
            _TrinhDoService.DeleteTrinhDo(id);
            return Redirect("/TrinhDo/Index");
        }
    }
}
