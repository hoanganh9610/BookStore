namespace DA_BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTXEMSACH")]
    public partial class CTXEMSACH
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaSach { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string TenTaiKhoan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayXemSach { get; set; }

        public virtual TRANH SACH { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
