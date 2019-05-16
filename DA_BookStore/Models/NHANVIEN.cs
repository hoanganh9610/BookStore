namespace DA_BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            HOADONGIAOHANGNHAPs = new HashSet<HOADONGIAOHANGNHAP>();
            HOADONNHAPHANGs = new HashSet<HOADONNHAPHANG>();
        }

        [Key]
        [StringLength(50)]
        public string TenTaiKhoanNV { get; set; }

        [StringLength(20)]
        public string ChucVuNV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADONGIAOHANGNHAP> HOADONGIAOHANGNHAPs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADONNHAPHANG> HOADONNHAPHANGs { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
