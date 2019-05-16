namespace DA_BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTHOADONGIAOHANGNHAP")]
    public partial class CTHOADONGIAOHANGNHAP
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaSach { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaHDGiaoNhap { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string MaHDNhap { get; set; }

        public short? SoLuongGiao { get; set; }

        public virtual HOADONGIAOHANGNHAP HOADONGIAOHANGNHAP { get; set; }

        public virtual HOADONNHAPHANG HOADONNHAPHANG { get; set; }

        public virtual TRANH SACH { get; set; }
    }
}
