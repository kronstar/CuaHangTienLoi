namespace CuaHangTienLoi.Web.Models.SliderModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Slider")]
    public class Slider
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSider { get; set; }

        [StringLength(200)]
        public string TieuDe { get; set; }

        public string HinhAnh { get; set; }

        public DateTime? NgayDang { get; set; }

        public int? ThuTu { get; set; }

        public string LienKet { get; set; }
    }
}
