namespace DA_BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTHDNHAPHANG")]
    public partial class CTHDNHAPHANG
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaSach { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaHDNhap { get; set; }

        public short? SoLuongNhap { get; set; }

        public virtual HOADONNHAPHANG HOADONNHAPHANG { get; set; }

        public virtual TRANH SACH { get; set; }
    }
}
