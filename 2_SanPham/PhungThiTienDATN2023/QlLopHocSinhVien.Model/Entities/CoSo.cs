using System;
using System.Collections.Generic;

namespace QlLopHocSinhVien.Model.Entities;

public partial class CoSo
{
    public string MaCs { get; set; } = null!;

    public string? TenCs { get; set; }

    public string? DiaChi { get; set; }

    public virtual ICollection<LopHoc> LopHocs { get; set; } = new List<LopHoc>();
}
