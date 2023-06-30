using Microsoft.AspNetCore.Mvc;
using QlLopHocSinhVien.Model.Entities;
using QlLopHocSinhVien.Service;

namespace QlLopHocSinhVien.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class PhongBanController : Controller
    {
        private readonly IPhongBanService phongBanService;
        private readonly INhanVienService nhanVienService;
        private readonly IQLThiService examService;

        public PhongBanController(IPhongBanService phongBanService, INhanVienService nhanVienService, IQLThiService examService)
        {
            this.phongBanService = phongBanService;
            this.nhanVienService = nhanVienService;
            this.examService = examService;
        }

        [HttpGet]
        public IActionResult Index(string keyword)
        {
            ViewBag.Title = "PHÒNG BAN";
            keyword = string.IsNullOrEmpty(keyword) ? "" : keyword;
            IEnumerable<PhongBan> result = phongBanService.GetAllPhongBan().Where(x => x.MaPb.ToLower().Contains(keyword.ToLower()) ||
                                                                                    x.TenPb.ToLower().Contains(keyword.ToLower()) || keyword == "");
            return View(result);
        }
        
        public IActionResult Create()
        {
            ViewBag.Title = "THÊM MỚI PHÒNG BAN";
            return View();
        }

        [HttpPost]
        public IActionResult Create(PhongBan pb)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var department = phongBanService.GetAllPhongBan().Where(x => x.MaPb.ToLower() == pb.MaPb.ToLower()).ToList();
                    if (department.Count > 0)
                    {
                        ViewBag.Message = $"Mã phòng ban [{pb.MaPb}] đã tồn tại!";
                    }
                    else
                    {
                        phongBanService.InsertPhongBan(pb);
                        return RedirectToAction("Index");
                    }
                    
                }

                return View(pb);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            PhongBan PhongBan = phongBanService.GetPhongBan(id);
            ViewBag.Title = "CẬP NHẬT PHÒNG BAN";
            return View(PhongBan);
        }

        [HttpPost]
        public IActionResult Edit(PhongBan PhongBan)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    phongBanService.UpdatePhongBan(PhongBan);
                    return RedirectToAction("Index");
                }

                return View(PhongBan);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //ModelState.AddModelError(string.Empty, ex.Message);
            }
            
        }

        public IActionResult Delete(string id)
        {
            try
            {
                var deparment = phongBanService.GetAllPhongBan().FirstOrDefault(x => x.MaPb == id);

                if (deparment != null)
                {
                    var employeeList = nhanVienService.GetAllNhanVien().Where(x => x.MaPb == deparment.MaPb).ToList();
                    var examList = examService.GetAllQLThi().Where(x=>x.MaPb == deparment.MaPb).ToList();

                    if (employeeList.Count > 0 || examList.Count > 0)
                    {
                        ViewBag.Message = $"Phòng ban [{id}] đang được sử dụng!";
                    }
                    else
                    {
                        phongBanService.DeletePhongBan(id);
                    }
                }

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
