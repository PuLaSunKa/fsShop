namespace fsShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HinhAnhSanPham")]
    public partial class HinhAnhSanPham
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaAnhSanPham { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSanPhan { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(255)]
        public string HinhAnh { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
