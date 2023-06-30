using System;
using System.Collections.Generic;

namespace QlLopHocSinhVien.Model.Entities;

public partial class KhoaHoc
{
    public string MaKh { get; set; } = null!;

    public byte[]? Anh { get; set; }

    public string TieuDe { get; set; } = null!;

    public string NoiDung { get; set; } = null!;

    public virtual ICollection<DangKiHoc> DangKiHocs { get; set; } = new List<DangKiHoc>();

    public virtual ICollection<LopHoc> LopHocs { get; set; } = new List<LopHoc>();
}
