namespace CuaHangTienLoi.Web.Models.AnhSanPhamModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using CuaHangTienLoi.Web.Models.SanPhamModel;

    [Table("AnhSanPham")]
    public class AnhSanPham
    {
        [Key]
        public int MaAnhSanPham { get; set; }

        public int MaSanPham { get; set; }

        public string LinkAnh { get; set; }

        [ForeignKey("MaSanPham")]
        public virtual SanPham SanPham { get; set; }
    }
}
