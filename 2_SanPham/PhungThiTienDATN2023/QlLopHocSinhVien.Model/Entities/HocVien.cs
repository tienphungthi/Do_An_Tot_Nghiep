using System;
using System.Collections.Generic;

namespace QlLopHocSinhVien.Model.Entities;

public partial class HocVien
{
    public string MaHv { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public byte[]? Anh { get; set; }

    public int? Sdt { get; set; }

    public string? Gmail { get; set; }

    public string? HoatDong { get; set; }

    public string? MaTaiKhoan { get; set; }

    public string? GioiTinh { get; set; }

    public DateTime? NgaySinh { get; set; }

    public string? TruongHoc { get; set; }

    public string? TrinhDoChuyenMon { get; set; }

    public string? DiaChi { get; set; }

    public string? ThanhPho { get; set; }

    public string? Quan { get; set; }

    public string? Facebook { get; set; }

    public DateTime? NgayThamGia { get; set; }

    public string? NgheNghiep { get; set; }

    public string? MaLh { get; set; }

    public virtual ICollection<BienLaiThuTien> BienLaiThuTiens { get; set; } = new List<BienLaiThuTien>();

    public virtual ICollection<DiemDanh> DiemDanhs { get; set; } = new List<DiemDanh>();

    public virtual LopHoc? MaLhNavigation { get; set; }

    public virtual TaiKhoan? MaTaiKhoanNavigation { get; set; }
}
