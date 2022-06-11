namespace CuaHangTienLoi.Web.Models.NhaCungCapModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhaCungCap")]
    public class NhaCungCap
    {
        [Key]
        /*[DatabaseGenerated(DatabaseGeneratedOption.None)]*/
        public int MaNhaCungCap { get; set; }

        [StringLength(100)]
        public string TenNhaCungCap { get; set; }

        [StringLength(100)]
        public string LienHe { get; set; }
    }
}
