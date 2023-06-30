using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QlLopHocSinhVien.Model.Entities;

public partial class GreenEduContext : DbContext
{
    public GreenEduContext()
    {
    }

    public GreenEduContext(DbContextOptions<GreenEduContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BienLaiThuTien> BienLaiThuTiens { get; set; }

    public virtual DbSet<ChucVu> ChucVus { get; set; }

    public virtual DbSet<ChuongTrinhHoc> ChuongTrinhHocs { get; set; }

    public virtual DbSet<CoSo> CoSos { get; set; }

    public virtual DbSet<DangKiHoc> DangKiHocs { get; set; }

    public virtual DbSet<DiemDanh> DiemDanhs { get; set; }

    public virtual DbSet<DotThi> DotThis { get; set; }

    public virtual DbSet<GiangVien> GiangViens { get; set; }

    public virtual DbSet<HocVien> HocViens { get; set; }

    public virtual DbSet<KhoaHoc> KhoaHocs { get; set; }

    public virtual DbSet<LichHoc> LichHocs { get; set; }

    public virtual DbSet<LichLamViec> LichLamViecs { get; set; }

    public virtual DbSet<LopHoc> LopHocs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<NoiDungThi> NoiDungThis { get; set; }

    public virtual DbSet<PhongBan> PhongBans { get; set; }

    public virtual DbSet<Picture> Pictures { get; set; }

    public virtual DbSet<Qlthi> Qlthis { get; set; }

    public virtual DbSet<QuanLyChamCong> QuanLyChamCongs { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<TrinhDo> TrinhDos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-QJAU8OA\\PHUNGTIEN;Database=GreenEdu;Integrated security=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BienLaiThuTien>(entity =>
        {
            entity.HasKey(e => e.MaBl).HasName("PK__BienLaiT__272475AFD4C92F9D");

            entity.ToTable("BienLaiThuTien");

            entity.Property(e => e.MaBl)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaBL");
            entity.Property(e => e.MaHv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaHV");
            entity.Property(e => e.NgayLap).HasColumnType("datetime");
            entity.Property(e => e.NoiDung).HasMaxLength(200);

            entity.HasOne(d => d.MaHvNavigation).WithMany(p => p.BienLaiThuTiens)
                .HasForeignKey(d => d.MaHv)
                .HasConstraintName("FK__BienLaiThu__MaHV__68487DD7");
        });

        modelBuilder.Entity<ChucVu>(entity =>
        {
            entity.HasKey(e => e.MaCv).HasName("PK__ChucVu__27258E76447F33F6");

            entity.ToTable("ChucVu");

            entity.Property(e => e.MaCv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaCV");
            entity.Property(e => e.MoTa).HasMaxLength(200);
            entity.Property(e => e.TenCv)
                .HasMaxLength(200)
                .HasColumnName("TenCV");
        });

        modelBuilder.Entity<ChuongTrinhHoc>(entity =>
        {
            entity.HasKey(e => e.MaCth).HasName("PK__ChuongTr__3DCB54F1293374DE");

            entity.ToTable("ChuongTrinhHoc");

            entity.Property(e => e.MaCth)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaCTH");
            entity.Property(e => e.NoiDung).HasMaxLength(500);
            entity.Property(e => e.TieuDe).HasMaxLength(100);
            entity.Property(e => e.TrangThai).HasMaxLength(200);
        });

        modelBuilder.Entity<CoSo>(entity =>
        {
            entity.HasKey(e => e.MaCs).HasName("PK__CoSo__27258E75A352FE4F");

            entity.ToTable("CoSo");

            entity.Property(e => e.MaCs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaCS");
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.TenCs)
                .HasMaxLength(200)
                .HasColumnName("TenCS");
        });

        modelBuilder.Entity<DangKiHoc>(entity =>
        {
            entity.HasKey(e => e.Ma).HasName("PK__DangKiHo__3214CC9F5EEF3B5E");

            entity.ToTable("DangKiHoc");

            entity.Property(e => e.Ma).ValueGeneratedNever();
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.MaKh)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaKH");
            entity.Property(e => e.TruongHoc).HasMaxLength(100);

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.DangKiHocs)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("FK__DangKiHoc__MaKH__7A672E12");
        });

        modelBuilder.Entity<DiemDanh>(entity =>
        {
            entity.HasKey(e => e.MaDd).HasName("PK__DiemDanh__2725866511B2AEF1");

            entity.ToTable("DiemDanh");

            entity.Property(e => e.MaDd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaDD");
            entity.Property(e => e.DiemDanh1)
                .HasMaxLength(20)
                .HasColumnName("DiemDanh");
            entity.Property(e => e.MaHv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaHV");
            entity.Property(e => e.MoTa).HasMaxLength(20);
            entity.Property(e => e.ThoiGian).HasColumnType("datetime");
            entity.Property(e => e.ThoiGianRa).HasColumnType("datetime");
            entity.Property(e => e.ThoiGianVao).HasColumnType("datetime");

            entity.HasOne(d => d.MaHvNavigation).WithMany(p => p.DiemDanhs)
                .HasForeignKey(d => d.MaHv)
                .HasConstraintName("FK__DiemDanh__MaHV__6B24EA82");
        });

        modelBuilder.Entity<DotThi>(entity =>
        {
            entity.HasKey(e => e.MaDt).HasName("PK__DotThi__27258655A08441EA");

            entity.ToTable("DotThi");

            entity.Property(e => e.MaDt)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaDT");
            entity.Property(e => e.NoiDung).HasMaxLength(200);
        });

        modelBuilder.Entity<GiangVien>(entity =>
        {
            entity.HasKey(e => e.MaGv).HasName("PK__GiangVie__2725AEF3B74DB411");

            entity.ToTable("GiangVien");

            entity.Property(e => e.MaGv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaGV");
            entity.Property(e => e.MaNv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.MaTrinhDo)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.GiangViens)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__GiangVien__MaNV__5629CD9C");

            entity.HasOne(d => d.MaTrinhDoNavigation).WithMany(p => p.GiangViens)
                .HasForeignKey(d => d.MaTrinhDo)
                .HasConstraintName("FK__GiangVien__MaTri__571DF1D5");
        });

        modelBuilder.Entity<HocVien>(entity =>
        {
            entity.HasKey(e => e.MaHv).HasName("PK__HocVien__2725A6D252E7019A");

            entity.ToTable("HocVien");

            entity.Property(e => e.MaHv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaHV");
            entity.Property(e => e.Anh).HasColumnType("image");
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.Facebook).HasMaxLength(200);
            entity.Property(e => e.GioiTinh).HasMaxLength(20);
            entity.Property(e => e.Gmail).HasMaxLength(50);
            entity.Property(e => e.HoTen).HasMaxLength(200);
            entity.Property(e => e.HoatDong).HasMaxLength(20);
            entity.Property(e => e.MaLh)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaLH");
            entity.Property(e => e.MaTaiKhoan)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NgaySinh).HasColumnType("datetime");
            entity.Property(e => e.NgayThamGia).HasColumnType("datetime");
            entity.Property(e => e.NgheNghiep).HasMaxLength(20);
            entity.Property(e => e.Quan).HasMaxLength(20);
            entity.Property(e => e.Sdt).HasColumnName("SDT");
            entity.Property(e => e.ThanhPho).HasMaxLength(20);
            entity.Property(e => e.TrinhDoChuyenMon).HasMaxLength(200);
            entity.Property(e => e.TruongHoc).HasMaxLength(50);

            entity.HasOne(d => d.MaLhNavigation).WithMany(p => p.HocViens)
                .HasForeignKey(d => d.MaLh)
                .HasConstraintName("FK__HocVien__MaLH__656C112C");

            entity.HasOne(d => d.MaTaiKhoanNavigation).WithMany(p => p.HocViens)
                .HasForeignKey(d => d.MaTaiKhoan)
                .HasConstraintName("FK__HocVien__MaTaiKh__6477ECF3");
        });

        modelBuilder.Entity<KhoaHoc>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("PK__KhoaHoc__2725CF1E235C0BCA");

            entity.ToTable("KhoaHoc");

            entity.Property(e => e.MaKh)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaKH");
            entity.Property(e => e.Anh).HasColumnType("image");
            entity.Property(e => e.NoiDung).HasMaxLength(200);
            entity.Property(e => e.TieuDe).HasMaxLength(100);
        });

        modelBuilder.Entity<LichHoc>(entity =>
        {
            entity.HasKey(e => e.MaLichHoc).HasName("PK__LichHoc__150EBC219B297C13");

            entity.ToTable("LichHoc");

            entity.Property(e => e.MaLichHoc)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MaLh)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaLH");
            entity.Property(e => e.MonHoc).HasMaxLength(20);
            entity.Property(e => e.SoGioDay).HasMaxLength(20);
            entity.Property(e => e.ThoiGianRa).HasColumnType("datetime");
            entity.Property(e => e.ThoiGianVao).HasColumnType("datetime");

            entity.HasOne(d => d.MaLhNavigation).WithMany(p => p.LichHocs)
                .HasForeignKey(d => d.MaLh)
                .HasConstraintName("FK__LichHoc__MaLH__619B8048");
        });

