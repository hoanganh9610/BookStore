namespace DA_BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THELOAI")]
    public partial class THELOAI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THELOAI()
        {
            CTTHELOAIs = new HashSet<CTTHELOAI>();
        }

        [Key]
        [StringLength(10)]
        public string MaTheLoai { get; set; }

        [StringLength(30)]
        public string TenTheLoai { get; set; }

        public bool? HienThiTL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTTHELOAI> CTTHELOAIs { get; set; }
    }
}
