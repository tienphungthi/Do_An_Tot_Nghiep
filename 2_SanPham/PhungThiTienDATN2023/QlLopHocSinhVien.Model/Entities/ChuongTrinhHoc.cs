using System;
using System.Collections.Generic;

namespace QlLopHocSinhVien.Model.Entities;

public partial class ChuongTrinhHoc
{
    public string MaCth { get; set; } = null!;

    public string TieuDe { get; set; } = null!;

    public string NoiDung { get; set; } = null!;

    public string? TrangThai { get; set; }

    public int? TongSoBuoi { get; set; }

    public virtual ICollection<LopHoc> LopHocs { get; set; } = new List<LopHoc>();
}
