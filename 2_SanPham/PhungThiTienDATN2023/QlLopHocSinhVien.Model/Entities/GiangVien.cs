using System;
using System.Collections.Generic;

namespace QlLopHocSinhVien.Model.Entities;

public partial class GiangVien
{
    public string MaGv { get; set; } = null!;

    public string? MaNv { get; set; }

    public string? MaTrinhDo { get; set; }

    public virtual NhanVien? MaNvNavigation { get; set; }

    public virtual TrinhDo? MaTrinhDoNavigation { get; set; }
}
