using System;
using System.Collections.Generic;

namespace QlLopHocSinhVien.Model.Entities;

public partial class NhanVien
{
    public string MaNv { get; set; } = null!;

    public string Ten { get; set; } = null!;

    public int? Sdt { get; set; }

    public string? Gmail { get; set; }

    public string? TrangThaiNhanSu { get; set; }

    public string? MaPb { get; set; }

    public string? MaCv { get; set; }

    public string? MaTaiKhoan { get; set; }

    public virtual ICollection<GiangVien> GiangViens { get; set; } = new List<GiangVien>();

    public virtual ICollection<LopHoc> LopHocs { get; set; } = new List<LopHoc>();

    public virtual ChucVu? MaCvNavigation { get; set; }

    public virtual PhongBan? MaPbNavigation { get; set; }

    public virtual TaiKhoan? MaTaiKhoanNavigation { get; set; }
}
