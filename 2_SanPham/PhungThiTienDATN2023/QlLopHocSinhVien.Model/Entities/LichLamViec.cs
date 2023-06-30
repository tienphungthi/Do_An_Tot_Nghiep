using System;
using System.Collections.Generic;

namespace QlLopHocSinhVien.Model.Entities;

public partial class LichLamViec
{
    public string MaLlv { get; set; } = null!;

    public int? Tuan { get; set; }

    public int? Ngay { get; set; }

    public DateTime? ThoiGianVao { get; set; }

    public DateTime? ThoiGianRa { get; set; }

    public DateTime ThoiGian { get; set; }

    public virtual ICollection<QuanLyChamCong> QuanLyChamCongs { get; set; } = new List<QuanLyChamCong>();
}
