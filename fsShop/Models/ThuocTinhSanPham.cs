namespace fsShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThuocTinhSanPham")]
    public partial class ThuocTinhSanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaThuocTinhSanPham { get; set; }

        public int MaGiaTriThuocTinh { get; set; }

        [Required]
        [StringLength(255)]
        public string Gia { get; set; }

        public int MaSanPham { get; set; }

        public virtual GiaTriThuocTinh GiaTriThuocTinh { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
