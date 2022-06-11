namespace CuaHangTienLoi.Web.Models.HoaDonModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using CuaHangTienLoi.Web.Models.TaiKhoanModel;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [Key]
        public int MaHoaDon { get; set; }

        public int? MaTaiKhoan { get; set; }

        public DateTime? NgayDat { get; set; }

        public bool TrangThai { get; set; }

        public int? TongHoaDon { get; set; }

        public string GhiChu { get; set; }

        public string HoTenNguoiMua { get; set; }

        public string DiaChi { get; set; }
        public string Email { get; set; }

        public string DienThoai { get; set; }
        [ForeignKey("MaTaiKhoan")]
        public virtual TaiKhoan TaiKhoans { get; set; }
    }
}
