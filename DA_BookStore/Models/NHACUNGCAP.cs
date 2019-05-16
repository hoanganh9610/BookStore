namespace DA_BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHACUNGCAP")]
    public partial class NHACUNGCAP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHACUNGCAP()
        {
            HOADONNHAPHANGs = new HashSet<HOADONNHAPHANG>();
            SACHes = new HashSet<TRANH>();
        }

        [Key]
        [StringLength(10)]
        public string MaNhaCungCap { get; set; }

        [StringLength(100)]
        public string DiaChiNCC { get; set; }

        [StringLength(10)]
        public string SoDienThoaiNCC { get; set; }

        [StringLength(30)]
        public string EmailNCC { get; set; }

        public bool? HienThiNCC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADONNHAPHANG> HOADONNHAPHANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRANH> SACHes { get; set; }
    }
}
