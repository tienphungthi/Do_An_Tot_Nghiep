using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Service;

namespace QlLopHocSinhVien.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DiemDanhController : Controller
    {
        ILopHocService lopHocService { get; set; }
        IHocVienService hocVienService { get; set; }
        IDiemDanhService diemDanhService { get; set; }

        GreenEduContext context { get; set; }

        public DiemDanhController(ILopHocService lopHocService, IHocVienService hocVienService, IDiemDanhService diemDanhService, GreenEduContext context)
        {
            this.lopHocService = lopHocService;
            this.hocVienService = hocVienService;
            this.diemDanhService = diemDanhService;
            this.context = context;   
        }

        public IActionResult Index()
        {
            ViewBag.LopHoc = new SelectList(lopHocService.GetAllLopHoc(), "MaLh", "TenLop");
            return View();
        }

        [HttpGet]
        public JsonResult GetAll(DateTime date, string malop)
        {
            var listStudents = hocVienService.GetAllHocVien().Where(x=>x.MaLh == malop).ToList();
            var listCheckInOut = diemDanhService.GetAllDiemDanh().Where(x=>x.ThoiGian == date).ToList();

            var list = (from s in listStudents
                        join c in listCheckInOut on s.MaHv equals c.MaHv into temp
                        from t in temp.DefaultIfEmpty()
                        select new
                        {
                            MaDd = t == null ? "":t.MaDd,
                            s.MaHv,
                            s.HoTen,
                            ThoiGianVao = t == null ? "" : (!t.ThoiGianVao.HasValue ? "": t.ThoiGianVao.Value.ToString("dd/MM/yyyy HH:mm")),
                            ThoiGianRa = t == null ? "" : (!t.ThoiGianRa.HasValue ? "" : t.ThoiGianRa.Value.ToString("dd/MM/yyyy HH:mm")),
                            MoTa = t == null ? "":t.MoTa
                        }).ToList();

            return Json(list, new System.Text.Json.JsonSerializerOptions());
        }

        [HttpPost]
        public JsonResult Create([FromBody] DiemDanh diemDanh)
        {
            try
            {
                DiemDanh check = diemDanhService.GetAllDiemDanh().FirstOrDefault(x => x.MaDd == diemDanh.MaDd);
                
                if (check == null)
                {
                    diemDanh.MaDd = $"DD_{DateTime.Now.ToString("ddMMyyy")}_{diemDanh.MaHv}";
                    
                    diemDanhService.InsertDiemDanh(diemDanh);

                    return Json(diemDanh.MaDd, new System.Text.Json.JsonSerializerOptions());
                }
                else
                {
                    
                    check.ThoiGianVao = diemDanh.ThoiGianVao;
                    check.ThoiGianRa = diemDanh.ThoiGianRa;
                    check.MoTa = diemDanh.MoTa;

                    diemDanhService.UpdateDiemDanh(check);

                    return Json(check.MaDd, new System.Text.Json.JsonSerializerOptions());
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public JsonResult Delete(string id)
        {
            try
            {
                DiemDanh diemDanh = diemDanhService.GetAllDiemDanh().FirstOrDefault(x => x.MaDd == id);
                if (diemDanh != null)
                {
                    diemDanhService.DeleteDiemDanh(id);
                    return Json(1, new System.Text.Json.JsonSerializerOptions());
                }

                return Json(0, new System.Text.Json.JsonSerializerOptions());
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
