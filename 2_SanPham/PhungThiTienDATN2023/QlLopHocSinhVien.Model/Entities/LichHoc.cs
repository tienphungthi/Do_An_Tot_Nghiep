using System;
using System.Collections.Generic;

namespace QlLopHocSinhVien.Model.Entities;

public partial class LichHoc
{
    public string MaLichHoc { get; set; } = null!;

    public string? SoGioDay { get; set; }

    public string? MonHoc { get; set; }

    public string? MaLh { get; set; }

    public DateTime? ThoiGianVao { get; set; }

    public DateTime? ThoiGianRa { get; set; }

    public int? Tuan { get; set; }

    public virtual LopHoc? MaLhNavigation { get; set; }
}
