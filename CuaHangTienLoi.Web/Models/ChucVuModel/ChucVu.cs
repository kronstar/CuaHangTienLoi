namespace CuaHangTienLoi.Web.Models.ChucVuModel
{
    using CuaHangTienLoi.Web.Models.NhanVienModel;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChucVu")]
    public class ChucVu
    {
        [Key]
        /*[DatabaseGenerated(DatabaseGeneratedOption.None)]*/
        public int MaChucVu { get; set; }
        [StringLength(100)]
        public string TenChucVu { get; set; }

        /*[ForeignKey("MaNhanVien")]
        public virtual NhanVien NhanVien { get; set; }*/
    }
}
