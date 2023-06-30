using System;
using System.Collections.Generic;

namespace QlLopHocSinhVien.Model.Entities;

public partial class PhongBan
{
    public string MaPb { get; set; } = null!;

    public string TenPb { get; set; } = null!;

    public string? NoiDung { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();

    public virtual ICollection<Qlthi> Qlthis { get; set; } = new List<Qlthi>();
}
