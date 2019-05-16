namespace DA_BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTHOADONMUAHANG")]
    public partial class CTHOADONMUAHANG
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaSach { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaHDMua { get; set; }

        public short? SoLuongMua { get; set; }

        public int? GiaHienHanh { get; set; }

        public virtual HOADONMUAHANG HOADONMUAHANG { get; set; }

        public virtual TRANH SACH { get; set; }
    }
}