        modelBuilder.Entity<LichLamViec>(entity =>
        {
            entity.HasKey(e => e.MaLlv).HasName("PK__LichLamV__3B9BF60F00F5A034");

            entity.ToTable("LichLamViec");

            entity.Property(e => e.MaLlv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaLLV");
            entity.Property(e => e.ThoiGian).HasColumnType("datetime");
            entity.Property(e => e.ThoiGianRa).HasColumnType("datetime");
            entity.Property(e => e.ThoiGianVao).HasColumnType("datetime");
        });

        modelBuilder.Entity<LopHoc>(entity =>
        {
            entity.HasKey(e => e.MaLh).HasName("PK__LopHoc__2725C77F4279FC3D");

            entity.ToTable("LopHoc");

            entity.Property(e => e.MaLh)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaLH");
            entity.Property(e => e.DoanhThuDuKien).HasMaxLength(200);
            entity.Property(e => e.MaChuongTrinhHoc)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MaCs)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaCS");
            entity.Property(e => e.MaKh)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaKH");
            entity.Property(e => e.MaNv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.NgayBatDau).HasColumnType("datetime");
            entity.Property(e => e.NgayKetThuc).HasColumnType("datetime");
            entity.Property(e => e.SoTienDaThu).HasMaxLength(200);
            entity.Property(e => e.SoTienDuThu).HasMaxLength(200);
            entity.Property(e => e.TenLop).HasMaxLength(100);
            entity.Property(e => e.TinhTrang).HasMaxLength(100);

            entity.HasOne(d => d.MaChuongTrinhHocNavigation).WithMany(p => p.LopHocs)
                .HasForeignKey(d => d.MaChuongTrinhHoc)
                .HasConstraintName("FK__LopHoc__MaChuong__5CD6CB2B");

            entity.HasOne(d => d.MaCsNavigation).WithMany(p => p.LopHocs)
                .HasForeignKey(d => d.MaCs)
                .HasConstraintName("FK__LopHoc__MaCS__5EBF139D");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.LopHocs)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("FK__LopHoc__MaKH__5DCAEF64");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.LopHocs)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__LopHoc__MaNV__5BE2A6F2");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("PK__NhanVien__2725D70A9876F97B");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.Gmail).HasMaxLength(50);
            entity.Property(e => e.MaCv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaCV");
            entity.Property(e => e.MaPb)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaPB");
            entity.Property(e => e.MaTaiKhoan)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Sdt).HasColumnName("SDT");
            entity.Property(e => e.Ten).HasMaxLength(100);
            entity.Property(e => e.TrangThaiNhanSu).HasMaxLength(100);

