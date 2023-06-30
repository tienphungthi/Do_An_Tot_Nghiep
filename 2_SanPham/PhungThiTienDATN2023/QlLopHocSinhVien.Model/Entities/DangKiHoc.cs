using System;
using System.Collections.Generic;

namespace QlLopHocSinhVien.Model.Entities;

public partial class DangKiHoc
{
    public int Ma { get; set; }

    public string HoTen { get; set; } = null!;

    public string? Email { get; set; }

    public int? DienThoai { get; set; }

    public string? DiaChi { get; set; }

    public string? MaKh { get; set; }

    public string? TruongHoc { get; set; }

    public string? GhiChu { get; set; }

    public virtual KhoaHoc? MaKhNavigation { get; set; }
}
