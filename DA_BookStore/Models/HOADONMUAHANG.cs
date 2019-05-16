namespace DA_BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADONMUAHANG")]
    public partial class HOADONMUAHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADONMUAHANG()
        {
            CTHOADONMUAHANGs = new HashSet<CTHOADONMUAHANG>();
        }

        [Key]
        [StringLength(10)]
        public string MaHDMua { get; set; }

        [StringLength(10)]
        public string TinhTrangThanhToan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiGianMua { get; set; }

        [Required]
        [StringLength(50)]
        public string TenTaiKhoan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHOADONMUAHANG> CTHOADONMUAHANGs { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
