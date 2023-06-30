using Microsoft.AspNetCore.Mvc;
using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Service;
using System.Linq;

namespace QlLopHocSinhVien.Controllers
{
    public class KhoaHocController : Controller
    {
        private readonly IKhoaHocService _KhoaHocService;
        private readonly IDangKiHocService dangkyhocService;

        public KhoaHocController(IKhoaHocService KhoaHocService, IDangKiHocService dangkyhocService)
        {
            _KhoaHocService = KhoaHocService;
            this.dangkyhocService = dangkyhocService;   
        }
        public IActionResult Index()
        {
            var list = _KhoaHocService.GetAllKhoaHoc().Take(12).ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Detail(string id)
        {
            KhoaHoc khoaHoc = _KhoaHocService.GetKhoaHoc(id);
            var list = _KhoaHocService.GetAllKhoaHoc().Take(4).ToList();

            var tuple = new Tuple<KhoaHoc,List<KhoaHoc>>(khoaHoc, list);
            return View(tuple);
        }

        [HttpPost]
        public JsonResult RegisterCourses([FromBody] DangKiHoc dangKi)
        {
            DangKiHoc register = dangkyhocService.GetAllDangKiHoc().OrderByDescending(x=>x.Ma).FirstOrDefault();

            dangKi.Ma = register == null ? 1 : register.Ma + 1;
            dangkyhocService.InsertDangKiHoc(dangKi);
            return Json(1, new System.Text.Json.JsonSerializerOptions());
        }
    }
}
