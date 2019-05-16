namespace DA_BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTGIOHANG")]
    public partial class CTGIOHANG
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaSach { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string TenTaiKhoan { get; set; }

        public short? SoLuongGioHang { get; set; }

        public virtual TRANH SACH { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
