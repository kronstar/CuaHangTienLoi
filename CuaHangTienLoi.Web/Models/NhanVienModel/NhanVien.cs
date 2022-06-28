namespace CuaHangTienLoi.Web.Models.NhanVienModel
{
    using CuaHangTienLoi.Web.Models.ChucVuModel;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public class NhanVien
    {
        [Key]
        public int MaNhanVien { get; set; }
        public int MaChucVu { get; set; }
        public int Luong { get; set; }

        [StringLength(50)]
        public string HoTen { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [StringLength(10)]
        public string SoDienThoai { get; set; }

        public DateTime? NgaySinh { get; set; }

        public bool? GioiTinh { get; set; }

        public DateTime? NgayThamGia { get; set; }

        [ForeignKey("MaChucVu")]
        public virtual ChucVu ChucVu { get; set; }
    }
}
