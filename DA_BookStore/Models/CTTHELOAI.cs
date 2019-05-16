namespace DA_BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTTHELOAI")]
    public partial class CTTHELOAI
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaTheLoai { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaSach { get; set; }

        public bool? HienThiCTTL { get; set; }

        public virtual TRANH SACH { get; set; }

        public virtual THELOAI THELOAI { get; set; }
    }
}
