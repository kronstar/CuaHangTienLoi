namespace CuaHangTienLoi.Web.Models.TinTucModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using CuaHangTienLoi.Web.Models.TaiKhoanModel;

    [Table("TinTuc")]
    public class TinTuc
    {
        [Key]
        public int MaTin { get; set; }
        public int MaTaiKhoan { get; set; }

        [StringLength(50)]
        public string TieuDe { get; set; }

        public string NoiDung { get; set; }

        public DateTime? NgayDang { get; set; }

        public bool? TrangThai { get; set; }

        [ForeignKey("MaTaiKhoan")]
        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
