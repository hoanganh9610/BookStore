namespace DA_BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SACH")]
    public partial class TRANH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRANH()
        {
            CTGIOHANGs = new HashSet<CTGIOHANG>();
            CTHDNHAPHANGs = new HashSet<CTHDNHAPHANG>();
            CTHOADONGIAOHANGNHAPs = new HashSet<CTHOADONGIAOHANGNHAP>();
            CTHOADONMUAHANGs = new HashSet<CTHOADONMUAHANG>();
            CTTHELOAIs = new HashSet<CTTHELOAI>();
            CTXEMSACHes = new HashSet<CTXEMSACH>();
        }

        [Key]
        [StringLength(10)]
        public string MaSach { get; set; }

        [Required]
        [StringLength(100)]
        public string TenSach { get; set; }

        [Required]
        [StringLength(20)]
        public string SKU { get; set; }

        [Required]
        [StringLength(10)]
        public string MaNhaCungCap { get; set; }

        [StringLength(10)]
        public string MaKhuyenMai { get; set; }

        [Required]
        [StringLength(10)]
        public string MaNhaXuatBan { get; set; }

        public int? GiaBan { get; set; }

        public int? SoLanTruyCap { get; set; }

        [StringLength(100)]
        public string HinhSach { get; set; }

        public short? SoLuongTon { get; set; }

        [StringLength(50)]
        public string TenTacGia { get; set; }

        public string GioiThieuSach { get; set; }

        public DateTime? NgayXuatBan { get; set; }

        public bool? HienThiS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTGIOHANG> CTGIOHANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHDNHAPHANG> CTHDNHAPHANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHOADONGIAOHANGNHAP> CTHOADONGIAOHANGNHAPs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHOADONMUAHANG> CTHOADONMUAHANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTTHELOAI> CTTHELOAIs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTXEMSACH> CTXEMSACHes { get; set; }

        public virtual KHUYENMAI KHUYENMAI { get; set; }

        public virtual NHACUNGCAP NHACUNGCAP { get; set; }

        public virtual NHAXUATBAN NHAXUATBAN { get; set; }
    }
}
