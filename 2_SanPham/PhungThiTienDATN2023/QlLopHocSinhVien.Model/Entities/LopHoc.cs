using System;
using System.Collections.Generic;

namespace QlLopHocSinhVien.Model.Entities;

public partial class LopHoc
{
    public string MaLh { get; set; } = null!;

    public string TenLop { get; set; } = null!;

    public int? SiSo { get; set; }

    public string? MaNv { get; set; }

    public string? TinhTrang { get; set; }

    public DateTime? NgayBatDau { get; set; }

    public DateTime? NgayKetThuc { get; set; }

    public string? MaChuongTrinhHoc { get; set; }

    public string? DoanhThuDuKien { get; set; }

    public string? SoTienDuThu { get; set; }

    public string? SoTienDaThu { get; set; }

    public string? MaKh { get; set; }

    public string? MaCs { get; set; }

    public virtual ICollection<HocVien> HocViens { get; set; } = new List<HocVien>();

    public virtual ICollection<LichHoc> LichHocs { get; set; } = new List<LichHoc>();

    public virtual ChuongTrinhHoc? MaChuongTrinhHocNavigation { get; set; }

    public virtual CoSo? MaCsNavigation { get; set; }

    public virtual KhoaHoc? MaKhNavigation { get; set; }

    public virtual NhanVien? MaNvNavigation { get; set; }
}
