namespace fsShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiaTriThuocTinh")]
    public partial class GiaTriThuocTinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GiaTriThuocTinh()
        {
            ThuocTinhSanPhams = new HashSet<ThuocTinhSanPham>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaGiaTriThuocTinh { get; set; }

        public int MaThuocTinh { get; set; }

        [Required]
        [StringLength(50)]
        public string Ten { get; set; }

        public virtual ThuocTinh ThuocTinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThuocTinhSanPham> ThuocTinhSanPhams { get; set; }
    }
}
