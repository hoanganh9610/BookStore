namespace DA_BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADONNHAPHANG")]
    public partial class HOADONNHAPHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADONNHAPHANG()
        {
            CTHDNHAPHANGs = new HashSet<CTHDNHAPHANG>();
            CTHOADONGIAOHANGNHAPs = new HashSet<CTHOADONGIAOHANGNHAP>();
        }

        [Key]
        [StringLength(10)]
        public string MaHDNhap { get; set; }

        [Required]
        [StringLength(10)]
        public string MaNhaCungCap { get; set; }

        [Required]
        [StringLength(50)]
        public string TenTaiKhoanNV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayLapHDNhap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHDNHAPHANG> CTHDNHAPHANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHOADONGIAOHANGNHAP> CTHOADONGIAOHANGNHAPs { get; set; }

        public virtual HOADONGIAOHANGNHAP HOADONGIAOHANGNHAP { get; set; }

        public virtual NHACUNGCAP NHACUNGCAP { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
