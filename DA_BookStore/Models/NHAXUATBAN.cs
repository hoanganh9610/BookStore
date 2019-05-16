namespace DA_BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHAXUATBAN")]
    public partial class NHAXUATBAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHAXUATBAN()
        {
            SACHes = new HashSet<TRANH>();
        }

        [Key]
        [StringLength(10)]
        public string MaNhaXuatBan { get; set; }

        [StringLength(50)]
        public string TenNhaXuatBan { get; set; }

        public short? SoDauSachXB { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRANH> SACHes { get; set; }
    }
}
