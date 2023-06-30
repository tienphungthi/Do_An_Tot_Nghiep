using Microsoft.AspNetCore.Mvc;
using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Service;

namespace QlLopHocSinhVien.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DangKiHocController : Controller
    {
        
        IDangKiHocService DangKiHocService { get; set; }

        //public DangKiHocController(IDangKiHocService DangKiHocService)
        //{
        //    this.DangKiHocService = DangKiHocService;
        //}
        private readonly IDangKiHocService _DangKiHocService;
        public DangKiHocController(IDangKiHocService DangKiHocService)
        {
            _DangKiHocService = DangKiHocService;
        }
        [HttpGet]
        public IActionResult Index()
        {

            IEnumerable<DangKiHoc> result = _DangKiHocService.GetAllDangKiHoc();
            return View(result);
        }
        
        public IActionResult Create()
        {
            var count = DangKiHocService.GetAllDangKiHoc().ToList().Count();

            ViewBag.Title = "THÊM MỚI CƠ SỞ";
            ViewBag.Code = $"CS_{DateTime.Now.ToString("ddMMyy")}_{count + 1}";
            return View();
        }

        public IActionResult Edit(string id)
        {
            //ViewBag.Title = "CẬP NHẬT CƠ SỞ";
            //DangKiHoc item = DangKiHocService.GetAllDangKiHoc().FirstOrDefault(x => x.MaCs == id);
            return View();
        }

        public IActionResult Delete(string id)
        {
            //try
            //{
            //    DangKiHoc item = DangKiHocService.GetAllDangKiHoc().FirstOrDefault(x => x.MaCs == id);
            //    if (item != null)
            //    {
            //        DangKiHocService.DeleteDangKiHoc(id);
            //    }


                return RedirectToAction("Index");
            //}
            //catch (Exception ex)
            //{

            //    throw new Exception(ex.Message);
            //}
        }

        [HttpPost]
        public IActionResult Create(DangKiHoc item)
        {
            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        var list = DangKiHocService.GetAllDangKiHoc().Where(x => x.MaCs.ToLower() == item.MaCs.ToLower()).ToList();
            //        if (list.Count > 0)
            //        {
            //            ViewBag.Message = $"Mã cơ sở [{item.MaCs}] đã tồn tại!";
            //        }
            //        else
            //        {
            //            DangKiHocService.InsertDangKiHoc(item);

                        return RedirectToAction("Index");
            //        }

            //    }

            //    return View(item);
            //}
            //catch (Exception ex)
            //{

            //    throw new Exception(ex.Message);
            //}
        }

        [HttpPost]
        public IActionResult Edit(DangKiHoc item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DangKiHocService.UpdateDangKiHoc(item);

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
