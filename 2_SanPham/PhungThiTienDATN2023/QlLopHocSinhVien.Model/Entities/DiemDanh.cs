using System;
using System.Collections.Generic;

namespace QlLopHocSinhVien.Model.Entities;

public partial class DiemDanh
{
    public string MaDd { get; set; } = null!;

    public string? MaHv { get; set; }

    public DateTime? ThoiGian { get; set; }

    public DateTime? ThoiGianVao { get; set; }

    public DateTime? ThoiGianRa { get; set; }

    public string? DiemDanh1 { get; set; }

    public string? MoTa { get; set; }

    public virtual HocVien? MaHvNavigation { get; set; }
}
