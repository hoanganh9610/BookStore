namespace DA_BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHUYENMAI")]
    public partial class KHUYENMAI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHUYENMAI()
        {
            SACHes = new HashSet<TRANH>();
        }

        [Key]
        [StringLength(10)]
        public string MaKhuyenMai { get; set; }

        [StringLength(30)]
        public string TenKhuyenMai { get; set; }

        public DateTime? NgayBatDau { get; set; }

        public DateTime? NgayKetThuc { get; set; }

        public byte? PhanTramKhuyenMai { get; set; }

        public bool? HienThiKM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRANH> SACHes { get; set; }
    }
}
