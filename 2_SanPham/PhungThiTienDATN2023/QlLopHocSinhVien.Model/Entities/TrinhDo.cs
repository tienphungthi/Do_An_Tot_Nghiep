using System;
using System.Collections.Generic;

namespace QlLopHocSinhVien.Model.Entities;

public partial class TrinhDo
{
    public string MaTrinhDo { get; set; } = null!;

    public string? TenTrinhDo { get; set; }

    public string? ThuTu { get; set; }

    public virtual ICollection<GiangVien> GiangViens { get; set; } = new List<GiangVien>();
}
