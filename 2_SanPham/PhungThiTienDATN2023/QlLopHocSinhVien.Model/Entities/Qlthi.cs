using System;
using System.Collections.Generic;

namespace QlLopHocSinhVien.Model.Entities;

public partial class Qlthi
{
    public string Ma { get; set; } = null!;

    public DateTime ThoiGianBd { get; set; }

    public DateTime ThoiGianKt { get; set; }

    public string? MaPb { get; set; }

    public string? MaDt { get; set; }

    public string? MaNdt { get; set; }

    public virtual DotThi? MaDtNavigation { get; set; }

    public virtual NoiDungThi? MaNdtNavigation { get; set; }

    public virtual PhongBan? MaPbNavigation { get; set; }
}
