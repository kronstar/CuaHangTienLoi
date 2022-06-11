namespace CuaHangTienLoi.Web.Models.SanPhamModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using CuaHangTienLoi.Web.Models.DanhMucModel;
    using CuaHangTienLoi.Web.Models.NhaCungCapModel;

    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        /*[DatabaseGenerated(DatabaseGeneratedOption.None)]*/
        public int MaSanPham { get; set; }

        public int MaDanhMuc { get; set; }

        public int MaNhaCungCap { get; set; }
        [StringLength(100)]
        public string TenSanPham { get; set; }

        public bool TinhTrang { get; set; }

        public string LinkAnh { get; set; }

        public string MoTa { get; set; }

        public int DonGia { get; set; }
        public int GiamGia { get; set; }
        public int PhanTramGiamGia { get; set; }

        public int LuotMua { get; set; }

        public DateTime NgayDang { get; set; }

        public int SoLuong { get; set; }

        public bool DaXoa { get; set; }

        [ForeignKey("MaDanhMuc")]
        public virtual DanhMuc DanhMuc { get; set; }
        [ForeignKey("MaNhaCungCap")]
        public virtual NhaCungCap NhaCungCap { get; set; }
    }
}
