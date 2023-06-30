using System;
using System.Collections.Generic;

namespace QlLopHocSinhVien.Model.Entities;

public partial class DotThi
{
    public string MaDt { get; set; } = null!;

    public string NoiDung { get; set; } = null!;

    public virtual ICollection<Qlthi> Qlthis { get; set; } = new List<Qlthi>();
}
