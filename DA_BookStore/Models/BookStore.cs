namespace DA_BookStore.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookStore : DbContext
    {
        public BookStore()
            : base("name=BookStore")
        {
        }

        public virtual DbSet<CTGIOHANG> CTGIOHANGs { get; set; }
        public virtual DbSet<CTHDNHAPHANG> CTHDNHAPHANGs { get; set; }
        public virtual DbSet<CTHOADONGIAOHANGNHAP> CTHOADONGIAOHANGNHAPs { get; set; }
        public virtual DbSet<CTHOADONMUAHANG> CTHOADONMUAHANGs { get; set; }
        public virtual DbSet<CTTHELOAI> CTTHELOAIs { get; set; }
        public virtual DbSet<CTXEMSACH> CTXEMSACHes { get; set; }
        public virtual DbSet<HOADONGIAOHANGNHAP> HOADONGIAOHANGNHAPs { get; set; }
        public virtual DbSet<HOADONMUAHANG> HOADONMUAHANGs { get; set; }
        public virtual DbSet<HOADONNHAPHANG> HOADONNHAPHANGs { get; set; }
        public virtual DbSet<KHUYENMAI> KHUYENMAIs { get; set; }
        public virtual DbSet<NHACUNGCAP> NHACUNGCAPs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<NHAXUATBAN> NHAXUATBANs { get; set; }
        public virtual DbSet<QUANGCAO> QUANGCAOs { get; set; }
        public virtual DbSet<TRANH> SACHes { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }
        public virtual DbSet<THELOAI> THELOAIs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CTGIOHANG>()
                .Property(e => e.MaSach)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTGIOHANG>()
                .Property(e => e.TenTaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<CTHDNHAPHANG>()
                .Property(e => e.MaSach)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTHDNHAPHANG>()
                .Property(e => e.MaHDNhap)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTHOADONGIAOHANGNHAP>()
                .Property(e => e.MaSach)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTHOADONGIAOHANGNHAP>()
                .Property(e => e.MaHDGiaoNhap)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTHOADONGIAOHANGNHAP>()
                .Property(e => e.MaHDNhap)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTHOADONMUAHANG>()
                .Property(e => e.MaSach)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTHOADONMUAHANG>()
                .Property(e => e.MaHDMua)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTTHELOAI>()
                .Property(e => e.MaTheLoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTTHELOAI>()
                .Property(e => e.MaSach)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTXEMSACH>()
                .Property(e => e.MaSach)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTXEMSACH>()
                .Property(e => e.TenTaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<HOADONGIAOHANGNHAP>()
                .Property(e => e.MaHDNhap)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HOADONGIAOHANGNHAP>()
                .Property(e => e.MaHDGiaoNhap)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HOADONGIAOHANGNHAP>()
                .Property(e => e.NgayGiao)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HOADONGIAOHANGNHAP>()
                .Property(e => e.TenTaiKhoanNV)
                .IsUnicode(false);

            modelBuilder.Entity<HOADONGIAOHANGNHAP>()
                .HasMany(e => e.CTHOADONGIAOHANGNHAPs)
                .WithRequired(e => e.HOADONGIAOHANGNHAP)
                .HasForeignKey(e => e.MaHDGiaoNhap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOADONMUAHANG>()
                .Property(e => e.MaHDMua)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HOADONMUAHANG>()
                .Property(e => e.TenTaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<HOADONMUAHANG>()
                .HasMany(e => e.CTHOADONMUAHANGs)
                .WithRequired(e => e.HOADONMUAHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOADONNHAPHANG>()
                .Property(e => e.MaHDNhap)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HOADONNHAPHANG>()
                .Property(e => e.MaNhaCungCap)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HOADONNHAPHANG>()
                .Property(e => e.TenTaiKhoanNV)
                .IsUnicode(false);

            modelBuilder.Entity<HOADONNHAPHANG>()
                .HasMany(e => e.CTHDNHAPHANGs)
                .WithRequired(e => e.HOADONNHAPHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOADONNHAPHANG>()
                .HasMany(e => e.CTHOADONGIAOHANGNHAPs)
                .WithRequired(e => e.HOADONNHAPHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOADONNHAPHANG>()
                .HasOptional(e => e.HOADONGIAOHANGNHAP)
                .WithRequired(e => e.HOADONNHAPHANG);

            modelBuilder.Entity<KHUYENMAI>()
                .Property(e => e.MaKhuyenMai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.MaNhaCungCap)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.SoDienThoaiNCC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.EmailNCC)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .HasMany(e => e.HOADONNHAPHANGs)
                .WithRequired(e => e.NHACUNGCAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .HasMany(e => e.SACHes)
                .WithRequired(e => e.NHACUNGCAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.TenTaiKhoanNV)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasMany(e => e.HOADONNHAPHANGs)
                .WithRequired(e => e.NHANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHAXUATBAN>()
                .Property(e => e.MaNhaXuatBan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHAXUATBAN>()
                .HasMany(e => e.SACHes)
                .WithRequired(e => e.NHAXUATBAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QUANGCAO>()
                .Property(e => e.MaQuangCao)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<QUANGCAO>()
                .Property(e => e.LinkQC)
                .IsUnicode(false);

            modelBuilder.Entity<QUANGCAO>()
                .Property(e => e.HinhQC)
                .IsUnicode(false);

            modelBuilder.Entity<QUANGCAO>()
                .Property(e => e.SdtChuQC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<QUANGCAO>()
                .Property(e => e.EmailChuQC)
                .IsUnicode(false);

            modelBuilder.Entity<TRANH>()
                .Property(e => e.MaSach)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TRANH>()
                .Property(e => e.SKU)
                .IsUnicode(false);

            modelBuilder.Entity<TRANH>()
                .Property(e => e.MaNhaCungCap)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TRANH>()
                .Property(e => e.MaKhuyenMai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TRANH>()
                .Property(e => e.MaNhaXuatBan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TRANH>()
                .Property(e => e.HinhSach)
                .IsUnicode(false);

            modelBuilder.Entity<TRANH>()
                .HasMany(e => e.CTGIOHANGs)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TRANH>()
                .HasMany(e => e.CTHDNHAPHANGs)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TRANH>()
                .HasMany(e => e.CTHOADONGIAOHANGNHAPs)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TRANH>()
                .HasMany(e => e.CTHOADONMUAHANGs)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TRANH>()
                .HasMany(e => e.CTTHELOAIs)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TRANH>()
                .HasMany(e => e.CTXEMSACHes)
                .WithRequired(e => e.SACH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.TenTaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.MauKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.Sdt)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.CTGIOHANGs)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.CTXEMSACHes)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.HOADONMUAHANGs)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasOptional(e => e.NHANVIEN)
                .WithRequired(e => e.TAIKHOAN);

            modelBuilder.Entity<THELOAI>()
                .Property(e => e.MaTheLoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<THELOAI>()
                .HasMany(e => e.CTTHELOAIs)
                .WithRequired(e => e.THELOAI)
                .WillCascadeOnDelete(false);
        }
    }
}
