namespace fsShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VaiTroChoPhep")]
    public partial class VaiTroChoPhep
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaVaiTroQuyen { get; set; }

        public int MaVaiTro { get; set; }

        public int MaQuyen { get; set; }

        public virtual Quyen Quyen { get; set; }

        public virtual VaiTro VaiTro { get; set; }
    }
}
