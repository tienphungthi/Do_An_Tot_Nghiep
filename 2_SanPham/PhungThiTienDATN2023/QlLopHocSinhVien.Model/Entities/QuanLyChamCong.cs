using System;
using System.Collections.Generic;

namespace QlLopHocSinhVien.Model.Entities;

public partial class QuanLyChamCong
{
    public string MaQlcc { get; set; } = null!;

    public string? MaCv { get; set; }

    public string? MaLlv { get; set; }

    public virtual ChucVu? MaCvNavigation { get; set; }

    public virtual LichLamViec? MaLlvNavigation { get; set; }
}
