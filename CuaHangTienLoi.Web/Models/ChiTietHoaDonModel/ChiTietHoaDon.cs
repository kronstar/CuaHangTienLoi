namespace CuaHangTienLoi.Web.Models.ChiTietHoaDonModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using CuaHangTienLoi.Web.Models.HoaDonModel;
    using CuaHangTienLoi.Web.Models.SanPhamModel;

    [Table("ChiTietHoaDon")]
    public class ChiTietHoaDon
    {
        [Key]
        public int MaChiTietHoaDon { get; set; }

        public int MaHoaDon { get; set; }

        public int MaSanPham { get; set; }

        public int SoLuong { get; set; }

        public int DonGia { get; set; }

        public int ThanhTien { get; set; }

        [ForeignKey("MaSanPham")]
        public virtual SanPham SanPham { get; set; }

        [ForeignKey("MaHoaDon")]
        public virtual HoaDon HoaDon { get; set; }
    }
}