            entity.HasOne(d => d.MaCvNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaCv)
                .HasConstraintName("FK__NhanVien__MaCV__52593CB8");

            entity.HasOne(d => d.MaPbNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaPb)
                .HasConstraintName("FK__NhanVien__MaPB__5165187F");

            entity.HasOne(d => d.MaTaiKhoanNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaTaiKhoan)
                .HasConstraintName("FK__NhanVien__MaTaiK__534D60F1");
        });

        modelBuilder.Entity<NoiDungThi>(entity =>
        {
            entity.HasKey(e => e.MaNdt).HasName("PK__NoiDungT__3A1855991C39AC1D");

            entity.ToTable("NoiDungThi");

            entity.Property(e => e.MaNdt)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaNDT");
            entity.Property(e => e.NoiDung).HasMaxLength(200);
        });

        modelBuilder.Entity<PhongBan>(entity =>
        {
            entity.HasKey(e => e.MaPb).HasName("PK__PhongBan__2725E7E4328D694F");

            entity.ToTable("PhongBan");

            entity.Property(e => e.MaPb)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaPB");
            entity.Property(e => e.MoTa).HasMaxLength(200);
            entity.Property(e => e.NoiDung).HasMaxLength(200);
            entity.Property(e => e.TenPb)
                .HasMaxLength(200)
                .HasColumnName("TenPB");
        });

        modelBuilder.Entity<Picture>(entity =>
        {
            entity.HasKey(e => e.PictureName).HasName("PK__Pictures__960C058835589A57");

            entity.Property(e => e.PictureName)
                .HasMaxLength(40)
                .HasColumnName("pictureName");
            entity.Property(e => e.PicFileName)
                .HasMaxLength(100)
                .HasColumnName("picFileName");
        });

        modelBuilder.Entity<Qlthi>(entity =>
        {
            entity.HasKey(e => e.Ma).HasName("PK__QLThi__3214CC9F3BE51EFD");

            entity.ToTable("QLThi");

            entity.Property(e => e.Ma)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MaDt)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaDT");
            entity.Property(e => e.MaNdt)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaNDT");
            entity.Property(e => e.MaPb)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaPB");
            entity.Property(e => e.ThoiGianBd)
                .HasColumnType("datetime")
                .HasColumnName("ThoiGianBD");
            entity.Property(e => e.ThoiGianKt)
                .HasColumnType("datetime")
                .HasColumnName("ThoiGianKT");

            entity.HasOne(d => d.MaDtNavigation).WithMany(p => p.Qlthis)
                .HasForeignKey(d => d.MaDt)
                .HasConstraintName("FK__QLThi__MaDT__440B1D61");

            entity.HasOne(d => d.MaNdtNavigation).WithMany(p => p.Qlthis)
                .HasForeignKey(d => d.MaNdt)
                .HasConstraintName("FK__QLThi__MaNDT__44FF419A");

            entity.HasOne(d => d.MaPbNavigation).WithMany(p => p.Qlthis)
                .HasForeignKey(d => d.MaPb)
                .HasConstraintName("FK__QLThi__MaPB__4316F928");
        });

        modelBuilder.Entity<QuanLyChamCong>(entity =>
        {
            entity.HasKey(e => e.MaQlcc).HasName("PK__QuanLyCh__8B932A19D2F628B5");

            entity.ToTable("QuanLyChamCong");

            entity.Property(e => e.MaQlcc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaQLCC");
            entity.Property(e => e.MaCv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaCV");
            entity.Property(e => e.MaLlv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaLLV");

            entity.HasOne(d => d.MaCvNavigation).WithMany(p => p.QuanLyChamCongs)
                .HasForeignKey(d => d.MaCv)
                .HasConstraintName("FK__QuanLyCham__MaCV__4BAC3F29");

            entity.HasOne(d => d.MaLlvNavigation).WithMany(p => p.QuanLyChamCongs)
                .HasForeignKey(d => d.MaLlv)
                .HasConstraintName("FK__QuanLyCha__MaLLV__4CA06362");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.MaTaiKhoan).HasName("PK__TaiKhoan__AD7C652960ED2B79");

            entity.ToTable("TaiKhoan");

            entity.Property(e => e.MaTaiKhoan)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MatKhau)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.TenTaiKhoan).HasMaxLength(100);
        });

        modelBuilder.Entity<TrinhDo>(entity =>
        {
            entity.HasKey(e => e.MaTrinhDo).HasName("PK__TrinhDo__B64C90D3256D513C");

            entity.ToTable("TrinhDo");

            entity.Property(e => e.MaTrinhDo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TenTrinhDo).HasMaxLength(200);
            entity.Property(e => e.ThuTu).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
