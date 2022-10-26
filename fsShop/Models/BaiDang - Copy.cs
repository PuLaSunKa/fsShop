namespace fsShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaiDang")]
    public partial class BaiDang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaiDang()
        {
            DangHinhAnhs = new HashSet<DangHinhAnh>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaBaiViet { get; set; }

        public int? MaDanhMuc { get; set; }

        [StringLength(128)]
        public string TieuDe { get; set; }

        [StringLength(255)]
        public string TieuDeWeb { get; set; }

        [Required]
        public string NoiDung { get; set; }

        [StringLength(128)]
        public string HinhAnh { get; set; }

        public DateTime NgayTao { get; set; }

        public int NguoiTao { get; set; }

        public bool TrangThai { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DangHinhAnh> DangHinhAnhs { get; set; }
    }
}
