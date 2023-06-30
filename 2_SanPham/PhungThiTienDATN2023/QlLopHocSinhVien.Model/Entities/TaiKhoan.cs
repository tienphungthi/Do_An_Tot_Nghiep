using System;
using System.Collections.Generic;

namespace QlLopHocSinhVien.Model.Entities;

public partial class TaiKhoan
{
    public string MaTaiKhoan { get; set; } = null!;

    public string TenTaiKhoan { get; set; } = null!;

    public string? MatKhau { get; set; }

    public virtual ICollection<HocVien> HocViens { get; set; } = new List<HocVien>();

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
