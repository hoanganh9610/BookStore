namespace DA_BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADONGIAOHANGNHAP")]
    public partial class HOADONGIAOHANGNHAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADONGIAOHANGNHAP()
        {
            CTHOADONGIAOHANGNHAPs = new HashSet<CTHOADONGIAOHANGNHAP>();
        }

        [Key]
        [StringLength(10)]
        public string MaHDNhap { get; set; }

        [Required]
        [StringLength(10)]
        public string MaHDGiaoNhap { get; set; }

        [StringLength(10)]
        public string NgayGiao { get; set; }

        [StringLength(50)]
        public string TenTaiKhoanNV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHOADONGIAOHANGNHAP> CTHOADONGIAOHANGNHAPs { get; set; }

        public virtual HOADONNHAPHANG HOADONNHAPHANG { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
