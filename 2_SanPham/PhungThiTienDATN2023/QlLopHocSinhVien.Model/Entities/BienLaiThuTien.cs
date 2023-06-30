using System;
using System.Collections.Generic;

namespace QlLopHocSinhVien.Model.Entities;

public partial class BienLaiThuTien
{
    public string MaBl { get; set; } = null!;

    public DateTime NgayLap { get; set; }

    public int SoTien { get; set; }

    public string? NoiDung { get; set; }

    public string? MaHv { get; set; }

    public virtual HocVien? MaHvNavigation { get; set; }
}
