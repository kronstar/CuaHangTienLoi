namespace CuaHangTienLoi.Web.Models.DanhMucModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMuc")]
    public class DanhMuc
    {
        [Key]
        public int MaDanhMuc { get; set; }

        [StringLength(200)]
        public string TenDanhMuc { get; set; }

        public int? Stt { get; set; }

        public bool? TrangThai { get; set; }
    }
}
