using System;
using System.Collections.Generic;

namespace QlLopHocSinhVien.Model.Entities;

public partial class ChucVu
{
    public string MaCv { get; set; } = null!;

    public string? TenCv { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();

    public virtual ICollection<QuanLyChamCong> QuanLyChamCongs { get; set; } = new List<QuanLyChamCong>();
}
