namespace fsShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DangHinhAnh")]
    public partial class DangHinhAnh
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaHinhAnh { get; set; }

        public int MaBaiViet { get; set; }

        [Required]
        [StringLength(128)]
        public string HinhAnh { get; set; }

        public virtual BaiDang BaiDang { get; set; }
    }
}
