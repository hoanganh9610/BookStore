namespace DA_BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUANGCAO")]
    public partial class QUANGCAO
    {
        [Key]
        [StringLength(10)]
        public string MaQuangCao { get; set; }

        [StringLength(50)]
        public string TenQC { get; set; }

        [StringLength(200)]
        public string LinkQC { get; set; }

        [StringLength(100)]
        public string HinhQC { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayBatDauQC { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayHetQC { get; set; }

        [StringLength(50)]
        public string ChuSoHuuQC { get; set; }

        [StringLength(10)]
        public string SdtChuQC { get; set; }

        [StringLength(30)]
        public string EmailChuQC { get; set; }

        public bool? HienThiQC { get; set; }
    }
}
